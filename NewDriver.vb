
Imports System.Text.RegularExpressions

Public Class NewDrivers

    Dim _mode As FormMode = FormMode.CreateNew
    Dim _driverID As Integer = -1
    Dim _asiFlag As Boolean = False
    Dim myDs As New DataSet

#Region "Control Events"

    Private Sub NewDrivers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Me._mode = FormMode.CreateNew And Me._driverID < 0 Then _
            Throw New Exception("A Driver ID must be passed unless mode is 'Create New'.")

        ' fill Truck cbx
        Me.FillTruckCBX()

        If Me._mode = FormMode.Edit Then
            Me.Text = "Edit Driver # " & Me._driverID.ToString
            Me.PopulateFields()
        ElseIf Me._mode = FormMode.Details Then
            Me.Text = "Driver ID # " & Me._driverID.ToString & " Details"
            Me.PopulateFields()
            Me.DisableControls()
        End If

        If Me._mode = FormMode.CreateNew Then
            Me.chkMask.Checked = False
        Else
            Me.chkMask.Enabled = Me._asiFlag
        End If

    End Sub

    Private Sub NewDrivers_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' clean up
        If Not IsNothing(myDs) Then myDs.Dispose()
    End Sub

    Private Sub chkDlExp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDlExp.CheckedChanged
        Me.dtpDlExp.Enabled = Me.chkDlExp.Checked
    End Sub

    Private Sub chkMedExp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMedExp.CheckedChanged
        Me.dtpMedCard.Enabled = Me.chkMedExp.Checked
    End Sub

    Private Sub chkSealinkExp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSealinkExp.CheckedChanged
        Me.dtpSealink.Enabled = Me.chkSealinkExp.Checked
    End Sub

    Private Sub chkDOB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDOB.CheckedChanged
        Me.dtpDOB.Enabled = Me.chkDOB.Checked
    End Sub

    Private Sub txtSSN1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSSN1.TextChanged
        If Me.txtSSN1.Text.Length = 3 Then Me.txtSSN2.Focus()
    End Sub

    Private Sub txtSSN2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSSN2.TextChanged
        If Me.txtSSN2.Text.Length = 2 Then Me.txtSSN3.Focus()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Me.ValidateFields() Then
            Dim ErrMsg As String = String.Empty
            If Me.InputData(ErrMsg) Then

                ' refresh driver list
                If GS.FormIsOpen(My.Forms.Form1.frmDriverList) Then
                    My.Forms.Form1.frmDriverList.RefreshDataAndList()
                End If

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
                    msg = "The Driver Name '" & Me.txtName.Text & "' already exists in the database." & vbCrLf & _
                          "Please choose a different name and try again."
                    Me.txtName.Focus()

                ElseIf ErrMsg = "2" Then
                    msg = "The Driver being edited no longer exists in database."
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

    Private Sub cbxTruck_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTruck.SelectedIndexChanged
        Me.btnTruckDetails.Enabled = (Me.cbxTruck.SelectedIndex > 0)
    End Sub

    Private Sub btnTruckDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTruckDetails.Click
        Dim Rows() As DataRow = Me.myDs.Tables("Trucks").Select("[Truck Number]='" & Me.cbxTruck.Text & "'")
        Dim frm As New NewTruck
        frm.Mode = FormMode.Details
        frm.TruckID = CInt(Rows(0).Item("Truck ID"))
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub chkMask_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMask.CheckedChanged
        Dim flag As Boolean = Me.chkMask.Checked

        If Not flag And Not Me._mode = FormMode.CreateNew Then
            Dim frm As New Login(My.Forms.Form1.myUser.Name)
            frm.ShowDialog()
            If Not frm.Confirmed Then
                flag = True
                Me.chkMask.Checked = True
            End If
        End If

        Me.Mask(flag)

        If Me._mode <> FormMode.Details Then _
            Me.ChangeControlsToReadOnly(flag)

    End Sub

    Private Sub txtDL_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDL.LostFocus
        Me.txtDL.Text = Me.txtDL.Text.ToUpper()
    End Sub

