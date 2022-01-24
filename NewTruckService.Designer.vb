<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewTruckService
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
        Me.btnTruckDetail = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbxDescription = New System.Windows.Forms.ComboBox
        Me.btnRemove = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPO = New System.Windows.Forms.TextBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.lsvService = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.chkServiceDate = New System.Windows.Forms.CheckBox
        Me.dtpService = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbxTruck = New System.Windows.Forms.ComboBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.chkPaid = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnTruckDetail)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtAmount)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbxDescription)
        Me.GroupBox1.Controls.Add(Me.btnRemove)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPO)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.lsvService)
        Me.GroupBox1.Controls.Add(Me.chkServiceDate)
        Me.GroupBox1.Controls.Add(Me.dtpService)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbxTruck)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(370, 285)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Truck Service"
        '
        'btnTruckDetail
        '
        Me.btnTruckDetail.Enabled = False
        Me.btnTruckDetail.Location = New System.Drawing.Point(271, 18)
        Me.btnTruckDetail.Name = "btnTruckDetail"
        Me.btnTruckDetail.Size = New System.Drawing.Size(24, 23)
        Me.btnTruckDetail.TabIndex = 2
        Me.btnTruckDetail.Tag = "2"
        Me.btnTruckDetail.Text = "..."
        Me.btnTruckDetail.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(219, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(222, 125)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(79, 20)
        Me.txtAmount.TabIndex = 7
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Description:"
        '
        'cbxDescription
        '
        Me.cbxDescription.FormattingEnabled = True
        Me.cbxDescription.Items.AddRange(New Object() {"Oil Change", "Labor", "Tax"})
        Me.cbxDescription.Location = New System.Drawing.Point(6, 125)
        Me.cbxDescription.Name = "cbxDescription"
        Me.cbxDescription.Size = New System.Drawing.Size(210, 21)
        Me.cbxDescription.TabIndex = 6
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(6, 255)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(57, 23)
        Me.btnRemove.TabIndex = 10
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(94, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "PO Number:"
        '
        'txtPO
        '
        Me.txtPO.Location = New System.Drawing.Point(165, 75)
        Me.txtPO.MaxLength = 50
        Me.txtPO.Name = "txtPO"
        Me.txtPO.Size = New System.Drawing.Size(100, 20)
        Me.txtPO.TabIndex = 5
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(307, 123)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(57, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(231, 258)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Total:"
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(271, 255)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(93, 20)
        Me.txtTotal.TabIndex = 11
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lsvService
        '
        Me.lsvService.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lsvService.FullRowSelect = True
        Me.lsvService.GridLines = True
        Me.lsvService.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvService.Location = New System.Drawing.Point(6, 152)
        Me.lsvService.Name = "lsvService"
        Me.lsvService.Size = New System.Drawing.Size(358, 97)
        Me.lsvService.TabIndex = 9
        Me.lsvService.UseCompatibleStateImageBehavior = False
        Me.lsvService.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Description:"
        Me.ColumnHeader1.Width = 229
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Amount"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 103
        '
        'chkServiceDate
        '
        Me.chkServiceDate.AutoSize = True
        Me.chkServiceDate.Location = New System.Drawing.Point(68, 49)
        Me.chkServiceDate.Name = "chkServiceDate"
        Me.chkServiceDate.Size = New System.Drawing.Size(91, 17)
        Me.chkServiceDate.TabIndex = 3
        Me.chkServiceDate.Text = "Service Date:"
        Me.chkServiceDate.UseVisualStyleBackColor = True
        '
        'dtpService
        '
        Me.dtpService.Enabled = False
        Me.dtpService.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpService.Location = New System.Drawing.Point(165, 46)
        Me.dtpService.Name = "dtpService"
        Me.dtpService.Size = New System.Drawing.Size(100, 20)
        Me.dtpService.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Truck Number:"
        '
        'cbxTruck
        '
        Me.cbxTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxTruck.FormattingEnabled = True
        Me.cbxTruck.Location = New System.Drawing.Point(165, 19)
        Me.cbxTruck.Name = "cbxTruck"
        Me.cbxTruck.Size = New System.Drawing.Size(100, 21)
        Me.cbxTruck.TabIndex = 1
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(307, 303)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(226, 303)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'chkPaid
        '
        Me.chkPaid.AutoSize = True
        Me.chkPaid.Location = New System.Drawing.Point(12, 303)
        Me.chkPaid.Name = "chkPaid"
        Me.chkPaid.Size = New System.Drawing.Size(47, 17)
        Me.chkPaid.TabIndex = 1
        Me.chkPaid.Text = "Paid"
        Me.chkPaid.UseVisualStyleBackColor = True
        '
        'NewTruckService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(394, 333)
        Me.Controls.Add(Me.chkPaid)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NewTruckService"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Truck Service"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxTruck As System.Windows.Forms.ComboBox
    Friend WithEvents chkServiceDate As System.Windows.Forms.CheckBox
    Friend WithEvents dtpService As System.Windows.Forms.DateTimePicker
    Friend WithEvents lsvService As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents chkPaid As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxDescription As System.Windows.Forms.ComboBox
    Friend WithEvents btnTruckDetail As System.Windows.Forms.Button
End Class
