<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewTruck
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbxYear = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtColor = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtVin = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPlate = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumber = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMake = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtEzpass = New System.Windows.Forms.TextBox
        Me.chkIfta = New System.Windows.Forms.CheckBox
        Me.chkEmission = New System.Windows.Forms.CheckBox
        Me.chkDOT = New System.Windows.Forms.CheckBox
        Me.chkReg = New System.Windows.Forms.CheckBox
        Me.dtpIfta = New System.Windows.Forms.DateTimePicker
        Me.dtpEmission = New System.Windows.Forms.DateTimePicker
        Me.dtpDot = New System.Windows.Forms.DateTimePicker
        Me.dtpReg = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.cbxOwner = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRegistration = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.chkInactive = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbxYear)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtColor)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtVin)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPlate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNumber)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMake)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 209)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Truck"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Year:"
        '
        'cbxYear
        '
        Me.cbxYear.FormattingEnabled = True
        Me.cbxYear.Location = New System.Drawing.Point(78, 149)
        Me.cbxYear.MaxLength = 4
        Me.cbxYear.Name = "cbxYear"
        Me.cbxYear.Size = New System.Drawing.Size(83, 21)
        Me.cbxYear.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Color:"
        '
        'txtColor
        '
        Me.txtColor.Location = New System.Drawing.Point(78, 123)
        Me.txtColor.MaxLength = 20
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(83, 20)
        Me.txtColor.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "VIN:"
        '
        'txtVin
        '
        Me.txtVin.Location = New System.Drawing.Point(78, 71)
        Me.txtVin.MaxLength = 50
        Me.txtVin.Name = "txtVin"
        Me.txtVin.Size = New System.Drawing.Size(182, 20)
        Me.txtVin.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Plate:"
        '
        'txtPlate
        '
        Me.txtPlate.Location = New System.Drawing.Point(78, 97)
        Me.txtPlate.MaxLength = 10
        Me.txtPlate.Name = "txtPlate"
        Me.txtPlate.Size = New System.Drawing.Size(83, 20)
        Me.txtPlate.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Number:"
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(78, 19)
        Me.txtNumber.MaxLength = 10
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(83, 20)
        Me.txtNumber.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Make:"
        '
        'txtMake
        '
        Me.txtMake.Location = New System.Drawing.Point(78, 45)
        Me.txtMake.MaxLength = 50
        Me.txtMake.Name = "txtMake"
        Me.txtMake.Size = New System.Drawing.Size(182, 20)
        Me.txtMake.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtEzpass)
        Me.GroupBox2.Controls.Add(Me.chkIfta)
        Me.GroupBox2.Controls.Add(Me.chkEmission)
        Me.GroupBox2.Controls.Add(Me.chkDOT)
        Me.GroupBox2.Controls.Add(Me.chkReg)
        Me.GroupBox2.Controls.Add(Me.dtpIfta)
        Me.GroupBox2.Controls.Add(Me.dtpEmission)
        Me.GroupBox2.Controls.Add(Me.dtpDot)
        Me.GroupBox2.Controls.Add(Me.dtpReg)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.cbxOwner)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtRegistration)
        Me.GroupBox2.Location = New System.Drawing.Point(286, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(268, 209)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentation"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "EZ Pass:"
        '
        'txtEzpass
        '
        Me.txtEzpass.Location = New System.Drawing.Point(80, 19)
        Me.txtEzpass.MaxLength = 50
        Me.txtEzpass.Name = "txtEzpass"
        Me.txtEzpass.Size = New System.Drawing.Size(182, 20)
        Me.txtEzpass.TabIndex = 0
        '
        'chkIfta
        '
        Me.chkIfta.AutoSize = True
        Me.chkIfta.Location = New System.Drawing.Point(36, 152)
        Me.chkIfta.Name = "chkIfta"
        Me.chkIfta.Size = New System.Drawing.Size(76, 17)
        Me.chkIfta.TabIndex = 8
        Me.chkIfta.Text = "IFTA Exp.:"
        Me.chkIfta.UseVisualStyleBackColor = True
        '
        'chkEmission
        '
        Me.chkEmission.AutoSize = True
        Me.chkEmission.Location = New System.Drawing.Point(36, 126)
        Me.chkEmission.Name = "chkEmission"
        Me.chkEmission.Size = New System.Drawing.Size(120, 17)
        Me.chkEmission.TabIndex = 6
        Me.chkEmission.Text = "Emission Insp. Exp.:"
        Me.chkEmission.UseVisualStyleBackColor = True
        '
        'chkDOT
        '
        Me.chkDOT.AutoSize = True
        Me.chkDOT.Location = New System.Drawing.Point(36, 100)
        Me.chkDOT.Name = "chkDOT"
        Me.chkDOT.Size = New System.Drawing.Size(102, 17)
        Me.chkDOT.TabIndex = 4
        Me.chkDOT.Text = "DOT Insp. Exp.:"
        Me.chkDOT.UseVisualStyleBackColor = True
        '
        'chkReg
        '
        Me.chkReg.AutoSize = True
        Me.chkReg.Location = New System.Drawing.Point(36, 74)
        Me.chkReg.Name = "chkReg"
        Me.chkReg.Size = New System.Drawing.Size(109, 17)
        Me.chkReg.TabIndex = 2
        Me.chkReg.Text = "Registration Exp.:"
        Me.chkReg.UseVisualStyleBackColor = True
        '
        'dtpIfta
        '
        Me.dtpIfta.Enabled = False
        Me.dtpIfta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIfta.Location = New System.Drawing.Point(162, 149)
        Me.dtpIfta.Name = "dtpIfta"
        Me.dtpIfta.Size = New System.Drawing.Size(100, 20)
        Me.dtpIfta.TabIndex = 9
        '
        'dtpEmission
        '
        Me.dtpEmission.Enabled = False
        Me.dtpEmission.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEmission.Location = New System.Drawing.Point(162, 123)
        Me.dtpEmission.Name = "dtpEmission"
        Me.dtpEmission.Size = New System.Drawing.Size(100, 20)
        Me.dtpEmission.TabIndex = 7
        '
        'dtpDot
        '
        Me.dtpDot.Enabled = False
        Me.dtpDot.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDot.Location = New System.Drawing.Point(162, 97)
        Me.dtpDot.Name = "dtpDot"
        Me.dtpDot.Size = New System.Drawing.Size(100, 20)
        Me.dtpDot.TabIndex = 5
        '
        'dtpReg
        '
        Me.dtpReg.Enabled = False
        Me.dtpReg.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReg.Location = New System.Drawing.Point(162, 71)
        Me.dtpReg.Name = "dtpReg"
        Me.dtpReg.Size = New System.Drawing.Size(100, 20)
        Me.dtpReg.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(33, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Owner:"
        '
        'cbxOwner
        '
        Me.cbxOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxOwner.FormattingEnabled = True
        Me.cbxOwner.Location = New System.Drawing.Point(80, 175)
        Me.cbxOwner.Name = "cbxOwner"
        Me.cbxOwner.Size = New System.Drawing.Size(182, 21)
        Me.cbxOwner.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Registration:"
        '
        'txtRegistration
        '
        Me.txtRegistration.Location = New System.Drawing.Point(80, 45)
        Me.txtRegistration.MaxLength = 50
        Me.txtRegistration.Name = "txtRegistration"
        Me.txtRegistration.Size = New System.Drawing.Size(182, 20)
        Me.txtRegistration.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(479, 227)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(398, 227)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'chkInactive
        '
        Me.chkInactive.AutoSize = True
        Me.chkInactive.Location = New System.Drawing.Point(12, 227)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.Size = New System.Drawing.Size(64, 17)
        Me.chkInactive.TabIndex = 2
        Me.chkInactive.Text = "Inactive"
        Me.chkInactive.UseVisualStyleBackColor = True
        '
        'NewTruck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(565, 256)
        Me.Controls.Add(Me.chkInactive)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewTruck"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Truck"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMake As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents cbxYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRegistration As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbxOwner As System.Windows.Forms.ComboBox
    Friend WithEvents dtpIfta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEmission As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDot As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReg As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkIfta As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmission As System.Windows.Forms.CheckBox
    Friend WithEvents chkDOT As System.Windows.Forms.CheckBox
    Friend WithEvents chkReg As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEzpass As System.Windows.Forms.TextBox
End Class