#End Region ' Control Events

#Region "Methods & Properties"

    Private Sub Mask(ByVal value As Boolean)

        Dim AsciiVal As Integer = 0

        If value Then AsciiVal = 42

        Dim PwdChar As Char = Chr(AsciiVal)

        Me.txtSSN1.PasswordChar = PwdChar
        Me.txtSSN2.PasswordChar = PwdChar
        Me.txtSSN3.PasswordChar = PwdChar
        Me.txtDL.PasswordChar = PwdChar

    End Sub

    Private Sub ChangeControlsToReadOnly(ByVal value As Boolean)
        Me.txtSSN1.ReadOnly = value
        Me.txtSSN2.ReadOnly = value
        Me.txtSSN3.ReadOnly = value
        Me.txtDL.ReadOnly = value
    End Sub

    Private Sub FillTruckCBX()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim flag As Boolean = False
        Dim CmdStr As String = "SELECT [Trucks].[Truck ID],[Trucks].[Truck Number] FROM [Trucks] WHERE [Trucks].[Inactive]=0"

        If Me._mode <> FormMode.CreateNew Then
            CmdStr &= " OR [Trucks].[Truck ID]=(SELECT [Drivers].[Truck ID] FROM [Drivers] WHERE [Drivers].[Driver ID]=" & Me._driverID.ToString & ")"
        End If

        CmdStr &= " ORDER BY [Trucks].[Truck Number]"

        myCmd.CommandText = CmdStr
        myCmd.Connection = myConn

        Try
            myConn.Open()

            myDa.SelectCommand = myCmd
            myDa.Fill(Me.myDs, "Trucks")

            If Not Me._mode = FormMode.CreateNew Then
                Me._asiFlag = My.Forms.Form1.myUser.AccessSensitiveInfo(myConn)
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to populate Trucks ComboBox.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then
                    myConn.Close()
                End If
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If flag Then Exit Sub

        Me.cbxTruck.Items.Add(String.Empty)

        For Each Row As DataRow In Me.myDs.Tables("Trucks").Rows
            Me.cbxTruck.Items.Add(Row.Item("Truck Number").ToString)
        Next

    End Sub

    Private Sub PopulateFields()

        Dim myDa As New SqlClient.SqlDataAdapter("SELECT * FROM [Drivers] WHERE [Driver ID]=" & Me._driverID.ToString, GS.ConnectionString)
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False

        Try

            myDa.Fill(myDs, "Drivers")

        Catch ex As Exception
            MessageBox.Show("An error occured while accessing the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If IsNothing(myDs.Tables("Drivers")) OrElse myDs.Tables("Drivers").Rows.Count = 0 Then
            MessageBox.Show("Truck # " & Me._driverID.ToString & " not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        End If

        If ErrFlag Then
            If Not IsNothing(myDs) Then myDs.Dispose()
            Me.Close()
            Exit Sub
        End If

        Dim Row As DataRow = myDs.Tables("Drivers").Rows(0)

        Me.txtName.Text = Row.Item("Driver Name").ToString
        Me.txtAddress1.Text = Row.Item("Address").ToString
        Me.txtAddress2.Text = Row.Item("Address2").ToString
        Me.txtCity.Text = Row.Item("City").ToString

        If Not IsDBNull(Row.Item("State")) Then _
            Me.cbxState.Text = USStates.GetStateName(Row.Item("State").ToString)

        Me.txtZipCode.Text = Row.Item("Zip Code").ToString

        If Not IsDBNull(Row.Item("DOB")) Then
            Me.chkDOB.Checked = True
            Me.dtpDOB.Value = CDate(Row.Item("DOB"))
        End If

        Me.txtPhone.Text = Row.Item("Phone").ToString
        Me.chkOwnerOper.Checked = CBool(Row.Item("Owner Operator"))

        If Not IsDBNull(Row.Item("SSN")) Then
            Try
                Dim SSN As String = Cryptography.TripleDES.Decode(Row.Item("SSN").ToString, GS.GlobalKey)
                Dim SSNs() As String = Split(SSN, "-")

                Me.txtSSN1.Text = SSNs(0)
                Me.txtSSN2.Text = SSNs(1)
                Me.txtSSN3.Text = SSNs(2)

            Catch ex As Exception
                MessageBox.Show("Unable to load Social Security Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        If Not IsDBNull(Row.Item("DL")) Then
            Try
                Me.txtDL.Text = Cryptography.TripleDES.Decode(Row.Item("DL").ToString, GS.GlobalKey)
            Catch ex As Exception
                MessageBox.Show("Unable to load Driver License Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        'Me.cbxDlState.Text = Row.Item("DL State").ToString
        If Not IsDBNull(Row.Item("DL State")) Then _
            Me.cbxDlState.Text = USStates.GetStateName(Row.Item("DL State").ToString)

        If Not IsDBNull(Row.Item("DL Exp")) Then
            Me.chkDlExp.Checked = True
            Me.dtpDlExp.Value = CDate(Row.Item("DL Exp"))
        End If

        If Not IsDBNull(Row.Item("MedCard Exp")) Then
            Me.chkMedExp.Checked = True
            Me.dtpMedCard.Value = CDate(Row.Item("MedCard Exp"))
        End If

        Me.txtSealink.Text = Row.Item("SeaLink").ToString

        If Not IsDBNull(Row.Item("SeaLink Exp")) Then
            Me.chkSealinkExp.Checked = True
            Me.dtpSealink.Value = CDate(Row.Item("SeaLink Exp"))
        End If

        Me.chkHazmat.Checked = CBool(Row.Item("Hazmat"))

        If Not IsDBNull(Row.Item("Truck ID")) Then
            Dim Rs() As DataRow = Me.myDs.Tables("Trucks").Select("[Truck ID]=" & Row.Item("Truck ID").ToString)
            Me.cbxTruck.Text = Rs(0).Item("Truck Number").ToString
        End If

        Me.chkInactive.Checked = CBool(Row.Item("Inactive"))

    End Sub

    Private Sub DisableControls()
        For Each c As Control In Me.GroupBox1.Controls
            If c.GetType.Name = "TextBox" Then
                CType(c, TextBox).ReadOnly = True
            ElseIf c.GetType.Name = "CheckBox" Or c.GetType.Name = "DateTimePicker" Or c.GetType.Name = "ComboBox" Then
                c.Enabled = False
            End If
        Next
        For Each c As Control In Me.GroupBox2.Controls
            If c.GetType.Name = "TextBox" Then
                CType(c, TextBox).ReadOnly = True
            ElseIf c.GetType.Name = "CheckBox" Or c.GetType.Name = "DateTimePicker" Or c.GetType.Name = "ComboBox" Then
                c.Enabled = False
            End If
        Next
        Me.chkInactive.Enabled = False
        Me.btnOK.Visible = False
        Me.btnCancel.Text = "Close"
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

        If Me.txtAddress1.Text <> String.Empty Then
            Fields &= ",[Address]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtAddress1.Text) & "'"
            UpStr &= ",[Address]='" & GS.FilterSingleQuote(Me.txtAddress1.Text) & "'"
        Else
            UpStr &= ",[Address]=NULL"
        End If

        If Me.txtAddress2.Text <> String.Empty Then
            Fields &= ",[Address2]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtAddress2.Text) & "'"
            UpStr &= ",[Address2]='" & GS.FilterSingleQuote(Me.txtAddress2.Text) & "'"
        Else
            UpStr &= ",[Address2]=NULL"
        End If

        If Me.txtCity.Text <> String.Empty Then
            Fields &= ",[City]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtCity.Text) & "'"
            UpStr &= ",[City]='" & GS.FilterSingleQuote(Me.txtCity.Text) & "'"
        Else
            UpStr &= ",[City]=NULL"
        End If

        If Me.cbxState.SelectedIndex > 0 Then
            Fields &= ",[State]"
            Values &= ",'" & USStates.GetAbreviation(Me.cbxState.Text) & "'"
            UpStr &= ",[State]='" & USStates.GetAbreviation(Me.cbxState.Text) & "'"
        Else
            UpStr &= ",[State]=NULL"
        End If

        If Me.txtZipCode.Text <> String.Empty Then
            Fields &= ",[Zip Code]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtZipCode.Text) & "'"
            UpStr &= ",[Zip Code]='" & GS.FilterSingleQuote(Me.txtZipCode.Text) & "'"
        Else
            UpStr &= ",[Zip Code]=NULL"
        End If

        If Me.chkDOB.Checked Then
            Fields &= ",[DOB]"
            Values &= ",'" & Me.dtpDOB.Value.ToShortDateString & "'"
            UpStr &= ",[DOB]='" & Me.dtpDOB.Value.ToShortDateString & "'"
        Else
            UpStr &= ",[DOB]=NULL"
        End If

        If Me.txtPhone.Text <> String.Empty Then
            Fields &= ",[Phone]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtPhone.Text) & "'"
            UpStr &= ",[Phone]='" & GS.FilterSingleQuote(Me.txtPhone.Text) & "'"
        Else
            UpStr &= ",[Phone]=NULL"
        End If

        If Me.chkOwnerOper.Checked Then
            Fields &= ",[Owner Operator]"
            Values &= ",1"
            UpStr &= ",[Owner Operator]=1"
        Else
            UpStr &= ",[Owner Operator]=0"
        End If

        If Me.txtSSN1.Text.Length > 0 Then
            Dim SsnHash As String = Cryptography.TripleDES.Encode(Me.txtSSN1.Text & "-" & Me.txtSSN2.Text & "-" & Me.txtSSN3.Text, GS.GlobalKey)
            Fields &= ",[SSN]"
            Values &= ",'" & GS.FilterSingleQuote(SsnHash) & "'"
            UpStr &= ",[SSN]='" & GS.FilterSingleQuote(SsnHash) & "'"
        Else
            UpStr &= ",[SSN]=NULL"
        End If

        If Me.txtDL.Text.Length > 0 Then
            Fields &= ",[DL]"
            Values &= ",'" & GS.FilterSingleQuote(Cryptography.TripleDES.Encode(Me.txtDL.Text, GS.GlobalKey)) & "'"
            UpStr &= ",[DL]='" & GS.FilterSingleQuote(Cryptography.TripleDES.Encode(Me.txtDL.Text, GS.GlobalKey)) & "'"
        Else
            UpStr &= ",[DL]=NULL"
        End If

        If Me.cbxDlState.SelectedIndex > 0 Then
            Fields &= ",[DL State]"
            Values &= ",'" & USStates.GetAbreviation(Me.cbxDlState.Text) & "'"
            UpStr &= ",[DL State]='" & USStates.GetAbreviation(Me.cbxDlState.Text) & "'"
        Else
            UpStr &= ",[DL State]=NULL"
        End If

        If Me.chkDlExp.Checked Then
            Fields &= ",[DL Exp]"
            Values &= ",'" & Me.dtpDlExp.Value.ToShortDateString & "'"
            UpStr &= ",[DL Exp]='" & Me.dtpDlExp.Value.ToShortDateString & "'"
        Else
            UpStr &= ",[DL Exp]=NULL"
        End If

        If Me.chkMedExp.Checked Then
            Fields &= ",[MedCard Exp]"
            Values &= ",'" & Me.dtpMedCard.Value.ToShortDateString & "'"
            UpStr &= ",[MedCard Exp]='" & Me.dtpMedCard.Value.ToShortDateString & "'"
        Else
            UpStr &= ",[MedCard Exp]=NULL"
        End If

        If Me.txtSealink.Text.Length > 0 Then
            Fields &= ",[SeaLink]"
            Values &= ",'" & Me.txtSealink.Text & "'"
            UpStr &= ",[SeaLink]='" & Me.txtSealink.Text & "'"
        Else
            UpStr &= ",[SeaLink]=NULL"
        End If

        If Me.chkSealinkExp.Checked Then
            Fields &= ",[SeaLink Exp]"
            Values &= ",'" & Me.dtpSealink.Value.ToShortDateString & "'"
            UpStr &= ",[SeaLink Exp]='" & Me.dtpSealink.Value.ToShortDateString & "'"
        Else
            UpStr &= ",[SeaLink Exp]=NULL"
        End If

        If Me.chkHazmat.Checked Then
            Fields &= ",[Hazmat]"
            Values &= ",1"
            UpStr &= ",[Hazmat]=1"
        Else
            UpStr &= ",[Hazmat]=0"
        End If

        If Me.cbxTruck.SelectedIndex > 0 Then
            Dim row() As DataRow = Me.myDs.Tables("Trucks").Select("[Truck Number]='" & Me.cbxTruck.Text & "'")
            Dim TrId As String = row(0).Item("Truck ID").ToString
            Fields &= ",[Truck ID]"
            Values &= "," & TrId
            UpStr &= ",[Truck ID]=" & TrId
        Else
            UpStr &= ",[Truck ID]=NULL"
        End If

        If Me.chkInactive.Checked Then
            Fields &= ",[Inactive]"
            Values &= ",1"
            UpStr &= ",[Inactive]=1"
        Else
            UpStr &= ",[Inactive]=0"
        End If

        If Me._mode = FormMode.CreateNew Then
            CmdStr = "INSERT INTO [Drivers] ([Driver Name]" & Fields & ") VALUES ('" & GS.FilterSingleQuote(Me.txtName.Text) & _
                "'" & Values & ")"
            CmdStr2 = "IF EXISTS (SELECT [Driver Name] FROM [Drivers] WHERE [Drivers].[Driver Name]='" & GS.FilterSingleQuote(Me.txtName.Text) & _
                "') SELECT '1' ELSE SELECT '0'"
        Else
            CmdStr = "UPDATE [Drivers] SET [Driver Name]='" & GS.FilterSingleQuote(Me.txtName.Text) & "'" & UpStr & _
                " WHERE [Driver ID]=" & Me._driverID.ToString

            CmdStr2 = "IF EXISTS (SELECT [Driver Name] FROM [Drivers] WHERE [Drivers].[Driver ID]=" & Me._driverID.ToString & _
                ") SELECT '1' ELSE SELECT '0'"
        End If

        Try

            myConn.Open()

            myCmd.Connection = myConn
            myCmd.CommandText = CmdStr2

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

    Private Function ValidateFields() As Boolean

        Dim flag As Boolean = True
        Dim ErrMsg As String = String.Empty

        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox1)
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox2)

        If Me.txtName.Text.Length = 0 Then
            Me.txtName.Focus()
            ErrMsg = "Please enter a Driver Name."
            flag = False
        ElseIf UCase(Me.txtName.Text) = "COMPANY" Then
            Me.txtName.Focus()
            ErrMsg = "Please choose a different Driver Name."
            flag = False
        ElseIf (Me.txtSSN1.Text.Length > 0 Or Me.txtSSN2.Text.Length > 0 Or Me.txtSSN3.Text.Length > 0) And _
            Not (Regex.IsMatch(Me.txtSSN1.Text, "^(\d{3})$") And Regex.IsMatch(Me.txtSSN2.Text, "^(\d{2})$") And Regex.IsMatch(Me.txtSSN3.Text, "^(\d{4})$")) Then
            Me.txtSSN1.Focus()
            ErrMsg = "Please enter a valid Social Security Number."
            flag = False
        ElseIf Not Regex.IsMatch(Me.txtSealink.Text, "^(\d*)$") Then
            Me.txtSealink.Focus()
            ErrMsg = "Please enter a valid SeaLink Number."
            flag = False
        End If

        If Not flag Then
            MessageBox.Show(ErrMsg, "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

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

    Friend Property DriverID() As Integer
        Get
            Return Me._driverID
        End Get
        Set(ByVal value As Integer)
            Me._driverID = value
        End Set
    End Property

#End Region ' Methods & Properties

End Class