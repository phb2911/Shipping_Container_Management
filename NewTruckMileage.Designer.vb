<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewTruckMileage
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.lsvMileage = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMiles = New System.Windows.Forms.TextBox
        Me.btnTruckDetail = New System.Windows.Forms.Button
        Me.dtpMileage = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbxTruck = New System.Windows.Forms.ComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.btnRemove)
        Me.GroupBox1.Controls.Add(Me.lsvMileage)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMiles)
        Me.GroupBox1.Controls.Add(Me.btnTruckDetail)
        Me.GroupBox1.Controls.Add(Me.dtpMileage)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbxTruck)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(289, 230)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Truck Mileage"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(75, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Date:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(165, 122)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(56, 23)
        Me.btnAdd.TabIndex = 37
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(227, 122)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(56, 23)
        Me.btnRemove.TabIndex = 36
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lsvMileage
        '
        Me.lsvMileage.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lsvMileage.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lsvMileage.FullRowSelect = True
        Me.lsvMileage.GridLines = True
        Me.lsvMileage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvMileage.Location = New System.Drawing.Point(6, 19)
        Me.lsvMileage.Name = "lsvMileage"
        Me.lsvMileage.Size = New System.Drawing.Size(277, 97)
        Me.lsvMileage.TabIndex = 35
        Me.lsvMileage.UseCompatibleStateImageBehavior = False
        Me.lsvMileage.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Truck Number"
        Me.ColumnHeader1.Width = 90
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Date"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 90
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Miles"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 207)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Miles:"
        '
        'txtMiles
        '
        Me.txtMiles.Location = New System.Drawing.Point(114, 204)
        Me.txtMiles.MaxLength = 10
        Me.txtMiles.Name = "txtMiles"
        Me.txtMiles.Size = New System.Drawing.Size(100, 20)
        Me.txtMiles.TabIndex = 33
        Me.txtMiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTruckDetail
        '
        Me.btnTruckDetail.Enabled = False
        Me.btnTruckDetail.Location = New System.Drawing.Point(220, 150)
        Me.btnTruckDetail.Name = "btnTruckDetail"
        Me.btnTruckDetail.Size = New System.Drawing.Size(24, 23)
        Me.btnTruckDetail.TabIndex = 29
        Me.btnTruckDetail.Tag = "2"
        Me.btnTruckDetail.Text = "..."
        Me.btnTruckDetail.UseVisualStyleBackColor = True
        '
        'dtpMileage
        '
        Me.dtpMileage.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpMileage.Location = New System.Drawing.Point(114, 178)
        Me.dtpMileage.Name = "dtpMileage"
        Me.dtpMileage.Size = New System.Drawing.Size(100, 20)
        Me.dtpMileage.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Truck Number:"
        '
        'cbxTruck
        '
        Me.cbxTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTruck.FormattingEnabled = True
        Me.cbxTruck.Location = New System.Drawing.Point(114, 151)
        Me.cbxTruck.Name = "cbxTruck"
        Me.cbxTruck.Size = New System.Drawing.Size(100, 21)
        Me.cbxTruck.TabIndex = 28
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(145, 248)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "Save"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(226, 248)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'NewTruckMileage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(313, 277)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewTruckMileage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Truck Mileage"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTruckDetail As System.Windows.Forms.Button
    Friend WithEvents dtpMileage As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxTruck As System.Windows.Forms.ComboBox
    Friend WithEvents txtMiles As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents lsvMileage As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
