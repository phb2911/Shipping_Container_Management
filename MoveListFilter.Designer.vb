<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoveListFilter
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMoveId = New System.Windows.Forms.TextBox
        Me.chkMoveID = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtWoId = New System.Windows.Forms.TextBox
        Me.chkWoId = New System.Windows.Forms.CheckBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkCont = New System.Windows.Forms.CheckBox
        Me.txtCont = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkDriver = New System.Windows.Forms.CheckBox
        Me.txtDriver = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkTruck = New System.Windows.Forms.CheckBox
        Me.txtTruck = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.radRange = New System.Windows.Forms.RadioButton
        Me.radLast30Days = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMoveId)
        Me.GroupBox1.Controls.Add(Me.chkMoveID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Move ID"
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
        'txtMoveId
        '
        Me.txtMoveId.Location = New System.Drawing.Point(9, 56)
        Me.txtMoveId.Name = "txtMoveId"
        Me.txtMoveId.Size = New System.Drawing.Size(167, 20)
        Me.txtMoveId.TabIndex = 1
        '
        'chkMoveID
        '
        Me.chkMoveID.AutoSize = True
        Me.chkMoveID.Checked = True
        Me.chkMoveID.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMoveID.Location = New System.Drawing.Point(7, 20)
        Me.chkMoveID.Name = "chkMoveID"
        Me.chkMoveID.Size = New System.Drawing.Size(67, 17)
        Me.chkMoveID.TabIndex = 0
        Me.chkMoveID.Text = "Show All"
        Me.chkMoveID.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtWoId)
        Me.GroupBox2.Controls.Add(Me.chkWoId)
        Me.GroupBox2.Location = New System.Drawing.Point(207, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Work Order ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ex.: 1, 3, 4-8"
        '
        'txtWoId
        '
        Me.txtWoId.Location = New System.Drawing.Point(9, 56)
        Me.txtWoId.Name = "txtWoId"
        Me.txtWoId.Size = New System.Drawing.Size(167, 20)
        Me.txtWoId.TabIndex = 1
        '
        'chkWoId
        '
        Me.chkWoId.AutoSize = True
        Me.chkWoId.Checked = True
        Me.chkWoId.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWoId.Location = New System.Drawing.Point(7, 20)
        Me.chkWoId.Name = "chkWoId"
        Me.chkWoId.Size = New System.Drawing.Size(67, 17)
        Me.chkWoId.TabIndex = 0
        Me.chkWoId.Text = "Show All"
        Me.chkWoId.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkCont)
        Me.GroupBox5.Controls.Add(Me.txtCont)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Location = New System.Drawing.Point(402, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Container"
        '
        'chkCont
        '
        Me.chkCont.AutoSize = True
        Me.chkCont.Checked = True
        Me.chkCont.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCont.Location = New System.Drawing.Point(6, 20)
        Me.chkCont.Name = "chkCont"
        Me.chkCont.Size = New System.Drawing.Size(67, 17)
        Me.chkCont.TabIndex = 0
        Me.chkCont.Text = "Show All"
        Me.chkCont.UseVisualStyleBackColor = True
        '
        'txtCont
        '
        Me.txtCont.Location = New System.Drawing.Point(9, 56)
        Me.txtCont.Name = "txtCont"
        Me.txtCont.Size = New System.Drawing.Size(167, 20)
        Me.txtCont.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Container Number:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkDriver)
        Me.GroupBox3.Controls.Add(Me.txtDriver)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(189, 134)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Driver"
        '
        'chkDriver
        '
        Me.chkDriver.AutoSize = True
        Me.chkDriver.Checked = True
        Me.chkDriver.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDriver.Location = New System.Drawing.Point(6, 20)
        Me.chkDriver.Name = "chkDriver"
        Me.chkDriver.Size = New System.Drawing.Size(67, 17)
        Me.chkDriver.TabIndex = 0
        Me.chkDriver.Text = "Show All"
        Me.chkDriver.UseVisualStyleBackColor = True
        '
        'txtDriver
        '
        Me.txtDriver.Location = New System.Drawing.Point(9, 56)
        Me.txtDriver.Name = "txtDriver"
        Me.txtDriver.Size = New System.Drawing.Size(167, 20)
        Me.txtDriver.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Driver Name:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkTruck)
        Me.GroupBox4.Controls.Add(Me.txtTruck)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(207, 104)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(189, 134)
        Me.GroupBox4.TabIndex = 5
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
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.radRange)
        Me.GroupBox8.Controls.Add(Me.radLast30Days)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label5)
        Me.GroupBox8.Controls.Add(Me.dtpTo)
        Me.GroupBox8.Controls.Add(Me.dtpFrom)
        Me.GroupBox8.Location = New System.Drawing.Point(402, 104)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(189, 134)
        Me.GroupBox8.TabIndex = 6
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
        Me.radLast30Days.Size = New System.Drawing.Size(148, 30)
        Me.radLast30Days.TabIndex = 0
        Me.radLast30Days.TabStop = True
        Me.radLast30Days.Text = "Show all Moves within the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "last 30 days"
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
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(516, 244)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(435, 244)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'MoveListFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(602, 272)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MoveListFilter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Move List Filter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMoveId As System.Windows.Forms.TextBox
    Friend WithEvents chkMoveID As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWoId As System.Windows.Forms.TextBox
    Friend WithEvents chkWoId As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCont As System.Windows.Forms.CheckBox
    Friend WithEvents txtCont As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDriver As System.Windows.Forms.CheckBox
    Friend WithEvents txtDriver As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkTruck As System.Windows.Forms.CheckBox
    Friend WithEvents txtTruck As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents radRange As System.Windows.Forms.RadioButton
    Friend WithEvents radLast30Days As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
