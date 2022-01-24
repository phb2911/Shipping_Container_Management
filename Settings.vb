
Imports System.Text.RegularExpressions

Public Class Settings

    Dim myUser As User = My.Forms.Form1.myUser
    Dim _crUsr As Boolean
    Dim _AccessSenData As Boolean
    Dim _asdCol As New Collection
    Dim _crUsCol As New Collection
    Dim _errFlag As Boolean = False
    Dim _logOutFlag As Boolean = False

#Region "Control Events"

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Size = New Size(469, 391)
        Me.pnlUsersEdit.Location = Me.pnlUsersNew.Location
        Me.pnlUsersEdit.Size = Me.pnlUsersNew.Size
        Me.pnlUsersDelete.Location = Me.pnlUsersNew.Location
        Me.pnlUsersDelete.Size = Me.pnlUsersNew.Size
        Me.pnlAutoBackup.Location = Me.pnlUsersNew.Location
        Me.pnlAutoBackup.Size = Me.pnlUsersNew.Size

        Me.TreeView1.Nodes("nodeUsers").Expand()

        Me._errFlag = Not Me.PopulateFields(Nothing)

        Me.SetAutoBackup()

    End Sub

    Private Sub SetAutoBackup()

        If CBool(GetSetting("Oceanne", "AutoBackup", "Active", "0")) Then

            Me.cbxAutoBkpH.Text = GetSetting("Oceanne", "AutoBackup", "Hr")
            Me.cbxAutoBkpM.Text = GetSetting("Oceanne", "AutoBackup", "Min")
            Me.cbxAutoBkpAmPm.Text = GetSetting("Oceanne", "AutoBackup", "AmPm")
        Else
            Me.cbxAutoBkpH.Text = "12"
            Me.cbxAutoBkpM.Text = "00"
            Me.cbxAutoBkpAmPm.Text = "AM"
        End If

    End Sub

    Private Sub Settings_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Me._logOutFlag Then My.Forms.Form1.LogOut(False)
    End Sub

    Private Sub Settings_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me._errFlag Then Me.Close()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

        Select Case e.Node.Name
            Case "nodeUsers", "nodeUsersNew"
                Me.HidePanels("pnlUsersNew")
            Case "nodeUsersEdit"
                Me.HidePanels("pnlUsersEdit")
            Case "nodeUsersDelete"
                Me.HidePanels("pnlUsersDelete")
            Case "nodeAutoBackup"
                'Me.HidePanels("pnlAutoBackup")
                ' hide all temporarely
                Me.HidePanels("")
        End Select

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkUsersEditChPwd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUsersEditChPwd.CheckedChanged
        Dim flag As Boolean = Me.chkUsersEditChPwd.Checked
        Me.Label5.Enabled = flag
        Me.Label6.Enabled = flag
        Me.txtUsersEditPassword.Enabled = flag
        Me.txtUsersEditConfPwd.Enabled = flag
    End Sub

    Private Sub btnUsersNewSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsersNewSave.Click

        If Me.ValidateNewUserFields() Then
            Dim level As Integer = 0
            Dim UN As String = Me.txtUserName.Text
            Dim Pwd As String = Me.txtPassword.Text

            If Me.chkCreateUsers.Checked Then level += 1
            If Me.chkAccessSenInfo.Checked Then level += 2

            If User.CreateNewUser(UN, Pwd, level) Then
                Me.cbxUsersEditUser.Items.Add(UN)
                Me.cbxUsersDeleteUser.Items.Add(UN)
                Me._crUsCol.Add(Me.chkCreateUsers.Checked, UN)
                Me._asdCol.Add(Me.chkAccessSenInfo.Checked, UN)
                Me.txtUserName.Text = ""
                Me.txtPassword.Text = ""
                Me.txtConfPwd.Text = ""
                Me.chkCreateUsers.Checked = False
                Me.chkAccessSenInfo.Checked = False
                MessageBox.Show("New User created successfully.", "New User", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub

    Private Sub cbxUsersEditUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxUsersEditUser.SelectedIndexChanged
        If Me.cbxUsersEditUser.SelectedIndex = 0 Then
            Me.chkUsersEditAsd.Checked = False
            Me.chkUsersEditCrUs.Checked = False
        Else
            Me.chkUsersEditAsd.Checked = CBool(Me._asdCol(Me.cbxUsersEditUser.Text))
            Me.chkUsersEditCrUs.Checked = CBool(Me._crUsCol(Me.cbxUsersEditUser.Text))
        End If
    End Sub

    Private Sub btnUsersDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsersDelete.Click
        If Me.cbxUsersDeleteUser.SelectedIndex < 1 Then
            MessageBox.Show("Please select an user.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else

            Dim UsName As String = Me.cbxUsersDeleteUser.Text
            Dim Prompt As String = ""
            Dim LogOutFlag As Boolean = False

            If Me.myUser.Name = UsName Then
                Prompt = "The user you are trying to delete is the same one you used to log in." & vbCrLf & _
                "Any modification to this user will cause the application to automatically log out." & vbCrLf & _
                "Would you like to continue?"
                LogOutFlag = True
            Else
                Prompt = "The user '" & UsName & "' will be permanently deleted." & vbCrLf & "Are you sure?"
            End If

            If MessageBox.Show(Prompt, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = _
                Windows.Forms.DialogResult.Yes Then

                Me.Cursor = Cursors.WaitCursor

                If User.DeleteUser(UsName) Then

                    Me.cbxUsersDeleteUser.Items.RemoveAt(Me.cbxUsersDeleteUser.SelectedIndex)
                    Me.cbxUsersEditUser.Items.Remove(UsName)
                    Me._crUsCol.Remove(UsName)
                    Me._asdCol.Remove(UsName)

                    If LogOutFlag Then
                        Me._logOutFlag = True
                        Me.Close()
                    End If

                    Me.Cursor = Cursors.Default

                Else

                    Me.Cursor = Cursors.Default

                    MessageBox.Show("Unable to delete user. Check if the user still exists in database.", _
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If

        End If

    End Sub

    Private Sub btnUsersEditSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsersEditSave.Click

        If Me.ValidateEditUserFields() Then
            Dim level As Integer = 0
            Dim UN As String = Me.cbxUsersEditUser.Text
            Dim Pwd As String = Me.txtUsersEditPassword.Text
            Dim ChangePwdFlag As Boolean = True

            If Me.chkUsersEditCrUs.Checked Then level += 1
            If Me.chkUsersEditAsd.Checked Then level += 2

            Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)

            Try
                myConn.Open()

                ' update pwd only if checkbox is checked
                If Me.chkUsersEditChPwd.Checked Then _
                    ChangePwdFlag = User.ChangePassword(UN, Pwd, myConn)

                If ChangePwdFlag AndAlso User.ChangeCredentials(UN, level, myConn) Then

                    Me.txtUsersEditPassword.Text = ""
                    Me.txtUsersEditConfPwd.Text = ""
                    Me.chkUsersEditChPwd.Checked = False

                    Me._crUsCol.Remove(UN)
                    Me._crUsCol.Add(Me.chkUsersEditCrUs.Checked, UN)
                    Me._asdCol.Remove(UN)
                    Me._asdCol.Add(Me.chkUsersEditAsd.Checked, UN)

                    If myUser.Name = UN Then

                        Me._crUsr = Me.chkUsersEditCrUs.Checked
                        Me._AccessSenData = Me.chkUsersEditAsd.Checked
                        Me.SetPermission()

                        If Not Me._crUsr Then
                            Me.cbxUsersEditUser.Items.Clear()
                            Me.cbxUsersEditUser.Items.Add("")
                            Me.cbxUsersEditUser.Items.Add(UN)
                            Me.cbxUsersEditUser.Text = UN
                        End If

                    End If

                    MessageBox.Show("The user's information were updated successfully.", "Success", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)

                Else
                    MessageBox.Show("The user's information could not be updated." & vbCrLf & "Check if the user still exists in database.", _
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                 "Details: " & ex.Message & vbCrLf & vbCrLf & "Please check your connection and try again.", "Error", _
                 MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If myConn IsNot Nothing Then
                    If myConn.State = ConnectionState.Open Then myConn.Close()
                    myConn.Dispose()
                End If
            End Try

        End If

    End Sub

#End Region 'Control Events

#Region "Methoes & Properties"

    Private Function ValidateEditUserFields() As Boolean

        Dim pattern As String = "^(\w+)$"
        Dim ErrMsg As String = String.Empty
        Dim flag As Boolean = True

        If Me.cbxUsersEditUser.SelectedIndex < 1 Then
            ErrMsg = "Please select an user."
            Me.cbxUsersEditUser.Focus()
            flag = False
        ElseIf Me.chkUsersEditChPwd.Checked And Not Regex.IsMatch(Me.txtUsersEditPassword.Text, pattern) Then
            ErrMsg = "Invalid Password Format."
            Me.txtUsersEditPassword.Focus()
            flag = False
        ElseIf Me.chkUsersEditChPwd.Checked And (Me.txtUsersEditPassword.Text.Length < 6 Or Me.txtUsersEditPassword.Text.Length > 20) Then
            ErrMsg = "The Password must be between 6 and 20 characters long."
            Me.txtUsersEditPassword.Focus()
            flag = False
        ElseIf Me.chkUsersEditChPwd.Checked And (Me.txtUsersEditPassword.Text <> Me.txtUsersEditConfPwd.Text) Then
            ErrMsg = "The two passwords must be identical."
            Me.txtUsersEditPassword.Focus()
            flag = False
        End If

        If Not flag Then _
            MessageBox.Show(ErrMsg, "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Return flag

    End Function

    Private Function ValidateNewUserFields() As Boolean

        Dim pattern As String = "^(\w+)$"
        Dim ErrMsg As String = String.Empty
        Dim flag As Boolean = True

        If Not (Regex.IsMatch(Me.txtUserName.Text, pattern)) Then
            ErrMsg = "Invalid User Name Format."
            Me.txtUserName.Focus()
            flag = False
        ElseIf Me.txtUserName.Text.Length < 6 Or Me.txtUserName.Text.Length > 20 Then
            ErrMsg = "The User Name must be between 6 and 20 characters long."
            Me.txtUserName.Focus()
            flag = False
        ElseIf Not (Regex.IsMatch(Me.txtPassword.Text, pattern)) Then
            ErrMsg = "Invalid Password Format."
            Me.txtPassword.Focus()
            flag = False
        ElseIf Me.txtPassword.Text.Length < 6 Or Me.txtPassword.Text.Length > 20 Then
            ErrMsg = "The Password must be between 6 and 20 characters long."
            Me.txtPassword.Focus()
            flag = False
        ElseIf Me.txtPassword.Text <> Me.txtConfPwd.Text Then
            ErrMsg = "The two passwords must be identical."
            Me.txtPassword.Focus()
            flag = False
        End If

        If Not flag Then _
            MessageBox.Show(ErrMsg, "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Return flag

    End Function

    Private Sub HidePanels(ByVal Exception As String)

        For Each ctl As Control In Me.Controls
            If ctl.GetType.Name = "Panel" Then
                If ctl.Name = Exception Then
                    ctl.Visible = True
                Else
                    ctl.Visible = False
                End If
            End If

        Next

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim Y As Integer = 327

        Dim myPen As New System.Drawing.Pen(Color.Gray)
        Dim myPen2 As New System.Drawing.Pen(Color.White)
        Dim formGraphics As System.Drawing.Graphics = Me.CreateGraphics()
        Dim W As Integer = Me.Width

        formGraphics.DrawLine(myPen, 0, Y, W, Y)
        formGraphics.DrawLine(myPen2, 0, Y + 1, W, Y + 1)

        myPen.Dispose()
        myPen2.Dispose()
        formGraphics.Dispose()

    End Sub

    Private Sub SetPermission()
        Me.pnlUsersNew.Enabled = Me._crUsr
        Me.pnlUsersDelete.Enabled = Me._crUsr
        Me.chkUsersEditAsd.Enabled = Me._AccessSenData
        Me.chkAccessSenInfo.Enabled = Me._AccessSenData
        Me.GroupBox3.Enabled = Me._crUsr
    End Sub

    Private Function PopulateFields(ByRef Connection As SqlClient.SqlConnection) As Boolean

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim OutConnFlag As Boolean = (Connection IsNot Nothing AndAlso Connection.State = ConnectionState.Open)
        Dim ErrFlag As Boolean = False

        Try
            If OutConnFlag Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
                myConn.Open()
            End If

            Me._crUsr = myUser.CreateUsers(myConn)
            Me._AccessSenData = myUser.AccessSensitiveInfo(myConn)

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [User Name],[CreateUsers],[AccessSensitiveInfo] FROM [Users] " & _
                "WHERE [User Name]<>'sa'"

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "Users")

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                 "Details: " & ex.Message & "Please check your connection and try again.", "Error", _
                 MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not OutConnFlag And myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If myCmd IsNot Nothing Then myCmd.Dispose()
            If myDa IsNot Nothing Then myDa.Dispose()
        End Try

        If ErrFlag Then
            If myDs IsNot Nothing Then myDs.Dispose()
            Return False
        End If

        Me.cbxUsersEditUser.Items.Add("")
        Me.cbxUsersDeleteUser.Items.Add("")

        Me._asdCol.Clear()
        Me._crUsCol.Clear()

        For Each Row As DataRow In myDs.Tables("Users").Rows

            Dim UsrName As String = Row("User Name").ToString

            If Me._crUsr Or (Not Me._crUsr And Me.myUser.Name.ToUpper = UsrName.ToUpper) Then
                Me.cbxUsersEditUser.Items.Add(UsrName)
                Me.cbxUsersDeleteUser.Items.Add(UsrName)
                Me._asdCol.Add(Row("AccessSensitiveInfo"), UsrName)
                Me._crUsCol.Add(Row("CreateUsers"), UsrName)
            End If

        Next

        Me.SetPermission()

        Return True

    End Function

#End Region 'Methoes & Properties

End Class