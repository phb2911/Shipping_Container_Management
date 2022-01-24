Public Class NewTruck

    Dim _mode As FormMode = FormMode.CreateNew
    Dim _truckId As Integer = -1
    Dim myDsDrivers As New DataSet

    Private Sub NewTruck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Me._mode = FormMode.CreateNew And Me._truckId < 0 Then _
            Throw New Exception("A Truck ID must be passed unless mode is 'Create New'.")

        ' create DS table 
        Me.myDsDrivers.Tables.Add("Drivers")

        ' fill year and owner CBXs
        Me.FillYearAndOwnerCBXs()

        If Me._mode = FormMode.Edit Then
            Me.Text = "Edit Truck ID # " & Me._truckId.ToString
            Me.PopulateFields()
        ElseIf Me._mode = FormMode.Details Then
            Me.Text = "Truck ID # " & Me._truckId.ToString & " Details"
            Me.PopulateFields()
            Me.DisableControls()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub DisableControls()
        For Each c As Control In Me.GroupBox1.Controls
            If c.GetType.Name = "TextBox" Then
                CType(c, TextBox).ReadOnly = True
            ElseIf c.GetType.Name = "ComboBox" Then
                c.Enabled = False
            End If
        Next
        For Each c As Control In Me.GroupBox2.Controls
            If c.GetType.Name = "TextBox" Then
                CType(c, TextBox).ReadOnly = True
            ElseIf c.GetType.Name = "ComboBox" Or c.GetType.Name = "CheckBox" Or c.GetType.Name = "DateTimePicker" Then
                c.Enabled = False
            End If
        Next
        Me.chkInactive.Enabled = False
        Me.btnCancel.Text = "Close"
        Me.btnOK.Visible = False
    End Sub

    Private Sub FillYearAndOwnerCBXs()

        ' fill year cbx
        Me.cbxYear.Items.Add(String.Empty)
        For i As Integer = Now.Year + 1 To Now.Year - 30 Step -1
            Me.cbxYear.Items.Add(i)
        Next

        ' fill owner cbx
        Dim CmdStr As String = "SELECT [Driver ID],[Driver Name] FROM [Drivers] WHERE [Inactive]=0"

        If Me._mode <> FormMode.CreateNew Then
            CmdStr &= " OR [Driver ID]=(SELECT [Owner] FROM [Trucks] WHERE [Truck ID]=" & Me._truckId.ToString & ")"
        End If

        Dim ErrFlag As Boolean = False
        Dim myDa As New SqlClient.SqlDataAdapter(CmdStr, GS.ConnectionString)

        Try
            myDa.Fill(Me.myDsDrivers, "Drivers")
        Catch ex As Exception
            MessageBox.Show("An error occured while the data was being sent to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
        Else

            Me.cbxOwner.Items.Add("Company")

            For Each Row As DataRow In Me.myDsDrivers.Tables("Drivers").Rows
                Me.cbxOwner.Items.Add(Row.Item("Driver Name"))
            Next

            Me.cbxOwner.SelectedIndex = 0

        End If

    End Sub

    Private Function ValidateFields() As Boolean

        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox1)
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox2)

        Me.cbxYear.Text = Trim(Me.cbxYear.Text)

        Dim msg As String = String.Empty
        Dim flag As Boolean = True

        If Me.txtNumber.Text.Length = 0 Then
            Me.txtNumber.Focus()
            msg = "Pleas enter a Truck Number."
            flag = False
        ElseIf Me.cbxYear.Text <> "" And Not System.Text.RegularExpressions.Regex.IsMatch(Me.cbxYear.Text, "^(\d+)$") Then
            Me.cbxYear.Focus()
            msg = "Invalid Year."
            flag = False
        End If

        If Not flag Then
            MessageBox.Show(msg, "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    Private Sub PopulateFields()

        Dim CmdStr As String = "SELECT [Trucks].*, (SELECT [Drivers].[Driver Name] FROM [drivers] WHERE [Drivers].[Driver ID]=Trucks.Owner) AS [Owner Name] " & _
                                "FROM [Trucks] WHERE [Trucks].[Truck ID]=" & Me._truckId.ToString
        Dim myDa As New SqlClient.SqlDataAdapter(CmdStr, GS.ConnectionString)
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False

        Try

            myDa.Fill(myDs, "Trucks")

        Catch ex As Exception
            MessageBox.Show("An error occured while accessing the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If IsNothing(myDs.Tables("Trucks")) OrElse myDs.Tables("Trucks").Rows.Count = 0 Then
            MessageBox.Show("Truck # " & Me._truckId.ToString & " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        End If

        If ErrFlag Then
            If Not IsNothing(myDs) Then myDs.Dispose()
            Me.Close()
            Exit Sub
        End If

        Dim Row As DataRow = myDs.Tables("Trucks").Rows(0)

        Me.txtNumber.Text = Row.Item("Truck Number").ToString
        Me.txtMake.Text = Row.Item("Make").ToString
        Me.txtVin.Text = Row.Item("VIN").ToString
        Me.txtPlate.Text = Row.Item("Plate").ToString
        Me.txtColor.Text = Row.Item("Color").ToString
        Me.cbxYear.Text = Row.Item("Year").ToString
        Me.txtEzpass.Text = Row.Item("Ezpass Number").ToString
        Me.txtRegistration.Text = Row.Item("Registration").ToString

        If Not IsDBNull(Row.Item("Registration Exp")) Then
            Me.dtpReg.Value = CDate(Row.Item("Registration Exp"))
            Me.chkReg.Checked = True
        End If

        If Not IsDBNull(Row.Item("DOT Insp Exp")) Then
            Me.dtpDot.Value = CDate(Row.Item("DOT Insp Exp"))
            Me.chkDOT.Checked = True
        End If

        If Not IsDBNull(Row.Item("Emission Insp Exp")) Then
            Me.dtpEmission.Value = CDate(Row.Item("Emission Insp Exp"))
            Me.chkEmission.Checked = True
        End If

        If Not IsDBNull(Row.Item("IFTA Exp")) Then
            Me.dtpIfta.Value = CDate(Row.Item("IFTA Exp"))
            Me.chkIfta.Checked = True
        End If

        If Not IsDBNull(Row.Item("Owner Name")) Then _
            Me.cbxOwner.Text = Row.Item("Owner Name").ToString

        Me.chkInactive.Checked = CBool(Row.Item("Inactive"))

        If Not IsNothing(myDs) Then myDs.Dispose()

    End Sub

    Private Function InputData(ByRef ErrorMessage As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim CmdStr As String = String.Empty
        Dim CmdStr2 As String = String.Empty
        Dim Fields As String = String.Empty
        Dim Values As String = String.Empty
        Dim UpStr As String = String.Empty
        Dim flag As Boolean = True

        If Me.txtMake.Text.Length > 0 Then
            Fields &= ",[Make]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtMake.Text) & "'"
            UpStr &= ",[Make]='" & GS.FilterSingleQuote(Me.txtMake.Text) & "'"
        Else
            UpStr &= ",[Make]=NULL"
        End If

        If Me.txtVin.Text.Length > 0 Then
            Fields &= ",[VIN]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtVin.Text) & "'"
            UpStr &= ",[VIN]='" & GS.FilterSingleQuote(Me.txtVin.Text) & "'"
        Else
            UpStr &= ",[VIN]=NULL"
        End If

        If Me.txtPlate.Text.Length > 0 Then
            Fields &= ",[Plate]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtPlate.Text) & "'"
            UpStr &= ",[Plate]='" & GS.FilterSingleQuote(Me.txtPlate.Text) & "'"
        Else
            UpStr &= ",[Plate]=NULL"
        End If

        If Me.txtColor.Text.Length > 0 Then
            Fields &= ",[Color]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtColor.Text) & "'"
            UpStr &= ",[Color]='" & GS.FilterSingleQuote(Me.txtColor.Text) & "'"
        Else
            UpStr &= ",[Color]=NULL"
        End If

        If Me.cbxYear.Text.Length > 0 Then
            Fields &= ",[Year]"
            Values &= ",'" & Me.cbxYear.Text & "'"
            UpStr &= ",[Year]='" & Me.cbxYear.Text & "'"
        Else
            UpStr &= ",[Year]=NULL"
        End If

        If Me.txtEzpass.Text.Length > 0 Then
            Fields &= ",[Ezpass Number]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtEzpass.Text) & "'"
            UpStr &= ",[Ezpass Number]='" & GS.FilterSingleQuote(Me.txtEzpass.Text) & "'"
        Else
            UpStr &= ",[Ezpass Number]=NULL"
        End If

        If Me.txtRegistration.Text.Length > 0 Then
            Fields &= ",[Registration]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtRegistration.Text) & "'"
            UpStr &= ",[Registration]='" & GS.FilterSingleQuote(Me.txtRegistration.Text) & "'"
        Else
            UpStr &= ",[Registration]=NULL"
        End If

        If Me.chkReg.Checked Then
            Fields &= ",[Registration Exp]"
            Values &= ",'" & Me.dtpReg.Value.ToShortDateString & "'"
            UpStr &= ",[Registration Exp]='" & Me.dtpReg.Value.ToShortDateString & "'"
        Else
            UpStr &= ",[Registration Exp]=NULL"
        End If

        If Me.chkDOT.Checked Then
            Fields &= ",[DOT Insp Exp]"
            Values &= ",'" & Me.dtpDot.Value.ToShortDateString & "'"
            UpStr &= ",[DOT Insp Exp]='" & Me.dtpDot.Value.ToShortDateString & "'"
        Else
            UpStr &= ",[DOT Insp Exp]=NULL"
        End If

        If Me.chkEmission.Checked Then
            Fields &= ",[Emission Insp Exp]"
            Values &= ",'" & Me.dtpEmission.Value.ToShortDateString & "'"
            UpStr &= ",[Emission Insp Exp]='" & Me.dtpEmission.Value.ToShortDateString & "'"
        Else
            UpStr &= ",[Emission Insp Exp]=NULL"
        End If

        If Me.chkIfta.Checked Then
            Fields &= ",[IFTA Exp]"
            Values &= ",'" & Me.dtpIfta.Value.ToShortDateString & "'"
            UpStr &= ",[IFTA Exp]='" & Me.dtpIfta.Value.ToShortDateString & "'"
        Else
            UpStr &= ",[IFTA Exp]=NULL"
        End If

        If Me.cbxOwner.SelectedIndex > 0 Then
            Dim Rows() As DataRow = Me.myDsDrivers.Tables("Drivers").Select("[Driver Name]='" & GS.FilterSingleQuote(Me.cbxOwner.Text) & "'")
            Fields &= ",[Owner]"
            Values &= ",'" & Rows(0).Item("Driver ID").ToString & "'"
            UpStr &= ",[Owner]='" & Rows(0).Item("Driver ID").ToString & "'"
        Else
            UpStr &= ",[Owner]=NULL"
        End If

        If Me.chkInactive.Checked Then
            Fields &= ",[Inactive]"
            Values &= ",1"
            UpStr &= ",[Inactive]=1"
        Else
            UpStr &= ",[Inactive]=0"
        End If

        If Me._mode = FormMode.CreateNew Then
            CmdStr = "INSERT INTO [Trucks] ([Truck Number]" & Fields & ") VALUES ('" & _
                GS.FilterSingleQuote(Me.txtNumber.Text) & "'" & Values & ")"

            CmdStr2 = "IF EXISTS (SELECT [Truck Number] FROM [Trucks] WHERE [Trucks].[Truck Number]='" & GS.FilterSingleQuote(Me.txtNumber.Text) & _
                "') SELECT '1' ELSE SELECT '0'"
        Else
            CmdStr = "UPDATE [Trucks] SET [Truck Number]='" & GS.FilterSingleQuote(Me.txtNumber.Text) & "'" & _
                 UpStr & " WHERE [Truck ID]=" & Me._truckId.ToString

            CmdStr2 = "IF EXISTS (SELECT [Truck Number] FROM [Trucks] WHERE [Trucks].[Truck ID]=" & Me._truckId.ToString & _
                ") SELECT '1' ELSE SELECT '0'"
        End If

        Try

            myConn.Open()

            myCmd.CommandText = CmdStr2
            myCmd.Connection = myConn

            Dim ExFlag As Boolean = CBool(myCmd.ExecuteScalar())

            If Me._mode = FormMode.CreateNew And ExFlag Then
                ErrorMessage = "1"
                flag = False
            ElseIf Me._mode = FormMode.Edit And Not ExFlag Then
                ErrorMessage = "2"
                flag = False
            Else
                myCmd = New SqlClient.SqlCommand(CmdStr, myConn)
                myCmd.ExecuteNonQuery()
            End If

        Catch ex As Exception
            ErrorMessage = ex.Message
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

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.ValidateFields() Then
            Dim ErrMsg As String = String.Empty
            If Me.InputData(ErrMsg) Then

                ' refresh truck List
                If GS.FormIsOpen(My.Forms.Form1.frmTruckList) Then My.Forms.Form1.frmTruckList.RefreshDataAndList()

                ' refresh dispatch window
                If GS.FormIsOpen(My.Forms.Form1.frmDispatch) Then
                    With My.Forms.Form1.frmDispatch
                        .RefreshMain()
                        .tsbRefreshWo_Click(Nothing, Nothing)
                        .tsbRefresh_Click(Nothing, Nothing)
                    End With
                End If

                Me.Close()

            Else
                Dim msg As String = String.Empty

                If ErrMsg = "1" Then
                    msg = "The Truck # '" & Me.txtNumber.Text & "' already exists in the database." & vbCrLf & _
                          "Please choose a different one and try again."
                    Me.txtNumber.Focus()

                ElseIf ErrMsg = "2" Then
                    msg = "The Truck being edited no longer exists in database."
                    Me.Close()
                Else
                    msg = "An error occured while the data was being sent to the database." & _
                          vbCrLf & vbCrLf & "Details: " & ErrMsg & vbCrLf & vbCrLf & _
                          "Check your connection and try again."
                End If

                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Friend Property Mode() As FormMode
        Get
            Return Me._mode
        End Get
        Set(ByVal value As FormMode)
            Me._mode = value
        End Set
    End Property

    Friend Property TruckID() As Integer
        Get
            Return Me._truckId
        End Get
        Set(ByVal value As Integer)
            Me._truckId = value
        End Set
    End Property

    Private Sub TextBoxes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumber.LostFocus, _
        txtVin.LostFocus, txtPlate.LostFocus, txtRegistration.LostFocus

        Dim myTextBox As TextBox = CType(sender, TextBox)

        myTextBox.Text = UCase(myTextBox.Text)

    End Sub

    Private Sub chkReg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReg.CheckedChanged
        Me.dtpReg.Enabled = Me.chkReg.Checked
    End Sub

    Private Sub chkDOT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDOT.CheckedChanged
        Me.dtpDot.Enabled = Me.chkDOT.Checked
    End Sub

    Private Sub chkIfta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIfta.CheckedChanged
        Me.dtpIfta.Enabled = Me.chkIfta.Checked
    End Sub

    Private Sub chkEmission_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEmission.CheckedChanged
        Me.dtpEmission.Enabled = Me.chkEmission.Checked
    End Sub
End Class