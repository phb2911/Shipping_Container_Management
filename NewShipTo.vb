Public Class NewShipTo

    Dim _CustName As String
    Dim _CustId As Integer
    Dim _ShipToID As Integer
    Dim frmNewWorkOrder As NewWorkOrder
    Dim _OwnerFlag As Boolean = False
    Dim _OkPressed As Boolean = False
    Dim _mode As FormMode = FormMode.CreateNew


    Public Sub New(ByVal CustomerID As Integer, ByVal CustomerName As String)
        Me.New(CustomerID, CustomerName, -1)
    End Sub

    Public Sub New(ByVal CustomerID As Integer, ByVal CustomerName As String, ByVal ShipToID As Integer)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me._CustId = CustomerID
        Me._CustName = CustomerName
        Me._ShipToID = ShipToID
    End Sub

#Region "Control Events"

    Private Sub NewShipTo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.Owner.Name = "NewWorkOrder" Then
            Me.frmNewWorkOrder = CType(Me.Owner, NewWorkOrder)
            Me._OwnerFlag = True
        End If

        ' validate mode
        If Not Me._mode = FormMode.CreateNew And Me._ShipToID < 0 Then _
            Throw New Exception("A 'ShipTo ID' must be passed unless mode is 'CreateNew'.")

        If Me._mode = FormMode.Details Then
            Me.Text = "ShipTo # " & Me._ShipToID.ToString & " details"
            Me.DisableControls()
            Me.PopulateControls()
        ElseIf Me._mode = FormMode.Edit Then
            Me.Text = "Edit ShipTo # " & Me._ShipToID.ToString
            Me.PopulateControls()
        End If

        Me.txtCustomer.Text = Me._CustName

    End Sub

    Private Sub NewShipTo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' select first line
        If Me._OwnerFlag And Not Me._OkPressed And Me._mode = FormMode.CreateNew Then _
            Me.frmNewWorkOrder.cbxShipTo.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Me.Cursor = Cursors.WaitCursor

        Dim ErrMsg As String = String.Empty
        Dim ErrFlag As Boolean = False
        Dim SerSize As Integer = 0

        ' trim textboxes text
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox1)
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox2)

        For Each li As ListViewItem In Me.lsvRate.Items
            SerSize += li.SubItems(0).Text.Length + li.SubItems(1).Text.Length + 3
        Next

        ' validate fields
        If Me.txtName.Text.Length = 0 Then
            ErrMsg = "Please enter a valid ShipTo Name."
            Me.txtName.Focus()
            ErrFlag = True
        ElseIf SerSize > 1950 Then
            ErrMsg = "The length of all Rate List items combined cannot exceed 2000 characters."
            ErrFlag = True
        End If

        If ErrFlag Then
            Me.Cursor = Cursors.Default
            MessageBox.Show(ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' input data
        If InputData(ErrMsg) Then

            If Me._OwnerFlag And Me.chkInactive.Checked Then
                ' if customer is inactive
                ' select blank cbx index
                Me.frmNewWorkOrder.cbxShipTo.SelectedIndex = 0
            ElseIf Me._OwnerFlag Then

                ' refresh DataSet ShipTo
                If Me.frmNewWorkOrder.FillDs(NewWorkOrder.FillTableType.ShipTo) Then
                    ' update cbx
                    Me.frmNewWorkOrder.cbxShipTo.Items.Add(Me.txtName.Text)

                    ' select newly added item (last index)
                    Me.frmNewWorkOrder.cbxShipTo.SelectedIndex = Me.frmNewWorkOrder.cbxShipTo.Items.Count - 1
                End If

            End If

            If GS.FormIsOpen(My.Forms.Form1.frmShipToList) Then
                My.Forms.Form1.frmShipToList.RefreshDataAndList()
            End If

            Me._OkPressed = True
            Me.Close()
        Else

            Dim msg As String = String.Empty

            If ErrMsg = "1" Then
                msg = "The customer '" & Me._CustName & "' already has the 'Ship To' name specified." & vbCrLf & _
                      "Please choose a different name and try again."
                Me.txtName.Focus()

            ElseIf ErrMsg = "2" Then
                msg = "The ShipTo being edited no longer exists in database."
                Me.Close()
            Else
                msg = "An error occured while the data was being sent to the database." & _
                      vbCrLf & vbCrLf & "Details: " & ErrMsg & vbCrLf & vbCrLf & _
                      "Check your connection and try again."
            End If

            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If


        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Dim ErrFlag As Boolean = False
        Dim ErrMsg As String = ""

        Me.cbxDescription.Text = Me.cbxDescription.Text.Trim()

        ' validate Rate
        If Me.cbxDescription.Text.IndexOf("|") >= 0 Or Me.cbxDescription.Text.IndexOf(":") >= 0 Then
            ErrMsg = "The characters ""|"" and "":"" cannot be used in the Rate Description field."
            ErrFlag = True
            Me.cbxDescription.Focus()
        ElseIf Not IsNumeric(Me.txtAmount.Text.Trim) Then
            ErrMsg = "Invalid Rate Amount."
            ErrFlag = True
            Me.txtAmount.Focus()
        End If

        If ErrFlag Then
            MessageBox.Show(ErrMsg, "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim lsvItem As New ListViewItem(Me.cbxDescription.Text)
            lsvItem.SubItems.Add(Format(CDbl(Me.txtAmount.Text.Trim), "Standard"))
            Me.lsvRate.Items.Add(lsvItem)
            Me.cbxDescription.Text = ""
            Me.txtAmount.Text = ""
            Me.CalculateRateTotal()
        End If

    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = 13 Then _
            Me.btnAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub txtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.LostFocus

        If IsNumeric(Me.txtAmount.Text.Trim) Then _
            Me.txtAmount.Text = Format(CDbl(Me.txtAmount.Text.Trim), "Standard")

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Me.lsvRate.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a list item.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Me.lsvRate.Items.RemoveAt(Me.lsvRate.SelectedItems(0).Index)
            Me.CalculateRateTotal()
        End If
    End Sub

#End Region ' Control Events

#Region "Methods & Properties"

    Private Sub CalculateRateTotal()

        Dim Total As Double = 0
        Dim EmptyFlag As Boolean = True

        For Each li As ListViewItem In Me.lsvRate.Items
            Total += CDbl(li.SubItems(1).Text)
            EmptyFlag = False
        Next

        If EmptyFlag Then
            Me.txtTotal.Text = ""
        Else
            Me.txtTotal.Text = Format(Total, "Standard")
        End If

    End Sub

    Private Sub PopulateControls()
        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand("SELECT * FROM [ShipTo] WHERE [ShipTo].[ShipTo ID]=" & Me._ShipToID.ToString, myConn)
        Dim myDa As New SqlClient.SqlDataAdapter(myCmd)
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False


        Try

            myDa.Fill(myDs, "ShipTo")

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                "Details: " & ex.Message & "Please check your connection and try again.", "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
            Exit Sub
        End If

        Dim Row As DataRow = myDs.Tables("ShipTo").Rows(0)

        Me.txtName.Text = Row.Item("ShipTo Name").ToString
        Me.txtAddress1.Text = Row.Item("Address").ToString
        Me.txtAddress2.Text = Row.Item("Address2").ToString
        Me.txtCity.Text = Row.Item("City").ToString

        If Not IsDBNull(Row.Item("State")) Then _
            Me.cbxState.Text = USStates.GetStateName(Row.Item("State").ToString)

        Me.txtZipCode.Text = Row.Item("Zip Code").ToString
        Me.txtDirections.Text = Row.Item("Directions").ToString
        Me.txtContactName.Text = Row.Item("Contact Name").ToString
        Me.txtPhone.Text = Row.Item("Phone").ToString
        Me.txtFax.Text = Row.Item("Fax").ToString
        Me.txtEmail.Text = Row.Item("E-mail").ToString

        GS.FillRateListView(Me.lsvRate, Row.Item("Rate").ToString)
        Me.CalculateRateTotal()

        Me.chkInactive.Checked = CBool(Row.Item("Inactive"))

    End Sub

    Private Sub DisableControls()
        Me.DisableGroupBoxControls(Me.GroupBox1)
        Me.DisableGroupBoxControls(Me.GroupBox2)
        Me.DisableGroupBoxControls(Me.GroupBox4)
        Me.txtDirections.ReadOnly = True
        Me.cbxState.Enabled = False
        Me.chkInactive.Enabled = False
        Me.btnOk.Visible = False
        Me.btnCancel.Text = "Close"
        Me.txtTotal.BackColor = Me.txtAmount.BackColor
        Me.lsvRate.BackColor = Me.txtAmount.BackColor
        Me.cbxDescription.Enabled = False
    End Sub

    Private Sub DisableGroupBoxControls(ByRef myGroupBox As GroupBox)
        For Each c As Control In myGroupBox.Controls
            If c.GetType.Name = "TextBox" Then
                CType(c, TextBox).ReadOnly = True
            ElseIf c.GetType.Name = "Button" Then
                CType(c, Button).Enabled = False
            End If
        Next
    End Sub

    Private Function InputData(ByRef ErrorMessage As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection
        Dim myCmd As SqlClient.SqlCommand = Nothing
        Dim CmdStr As String = String.Empty
        Dim CmdStr2 As String = String.Empty
        Dim Fields As String = String.Empty
        Dim Values As String = String.Empty
        Dim UpdateStr As String = String.Empty
        Dim flag As Boolean = True

        If Me.txtAddress1.Text <> String.Empty Then
            Fields &= ",[Address]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtAddress1.Text) & "'"
            UpdateStr &= ",[Address]='" & GS.FilterSingleQuote(Me.txtAddress1.Text) & "'"
        Else
            UpdateStr &= ",[Address]=NULL"
        End If

        If Me.txtAddress2.Text <> String.Empty Then
            Fields &= ",[Address2]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtAddress2.Text) & "'"
            UpdateStr &= ",[Address2]='" & GS.FilterSingleQuote(Me.txtAddress2.Text) & "'"
        Else
            UpdateStr &= ",[Address2]=NULL"
        End If

        If Me.txtCity.Text <> String.Empty Then
            Fields &= ",[City]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtCity.Text) & "'"
            UpdateStr &= ",[City]='" & GS.FilterSingleQuote(Me.txtCity.Text) & "'"
        Else
            UpdateStr &= ",[City]=NULL"
        End If

        If Me.cbxState.SelectedIndex > 0 Then
            Fields &= ",[State]"
            Values &= ",'" & USStates.GetAbreviation(Me.cbxState.Text) & "'"
            UpdateStr &= ",[State]='" & USStates.GetAbreviation(Me.cbxState.Text) & "'"
        Else
            UpdateStr &= ",[State]=NULL"
        End If

        If Me.txtZipCode.Text <> String.Empty Then
            Fields &= ",[Zip Code]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtZipCode.Text) & "'"
            UpdateStr &= ",[Zip Code]='" & GS.FilterSingleQuote(Me.txtZipCode.Text) & "'"
        Else
            UpdateStr &= ",[Zip Code]=NULL"
        End If

        If Me.txtDirections.Text <> String.Empty Then
            Fields &= ",[Directions]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtDirections.Text) & "'"
            UpdateStr &= ",[Directions]='" & GS.FilterSingleQuote(Me.txtDirections.Text) & "'"
        Else
            UpdateStr &= ",[Directions]=NULL"
        End If

        If Me.txtContactName.Text <> String.Empty Then
            Fields &= ",[Contact Name]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtContactName.Text) & "'"
            UpdateStr &= ",[Contact Name]='" & GS.FilterSingleQuote(Me.txtContactName.Text) & "'"
        Else
            UpdateStr &= ",[Contact Name]=NULL"
        End If

        If Me.txtPhone.Text <> String.Empty Then
            Fields &= ",[Phone]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtPhone.Text) & "'"
            UpdateStr &= ",[Phone]='" & GS.FilterSingleQuote(Me.txtPhone.Text) & "'"
        Else
            UpdateStr &= ",[Phone]=NULL"
        End If

        If Me.txtFax.Text <> String.Empty Then
            Fields &= ",[Fax]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtFax.Text) & "'"
            UpdateStr &= ",[Fax]='" & GS.FilterSingleQuote(Me.txtFax.Text) & "'"
        Else
            UpdateStr &= ",[Fax]=NULL"
        End If

        If Me.txtEmail.Text <> String.Empty Then
            Fields &= ",[E-Mail]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtEmail.Text) & "'"
            UpdateStr &= ",[E-Mail]='" & GS.FilterSingleQuote(Me.txtEmail.Text) & "'"
        Else
            UpdateStr &= ",[E-Mail]=NULL"
        End If

        ' rate list
        Dim RateList As String = String.Empty
        For Each li As ListViewItem In Me.lsvRate.Items
            RateList &= li.SubItems(0).Text & "||" & li.SubItems(1).Text & "::"
        Next

        If RateList.Length > 0 Then
            Fields &= ",[Rate]"
            Values &= ",'" & GS.FilterSingleQuote(RateList) & "'"
            UpdateStr &= ",[Rate]='" & GS.FilterSingleQuote(RateList) & "'"
        Else
            UpdateStr &= ",[Rate]=NULL"
        End If

        If Me.chkInactive.Checked Then
            Fields &= ",[Inactive]"
            Values &= ",1"
            UpdateStr &= ",[Inactive]=1"
        Else
            UpdateStr &= ",[Inactive]=0"
        End If

        If Me._mode = FormMode.CreateNew Then
            CmdStr = "INSERT INTO [ShipTo] ([ShipTo Name],[Customer ID]" & Fields & ") VALUES ('" & _
                     GS.FilterSingleQuote(Me.txtName.Text) & "'," & Me._CustId.ToString & Values & ")"

            CmdStr2 = "IF EXISTS (SELECT [ShipTo ID] FROM [ShipTo] WHERE [ShipTo].[ShipTo Name]='" & GS.FilterSingleQuote(Me.txtName.Text) & _
                                    "' AND [ShipTo].[Customer ID]=" & Me._CustId.ToString & ") SELECT '1' ELSE SELECT '0'"
        Else
            CmdStr = "UPDATE [ShipTo] SET [ShipTo Name]='" & GS.FilterSingleQuote(Me.txtName.Text) & _
                            "'" & UpdateStr & " WHERE [ShipTo ID]=" & Me._ShipToID.ToString

            CmdStr2 = "IF EXISTS (SELECT * FROM [ShipTo] WHERE [ShipTo ID]=" & Me._ShipToID.ToString & ") SELECT '1' ELSE SELECT '0'"
        End If

        Try

            ' open connection
            myConn.ConnectionString = GS.ConnectionString
            myConn.Open()

            myCmd = New SqlClient.SqlCommand(CmdStr2, myConn)

            Dim ExFlag As Boolean = CBool(myCmd.ExecuteScalar())

            If Me._mode = FormMode.CreateNew And ExFlag Then
                ErrorMessage = "1"
                flag = False
            ElseIf Me._mode = FormMode.Edit And Not ExFlag Then
                ErrorMessage = "2"
                flag = False
            Else

                myCmd = New SqlClient.SqlCommand(CmdStr, myConn)

                ' execute command
                myCmd.ExecuteNonQuery()
            End If



        Catch ex As Exception
            ErrorMessage = ex.Message
            flag = False
        Finally
            If myConn.State = ConnectionState.Open Then myConn.Close()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
        End Try

        Return flag

    End Function

    Friend Property Mode() As FormMode
        Get
            Return Me._mode
        End Get
        Set(ByVal value As FormMode)
            Me._mode = value
        End Set
    End Property

    Friend Property ShipToID() As Integer
        Get
            Return Me._ShipToID
        End Get
        Set(ByVal value As Integer)
            Me._ShipToID = value
        End Set
    End Property

#End Region ' Methods & Properties

End Class