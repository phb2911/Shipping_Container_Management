<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrMilListFilter
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
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.radRange = New System.Windows.Forms.RadioButton
        Me.radLast30Days = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkTruck = New System.Windows.Forms.CheckBox
        Me.txtTruck = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMileageId = New System.Windows.Forms.TextBox
        Me.chkMileageID = New System.Windows.Forms.CheckBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.radRange)
        Me.GroupBox8.Controls.Add(Me.radLast30Days)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label5)
        Me.GroupBox8.Controls.Add(Me.dtpTo)
        Me.GroupBox8.Controls.Add(Me.dtpFrom)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(384, 134)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Date"
        '
        'radRange
        '
        Me.radRange.AutoSize = True
        Me.radRange.Location = New System.Drawing.Point(7, 55)
        Me.radRange.Name = "radRange"
        Me.radRange.Size = New System.Drawing.Size(86, 17)
        Me.radRange.TabIndex = 1
        Me.radRange.Text = "Show Dates:"
        Me.radRange.UseVisualStyleBackColor = True
        '
        'radLast30Days
        '
        Me.radLast30Days.AutoSize = True
        Me.radLast30Days.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.radLast30Days.Checked = True
        Me.radLast30Days.Location = New System.Drawing.Point(7, 19)
        Me.radLast30Days.Name = "radLast30Days"
        Me.radLast30Days.Size = New System.Drawing.Size(165, 30)
        Me.radLast30Days.TabIndex = 0
        Me.radLast30Days.TabStop = True
        Me.radLast30Days.Text = "Show all Mileage dated within" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the last 30 days"
        Me.radLast30Days.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(43, 108)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "To"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(33, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "From"
        '
        'dtpTo
        '
        Me.dtpTo.Enabled = False
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(69, 104)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(114, 20)
        Me.dtpTo.TabIndex = 3
        '
        'dtpFrom
        '
        Me.dtpFrom.Enabled = False
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(69, 78)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(114, 20)
        Me.dtpFrom.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkTruck)
        Me.GroupBox4.Controls.Add(Me.txtTruck)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(207, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Truck Number"
        '
        'chkTruck
        '
        Me.chkTruck.AutoSize = True
        Me.chkTruck.Checked = True
        Me.chkTruck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTruck.Location = New System.Drawing.Point(6, 20)
        Me.chkTruck.Name = "chkTruck"
        Me.chkTruck.Size = New System.Drawing.Size(67, 17)
        Me.chkTruck.TabIndex = 0
        Me.chkTruck.Text = "Show All"
        Me.chkTruck.UseVisualStyleBackColor = True
        '
        'txtTruck
        '
        Me.txtTruck.Location = New System.Drawing.Point(9, 56)
        Me.txtTruck.Name = "txtTruck"
        Me.txtTruck.Size = New System.Drawing.Size(167, 20)
        Me.txtTruck.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ex.: 1, 3, 4-8"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMileageId)
        Me.GroupBox1.Controls.Add(Me.chkMileageID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mileage ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ex.: 1, 3, 4-8"
        '
        'txtMileageId
        '
        Me.txtMileageId.Location = New System.Drawing.Point(9, 56)
        Me.txtMileageId.Name = "txtMileageId"
        Me.txtMileageId.Size = New System.Drawing.Size(167, 20)
        Me.txtMileageId.TabIndex = 1
        '
        'chkMileageID
        '
        Me.chkMileageID.AutoSize = True
        Me.chkMileageID.Checked = True
        Me.chkMileageID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMileageID.Location = New System.Drawing.Point(7, 20)
        Me.chkMileageID.Name = "chkMileageID"
        Me.chkMileageID.Size = New System.Drawing.Size(67, 17)
        Me.chkMileageID.TabIndex = 0
        Me.chkMileageID.Text = "Show All"
        Me.chkMileageID.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(240, 244)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 11
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(321, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'TrMilListFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(408, 274)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TrMilListFilter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Truck Mileage List Filter"
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents radRange As System.Windows.Forms.RadioButton
    Friend WithEvents radLast30Days As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTruck As System.Windows.Forms.CheckBox
    Friend WithEvents txtTruck As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMileageId As System.Windows.Forms.TextBox
    Friend WithEvents chkMileageID As System.Windows.Forms.CheckBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
