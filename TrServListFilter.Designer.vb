<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrServListFilter
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
        Me.txtId = New System.Windows.Forms.TextBox
        Me.chkIdShowAll = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkShowAllTrucks = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbxTruck = New System.Windows.Forms.ComboBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker
        Me.chkShowAllDates = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.radStatusAll = New System.Windows.Forms.RadioButton
        Me.radStatusPaid = New System.Windows.Forms.RadioButton
        Me.radSatusOpen = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtId)
        Me.GroupBox1.Controls.Add(Me.chkIdShowAll)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Service ID"
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
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(9, 56)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(167, 20)
        Me.txtId.TabIndex = 1
        '
        'chkIdShowAll
        '
        Me.chkIdShowAll.AutoSize = True
        Me.chkIdShowAll.Checked = True
        Me.chkIdShowAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIdShowAll.Location = New System.Drawing.Point(7, 20)
        Me.chkIdShowAll.Name = "chkIdShowAll"
        Me.chkIdShowAll.Size = New System.Drawing.Size(67, 17)
        Me.chkIdShowAll.TabIndex = 0
        Me.chkIdShowAll.Text = "Show All"
        Me.chkIdShowAll.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxTruck)
        Me.GroupBox2.Controls.Add(Me.chkShowAllTrucks)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(207, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Truck"
        '
        'chkShowAllTrucks
        '
        Me.chkShowAllTrucks.AutoSize = True
        Me.chkShowAllTrucks.Checked = True
        Me.chkShowAllTrucks.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowAllTrucks.Location = New System.Drawing.Point(6, 20)
        Me.chkShowAllTrucks.Name = "chkShowAllTrucks"
        Me.chkShowAllTrucks.Size = New System.Drawing.Size(67, 17)
        Me.chkShowAllTrucks.TabIndex = 0
        Me.chkShowAllTrucks.Text = "Show All"
        Me.chkShowAllTrucks.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(6, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Truck Number:"
        '
        'cbxTruck
        '
        Me.cbxTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTruck.Enabled = False
        Me.cbxTruck.FormattingEnabled = True
        Me.cbxTruck.Location = New System.Drawing.Point(9, 56)
        Me.cbxTruck.Name = "cbxTruck"
        Me.cbxTruck.Size = New System.Drawing.Size(167, 21)
        Me.cbxTruck.TabIndex = 1
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkShowAllDates)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.dtpDateTo)
        Me.GroupBox8.Controls.Add(Me.dtpDateFrom)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(189, 99)
        Me.GroupBox8.TabIndex = 3
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Delivery Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(36, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(26, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "From"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Enabled = False
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateTo.Location = New System.Drawing.Point(62, 68)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(114, 20)
        Me.dtpDateTo.TabIndex = 2
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Enabled = False
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateFrom.Location = New System.Drawing.Point(62, 42)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(114, 20)
        Me.dtpDateFrom.TabIndex = 1
        '
        'chkShowAllDates
        '
        Me.chkShowAllDates.AutoSize = True
        Me.chkShowAllDates.Checked = True
        Me.chkShowAllDates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowAllDates.Location = New System.Drawing.Point(7, 19)
        Me.chkShowAllDates.Name = "chkShowAllDates"
        Me.chkShowAllDates.Size = New System.Drawing.Size(67, 17)
        Me.chkShowAllDates.TabIndex = 0
        Me.chkShowAllDates.Text = "Show All"
        Me.chkShowAllDates.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.radSatusOpen)
        Me.GroupBox3.Controls.Add(Me.radStatusPaid)
        Me.GroupBox3.Controls.Add(Me.radStatusAll)
        Me.GroupBox3.Location = New System.Drawing.Point(207, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(189, 99)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(321, 209)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(240, 209)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 5
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'radStatusAll
        '
        Me.radStatusAll.AutoSize = True
        Me.radStatusAll.Location = New System.Drawing.Point(6, 65)
        Me.radStatusAll.Name = "radStatusAll"
        Me.radStatusAll.Size = New System.Drawing.Size(84, 17)
        Me.radStatusAll.TabIndex = 0
        Me.radStatusAll.Text = "Open && Paid"
        Me.radStatusAll.UseVisualStyleBackColor = True
        '
        'radStatusPaid
        '
        Me.radStatusPaid.AutoSize = True
        Me.radStatusPaid.Location = New System.Drawing.Point(6, 42)
        Me.radStatusPaid.Name = "radStatusPaid"
        Me.radStatusPaid.Size = New System.Drawing.Size(46, 17)
        Me.radStatusPaid.TabIndex = 1
        Me.radStatusPaid.Text = "Paid"
        Me.radStatusPaid.UseVisualStyleBackColor = True
        '
        'radSatusOpen
        '
        Me.radSatusOpen.AutoSize = True
        Me.radSatusOpen.Checked = True
        Me.radSatusOpen.Location = New System.Drawing.Point(6, 19)
        Me.radSatusOpen.Name = "radSatusOpen"
        Me.radSatusOpen.Size = New System.Drawing.Size(51, 17)
        Me.radSatusOpen.TabIndex = 2
        Me.radSatusOpen.TabStop = True
        Me.radSatusOpen.Text = "Open"
        Me.radSatusOpen.UseVisualStyleBackColor = True
        '
        'TrServListFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(408, 239)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TrServListFilter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Truck Service List Filter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents chkIdShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowAllTrucks As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxTruck As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowAllDates As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents radSatusOpen As System.Windows.Forms.RadioButton
    Friend WithEvents radStatusPaid As System.Windows.Forms.RadioButton
    Friend WithEvents radStatusAll As System.Windows.Forms.RadioButton
End Class
