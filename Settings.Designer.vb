<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("New")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Edit")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Delete")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Users", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Auto-Backup")
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlUsersNew = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnUsersNewSave = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkAccessSenInfo = New System.Windows.Forms.CheckBox
        Me.chkCreateUsers = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtConfPwd = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlUsersEdit = New System.Windows.Forms.Panel
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkUsersEditChPwd = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtUsersEditConfPwd = New System.Windows.Forms.TextBox
        Me.txtUsersEditPassword = New System.Windows.Forms.TextBox
        Me.btnUsersEditSave = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkUsersEditAsd = New System.Windows.Forms.CheckBox
        Me.chkUsersEditCrUs = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cbxUsersEditUser = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.pnlUsersDelete = New System.Windows.Forms.Panel
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btnUsersDelete = New System.Windows.Forms.Button
        Me.cbxUsersDeleteUser = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.pnlAutoBackup = New System.Windows.Forms.Panel
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.cbxAutoBkpAmPm = New System.Windows.Forms.ComboBox
        Me.cbxAutoBkpM = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbxAutoBkpH = New System.Windows.Forms.ComboBox
        Me.radAutoBkpAtTime = New System.Windows.Forms.RadioButton
        Me.RadAutoBkpOnAppClose = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtAutoBkpFilePath = New System.Windows.Forms.TextBox
        Me.chkActAutoBkp = New System.Windows.Forms.CheckBox
        Me.pnlUsersNew.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlUsersEdit.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.pnlUsersDelete.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.pnlAutoBackup.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.HideSelection = False
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "nodeUsersNew"
        TreeNode1.Text = "New"
        TreeNode2.Name = "nodeUsersEdit"
        TreeNode2.Text = "Edit"
        TreeNode3.Name = "nodeUsersDelete"
        TreeNode3.Text = "Delete"
        TreeNode4.Checked = True
        TreeNode4.Name = "nodeUsers"
        TreeNode4.Text = "Users"
        TreeNode5.Name = "nodeAutoBackup"
        TreeNode5.Text = "Auto-Backup"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5})
        Me.TreeView1.Size = New System.Drawing.Size(148, 312)
        Me.TreeView1.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(376, 331)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'pnlUsersNew
        '
        Me.pnlUsersNew.Controls.Add(Me.Label7)
        Me.pnlUsersNew.Controls.Add(Me.btnUsersNewSave)
        Me.pnlUsersNew.Controls.Add(Me.GroupBox2)
        Me.pnlUsersNew.Controls.Add(Me.GroupBox1)
        Me.pnlUsersNew.Location = New System.Drawing.Point(166, 12)
        Me.pnlUsersNew.Name = "pnlUsersNew"
        Me.pnlUsersNew.Size = New System.Drawing.Size(285, 312)
        Me.pnlUsersNew.TabIndex = 1
        Me.pnlUsersNew.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Location = New System.Drawing.Point(14, 257)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(255, 41)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "The User Name and Password must be between 6 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and 20 characters and contain numb" & _
            "ers, letters and " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "underscore only."
        '
        'btnUsersNewSave
        '
        Me.btnUsersNewSave.Location = New System.Drawing.Point(175, 220)
        Me.btnUsersNewSave.Name = "btnUsersNewSave"
        Me.btnUsersNewSave.Size = New System.Drawing.Size(107, 23)
        Me.btnUsersNewSave.TabIndex = 2
        Me.btnUsersNewSave.Text = "Create New User"
        Me.btnUsersNewSave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkAccessSenInfo)
        Me.GroupBox2.Controls.Add(Me.chkCreateUsers)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 147)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 67)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Credentials"
        '
        'chkAccessSenInfo
        '
        Me.chkAccessSenInfo.AutoSize = True
        Me.chkAccessSenInfo.Location = New System.Drawing.Point(9, 42)
        Me.chkAccessSenInfo.Name = "chkAccessSenInfo"
        Me.chkAccessSenInfo.Size = New System.Drawing.Size(133, 17)
        Me.chkAccessSenInfo.TabIndex = 1
        Me.chkAccessSenInfo.Text = "Access Sensitive Data"
        Me.chkAccessSenInfo.UseVisualStyleBackColor = True
        '
        'chkCreateUsers
        '
        Me.chkCreateUsers.AutoSize = True
        Me.chkCreateUsers.Location = New System.Drawing.Point(9, 19)
        Me.chkCreateUsers.Name = "chkCreateUsers"
        Me.chkCreateUsers.Size = New System.Drawing.Size(123, 17)
        Me.chkCreateUsers.TabIndex = 0
        Me.chkCreateUsers.Text = "Create/Modify Users"
        Me.chkCreateUsers.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtConfPwd)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 138)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New User"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Confirm Password:"
        '
        'txtConfPwd
        '
        Me.txtConfPwd.Location = New System.Drawing.Point(9, 110)
        Me.txtConfPwd.MaxLength = 20
        Me.txtConfPwd.Name = "txtConfPwd"
        Me.txtConfPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfPwd.Size = New System.Drawing.Size(264, 20)
        Me.txtConfPwd.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(9, 71)
        Me.txtPassword.MaxLength = 20
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(264, 20)
        Me.txtPassword.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password:"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(9, 32)
        Me.txtUserName.MaxLength = 20
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(264, 20)
        Me.txtUserName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name:"
        '
        'pnlUsersEdit
        '
        Me.pnlUsersEdit.Controls.Add(Me.GroupBox5)
        Me.pnlUsersEdit.Controls.Add(Me.btnUsersEditSave)
        Me.pnlUsersEdit.Controls.Add(Me.GroupBox3)
        Me.pnlUsersEdit.Controls.Add(Me.GroupBox4)
        Me.pnlUsersEdit.Location = New System.Drawing.Point(472, 89)
        Me.pnlUsersEdit.Name = "pnlUsersEdit"
        Me.pnlUsersEdit.Size = New System.Drawing.Size(72, 90)
        Me.pnlUsersEdit.TabIndex = 1
        Me.pnlUsersEdit.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.chkUsersEditChPwd)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.txtUsersEditConfPwd)
        Me.GroupBox5.Controls.Add(Me.txtUsersEditPassword)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 69)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(279, 121)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(6, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Confirm Password:"
        '
        'chkUsersEditChPwd
        '
        Me.chkUsersEditChPwd.AutoSize = True
        Me.chkUsersEditChPwd.Location = New System.Drawing.Point(6, 19)
        Me.chkUsersEditChPwd.Name = "chkUsersEditChPwd"
        Me.chkUsersEditChPwd.Size = New System.Drawing.Size(112, 17)
        Me.chkUsersEditChPwd.TabIndex = 0
        Me.chkUsersEditChPwd.Text = "Change Password"
        Me.chkUsersEditChPwd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(6, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Password:"
        '
        'txtUsersEditConfPwd
        '
        Me.txtUsersEditConfPwd.Enabled = False
        Me.txtUsersEditConfPwd.Location = New System.Drawing.Point(9, 94)
        Me.txtUsersEditConfPwd.MaxLength = 20
        Me.txtUsersEditConfPwd.Name = "txtUsersEditConfPwd"
        Me.txtUsersEditConfPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUsersEditConfPwd.Size = New System.Drawing.Size(264, 20)
        Me.txtUsersEditConfPwd.TabIndex = 2
        '
        'txtUsersEditPassword
        '
        Me.txtUsersEditPassword.Enabled = False
        Me.txtUsersEditPassword.Location = New System.Drawing.Point(9, 55)
        Me.txtUsersEditPassword.MaxLength = 20
        Me.txtUsersEditPassword.Name = "txtUsersEditPassword"
        Me.txtUsersEditPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUsersEditPassword.Size = New System.Drawing.Size(264, 20)
        Me.txtUsersEditPassword.TabIndex = 1
        '
        'btnUsersEditSave
        '
        Me.btnUsersEditSave.Location = New System.Drawing.Point(207, 269)
        Me.btnUsersEditSave.Name = "btnUsersEditSave"
        Me.btnUsersEditSave.Size = New System.Drawing.Size(75, 23)
        Me.btnUsersEditSave.TabIndex = 3
        Me.btnUsersEditSave.Text = "Save"
        Me.btnUsersEditSave.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkUsersEditAsd)
        Me.GroupBox3.Controls.Add(Me.chkUsersEditCrUs)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 196)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 67)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Credentials"
        '
        'chkUsersEditAsd
        '
        Me.chkUsersEditAsd.AutoSize = True
        Me.chkUsersEditAsd.Location = New System.Drawing.Point(9, 42)
        Me.chkUsersEditAsd.Name = "chkUsersEditAsd"
        Me.chkUsersEditAsd.Size = New System.Drawing.Size(133, 17)
        Me.chkUsersEditAsd.TabIndex = 1
        Me.chkUsersEditAsd.Text = "Access Sensitive Data"
        Me.chkUsersEditAsd.UseVisualStyleBackColor = True
        '
        'chkUsersEditCrUs
        '
        Me.chkUsersEditCrUs.AutoSize = True
        Me.chkUsersEditCrUs.Location = New System.Drawing.Point(9, 19)
        Me.chkUsersEditCrUs.Name = "chkUsersEditCrUs"
        Me.chkUsersEditCrUs.Size = New System.Drawing.Size(87, 17)
        Me.chkUsersEditCrUs.TabIndex = 0
        Me.chkUsersEditCrUs.Text = "Create Users"
        Me.chkUsersEditCrUs.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbxUsersEditUser)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(279, 60)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Edit User"
        '
        'cbxUsersEditUser
        '
        Me.cbxUsersEditUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxUsersEditUser.FormattingEnabled = True
        Me.cbxUsersEditUser.Location = New System.Drawing.Point(9, 31)
        Me.cbxUsersEditUser.Name = "cbxUsersEditUser"
        Me.cbxUsersEditUser.Size = New System.Drawing.Size(264, 21)
        Me.cbxUsersEditUser.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "User Name:"
        '
        'pnlUsersDelete
        '
        Me.pnlUsersDelete.Controls.Add(Me.GroupBox8)
        Me.pnlUsersDelete.Location = New System.Drawing.Point(472, 27)
        Me.pnlUsersDelete.Name = "pnlUsersDelete"
        Me.pnlUsersDelete.Size = New System.Drawing.Size(63, 56)
        Me.pnlUsersDelete.TabIndex = 1
        Me.pnlUsersDelete.Visible = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btnUsersDelete)
        Me.GroupBox8.Controls.Add(Me.cbxUsersDeleteUser)
        Me.GroupBox8.Controls.Add(Me.Label9)
        Me.GroupBox8.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(279, 87)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Delete User"
        '
        'btnUsersDelete
        '
        Me.btnUsersDelete.Location = New System.Drawing.Point(198, 58)
        Me.btnUsersDelete.Name = "btnUsersDelete"
        Me.btnUsersDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnUsersDelete.TabIndex = 1
        Me.btnUsersDelete.Text = "Delete"
        Me.btnUsersDelete.UseVisualStyleBackColor = True
        '
        'cbxUsersDeleteUser
        '
        Me.cbxUsersDeleteUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxUsersDeleteUser.FormattingEnabled = True
        Me.cbxUsersDeleteUser.Location = New System.Drawing.Point(9, 31)
        Me.cbxUsersDeleteUser.Name = "cbxUsersDeleteUser"
        Me.cbxUsersDeleteUser.Size = New System.Drawing.Size(264, 21)
        Me.cbxUsersDeleteUser.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "User Name:"
        '
        'pnlAutoBackup
        '
        Me.pnlAutoBackup.Controls.Add(Me.GroupBox6)
        Me.pnlAutoBackup.Location = New System.Drawing.Point(456, 327)
        Me.pnlAutoBackup.Name = "pnlAutoBackup"
        Me.pnlAutoBackup.Size = New System.Drawing.Size(285, 312)
        Me.pnlAutoBackup.TabIndex = 3
        Me.pnlAutoBackup.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cbxAutoBkpAmPm)
        Me.GroupBox6.Controls.Add(Me.cbxAutoBkpM)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.cbxAutoBkpH)
        Me.GroupBox6.Controls.Add(Me.radAutoBkpAtTime)
        Me.GroupBox6.Controls.Add(Me.RadAutoBkpOnAppClose)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.txtAutoBkpFilePath)
        Me.GroupBox6.Controls.Add(Me.chkActAutoBkp)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(279, 185)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Auto-Backup"
        '
        'cbxAutoBkpAmPm
        '
        Me.cbxAutoBkpAmPm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAutoBkpAmPm.FormattingEnabled = True
        Me.cbxAutoBkpAmPm.Items.AddRange(New Object() {"AM", "PM"})
        Me.cbxAutoBkpAmPm.Location = New System.Drawing.Point(159, 141)
        Me.cbxAutoBkpAmPm.Name = "cbxAutoBkpAmPm"
        Me.cbxAutoBkpAmPm.Size = New System.Drawing.Size(47, 21)
        Me.cbxAutoBkpAmPm.TabIndex = 12
        '
        'cbxAutoBkpM
        '
        Me.cbxAutoBkpM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAutoBkpM.FormattingEnabled = True
        Me.cbxAutoBkpM.Items.AddRange(New Object() {"00", "15", "30", "45"})
        Me.cbxAutoBkpM.Location = New System.Drawing.Point(106, 141)
        Me.cbxAutoBkpM.Name = "cbxAutoBkpM"
        Me.cbxAutoBkpM.Size = New System.Drawing.Size(47, 21)
        Me.cbxAutoBkpM.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(94, 146)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = ":"
        '
        'cbxAutoBkpH
        '
        Me.cbxAutoBkpH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAutoBkpH.FormattingEnabled = True
        Me.cbxAutoBkpH.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbxAutoBkpH.Location = New System.Drawing.Point(44, 141)
        Me.cbxAutoBkpH.Name = "cbxAutoBkpH"
        Me.cbxAutoBkpH.Size = New System.Drawing.Size(47, 21)
        Me.cbxAutoBkpH.TabIndex = 9
        '
        'radAutoBkpAtTime
        '
        Me.radAutoBkpAtTime.AutoSize = True
        Me.radAutoBkpAtTime.Location = New System.Drawing.Point(24, 118)
        Me.radAutoBkpAtTime.Name = "radAutoBkpAtTime"
        Me.radAutoBkpAtTime.Size = New System.Drawing.Size(176, 17)
        Me.radAutoBkpAtTime.TabIndex = 8
        Me.radAutoBkpAtTime.TabStop = True
        Me.radAutoBkpAtTime.Text = "Start Auto-Backup every day at:"
        Me.radAutoBkpAtTime.UseVisualStyleBackColor = True
        '
        'RadAutoBkpOnAppClose
        '
        Me.RadAutoBkpOnAppClose.AutoSize = True
        Me.RadAutoBkpOnAppClose.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadAutoBkpOnAppClose.Checked = True
        Me.RadAutoBkpOnAppClose.Location = New System.Drawing.Point(24, 82)
        Me.RadAutoBkpOnAppClose.Name = "RadAutoBkpOnAppClose"
        Me.RadAutoBkpOnAppClose.Size = New System.Drawing.Size(245, 30)
        Me.RadAutoBkpOnAppClose.TabIndex = 7
        Me.RadAutoBkpOnAppClose.TabStop = True
        Me.RadAutoBkpOnAppClose.Text = "Start Auto-Backup every time the application is" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "closed."
        Me.RadAutoBkpOnAppClose.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Backup File Path:"
        '
        'txtAutoBkpFilePath
        '
        Me.txtAutoBkpFilePath.Location = New System.Drawing.Point(24, 56)
        Me.txtAutoBkpFilePath.MaxLength = 20
        Me.txtAutoBkpFilePath.Name = "txtAutoBkpFilePath"
        Me.txtAutoBkpFilePath.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtAutoBkpFilePath.Size = New System.Drawing.Size(249, 20)
        Me.txtAutoBkpFilePath.TabIndex = 5
        '
        'chkActAutoBkp
        '
        Me.chkActAutoBkp.AutoSize = True
        Me.chkActAutoBkp.Location = New System.Drawing.Point(6, 20)
        Me.chkActAutoBkp.Name = "chkActAutoBkp"
        Me.chkActAutoBkp.Size = New System.Drawing.Size(130, 17)
        Me.chkActAutoBkp.TabIndex = 0
        Me.chkActAutoBkp.Text = "Activate Auto-Backup"
        Me.chkActAutoBkp.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 655)
        Me.Controls.Add(Me.pnlAutoBackup)
        Me.Controls.Add(Me.pnlUsersDelete)
        Me.Controls.Add(Me.pnlUsersEdit)
        Me.Controls.Add(Me.pnlUsersNew)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TreeView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Settings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.pnlUsersNew.ResumeLayout(False)
        Me.pnlUsersNew.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlUsersEdit.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.pnlUsersDelete.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.pnlAutoBackup.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlUsersNew As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAccessSenInfo As System.Windows.Forms.CheckBox
    Friend WithEvents chkCreateUsers As System.Windows.Forms.CheckBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUsersNewSave As System.Windows.Forms.Button
    Friend WithEvents pnlUsersEdit As System.Windows.Forms.Panel
    Friend WithEvents btnUsersEditSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkUsersEditAsd As System.Windows.Forms.CheckBox
    Friend WithEvents chkUsersEditCrUs As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxUsersEditUser As System.Windows.Forms.ComboBox
    Friend WithEvents txtUsersEditPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtConfPwd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUsersEditConfPwd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkUsersEditChPwd As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlUsersDelete As System.Windows.Forms.Panel
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUsersDelete As System.Windows.Forms.Button
    Friend WithEvents cbxUsersDeleteUser As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlAutoBackup As System.Windows.Forms.Panel
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkActAutoBkp As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAutoBkpFilePath As System.Windows.Forms.TextBox
    Friend WithEvents RadAutoBkpOnAppClose As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbxAutoBkpH As System.Windows.Forms.ComboBox
    Friend WithEvents radAutoBkpAtTime As System.Windows.Forms.RadioButton
    Friend WithEvents cbxAutoBkpAmPm As System.Windows.Forms.ComboBox
    Friend WithEvents cbxAutoBkpM As System.Windows.Forms.ComboBox
End Class
