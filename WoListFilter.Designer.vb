<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WoListFilter
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
        Me.txtWoId = New System.Windows.Forms.TextBox
        Me.chkIdShowAll = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ChkCustShowAll = New System.Windows.Forms.CheckBox
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkShToShowAll = New System.Windows.Forms.CheckBox
        Me.txtShipTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkRefShowAll = New System.Windows.Forms.CheckBox
        Me.txtRef = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkContShowAll = New System.Windows.Forms.CheckBox
        Me.txtCont = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.chkBKBLShowAll = New System.Windows.Forms.CheckBox
        Me.txtBkBl = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.chkStatusInactive = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.chkStatusClosed = New System.Windows.Forms.CheckBox
        Me.ChkStatusActive = New System.Windows.Forms.CheckBox
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.radDelRange = New System.Windows.Forms.RadioButton
        Me.radDelUns = New System.Windows.Forms.RadioButton
        Me.radDelShowAll = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDelDateTo = New System.Windows.Forms.DateTimePicker
        Me.dtpDelDateFrom = New System.Windows.Forms.DateTimePicker
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.radPupRange = New System.Windows.Forms.RadioButton
        Me.radPupUns = New System.Windows.Forms.RadioButton
        Me.radPupShowAll = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtpPupTo = New System.Windows.Forms.DateTimePicker
        Me.dtpPupFrom = New System.Windows.Forms.DateTimePicker
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.radDropRange = New System.Windows.Forms.RadioButton
        Me.radDropUns = New System.Windows.Forms.RadioButton
        Me.radDropShowAll = New System.Windows.Forms.RadioButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtpDropTo = New System.Windows.Forms.DateTimePicker
        Me.dtpDropFrom = New System.Windows.Forms.DateTimePicker
        Me.GroupBox11 = New System.Windows.Forms.GroupBox
        Me.radWoLast30Days = New System.Windows.Forms.RadioButton
        Me.radWoDateRange = New System.Windows.Forms.RadioButton
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.dtpWoTo = New System.Windows.Forms.DateTimePicker
        Me.dtpWoFrom = New System.Windows.Forms.DateTimePicker
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.chkBillingNotBillable = New System.Windows.Forms.CheckBox
        Me.chkBillingNotBilled = New System.Windows.Forms.CheckBox
        Me.chkBillingReadyToBill = New System.Windows.Forms.CheckBox
        Me.chkBillingBilled = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtWoId)
        Me.GroupBox1.Controls.Add(Me.chkIdShowAll)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Work Order ID"
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
        'txtWoId
        '
        Me.txtWoId.Location = New System.Drawing.Point(9, 56)
        Me.txtWoId.Name = "txtWoId"
        Me.txtWoId.Size = New System.Drawing.Size(167, 20)
        Me.txtWoId.TabIndex = 1
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
        Me.GroupBox2.Controls.Add(Me.ChkCustShowAll)
        Me.GroupBox2.Controls.Add(Me.txtCustomer)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(207, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer"
        '
        'ChkCustShowAll
        '
        Me.ChkCustShowAll.AutoSize = True
        Me.ChkCustShowAll.Checked = True
        Me.ChkCustShowAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkCustShowAll.Location = New System.Drawing.Point(6, 20)
        Me.ChkCustShowAll.Name = "ChkCustShowAll"
        Me.ChkCustShowAll.Size = New System.Drawing.Size(67, 17)
        Me.ChkCustShowAll.TabIndex = 2
        Me.ChkCustShowAll.Text = "Show All"
        Me.ChkCustShowAll.UseVisualStyleBackColor = True
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(9, 56)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(167, 20)
        Me.txtCustomer.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Customer Name:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkShToShowAll)
        Me.GroupBox3.Controls.Add(Me.txtShipTo)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Location = New System.Drawing.Point(402, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ShipTo"
        '
        'chkShToShowAll
        '
        Me.chkShToShowAll.AutoSize = True
        Me.chkShToShowAll.Checked = True
        Me.chkShToShowAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShToShowAll.Location = New System.Drawing.Point(6, 20)
        Me.chkShToShowAll.Name = "chkShToShowAll"
        Me.chkShToShowAll.Size = New System.Drawing.Size(67, 17)
        Me.chkShToShowAll.TabIndex = 5
        Me.chkShToShowAll.Text = "Show All"
        Me.chkShToShowAll.UseVisualStyleBackColor = True
        '
        'txtShipTo
        '
        Me.txtShipTo.Location = New System.Drawing.Point(9, 56)
        Me.txtShipTo.Name = "txtShipTo"
        Me.txtShipTo.Size = New System.Drawing.Size(167, 20)
        Me.txtShipTo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ShipTo Name:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkRefShowAll)
        Me.GroupBox4.Controls.Add(Me.txtRef)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 104)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Reference"
        '
        'chkRefShowAll
        '
        Me.chkRefShowAll.AutoSize = True
        Me.chkRefShowAll.Checked = True
        Me.chkRefShowAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRefShowAll.Location = New System.Drawing.Point(7, 19)
        Me.chkRefShowAll.Name = "chkRefShowAll"
        Me.chkRefShowAll.Size = New System.Drawing.Size(67, 17)
        Me.chkRefShowAll.TabIndex = 7
        Me.chkRefShowAll.Text = "Show All"
        Me.chkRefShowAll.UseVisualStyleBackColor = True
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(9, 56)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(167, 20)
        Me.txtRef.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Reference Number:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkContShowAll)
        Me.GroupBox5.Controls.Add(Me.txtCont)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Location = New System.Drawing.Point(207, 104)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Container"
        '
        'chkContShowAll
        '
        Me.chkContShowAll.AutoSize = True
        Me.chkContShowAll.Checked = True
        Me.chkContShowAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkContShowAll.Location = New System.Drawing.Point(6, 20)
        Me.chkContShowAll.Name = "chkContShowAll"
        Me.chkContShowAll.Size = New System.Drawing.Size(67, 17)
        Me.chkContShowAll.TabIndex = 9
        Me.chkContShowAll.Text = "Show All"
        Me.chkContShowAll.UseVisualStyleBackColor = True
        '
        'txtCont
        '
        Me.txtCont.Location = New System.Drawing.Point(9, 56)
        Me.txtCont.Name = "txtCont"
        Me.txtCont.Size = New System.Drawing.Size(167, 20)
        Me.txtCont.TabIndex = 10
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
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.chkBKBLShowAll)
        Me.GroupBox6.Controls.Add(Me.txtBkBl)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Location = New System.Drawing.Point(402, 104)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(189, 86)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "BK/BL"
        '
        'chkBKBLShowAll
        '
        Me.chkBKBLShowAll.AutoSize = True
        Me.chkBKBLShowAll.Checked = True
        Me.chkBKBLShowAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBKBLShowAll.Location = New System.Drawing.Point(6, 20)
        Me.chkBKBLShowAll.Name = "chkBKBLShowAll"
        Me.chkBKBLShowAll.Size = New System.Drawing.Size(67, 17)
        Me.chkBKBLShowAll.TabIndex = 11
        Me.chkBKBLShowAll.Text = "Show All"
        Me.chkBKBLShowAll.UseVisualStyleBackColor = True
        '
        'txtBkBl
        '
        Me.txtBkBl.Location = New System.Drawing.Point(9, 56)
        Me.txtBkBl.Name = "txtBkBl"
        Me.txtBkBl.Size = New System.Drawing.Size(167, 20)
        Me.txtBkBl.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "BK/BL Number:"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(516, 498)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(435, 498)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 12
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'chkStatusInactive
        '
        Me.chkStatusInactive.AutoSize = True
        Me.chkStatusInactive.Location = New System.Drawing.Point(9, 42)
        Me.chkStatusInactive.Name = "chkStatusInactive"
        Me.chkStatusInactive.Size = New System.Drawing.Size(64, 17)
        Me.chkStatusInactive.TabIndex = 1
        Me.chkStatusInactive.Text = "Inactive"
        Me.chkStatusInactive.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkStatusClosed)
        Me.GroupBox7.Controls.Add(Me.ChkStatusActive)
        Me.GroupBox7.Controls.Add(Me.chkStatusInactive)
        Me.GroupBox7.Location = New System.Drawing.Point(402, 347)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(189, 145)
        Me.GroupBox7.TabIndex = 11
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Status"
        '
        'chkStatusClosed
        '
        Me.chkStatusClosed.AutoSize = True
        Me.chkStatusClosed.Location = New System.Drawing.Point(9, 65)
        Me.chkStatusClosed.Name = "chkStatusClosed"
        Me.chkStatusClosed.Size = New System.Drawing.Size(58, 17)
        Me.chkStatusClosed.TabIndex = 2
        Me.chkStatusClosed.Text = "Closed"
        Me.chkStatusClosed.UseVisualStyleBackColor = True
        '
        'ChkStatusActive
        '
        Me.ChkStatusActive.AutoSize = True
        Me.ChkStatusActive.Checked = True
        Me.ChkStatusActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkStatusActive.Location = New System.Drawing.Point(9, 19)
        Me.ChkStatusActive.Name = "ChkStatusActive"
        Me.ChkStatusActive.Size = New System.Drawing.Size(56, 17)
        Me.ChkStatusActive.TabIndex = 0
        Me.ChkStatusActive.Text = "Active"
        Me.ChkStatusActive.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.radDelRange)
        Me.GroupBox8.Controls.Add(Me.radDelUns)
        Me.GroupBox8.Controls.Add(Me.radDelShowAll)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.dtpDelDateTo)
        Me.GroupBox8.Controls.Add(Me.dtpDelDateFrom)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 196)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(189, 145)
        Me.GroupBox8.TabIndex = 6
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Delivery Date"
        '
        'radDelRange
        '
        Me.radDelRange.AutoSize = True
        Me.radDelRange.Location = New System.Drawing.Point(6, 65)
        Me.radDelRange.Name = "radDelRange"
        Me.radDelRange.Size = New System.Drawing.Size(86, 17)
        Me.radDelRange.TabIndex = 15
        Me.radDelRange.Text = "Show Dates:"
        Me.radDelRange.UseVisualStyleBackColor = True
        '
        'radDelUns
        '
        Me.radDelUns.AutoSize = True
        Me.radDelUns.Location = New System.Drawing.Point(6, 42)
        Me.radDelUns.Name = "radDelUns"
        Me.radDelUns.Size = New System.Drawing.Size(142, 17)
        Me.radDelUns.TabIndex = 14
        Me.radDelUns.Text = "Show Unscheduled Only"
        Me.radDelUns.UseVisualStyleBackColor = True
        '
        'radDelShowAll
        '
        Me.radDelShowAll.AutoSize = True
        Me.radDelShowAll.Checked = True
        Me.radDelShowAll.Location = New System.Drawing.Point(6, 19)
        Me.radDelShowAll.Name = "radDelShowAll"
        Me.radDelShowAll.Size = New System.Drawing.Size(66, 17)
        Me.radDelShowAll.TabIndex = 13
        Me.radDelShowAll.TabStop = True
        Me.radDelShowAll.Text = "Show All"
        Me.radDelShowAll.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(36, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(26, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "From"
        '
        'dtpDelDateTo
        '
        Me.dtpDelDateTo.Enabled = False
        Me.dtpDelDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDelDateTo.Location = New System.Drawing.Point(62, 114)
        Me.dtpDelDateTo.Name = "dtpDelDateTo"
        Me.dtpDelDateTo.Size = New System.Drawing.Size(114, 20)
        Me.dtpDelDateTo.TabIndex = 17
        '
        'dtpDelDateFrom
        '
        Me.dtpDelDateFrom.Enabled = False
        Me.dtpDelDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDelDateFrom.Location = New System.Drawing.Point(62, 88)
        Me.dtpDelDateFrom.Name = "dtpDelDateFrom"
        Me.dtpDelDateFrom.Size = New System.Drawing.Size(114, 20)
        Me.dtpDelDateFrom.TabIndex = 16
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.radPupRange)
        Me.GroupBox9.Controls.Add(Me.radPupUns)
        Me.GroupBox9.Controls.Add(Me.radPupShowAll)
        Me.GroupBox9.Controls.Add(Me.Label9)
        Me.GroupBox9.Controls.Add(Me.Label10)
        Me.GroupBox9.Controls.Add(Me.dtpPupTo)
        Me.GroupBox9.Controls.Add(Me.dtpPupFrom)
        Me.GroupBox9.Location = New System.Drawing.Point(207, 196)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(189, 145)
        Me.GroupBox9.TabIndex = 7
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "PickUp Date"
        '
        'radPupRange
        '
        Me.radPupRange.AutoSize = True
        Me.radPupRange.Location = New System.Drawing.Point(6, 65)
        Me.radPupRange.Name = "radPupRange"
        Me.radPupRange.Size = New System.Drawing.Size(86, 17)
        Me.radPupRange.TabIndex = 20
        Me.radPupRange.Text = "Show Dates:"
        Me.radPupRange.UseVisualStyleBackColor = True
        '
        'radPupUns
        '
        Me.radPupUns.AutoSize = True
        Me.radPupUns.Location = New System.Drawing.Point(6, 42)
        Me.radPupUns.Name = "radPupUns"
        Me.radPupUns.Size = New System.Drawing.Size(142, 17)
        Me.radPupUns.TabIndex = 19
        Me.radPupUns.Text = "Show Unscheduled Only"
        Me.radPupUns.UseVisualStyleBackColor = True
        '
        'radPupShowAll
        '
        Me.radPupShowAll.AutoSize = True
        Me.radPupShowAll.Checked = True
        Me.radPupShowAll.Location = New System.Drawing.Point(6, 19)
        Me.radPupShowAll.Name = "radPupShowAll"
        Me.radPupShowAll.Size = New System.Drawing.Size(66, 17)
        Me.radPupShowAll.TabIndex = 18
        Me.radPupShowAll.TabStop = True
        Me.radPupShowAll.Text = "Show All"
        Me.radPupShowAll.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(36, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Enabled = False
        Me.Label10.Location = New System.Drawing.Point(26, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "From"
        '
        'dtpPupTo
        '
        Me.dtpPupTo.Enabled = False
        Me.dtpPupTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPupTo.Location = New System.Drawing.Point(62, 114)
        Me.dtpPupTo.Name = "dtpPupTo"
        Me.dtpPupTo.Size = New System.Drawing.Size(114, 20)
        Me.dtpPupTo.TabIndex = 22
        '
        'dtpPupFrom
        '
        Me.dtpPupFrom.Enabled = False
        Me.dtpPupFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPupFrom.Location = New System.Drawing.Point(62, 88)
        Me.dtpPupFrom.Name = "dtpPupFrom"
        Me.dtpPupFrom.Size = New System.Drawing.Size(114, 20)
        Me.dtpPupFrom.TabIndex = 21
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.radDropRange)
        Me.GroupBox10.Controls.Add(Me.radDropUns)
        Me.GroupBox10.Controls.Add(Me.radDropShowAll)
        Me.GroupBox10.Controls.Add(Me.Label11)
        Me.GroupBox10.Controls.Add(Me.Label12)
        Me.GroupBox10.Controls.Add(Me.dtpDropTo)
        Me.GroupBox10.Controls.Add(Me.dtpDropFrom)
        Me.GroupBox10.Location = New System.Drawing.Point(402, 196)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(189, 145)
        Me.GroupBox10.TabIndex = 8
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "DropOff Date"
        '
        'radDropRange
        '
        Me.radDropRange.AutoSize = True
        Me.radDropRange.Location = New System.Drawing.Point(6, 65)
        Me.radDropRange.Name = "radDropRange"
        Me.radDropRange.Size = New System.Drawing.Size(86, 17)
        Me.radDropRange.TabIndex = 25
        Me.radDropRange.Text = "Show Dates:"
        Me.radDropRange.UseVisualStyleBackColor = True
        '
        'radDropUns
        '
        Me.radDropUns.AutoSize = True
        Me.radDropUns.Location = New System.Drawing.Point(6, 42)
        Me.radDropUns.Name = "radDropUns"
        Me.radDropUns.Size = New System.Drawing.Size(142, 17)
        Me.radDropUns.TabIndex = 24
        Me.radDropUns.Text = "Show Unscheduled Only"
        Me.radDropUns.UseVisualStyleBackColor = True
        '
        'radDropShowAll
        '
        Me.radDropShowAll.AutoSize = True
        Me.radDropShowAll.Checked = True
        Me.radDropShowAll.Location = New System.Drawing.Point(6, 19)
        Me.radDropShowAll.Name = "radDropShowAll"
        Me.radDropShowAll.Size = New System.Drawing.Size(66, 17)
        Me.radDropShowAll.TabIndex = 23
        Me.radDropShowAll.TabStop = True
        Me.radDropShowAll.Text = "Show All"
        Me.radDropShowAll.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Location = New System.Drawing.Point(36, 118)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(20, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "To"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Location = New System.Drawing.Point(26, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "From"
        '
        'dtpDropTo
        '
        Me.dtpDropTo.Enabled = False
        Me.dtpDropTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDropTo.Location = New System.Drawing.Point(62, 114)
        Me.dtpDropTo.Name = "dtpDropTo"
        Me.dtpDropTo.Size = New System.Drawing.Size(114, 20)
        Me.dtpDropTo.TabIndex = 27
        '
        'dtpDropFrom
        '
        Me.dtpDropFrom.Enabled = False
        Me.dtpDropFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDropFrom.Location = New System.Drawing.Point(62, 88)
        Me.dtpDropFrom.Name = "dtpDropFrom"
        Me.dtpDropFrom.Size = New System.Drawing.Size(114, 20)
        Me.dtpDropFrom.TabIndex = 26
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.radWoLast30Days)
        Me.GroupBox11.Controls.Add(Me.radWoDateRange)
        Me.GroupBox11.Controls.Add(Me.Label13)
        Me.GroupBox11.Controls.Add(Me.Label14)
        Me.GroupBox11.Controls.Add(Me.dtpWoTo)
        Me.GroupBox11.Controls.Add(Me.dtpWoFrom)
        Me.GroupBox11.Location = New System.Drawing.Point(12, 347)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(188, 145)
        Me.GroupBox11.TabIndex = 9
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "WorkOrder Date"
        '
        'radWoLast30Days
        '
        Me.radWoLast30Days.AutoSize = True
        Me.radWoLast30Days.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.radWoLast30Days.Checked = True
        Me.radWoLast30Days.Location = New System.Drawing.Point(6, 19)
        Me.radWoLast30Days.Name = "radWoLast30Days"
        Me.radWoLast30Days.Size = New System.Drawing.Size(158, 30)
        Me.radWoLast30Days.TabIndex = 1
        Me.radWoLast30Days.TabStop = True
        Me.radWoLast30Days.Text = "Show all Work Orders dated" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "within the last 30 days."
        Me.radWoLast30Days.UseVisualStyleBackColor = True
        '
        'radWoDateRange
        '
        Me.radWoDateRange.AutoSize = True
        Me.radWoDateRange.Location = New System.Drawing.Point(6, 55)
        Me.radWoDateRange.Name = "radWoDateRange"
        Me.radWoDateRange.Size = New System.Drawing.Size(86, 17)
        Me.radWoDateRange.TabIndex = 2
        Me.radWoDateRange.Text = "Show Dates:"
        Me.radWoDateRange.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Enabled = False
        Me.Label13.Location = New System.Drawing.Point(42, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(20, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "To"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Enabled = False
        Me.Label14.Location = New System.Drawing.Point(32, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "From"
        '
        'dtpWoTo
        '
        Me.dtpWoTo.Enabled = False
        Me.dtpWoTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpWoTo.Location = New System.Drawing.Point(68, 104)
        Me.dtpWoTo.Name = "dtpWoTo"
        Me.dtpWoTo.Size = New System.Drawing.Size(114, 20)
        Me.dtpWoTo.TabIndex = 4
        '
        'dtpWoFrom
        '
        Me.dtpWoFrom.Enabled = False
        Me.dtpWoFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpWoFrom.Location = New System.Drawing.Point(68, 78)
        Me.dtpWoFrom.Name = "dtpWoFrom"
        Me.dtpWoFrom.Size = New System.Drawing.Size(114, 20)
        Me.dtpWoFrom.TabIndex = 3
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.chkBillingBilled)
        Me.GroupBox12.Controls.Add(Me.chkBillingReadyToBill)
        Me.GroupBox12.Controls.Add(Me.chkBillingNotBilled)
        Me.GroupBox12.Controls.Add(Me.chkBillingNotBillable)
        Me.GroupBox12.Location = New System.Drawing.Point(207, 347)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(189, 145)
        Me.GroupBox12.TabIndex = 10
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Billing Status"
        '
        'chkBillingNotBillable
        '
        Me.chkBillingNotBillable.AutoSize = True
        Me.chkBillingNotBillable.Checked = True
        Me.chkBillingNotBillable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBillingNotBillable.Location = New System.Drawing.Point(9, 19)
        Me.chkBillingNotBillable.Name = "chkBillingNotBillable"
        Me.chkBillingNotBillable.Size = New System.Drawing.Size(79, 17)
        Me.chkBillingNotBillable.TabIndex = 0
        Me.chkBillingNotBillable.Text = "Not Billable"
        Me.chkBillingNotBillable.UseVisualStyleBackColor = True
        '
        'chkBillingNotBilled
        '
        Me.chkBillingNotBilled.AutoSize = True
        Me.chkBillingNotBilled.Checked = True
        Me.chkBillingNotBilled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBillingNotBilled.Location = New System.Drawing.Point(9, 42)
        Me.chkBillingNotBilled.Name = "chkBillingNotBilled"
        Me.chkBillingNotBilled.Size = New System.Drawing.Size(71, 17)
        Me.chkBillingNotBilled.TabIndex = 1
        Me.chkBillingNotBilled.Text = "Not Billed"
        Me.chkBillingNotBilled.UseVisualStyleBackColor = True
        '
        'chkBillingReadyToBill
        '
        Me.chkBillingReadyToBill.AutoSize = True
        Me.chkBillingReadyToBill.Checked = True
        Me.chkBillingReadyToBill.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBillingReadyToBill.Location = New System.Drawing.Point(9, 65)
        Me.chkBillingReadyToBill.Name = "chkBillingReadyToBill"
        Me.chkBillingReadyToBill.Size = New System.Drawing.Size(89, 17)
        Me.chkBillingReadyToBill.TabIndex = 2
        Me.chkBillingReadyToBill.Text = "Ready To Bill"
        Me.chkBillingReadyToBill.UseVisualStyleBackColor = True
        '
        'chkBillingBilled
        '
        Me.chkBillingBilled.AutoSize = True
        Me.chkBillingBilled.Checked = True
        Me.chkBillingBilled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBillingBilled.Location = New System.Drawing.Point(9, 88)
        Me.chkBillingBilled.Name = "chkBillingBilled"
        Me.chkBillingBilled.Size = New System.Drawing.Size(51, 17)
        Me.chkBillingBilled.TabIndex = 3
        Me.chkBillingBilled.Text = "Billed"
        Me.chkBillingBilled.UseVisualStyleBackColor = True
        '
        'WoListFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(602, 524)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WoListFilter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Work Order List Filter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkIdShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkCustShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShToShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtShipTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRefShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chkContShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtCont As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBKBLShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents txtBkBl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtWoId As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents chkStatusInactive As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkStatusActive As System.Windows.Forms.CheckBox
    Friend WithEvents chkStatusClosed As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpDelDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDelDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpPupTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPupFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpDropTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDropFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents radDelRange As System.Windows.Forms.RadioButton
    Friend WithEvents radDelUns As System.Windows.Forms.RadioButton
    Friend WithEvents radDelShowAll As System.Windows.Forms.RadioButton
    Friend WithEvents radPupRange As System.Windows.Forms.RadioButton
    Friend WithEvents radPupUns As System.Windows.Forms.RadioButton
    Friend WithEvents radPupShowAll As System.Windows.Forms.RadioButton
    Friend WithEvents radDropRange As System.Windows.Forms.RadioButton
    Friend WithEvents radDropUns As System.Windows.Forms.RadioButton
    Friend WithEvents radDropShowAll As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents radWoLast30Days As System.Windows.Forms.RadioButton
    Friend WithEvents radWoDateRange As System.Windows.Forms.RadioButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpWoTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpWoFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents chkBillingBilled As System.Windows.Forms.CheckBox
    Friend WithEvents chkBillingReadyToBill As System.Windows.Forms.CheckBox
    Friend WithEvents chkBillingNotBilled As System.Windows.Forms.CheckBox
    Friend WithEvents chkBillingNotBillable As System.Windows.Forms.CheckBox
End Class
