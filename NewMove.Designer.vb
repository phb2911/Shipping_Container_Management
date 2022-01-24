<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewMove
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
        Me.txtWoNum = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbxEndAmPm = New System.Windows.Forms.ComboBox
        Me.cbxEndMinute = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbxEndHour = New System.Windows.Forms.ComboBox
        Me.chkEnd = New System.Windows.Forms.CheckBox
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker
        Me.chkComplete = New System.Windows.Forms.CheckBox
        Me.radMT = New System.Windows.Forms.RadioButton
        Me.radLD = New System.Windows.Forms.RadioButton
        Me.cbxAMPM = New System.Windows.Forms.ComboBox
        Me.cbxMinute = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.cbxHour = New System.Windows.Forms.ComboBox
        Me.btnTruckDetails = New System.Windows.Forms.Button
        Me.btnDriverDetails = New System.Windows.Forms.Button
        Me.btnToDetails = New System.Windows.Forms.Button
        Me.btnFromDetails = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbxTruck = New System.Windows.Forms.ComboBox
        Me.cbxDriver = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbxTo = New System.Windows.Forms.ComboBox
        Me.cbxFrom = New System.Windows.Forms.ComboBox
        Me.chkStart = New System.Windows.Forms.CheckBox
        Me.dtpStart = New System.Windows.Forms.DateTimePicker
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.chkReadyToBill = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtWoNum
        '
        Me.txtWoNum.Location = New System.Drawing.Point(111, 12)
        Me.txtWoNum.Name = "txtWoNum"
        Me.txtWoNum.ReadOnly = True
        Me.txtWoNum.Size = New System.Drawing.Size(100, 20)
        Me.txtWoNum.TabIndex = 0
        Me.txtWoNum.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Work Order #"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkReadyToBill)
        Me.GroupBox1.Controls.Add(Me.cbxEndAmPm)
        Me.GroupBox1.Controls.Add(Me.cbxEndMinute)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbxEndHour)
        Me.GroupBox1.Controls.Add(Me.chkEnd)
        Me.GroupBox1.Controls.Add(Me.dtpEnd)
        Me.GroupBox1.Controls.Add(Me.chkComplete)
        Me.GroupBox1.Controls.Add(Me.radMT)
        Me.GroupBox1.Controls.Add(Me.radLD)
        Me.GroupBox1.Controls.Add(Me.cbxAMPM)
        Me.GroupBox1.Controls.Add(Me.cbxMinute)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cbxHour)
        Me.GroupBox1.Controls.Add(Me.btnTruckDetails)
        Me.GroupBox1.Controls.Add(Me.btnDriverDetails)
        Me.GroupBox1.Controls.Add(Me.btnToDetails)
        Me.GroupBox1.Controls.Add(Me.btnFromDetails)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbxTruck)
        Me.GroupBox1.Controls.Add(Me.cbxDriver)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbxTo)
        Me.GroupBox1.Controls.Add(Me.cbxFrom)
        Me.GroupBox1.Controls.Add(Me.chkStart)
        Me.GroupBox1.Controls.Add(Me.dtpStart)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 300)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Move"
        '
        'cbxEndAmPm
        '
        Me.cbxEndAmPm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEndAmPm.Enabled = False
        Me.cbxEndAmPm.FormattingEnabled = True
        Me.cbxEndAmPm.Items.AddRange(New Object() {"AM", "PM"})
        Me.cbxEndAmPm.Location = New System.Drawing.Point(207, 98)
        Me.cbxEndAmPm.Name = "cbxEndAmPm"
        Me.cbxEndAmPm.Size = New System.Drawing.Size(43, 21)
        Me.cbxEndAmPm.TabIndex = 57
        '
        'cbxEndMinute
        '
        Me.cbxEndMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEndMinute.Enabled = False
        Me.cbxEndMinute.FormattingEnabled = True
        Me.cbxEndMinute.Items.AddRange(New Object() {"00", "15", "30", "45"})
        Me.cbxEndMinute.Location = New System.Drawing.Point(158, 98)
        Me.cbxEndMinute.Name = "cbxEndMinute"
        Me.cbxEndMinute.Size = New System.Drawing.Size(43, 21)
        Me.cbxEndMinute.TabIndex = 56
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(145, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = ":"
        '
        'cbxEndHour
        '
        Me.cbxEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEndHour.Enabled = False
        Me.cbxEndHour.FormattingEnabled = True
        Me.cbxEndHour.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbxEndHour.Location = New System.Drawing.Point(99, 98)
        Me.cbxEndHour.Name = "cbxEndHour"
        Me.cbxEndHour.Size = New System.Drawing.Size(43, 21)
        Me.cbxEndHour.TabIndex = 55
        '
        'chkEnd
        '
        Me.chkEnd.AutoSize = True
        Me.chkEnd.Location = New System.Drawing.Point(48, 75)
        Me.chkEnd.Name = "chkEnd"
        Me.chkEnd.Size = New System.Drawing.Size(48, 17)
        Me.chkEnd.TabIndex = 53
        Me.chkEnd.Text = "End:"
        Me.chkEnd.UseVisualStyleBackColor = True
        '
        'dtpEnd
        '
        Me.dtpEnd.Enabled = False
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEnd.Location = New System.Drawing.Point(99, 72)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(182, 20)
        Me.dtpEnd.TabIndex = 54
        '
        'chkComplete
        '
        Me.chkComplete.AutoSize = True
        Me.chkComplete.Location = New System.Drawing.Point(99, 256)
        Me.chkComplete.Name = "chkComplete"
        Me.chkComplete.Size = New System.Drawing.Size(70, 17)
        Me.chkComplete.TabIndex = 15
        Me.chkComplete.Text = "Complete"
        Me.chkComplete.UseVisualStyleBackColor = True
        '
        'radMT
        '
        Me.radMT.AutoSize = True
        Me.radMT.Location = New System.Drawing.Point(144, 233)
        Me.radMT.Name = "radMT"
        Me.radMT.Size = New System.Drawing.Size(41, 17)
        Me.radMT.TabIndex = 14
        Me.radMT.TabStop = True
        Me.radMT.Text = "MT"
        Me.radMT.UseVisualStyleBackColor = True
        '
        'radLD
        '
        Me.radLD.AutoSize = True
        Me.radLD.Location = New System.Drawing.Point(99, 233)
        Me.radLD.Name = "radLD"
        Me.radLD.Size = New System.Drawing.Size(39, 17)
        Me.radLD.TabIndex = 13
        Me.radLD.TabStop = True
        Me.radLD.Text = "LD"
        Me.radLD.UseVisualStyleBackColor = True
        '
        'cbxAMPM
        '
        Me.cbxAMPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxAMPM.Enabled = False
        Me.cbxAMPM.FormattingEnabled = True
        Me.cbxAMPM.Items.AddRange(New Object() {"AM", "PM"})
        Me.cbxAMPM.Location = New System.Drawing.Point(207, 45)
        Me.cbxAMPM.Name = "cbxAMPM"
        Me.cbxAMPM.Size = New System.Drawing.Size(43, 21)
        Me.cbxAMPM.TabIndex = 4
        '
        'cbxMinute
        '
        Me.cbxMinute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMinute.Enabled = False
        Me.cbxMinute.FormattingEnabled = True
        Me.cbxMinute.Items.AddRange(New Object() {"00", "15", "30", "45"})
        Me.cbxMinute.Location = New System.Drawing.Point(158, 45)
        Me.cbxMinute.Name = "cbxMinute"
        Me.cbxMinute.Size = New System.Drawing.Size(43, 21)
        Me.cbxMinute.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(145, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 13)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = ":"
        '
        'cbxHour
        '
        Me.cbxHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxHour.Enabled = False
        Me.cbxHour.FormattingEnabled = True
        Me.cbxHour.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cbxHour.Location = New System.Drawing.Point(99, 45)
        Me.cbxHour.Name = "cbxHour"
        Me.cbxHour.Size = New System.Drawing.Size(43, 21)
        Me.cbxHour.TabIndex = 2
        '
        'btnTruckDetails
        '
        Me.btnTruckDetails.Enabled = False
        Me.btnTruckDetails.Location = New System.Drawing.Point(287, 204)
        Me.btnTruckDetails.Name = "btnTruckDetails"
        Me.btnTruckDetails.Size = New System.Drawing.Size(24, 23)
        Me.btnTruckDetails.TabIndex = 12
        Me.btnTruckDetails.Tag = ""
        Me.btnTruckDetails.Text = "..."
        Me.btnTruckDetails.UseVisualStyleBackColor = True
        '
        'btnDriverDetails
        '
        Me.btnDriverDetails.Enabled = False
        Me.btnDriverDetails.Location = New System.Drawing.Point(287, 177)
        Me.btnDriverDetails.Name = "btnDriverDetails"
        Me.btnDriverDetails.Size = New System.Drawing.Size(24, 23)
        Me.btnDriverDetails.TabIndex = 10
        Me.btnDriverDetails.Tag = ""
        Me.btnDriverDetails.Text = "..."
        Me.btnDriverDetails.UseVisualStyleBackColor = True
        '
        'btnToDetails
        '
        Me.btnToDetails.Enabled = False
        Me.btnToDetails.Location = New System.Drawing.Point(287, 150)
        Me.btnToDetails.Name = "btnToDetails"
        Me.btnToDetails.Size = New System.Drawing.Size(24, 23)
        Me.btnToDetails.TabIndex = 8
        Me.btnToDetails.Tag = "2"
        Me.btnToDetails.Text = "..."
        Me.btnToDetails.UseVisualStyleBackColor = True
        '
        'btnFromDetails
        '
        Me.btnFromDetails.Enabled = False
        Me.btnFromDetails.Location = New System.Drawing.Point(287, 123)
        Me.btnFromDetails.Name = "btnFromDetails"
        Me.btnFromDetails.Size = New System.Drawing.Size(24, 23)
        Me.btnFromDetails.TabIndex = 6
        Me.btnFromDetails.Tag = "1"
        Me.btnFromDetails.Text = "..."
        Me.btnFromDetails.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Truck Number:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(55, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Driver:"
        '
        'cbxTruck
        '
        Me.cbxTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTruck.FormattingEnabled = True
        Me.cbxTruck.Location = New System.Drawing.Point(99, 206)
        Me.cbxTruck.Name = "cbxTruck"
        Me.cbxTruck.Size = New System.Drawing.Size(182, 21)
        Me.cbxTruck.TabIndex = 11
        Me.cbxTruck.Tag = "1"
        '
        'cbxDriver
        '
        Me.cbxDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDriver.FormattingEnabled = True
        Me.cbxDriver.Location = New System.Drawing.Point(99, 179)
        Me.cbxDriver.Name = "cbxDriver"
        Me.cbxDriver.Size = New System.Drawing.Size(182, 21)
        Me.cbxDriver.TabIndex = 9
        Me.cbxDriver.Tag = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(70, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "From:"
        '
        'cbxTo
        '
        Me.cbxTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTo.FormattingEnabled = True
        Me.cbxTo.Location = New System.Drawing.Point(99, 152)
        Me.cbxTo.Name = "cbxTo"
        Me.cbxTo.Size = New System.Drawing.Size(182, 21)
        Me.cbxTo.TabIndex = 7
        Me.cbxTo.Tag = "1"
        '
        'cbxFrom
        '
        Me.cbxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFrom.FormattingEnabled = True
        Me.cbxFrom.Location = New System.Drawing.Point(99, 125)
        Me.cbxFrom.Name = "cbxFrom"
        Me.cbxFrom.Size = New System.Drawing.Size(182, 21)
        Me.cbxFrom.TabIndex = 5
        Me.cbxFrom.Tag = "1"
        '
        'chkStart
        '
        Me.chkStart.AutoSize = True
        Me.chkStart.Location = New System.Drawing.Point(45, 22)
        Me.chkStart.Name = "chkStart"
        Me.chkStart.Size = New System.Drawing.Size(51, 17)
        Me.chkStart.TabIndex = 0
        Me.chkStart.Text = "Start:"
        Me.chkStart.UseVisualStyleBackColor = True
        '
        'dtpStart
        '
        Me.dtpStart.Enabled = False
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(99, 19)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(182, 20)
        Me.dtpStart.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(266, 344)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(185, 344)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'chkReadyToBill
        '
        Me.chkReadyToBill.AutoSize = True
        Me.chkReadyToBill.Location = New System.Drawing.Point(99, 279)
        Me.chkReadyToBill.Name = "chkReadyToBill"
        Me.chkReadyToBill.Size = New System.Drawing.Size(192, 17)
        Me.chkReadyToBill.TabIndex = 59
        Me.chkReadyToBill.Text = "Mark Work Order as ""Rady To Bill"""
        Me.chkReadyToBill.UseVisualStyleBackColor = True
        '
        'NewMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(353, 371)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtWoNum)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewMove"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Move"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtWoNum As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkStart As System.Windows.Forms.CheckBox
    Friend WithEvents cbxTo As System.Windows.Forms.ComboBox
    Friend WithEvents cbxFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxTruck As System.Windows.Forms.ComboBox
    Friend WithEvents cbxDriver As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnTruckDetails As System.Windows.Forms.Button
    Friend WithEvents btnDriverDetails As System.Windows.Forms.Button
    Friend WithEvents btnToDetails As System.Windows.Forms.Button
    Friend WithEvents btnFromDetails As System.Windows.Forms.Button
    Friend WithEvents cbxAMPM As System.Windows.Forms.ComboBox
    Friend WithEvents cbxMinute As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxHour As System.Windows.Forms.ComboBox
    Friend WithEvents radMT As System.Windows.Forms.RadioButton
    Friend WithEvents radLD As System.Windows.Forms.RadioButton
    Friend WithEvents chkComplete As System.Windows.Forms.CheckBox
    Friend WithEvents cbxEndAmPm As System.Windows.Forms.ComboBox
    Friend WithEvents cbxEndMinute As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxEndHour As System.Windows.Forms.ComboBox
    Friend WithEvents chkEnd As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkReadyToBill As System.Windows.Forms.CheckBox
End Class
