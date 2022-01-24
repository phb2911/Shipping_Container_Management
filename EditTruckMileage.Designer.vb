<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditTruckMileage
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
        Me.txtMiles = New System.Windows.Forms.TextBox
        Me.btnTruckDetail = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.dtpMileage = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbxTruck = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMiles
        '
        Me.txtMiles.Location = New System.Drawing.Point(120, 72)
        Me.txtMiles.MaxLength = 10
        Me.txtMiles.Name = "txtMiles"
        Me.txtMiles.Size = New System.Drawing.Size(100, 20)
        Me.txtMiles.TabIndex = 3
        Me.txtMiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTruckDetail
        '
        Me.btnTruckDetail.Enabled = False
        Me.btnTruckDetail.Location = New System.Drawing.Point(226, 18)
        Me.btnTruckDetail.Name = "btnTruckDetail"
        Me.btnTruckDetail.Size = New System.Drawing.Size(24, 23)
        Me.btnTruckDetail.TabIndex = 1
        Me.btnTruckDetail.Tag = "2"
        Me.btnTruckDetail.Text = "..."
        Me.btnTruckDetail.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(80, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Miles:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(226, 121)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dtpMileage
        '
        Me.dtpMileage.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMileage.Location = New System.Drawing.Point(120, 46)
        Me.dtpMileage.Name = "dtpMileage"
        Me.dtpMileage.Size = New System.Drawing.Size(100, 20)
        Me.dtpMileage.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Truck Number:"
        '
        'cbxTruck
        '
        Me.cbxTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTruck.FormattingEnabled = True
        Me.cbxTruck.Location = New System.Drawing.Point(120, 19)
        Me.cbxTruck.Name = "cbxTruck"
        Me.cbxTruck.Size = New System.Drawing.Size(100, 21)
        Me.cbxTruck.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(81, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Date:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(145, 121)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Save"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMiles)
        Me.GroupBox1.Controls.Add(Me.btnTruckDetail)
        Me.GroupBox1.Controls.Add(Me.dtpMileage)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbxTruck)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 103)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Truck Mileage"
        '
        'EditTruckMileage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(312, 150)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditTruckMileage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Truck Mileage ID # "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMiles As System.Windows.Forms.TextBox
    Friend WithEvents btnTruckDetail As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents dtpMileage As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxTruck As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
