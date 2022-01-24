Public Class NewTruckService

    Dim myDsTrucks As New DataSet
    Dim _mode As FormMode = FormMode.CreateNew
    Dim _trServId As Integer = -1

#Region "Control Events"

    Private Sub NewTruckService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Me._mode = FormMode.CreateNew And Me._trServId < 0 Then _
            Throw New Exception("A Truck Service ID must be passed unless mode is 'Create New'.")

        Me.PopulateTruckCBX()

        If Me._mode = FormMode.Details Then
            Me.Text = "Truck Service ID # " & Me._trServId.ToString & " Details"
            Me.PopulateFields()
            Me.DisableControls()
        ElseIf Me._mode = FormMode.Edit Then
            Me.Text = "Edit Truck Service ID # " & Me._trServId.ToString
            Me.PopulateFields()
        End If

    End Sub

    Private Sub NewTruckService_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' clean up
        If Not IsNothing(Me.myDsTrucks) Then Me.myDsTrucks.Dispose()
    End Sub

    Private Sub chkServiceDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkServiceDate.CheckedChanged
        Me.dtpService.Enabled = Me.chkServiceDate.Checked
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.cbxDescription.Text = Trim(Me.cbxDescription.Text)
        Me.txtAmount.Text = Trim(Me.txtAmount.Text)

        If Me.cbxDescription.Text.Length = 0 Then
            MessageBox.Show("Please enter a valid description.", "Invalid Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbxDescription.Focus()
        ElseIf Me.cbxDescription.Text.IndexOf("|") >= 0 Or Me.cbxDescription.Text.IndexOf(":") >= 0 Then
            MessageBox.Show("The characters ""|"" and "":"" cannot be used in the Service Description field.", "Invalid Description", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbxDescription.Focus()
        ElseIf Me.txtAmount.Text.Length > 0 AndAlso Not IsNumeric(Me.txtAmount.Text) Then
            MessageBox.Show("Please enter a valid Amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtAmount.Focus()
        Else
            ' add values to listview
            Dim li As New ListViewItem(Me.cbxDescription.Text)
            li.SubItems.Add(Format(Me.txtAmount.Text, "Fixed"))
            Me.lsvService.Items.Add(li)
            Me.cbxDescription.Text = String.Empty
            Me.txtAmount.Text = String.Empty

            Me.CalculateTotal()

        End If

    End Sub

    Private Sub txtAmount_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        If e.KeyValue = 13 Then Me.btnAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub TextBoxes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.LostFocus, txtTotal.LostFocus

        Dim myTB As TextBox = CType(sender, TextBox)

        If IsNumeric(myTB.Text) Then _
            myTB.Text = Format(myTB.Text, "Fixed")

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        For Each li As ListViewItem In Me.lsvService.SelectedItems
            Me.lsvService.Items.Remove(li)
        Next
        Me.CalculateTotal()
    End Sub

    Private Sub cbxTruck_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTruck.SelectedIndexChanged
        Me.btnTruckDetail.Enabled = (Me.cbxTruck.SelectedIndex > 0)
    End Sub

    Private Sub btnTruckDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTruckDetail.Click

        Dim Rows() As DataRow = Me.myDsTrucks.Tables("Trucks").Select("[Truck Number]='" & GS.FilterSingleQuote(Me.cbxTruck.Text) & "'")

        Dim frm As New NewTruck
        frm.Mode = FormMode.Details
        frm.TruckID = CInt(Rows(0).Item("Truck ID"))
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Me.ValidateFields() AndAlso Me.InputData() Then
            If GS.FormIsOpen(My.Forms.Form1.frmTruckServiceList) Then _
                My.Forms.Form1.frmTruckServiceList.tsbRefresh_Click(Nothing, Nothing)
            Me.Close()
        End If
    End Sub

    Private Sub cbxDescription_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbxDescription.KeyUp
        If e.KeyValue = 13 Then Me.btnAdd_Click(Nothing, Nothing)
    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Private Sub PopulateFields()

        Dim CmdStr As String = "SELECT [TruckServices].*,[Trucks].[Truck Number] FROM [TruckServices]" & _
            " INNER JOIN [Trucks] ON [TruckServices].[Truck ID]=[Trucks].[Truck ID] WHERE [Service ID]=" & _
            Me._trServId.ToString

        Dim myDa As New SqlClient.SqlDataAdapter(CmdStr, GS.ConnectionString)
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False

        Try
            myDa.Fill(myDs, "TruckServices")
        Catch ex As Exception
            MessageBox.Show("An error occured while accessing the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            If Not IsNothing(myDs) Then myDs.Dispose()
            Me.Close()
            Exit Sub
        End If

        Dim Row As DataRow = myDs.Tables("TruckServices").Rows(0)

        Me.cbxTruck.Text = Row.Item("Truck Number").ToString

        If Not IsDBNull(Row.Item("Service Date")) Then
            Dim dt As Date = CDate(Row.Item("Service Date"))
            Me.dtpService.Value = dt
            Me.chkServiceDate.Checked = True
        End If

        Me.txtPO.Text = Row.Item("PO Number").ToString

        If Not IsDBNull(Row.Item("Service List")) Then

            Dim Services() As String = Split(Row.Item("Service List").ToString, "::")
            Dim It() As String = Nothing
            Dim li As ListViewItem = Nothing

            For Each Service As String In Services

                If Not IsNothing(It) Then Array.Clear(It, 0, It.Length)

                If Service.Length > 0 Then
                    It = Split(Service, "||")

                    li = New ListViewItem(It(0))
                    li.SubItems.Add(It(1))

                    Me.lsvService.Items.Add(li)

                End If
            Next

        End If

        Me.txtTotal.Text = Format(Row.Item("Total").ToString, "Fixed")
        Me.chkPaid.Checked = CBool(Row.Item("Paid"))

    End Sub

    Private Sub DisableControls()
        For Each c As Control In Me.GroupBox1.Controls
            If c.GetType.Name = "ComboBox" Or c.GetType.Name = "Button" Or c.GetType.Name = "CheckBox" Then
                c.Enabled = False
            ElseIf c.GetType.Name = "TextBox" Then
                CType(c, TextBox).ReadOnly = True
            End If
        Next
        Me.dtpService.Enabled = False
        Me.chkPaid.Enabled = False
        Me.btnOk.Visible = False
        Me.btnCancel.Text = "Close"
    End Sub

    Private Function InputData() As Boolean
        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim CmdStr As String = String.Empty
        Dim Fields As String = String.Empty
        Dim Values As String = String.Empty
        Dim UpStr As String = String.Empty
        Dim flag As Boolean = True

        If Me.txtPO.Text.Length > 0 Then
            Fields &= ",[PO Number]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtPO.Text) & "'"
            UpStr &= ",[PO Number]='" & GS.FilterSingleQuote(Me.txtPO.Text) & "'"
        Else
            UpStr &= ",[PO Number]=NULL"
        End If

        If Me.chkPaid.Checked Then
            Fields &= ",[Paid]"
            Values &= ",1"
            UpStr &= ",[Paid]=1"
        Else
            UpStr &= ",[Paid]=0"
        End If

        ' get truck id
        Dim Rows() As DataRow = Me.myDsTrucks.Tables("Trucks").Select("[Truck Number]='" & GS.FilterSingleQuote(Me.cbxTruck.Text) & "'")
        Dim TrId As String = Rows(0).Item("Truck ID").ToString

        ' get truck services
        Dim ServiceList As String = String.Empty
        For Each li As ListViewItem In Me.lsvService.Items
            ServiceList &= li.SubItems(0).Text & "||" & li.SubItems(1).Text & "::"
        Next

        If Me._mode = FormMode.CreateNew Then
            CmdStr = "INSERT INTO [TruckServices] ([Truck ID],[Service Date],[Service List],[Total]" & Fields & _
                ") VALUES (" & TrId & ",'" & Me.dtpService.Value.ToShortDateString & "','" & _
                GS.FilterSingleQuote(ServiceList) & "'," & Me.txtTotal.Text & Values & ")"
        Else
            CmdStr = "UPDATE [TruckServices] SET [Truck ID]=" & TrId & ",[Service Date]='" & Me.dtpService.Value.ToShortDateString & _
                "',[Service List]='" & GS.FilterSingleQuote(ServiceList) & "',[Total]=" & Me.txtTotal.Text & UpStr & _
                " WHERE [Service ID]=" & Me._trServId
        End If

        Try
            myConn.Open()

            myCmd.CommandText = CmdStr
            myCmd.Connection = myConn

            myCmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("An error occured while the data was being sent to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
        End Try

        Return flag

    End Function

    Private Function ValidateFields() As Boolean

        Dim flag As Boolean = True
        Dim ErrMsg As String = String.Empty
        Dim SerSize As Integer = 0

        Me.txtPO.Text = Trim(Me.txtPO.Text)
        Me.txtTotal.Text = Trim(Me.txtTotal.Text)

        For Each li As ListViewItem In Me.lsvService.Items
            SerSize += li.SubItems(0).Text.Length + li.SubItems(1).Text.Length + 3
        Next

        If Me.cbxTruck.SelectedIndex < 1 Then
            ErrMsg = "Please select a Truck Number."
            flag = False
            Me.cbxTruck.Focus()
        ElseIf Not Me.chkServiceDate.Checked Then
            ErrMsg = "Please enter a Service Date."
            flag = False
            Me.chkServiceDate.Focus()
        ElseIf Me.lsvService.Items.Count = 0 Then
            ErrMsg = "Please enter at least one item in the Service List."
            flag = False
        ElseIf SerSize > 7900 Then
            ErrMsg = "The length of all Service List items combined cannot exceed 8000 characters."
        ElseIf Not IsNumeric(Me.txtTotal.Text) Then
            ErrMsg = "Please enter valid a Total."
            flag = False
            Me.txtTotal.Focus()
        End If

        If Not flag Then
            MessageBox.Show(ErrMsg, "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    Private Sub PopulateTruckCBX()

        Dim CmdStr As String = "SELECT [Truck ID],[Truck Number] FROM [Trucks] WHERE [Inactive]=0"

        ' if mode is edit or details and truck is inactive
        ' but it has to apear in CBX
        If Me._mode <> FormMode.CreateNew Then
            CmdStr &= " OR [Truck ID]=(SELECT [Truck ID] FROM [TruckServices] WHERE [Service ID]=" & Me._trServId.ToString & ")"
        End If

        CmdStr &= " ORDER BY [Truck Number]"

        Dim myDa As New SqlClient.SqlDataAdapter(CmdStr, GS.ConnectionString)
        Dim ErrFlag As Boolean = False

        Try
            myDa.Fill(Me.myDsTrucks, "Trucks")
        Catch ex As Exception
            MessageBox.Show("Unable to populate Truck Number ComboBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ErrFlag = True
        Finally
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then Exit Sub

        Me.cbxTruck.Items.Add(String.Empty)

        For Each Row As DataRow In Me.myDsTrucks.Tables("Trucks").Rows
            Me.cbxTruck.Items.Add(Row.Item("Truck Number"))
        Next

    End Sub

    Private Sub CalculateTotal()
        ' calculate total
        Dim total As Double = 0

        For Each lsvi As ListViewItem In Me.lsvService.Items
            If lsvi.SubItems(1).Text.Length > 0 Then
                total += CDbl(lsvi.SubItems(1).Text)
            End If
        Next

        Me.txtTotal.Text = Format(total, "Fixed")
    End Sub

    Friend Property Mode() As FormMode
        Get
            Return Me._mode
        End Get
        Set(ByVal value As FormMode)
            Me._mode = value
        End Set
    End Property

    Friend Property TruckServiceID() As Integer
        Get
            Return Me._trServId
        End Get
        Set(ByVal value As Integer)
            Me._trServId = value
        End Set
    End Property

#End Region 'Methods & Properties

End Class