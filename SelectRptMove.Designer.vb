<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectRptMove
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
        Me.lsvDrivers = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkClosed = New System.Windows.Forms.CheckBox
        Me.chkInactive = New System.Windows.Forms.CheckBox
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.btnOk_Wo = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lsvLocations = New System.Windows.Forms.ListView
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.chkAllLoc = New System.Windows.Forms.CheckBox
        Me.btnOk_Cont = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvDrivers
        '
        Me.lsvDrivers.CheckBoxes = True
        Me.lsvDrivers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lsvDrivers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvDrivers.Location = New System.Drawing.Point(6, 42)
        Me.lsvDrivers.MultiSelect = False
        Me.lsvDrivers.Name = "lsvDrivers"
        Me.lsvDrivers.Size = New System.Drawing.Size(170, 88)
        Me.lsvDrivers.TabIndex = 1
        Me.lsvDrivers.UseCompatibleStateImageBehavior = False
        Me.lsvDrivers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 149
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(48, 45)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(128, 20)
        Me.dtpTo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To:"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(48, 19)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(128, 20)
        Me.dtpFrom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "From:"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(226, 154)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(307, 154)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(200, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(182, 136)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Location = New System.Drawing.Point(6, 19)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(73, 17)
        Me.chkAll.TabIndex = 0
        Me.chkAll.Text = "All Drivers"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lsvDrivers)
        Me.GroupBox2.Controls.Add(Me.chkAll)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(182, 136)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Driver"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkClosed)
        Me.GroupBox3.Controls.Add(Me.chkInactive)
        Me.GroupBox3.Controls.Add(Me.chkActive)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 154)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(182, 136)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Select Work Order Status"
        Me.GroupBox3.Visible = False
        '
        'chkClosed
        '
        Me.chkClosed.AutoSize = True
        Me.chkClosed.Checked = True
        Me.chkClosed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClosed.Location = New System.Drawing.Point(6, 65)
        Me.chkClosed.Name = "chkClosed"
        Me.chkClosed.Size = New System.Drawing.Size(58, 17)
        Me.chkClosed.TabIndex = 2
        Me.chkClosed.Text = "Closed"
        Me.chkClosed.UseVisualStyleBackColor = True
        '
        'chkInactive
        '
        Me.chkInactive.AutoSize = True
        Me.chkInactive.Checked = True
        Me.chkInactive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInactive.Location = New System.Drawing.Point(6, 42)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.Size = New System.Drawing.Size(64, 17)
        Me.chkInactive.TabIndex = 1
        Me.chkInactive.Text = "Inactive"
        Me.chkInactive.UseVisualStyleBackColor = True
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Location = New System.Drawing.Point(6, 19)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(56, 17)
        Me.chkActive.TabIndex = 0
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'btnOk_Wo
        '
        Me.btnOk_Wo.Location = New System.Drawing.Point(226, 267)
        Me.btnOk_Wo.Name = "btnOk_Wo"
        Me.btnOk_Wo.Size = New System.Drawing.Size(75, 23)
        Me.btnOk_Wo.TabIndex = 3
        Me.btnOk_Wo.Text = "OK"
        Me.btnOk_Wo.UseVisualStyleBackColor = True
        Me.btnOk_Wo.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lsvLocations)
        Me.GroupBox4.Controls.Add(Me.chkAllLoc)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 296)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(370, 136)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Select Location"
        Me.GroupBox4.Visible = False
        '
        'lsvLocations
        '
        Me.lsvLocations.CheckBoxes = True
        Me.lsvLocations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lsvLocations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvLocations.Location = New System.Drawing.Point(6, 42)
        Me.lsvLocations.MultiSelect = False
        Me.lsvLocations.Name = "lsvLocations"
        Me.lsvLocations.Size = New System.Drawing.Size(358, 88)
        Me.lsvLocations.TabIndex = 1
        Me.lsvLocations.UseCompatibleStateImageBehavior = False
        Me.lsvLocations.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 149
        '
        'chkAllLoc
        '
        Me.chkAllLoc.AutoSize = True
        Me.chkAllLoc.Checked = True
        Me.chkAllLoc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAllLoc.Location = New System.Drawing.Point(6, 19)
        Me.chkAllLoc.Name = "chkAllLoc"
        Me.chkAllLoc.Size = New System.Drawing.Size(86, 17)
        Me.chkAllLoc.TabIndex = 0
        Me.chkAllLoc.Text = "All Locations"
        Me.chkAllLoc.UseVisualStyleBackColor = True
        '
        'btnOk_Cont
        '
        Me.btnOk_Cont.Location = New System.Drawing.Point(222, 438)
        Me.btnOk_Cont.Name = "btnOk_Cont"
        Me.btnOk_Cont.Size = New System.Drawing.Size(75, 23)
        Me.btnOk_Cont.TabIndex = 5
        Me.btnOk_Cont.Text = "OK"
        Me.btnOk_Cont.UseVisualStyleBackColor = True
        Me.btnOk_Cont.Visible = False
        '
        'SelectRptMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 471)
        Me.Controls.Add(Me.btnOk_Cont)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnOk_Wo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectRptMove"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsvDrivers As System.Windows.Forms.ListView
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk_Wo As System.Windows.Forms.Button
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lsvLocations As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkAllLoc As System.Windows.Forms.CheckBox
    Friend WithEvents btnOk_Cont As System.Windows.Forms.Button
End Class
