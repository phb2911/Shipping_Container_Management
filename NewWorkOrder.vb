
Imports System.Text.RegularExpressions

Public Class NewWorkOrder

#Region "Global Vars"

    Dim _mode As FormMode = FormMode.CreateNew
    Dim _WorkOrderID As Integer = -1
    Dim myDsWo As New DataSet
    Dim _oldRate As String = ""

    Friend Enum FillTableType As Byte
        Customers
        ShipTo
        Location
        ShippingLine
        All
    End Enum

#End Region ' Global Vars

#Region "Control Events"

    Private Sub NewWorkOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me._mode = FormMode.Edit And Me._WorkOrderID < 0 Then _
            Throw New Exception("A Work Order ID number must be passed on Edit mode.")

        ' create Ds tables
        Me.myDsWo.Tables.Add("Customers")
        Me.myDsWo.Tables.Add("ShipTo")
        Me.myDsWo.Tables.Add("Location")
        Me.myDsWo.Tables.Add("ShippingLine")

        ' Fill DsWorkOrders
        If Me.FillDs(FillTableType.All) Then

            ' Populate customers cbx
            Me.PopulateCustomersCBX()

            ' Populate Location cbx
            Me.PopulatePickUpDropoffCBX(False)

            ' populate shipping line cbx
            Me.PopulateShippingLineCBX()

        Else
            Me.Close()
        End If

        If Me._mode = FormMode.Edit Then
            Me.Text = "Edit Work Order # " & Me._WorkOrderID.ToString
            Me.DisableControls()
            Me.PopulateControls()
        End If

    End Sub

    Private Sub NewWorkOrder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' clean up 
        If Not IsNothing(Me.myDsWo) Then Me.myDsWo.Dispose()
    End Sub

    Private Sub chkPrevMove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrevMove.CheckedChanged

        Dim flag As Boolean = Not Me.chkPrevMove.Checked

        Me.txtOutTIR.Text = String.Empty
        Me.Label16.Enabled = flag
        Me.txtOutTIR.Enabled = flag

    End Sub

    Private Sub chkSaveContainer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSaveContainer.CheckedChanged
        Dim flag As Boolean = Not Me.chkSaveContainer.Checked

        Me.txtInTIR.Text = String.Empty
        Me.Label13.Enabled = flag
        Me.txtInTIR.Enabled = flag
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cbxCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCustomer.SelectedIndexChanged

        Static PrevInd As Integer = -1
        Dim SelInd As Integer = Me.cbxCustomer.SelectedIndex

        If SelInd = PrevInd Then Exit Sub
        PrevInd = SelInd

        ' clear ship to combobox
        Me.cbxShipTo.Items.Clear()

        If SelInd = 1 Then
            ' open new customer form
            Dim frm As New NewCustomer
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        ElseIf SelInd > 1 Then
            ' customer selected
            ' populate ship to combobox
            Me.cbxShipTo.Items.Add(String.Empty)
            Me.cbxShipTo.Items.Add("<Create New>")

            For Each Row As DataRow In Me.myDsWo.Tables("ShipTo").Rows
                If Row.Item("Customer Name").ToString = Me.cbxCustomer.Text Then
                    Me.cbxShipTo.Items.Add(Row.Item("ShipTo Name").ToString)
                End If
            Next

        End If

        Me.btnCustomerDetails.Enabled = (SelInd > 1)

    End Sub

    Private Sub cbxShipTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxShipTo.SelectedIndexChanged

        If Me.cbxShipTo.SelectedIndex = 1 Then
            ' open new ship to dialog box

            ' get the customer Id from the dataset
            Dim CustRows() As Data.DataRow = Me.myDsWo.Tables("Customers").Select("[Customer Name]='" & Me.cbxCustomer.Text & "'")
            Dim CId As Integer = CInt(CustRows(0).Item("Customer ID"))

            Dim frm As New NewShipTo(CId, Me.cbxCustomer.Text)
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        ElseIf Me.cbxShipTo.SelectedIndex > 1 Then

            Dim Rows As DataRow() = Me.myDsWo.Tables("ShipTo").Select("[ShipTo Name]='" & GS.FilterSingleQuote(Me.cbxShipTo.Text) & _
            "' AND [Customer Name]='" & GS.FilterSingleQuote(Me.cbxCustomer.Text) & "'")
            Dim RateString As String = Rows(0).Item("Rate").ToString

            GS.FillRateListView(Me.lsvRate, RateString)
            Me.CalculateRateTotal()

            Me._oldRate = RateString

        End If

        Me.btnShipToDetails.Enabled = (Me.cbxShipTo.SelectedIndex > 1)

    End Sub

    Private Sub chkDelDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDelDate.CheckedChanged
        Dim flag As Boolean = Me.chkDelDate.Checked

        Me.dtpDelDate.Enabled = flag
        Me.cbxDelHour.Enabled = flag
        Me.cbxDelMinute.Enabled = flag
        Me.cbxDelAMPM.Enabled = flag
        Me.Label18.Enabled = flag

    End Sub

    Private Sub chkPickupDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPickupDate.CheckedChanged
        Me.dtpPickup.Enabled = Me.chkPickupDate.Checked
    End Sub

    Private Sub chkDropOffDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDropOffDate.CheckedChanged
        Dim flag As Boolean = Me.chkDropOffDate.Checked

        Me.dtpDropOff.Enabled = flag
        Me.cbxDropOffHour.Enabled = flag
        Me.cbxDropOffMinute.Enabled = flag
        Me.cbxDropOffAMPM.Enabled = flag
        Me.Label14.Enabled = flag

    End Sub

    Private Sub cbxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxType.SelectedIndexChanged

        Static PrevSelIndex As Integer = -1
        Dim SelIndex As Integer = Me.cbxType.SelectedIndex
        Dim flag As Boolean = (SelIndex <> 3)

        ' fixes unwanted result
        If SelIndex = PrevSelIndex Then Exit Sub

        Select Case SelIndex
            Case -1, 0
                Me.radLD.Enabled = False
                Me.radMT.Enabled = False
                Me.radLD.Checked = False
                Me.radMT.Checked = False
            Case 1
                Me.radLD.Enabled = False
                Me.radMT.Enabled = False
                Me.radLD.Checked = True
                Me.radMT.Checked = False
            Case 2
                Me.radLD.Enabled = False
                Me.radMT.Enabled = False
                Me.radLD.Checked = False
                Me.radMT.Checked = True
            Case 3
                Me.radLD.Enabled = True
                Me.radMT.Enabled = True
                Me.radLD.Checked = False
                Me.radMT.Checked = False
        End Select

        If (PrevSelIndex = 3 And SelIndex <> 3) Or (PrevSelIndex <> 3 And SelIndex = 3) Then _
            Me.PopulatePickUpDropoffCBX(Not flag)

        'Me.chkDelDate.Enabled = flag
        'Me.dtpDelDate.Enabled = (flag And Me.chkDelDate.Checked)
        'Me.cbxDelHour.Enabled = (flag And Me.chkDelDate.Checked)
        'Me.cbxDelMinute.Enabled = (flag And Me.chkDelDate.Checked)
        'Me.cbxDelAMPM.Enabled = (flag And Me.chkDelDate.Checked)

        Me.chkPrevMove.Enabled = flag
        Me.txtOutTIR.Enabled = (flag And Not Me.chkPrevMove.Checked)
        Me.Label16.Enabled = (flag And Not Me.chkPrevMove.Checked)

        Me.cbxDropOff.Enabled = flag
        Me.Label12.Enabled = flag
        Me.btnDropOffDetails.Enabled = (flag And Me.cbxDropOff.SelectedIndex > 1)
        Me.chkDropOffDate.Enabled = flag
        Me.dtpDropOff.Enabled = (flag And Me.chkDropOffDate.Checked)
        Me.cbxDropOffHour.Enabled = (flag And Me.chkDropOffDate.Checked)
        Me.cbxDropOffMinute.Enabled = (flag And Me.chkDropOffDate.Checked)
        Me.cbxDropOffAMPM.Enabled = (flag And Me.chkDropOffDate.Checked)
        Me.Label14.Enabled = (flag And Me.chkDropOffDate.Checked)
        Me.chkSaveContainer.Enabled = flag
        Me.txtInTIR.Enabled = (flag And Not Me.chkSaveContainer.Checked)
        Me.Label13.Enabled = (flag And Not Me.chkSaveContainer.Checked)

        PrevSelIndex = SelIndex

    End Sub

    Private Sub cbxPickupDropOff_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxPickup.SelectedIndexChanged, cbxDropOff.SelectedIndexChanged

        Dim cbxSender As ComboBox = CType(sender, ComboBox)

        If cbxSender.SelectedIndex = 1 Then
            Dim frm As New NewLocation
            frm.Owner = Me
            frm.PickUpDropOffLocation = True
            frm.ComboBoxOwner = cbxSender
            frm.ShowDialog()
            frm.Dispose()
        End If

        If CInt(cbxSender.Tag) = 1 Then
            Me.btnPickupDetails.Enabled = (cbxSender.SelectedIndex > 1)
        Else
            Me.btnDropOffDetails.Enabled = (cbxSender.SelectedIndex > 1)
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click, btnSaveClose.Click

        Dim SaveClose As Boolean = (CType(sender, Button).Name = "btnSaveClose")
        Dim ErrMsg As String = String.Empty

        Me.Cursor = Cursors.WaitCursor

        ' trim text boxes
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox1)
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox2)
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox3)
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox4)
        Me.cbxShippingLine.Text = Trim(Me.cbxShippingLine.Text)

        ' validate fields
        If Not Me.ValidateFields() Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If Me.InputData(ErrMsg) Then

            ' refresh WO list if open
            If GS.FormIsOpen(My.Forms.Form1.frmWrkOrderList) Then
                My.Forms.Form1.frmWrkOrderList.RefreshList()
            End If

            ' refresh WODetails if open
            If Me._mode = FormMode.Edit AndAlso GS.DetailFormIsOpen(My.Forms.Form1.frmWoDetails, Me._WorkOrderID) Then
                My.Forms.Form1.frmWoDetails.RefreshData()
            End If

            ' refresh Container list if open
            If GS.FormIsOpen(My.Forms.Form1.frmContainerList) Then
                My.Forms.Form1.frmContainerList.tsbRefresh_Click(Nothing, Nothing)
            End If

            ' refresh Work Order Lists from Dispatch window if open
            If GS.FormIsOpen(My.Forms.Form1.frmDispatch) Then
                My.Forms.Form1.frmDispatch.tsbRefreshWo_Click(Nothing, Nothing)
                My.Forms.Form1.frmDispatch.RefreshMain()
            End If

            If SaveClose Then
                Me.Close()
            Else
                MessageBox.Show("The New Work Order was created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' clear fields
                If Not Me.chkKeepWoInfo.Checked Then Me.ResetControl(Me.GroupBox1)
                Me.ResetControl(Me.GroupBox2)
                Me.ResetControl(Me.GroupBox3)
                Me.ResetControl(Me.GroupBox4)

            End If
        Else
            MessageBox.Show("An error occured while the data was being sent to the database." & _
                      vbCrLf & vbCrLf & "Details: " & ErrMsg & vbCrLf & vbCrLf & _
                      "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TextBoxes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContNum.LostFocus, _
        txtBL.LostFocus, txtInTIR.LostFocus, txtOutTIR.LostFocus, txtRefNum.LostFocus, txtChsNumber.LostFocus

        ' on LostFocus convert text to upper case
        Dim myTxt As TextBox = CType(sender, TextBox)
        myTxt.Text = UCase(myTxt.Text)

    End Sub

    Private Sub btnCustomerDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomerDetails.Click
        Dim frm As New NewCustomer
        frm.Owner = Me
        frm.Mode = FormMode.Details

        ' get the customer Id from the dataset
        Dim CustRows() As Data.DataRow = Me.myDsWo.Tables("Customers").Select("[Customer Name]='" & GS.FilterSingleQuote(Me.cbxCustomer.Text) & "'")
        frm.CustomerID = CInt(CustRows(0).Item("Customer ID"))

        frm.ShowDialog()
        frm.Dispose()

    End Sub

    Private Sub btnShipToDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShipToDetails.Click

        Dim CustRows() As Data.DataRow = Me.myDsWo.Tables("Customers").Select("[Customer Name]='" & GS.FilterSingleQuote(Me.cbxCustomer.Text) & "'")
        Dim custID As Integer = CInt(CustRows(0).Item("Customer ID"))
        Dim ShToRows() As Data.DataRow = Me.myDsWo.Tables("ShipTo").Select("[ShipTo Name]='" & GS.FilterSingleQuote(Me.cbxShipTo.Text) & _
            "' AND [Customer Name]='" & GS.FilterSingleQuote(Me.cbxCustomer.Text) & "'")
        Dim shipToID As Integer = CInt(ShToRows(0).Item("ShipTo ID"))

        Dim frm As New NewShipTo(custID, Me.cbxCustomer.Text, shipToID)
        frm.Mode = FormMode.Details
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()

    End Sub

    Private Sub btnPickupDropOffDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickupDetails.Click, btnDropOffDetails.Click

        Dim myCBX As ComboBox = Nothing

        If CInt(CType(sender, Button).Tag) = 1 Then
            myCBX = Me.cbxPickup
        Else
            myCBX = Me.cbxDropOff
        End If

        Dim frm As New NewLocation
        frm.Owner = Me
        frm.Mode = FormMode.Details

        Dim LocRows() As DataRow = Me.myDsWo.Tables("Location").Select("[Location Name]='" & GS.FilterSingleQuote(myCBX.Text) & "'")
        frm.LocationID = CInt(LocRows(0).Item("Location ID"))

        frm.ShowDialog()
        frm.Dispose()

    End Sub

    Private Sub txtWeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWeight.LostFocus
        If IsNumeric(Me.txtWeight.Text) AndAlso (CLng(Me.txtWeight.Text) <= 2147483647 And CLng(Me.txtWeight.Text) > 0) Then
            Me.txtWeight.Text = Format(CInt(Me.txtWeight.Text), "#,###,###,###")
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim ErrFlag As Boolean = False
        Dim ErrMsg As String = ""

        Me.cbxDescription.Text = Me.cbxDescription.Text.Trim()

        ' validate Rate
        If Me.cbxDescription.Text.IndexOf("|") >= 0 Or Me.cbxDescription.Text.IndexOf(":") >= 0 Then
            ErrMsg = "The characters ""|"" and "":"" cannot be used in the Rate Description field."
            ErrFlag = True
            Me.cbxDescription.Focus()
        ElseIf Not IsNumeric(Me.txtAmount.Text.Trim) Then
            ErrMsg = "Invalid Rate Amount."
            ErrFlag = True
            Me.txtAmount.Focus()
        End If

        If ErrFlag Then
            MessageBox.Show(ErrMsg, "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim lsvItem As New ListViewItem(Me.cbxDescription.Text)
            lsvItem.SubItems.Add(Format(CDbl(Me.txtAmount.Text.Trim), "Standard"))
            Me.lsvRate.Items.Add(lsvItem)
            Me.cbxDescription.Text = ""
            Me.txtAmount.Text = ""
            Me.CalculateRateTotal()
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Me.lsvRate.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a list item.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Me.lsvRate.Items.RemoveAt(Me.lsvRate.SelectedItems(0).Index)
            Me.CalculateRateTotal()
        End If
    End Sub

    Private Sub txtAmount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyDown
        If e.KeyValue = 13 Then _
            Me.btnAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub txtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.LostFocus

        If IsNumeric(Me.txtAmount.Text.Trim) Then _
            Me.txtAmount.Text = Format(CDbl(Me.txtAmount.Text.Trim), "Standard")

    End Sub

    Private Sub chkBillingBillable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBillingBillable.CheckedChanged

        Dim flag As Boolean = Me.chkBillingBillable.Checked

        Me.radBillingNotBilled.Enabled = flag
        Me.radBillingReadyToBill.Enabled = flag
        Me.radBillingBilled.Enabled = flag

    End Sub

#End Region 'Control Events

#Region "Methods and Properties"

    Private Sub CalculateRateTotal()
        Dim Total As Double = 0
        Dim EmptyFlag As Boolean = True

        For Each li As ListViewItem In Me.lsvRate.Items
            Total += CDbl(li.SubItems(1).Text)
            EmptyFlag = False
        Next

        If EmptyFlag Then
            Me.txtTotal.Text = ""
        Else
            Me.txtTotal.Text = Format(Total, "Standard")
        End If
    End Sub

    Private Sub PopulateControls()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myDa As New SqlClient.SqlDataAdapter("SELECT * FROM [WorkOrders] WHERE [WorkOrders].[WorkOrder ID]=" & Me._WorkOrderID.ToString, myConn)
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False

        Try
            myDa.Fill(myDs, "WorkOrders")
        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                            "Details: " & ex.Message & "Please check your connection and try again.", "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
            Exit Sub
        End If

        ' select the first and only selectde row
        Dim Row As DataRow = myDs.Tables("WorkOrders").Rows(0)

        ' if status is closed, exit
        If CInt(Row.Item("status")) = 2 Then
            MessageBox.Show("The Work Order selected is closed and cannot be edited.", "Can't Edit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
            Exit Sub
        End If

        ' customer name
        Dim CustRows() As DataRow = Me.myDsWo.Tables("Customers").Select("[Customer ID]='" & Row.Item("Customer ID").ToString & "'")
        Dim CustName As String = CustRows(0).Item("Customer Name").ToString

        For i As Integer = 0 To Me.cbxCustomer.Items.Count - 1
            If Me.cbxCustomer.Items.Item(i).ToString = CustName Then
                Me.cbxCustomer.SelectedIndex = i
                Exit For
            End If
        Next

        ' shipto name
        Dim ShipToRows() As DataRow = Me.myDsWo.Tables("ShipTo").Select("[ShipTo ID]='" & Row.Item("ShipTo ID").ToString & "'")
        Dim ShipToName As String = ShipToRows(0).Item("ShipTo Name").ToString

        For i As Integer = 0 To Me.cbxShipTo.Items.Count - 1
            If Me.cbxShipTo.Items.Item(i).ToString = ShipToName Then
                Me.cbxShipTo.SelectedIndex = i
                Exit For
            End If
        Next

        ' consegnee
        Me.txtConsignee.Text = Row.Item("Consignee").ToString

        ' reference
        Me.txtRefNum.Text = Row.Item("Reference").ToString

        ' move type
        Me.cbxType.SelectedIndex = CInt(Row.Item("Move Type"))

        ' rate
        GS.FillRateListView(Me.lsvRate, Row.Item("Rate").ToString)
        Me.CalculateRateTotal()
        Me._oldRate = Row.Item("Rate").ToString

        ' billing
        Select Case CInt(Row.Item("Billing"))
            Case 0
                Me.chkBillingBillable.Checked = False
            Case 1
                Me.chkBillingBillable.Checked = True
                Me.radBillingNotBilled.Checked = True
            Case 2
                Me.chkBillingBillable.Checked = True
                Me.radBillingReadyToBill.Checked = True
            Case 3
                Me.chkBillingBillable.Checked = True
                Me.radBillingBilled.Checked = True
        End Select

        Me.chkBillingBillable_CheckedChanged(Nothing, Nothing)

        ' delivery date
        If Not IsDBNull(Row.Item("Delivery Date")) Then
            Dim DelDate As Date = CDate(Row.Item("Delivery Date"))
            Dim hflag As Integer = DelDate.Hour
            Dim mFlag As Integer = DelDate.Minute
            Dim AmPmFlag As Integer = 1

            Me.chkDelDate.Checked = True

            If hflag > 11 Then
                hflag -= 12
                AmPmFlag = 2
            End If

            If hflag = 0 Then hflag = 12

            mFlag = CInt((mFlag / 15) + 1)

            Me.dtpDelDate.Value = DelDate
            Me.cbxDelHour.SelectedIndex = hflag
            Me.cbxDelMinute.SelectedIndex = mFlag
            Me.cbxDelAMPM.SelectedIndex = AmPmFlag
        End If

        ' remarks
        Me.txtRemarks.Text = Row.Item("Remarks").ToString

        ' inactive
        Me.chkInactive.Checked = (CInt(Row.Item("Status")) = 1)

        ' cont. number
        Me.txtContNum.Text = Row.Item("Container Number").ToString

        ' bk bl number
        Me.txtBL.Text = Row.Item("BK BL").ToString

        ' shipping line
        Me.cbxShippingLine.Text = Row.Item("Shipping Line").ToString

        ' chassis number
        Me.txtChsNumber.Text = Row.Item("Chassis Number").ToString

        ' commodity
        Me.txtCommodity.Text = Row.Item("Commodity").ToString

        ' weight
        If Not IsDBNull(Row.Item("Load Weight")) Then
            Me.txtWeight.Text = Format(CInt(Row.Item("Load Weight")), "#,###,###,###")
        End If

        ' size
        Me.cbxSize.Text = Row.Item("Container Size").ToString

        ' cont. type
        Me.cbxContType.Text = Row.Item("Container Type").ToString

        ' Hazard
        Me.chkHazardous.Checked = CBool(Row.Item("Hazardous"))

        ' LD MT
        If Not IsDBNull(Row.Item("LD MT")) Then
            If CInt(Row.Item("LD MT")) = 0 Then
                Me.radLD.Checked = True
            Else
                Me.radMT.Checked = True
            End If
        End If

        ' pickup terminal
        If Not IsDBNull(Row.Item("PickUp Terminal")) Then
            Dim PupRows() As DataRow = Me.myDsWo.Tables("Location").Select("[Location ID]=" & Row.Item("PickUp Terminal").ToString)
            Dim PupTerm As String = PupRows(0).Item("Location Name").ToString
            Me.cbxPickup.Text = PupTerm
        End If

        ' pickup date
        If Not IsDBNull(Row.Item("PickUp Date")) Then
            Me.chkPickupDate.Checked = True
            Me.dtpPickup.Value = CDate(Row.Item("PickUp Date"))
        End If

        ' prev_wo and TIR out
        If CBool(Row.Item("Prev_WO")) Then
            Me.chkPrevMove.Checked = True
        Else
            Me.txtOutTIR.Text = Row.Item("Out TIR").ToString
        End If

        ' Drop Off Terminal
        If Not IsDBNull(Row.Item("DropOff Terminal")) Then
            Dim DrRows() As DataRow = Me.myDsWo.Tables("Location").Select("[Location ID]=" & Row.Item("DropOff Terminal").ToString)
            Dim DrTerm As String = DrRows(0).Item("Location Name").ToString
            Me.cbxDropOff.Text = DrTerm
        End If

        ' DropOff Date
        If Not IsDBNull(Row.Item("DropOff Date")) Then
            Dim DrDate As Date = CDate(Row.Item("DropOff Date"))
            Dim hFlag As Integer = DrDate.Hour
            Dim mFlag As Integer = DrDate.Minute
            Dim AmPmFlag As Integer = 1

            Me.chkDropOffDate.Checked = True

            If hFlag > 11 Then
                hFlag -= 12
                AmPmFlag = 2
            End If

            If hFlag = 0 Then hFlag = 12

            mFlag = CInt((mFlag / 15) + 1)

            Me.dtpDropOff.Value = DrDate
            Me.cbxDropOffHour.SelectedIndex = hFlag
            Me.cbxDropOffMinute.SelectedIndex = mFlag
            Me.cbxDropOffAMPM.SelectedIndex = AmPmFlag
        End If

        ' future_wo and TIR in
        If CBool(Row.Item("Future_WO")) Then
            Me.chkSaveContainer.Checked = True
        Else
            Me.txtInTIR.Text = Row.Item("In TIR").ToString
        End If


    End Sub

    Private Sub DisableControls()

        Me.chkKeepWoInfo.Visible = False
        Me.btnSave.Visible = False
        Me.btnSaveClose.Text = "Save"
        Me.GroupBox1.Height = 365

    End Sub

    Private Function InputData(ByRef ErrorMessage As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim CmdStr As String = Me.CreateCommandString()
        Dim flag As Boolean = True
        Dim RateListStr As String = String.Empty

        For Each li As ListViewItem In Me.lsvRate.Items
            RateListStr &= li.SubItems(0).Text & "||" & li.SubItems(1).Text & "::"
        Next

        If RateListStr.Length > 0 And RateListStr <> Me._oldRate Then
            Dim Rows As DataRow() = Me.myDsWo.Tables("ShipTo").Select("[ShipTo Name]='" & GS.FilterSingleQuote(Me.cbxShipTo.Text) & _
            "' AND [Customer Name]='" & GS.FilterSingleQuote(Me.cbxCustomer.Text) & "'")

            If Rows(0).Item("Rate").ToString <> RateListStr AndAlso MessageBox.Show("The Rate for the ShipTo selected was modified." & _
                vbCrLf & vbCrLf & "Would you like to have this new information to appear next time?", "Confirmation", _
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                CmdStr &= "; UPDATE [ShipTo] SET [Rate]='" & GS.FilterSingleQuote(RateListStr) & _
                    "' WHERE [ShipTo ID]=" & Rows(0).Item("ShipTo ID").ToString

            End If

        End If

        myCmd.CommandText = CmdStr
        myCmd.Connection = myConn

        Try

            ' open connection
            myConn.Open()
            ' execute command
            myCmd.ExecuteNonQuery()

        Catch ex As Exception
            ErrorMessage = ex.Message
            flag = False
        Finally
            If Not IsNothing(myConn) AndAlso myConn.State = ConnectionState.Open Then myConn.Close()
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
        End Try

        Return flag

    End Function

    Private Function CreateCommandString() As String
        Dim result As String = String.Empty
        Dim Fd As String = String.Empty
        Dim Val As String = String.Empty
        Dim UpStr As String = String.Empty
        Dim CustomerID As String = String.Empty
        Dim ShipToID As String = String.Empty
        Dim MoveType As String = String.Empty
        Dim myRows() As DataRow

        If Me.txtConsignee.Text.Length > 0 Then
            Fd &= ",[Consignee]"
            Val &= ",'" & GS.FilterSingleQuote(Me.txtConsignee.Text) & "'"
            UpStr &= ",[Consignee]='" & GS.FilterSingleQuote(Me.txtConsignee.Text) & "'"
        Else
            UpStr &= ",[Consignee]=NULL"
        End If

        If Me.txtRefNum.Text.Length > 0 Then
            Fd &= ",[Reference]"
            Val &= ",'" & GS.FilterSingleQuote(Me.txtRefNum.Text) & "'"
            UpStr &= ",[Reference]='" & GS.FilterSingleQuote(Me.txtRefNum.Text) & "'"
        Else
            UpStr &= ",[Reference]=NULL"
        End If

        Dim RateListStr As String = String.Empty
        For Each li As ListViewItem In Me.lsvRate.Items
            RateListStr &= li.SubItems(0).Text & "||" & li.SubItems(1).Text & "::"
        Next

        If RateListStr.Length > 0 Then
            Fd &= ",[Rate]"
            Val &= ",'" & GS.FilterSingleQuote(RateListStr) & "'"
            UpStr &= ",[Rate]='" & GS.FilterSingleQuote(RateListStr) & "'"
        Else
            UpStr &= ",[Rate]=NULL"
        End If

        Dim BillingStatus As Integer = 0

        If Me.chkBillingBillable.Checked Then
            If Me.radBillingNotBilled.Checked Then
                BillingStatus = 1
            ElseIf Me.radBillingReadyToBill.Checked Then
                BillingStatus = 2
            ElseIf Me.radBillingBilled.Checked Then
                BillingStatus = 3
            End If
        End If

        Fd &= ",[Billing]"
        Val &= "," & BillingStatus.ToString
        UpStr &= ",[Billing]=" & BillingStatus.ToString

        If Me.chkDelDate.Checked Then
            Dim DelDate As Date = Nothing
            Dim H As Integer = 0
            Dim M As Integer = 0

            If Me.cbxDelHour.SelectedIndex > 0 Then
                H = CInt(Me.cbxDelHour.Text)
                M = CInt(Me.cbxDelMinute.Text)

                If Me.cbxDelAMPM.SelectedIndex = 1 And H = 12 Then
                    H = 0
                ElseIf Me.cbxDelAMPM.SelectedIndex = 2 And H <> 12 Then
                    H += 12
                End If
            End If

            With Me.dtpDelDate.Value
                DelDate = New Date(.Year, .Month, .Day, H, M, 0)
            End With

            Fd &= ",[Delivery Date]"
            Val &= ",'" & DelDate.ToString & "'"
            UpStr &= ",[Delivery Date]='" & DelDate.ToString & "'"
        Else
            UpStr &= ",[Delivery Date]=NULL"
        End If

        If Me.txtRemarks.Text.Length > 0 Then
            Fd &= ",[Remarks]"
            Val &= ",'" & GS.FilterSingleQuote(Me.txtRemarks.Text) & "'"
            UpStr &= ",[Remarks]='" & GS.FilterSingleQuote(Me.txtRemarks.Text) & "'"
        Else
            UpStr &= ",[Remarks]=NULL"
        End If

        If Me.chkInactive.Checked Then
            Fd &= ",[Status]"
            Val &= ",1"
            UpStr &= ",[Status]=1"
        Else
            UpStr &= ",[Status]=0"
        End If

        If Me.txtContNum.Text.Length > 0 Then
            Fd &= ",[Container Number]"
            Val &= ",'" & GS.FilterSingleQuote(Me.txtContNum.Text) & "'"
            UpStr &= ",[Container Number]='" & GS.FilterSingleQuote(Me.txtContNum.Text) & "'"
        Else
            UpStr &= ",[Container Number]=NULL"
        End If

        If Me.cbxShippingLine.Text.Length > 0 Then
            Fd &= ",[Shipping Line]"
            Val &= ",'" & GS.FilterSingleQuote(Me.cbxShippingLine.Text) & "'"
            UpStr &= ",[Shipping Line]='" & GS.FilterSingleQuote(Me.cbxShippingLine.Text) & "'"
        Else
            UpStr &= ",[Shipping Line]=NULL"
        End If

        If Me.txtChsNumber.Text.Length > 0 Then
            Fd &= ",[Chassis Number]"
            Val &= ",'" & GS.FilterSingleQuote(Me.txtChsNumber.Text) & "'"
            UpStr &= ",[Chassis Number]='" & GS.FilterSingleQuote(Me.txtChsNumber.Text) & "'"
        Else
            UpStr &= ",[Chassis Number]=NULL"
        End If

        If Me.txtCommodity.Text.Length > 0 Then
            Fd &= ",[Commodity]"
            Val &= ",'" & GS.FilterSingleQuote(Me.txtCommodity.Text) & "'"
            UpStr &= ",[Commodity]='" & GS.FilterSingleQuote(Me.txtCommodity.Text) & "'"
        Else
            UpStr &= ",[Commodity]=NULL"
        End If

        If Me.txtWeight.Text.Length > 0 Then
            Fd &= ",[Load Weight]"
            Val &= "," & CInt(Me.txtWeight.Text).ToString & " "
            UpStr &= ",[Load Weight]=" & CInt(Me.txtWeight.Text).ToString & " "
        Else
            UpStr &= ",[Load Weight]=NULL"
        End If

        If Me.cbxSize.SelectedIndex > 0 Then
            Fd &= ",[Container Size]"
            Val &= "," & Me.cbxSize.Text
            UpStr &= ",[Container Size]='" & Me.cbxSize.Text & "'"
        Else
            UpStr &= ",[Container Size]=NULL"
        End If

        If Me.cbxContType.SelectedIndex > 0 Then
            Fd &= ",[Container Type]"
            Val &= ",'" & Me.cbxContType.Text & "'"
            UpStr &= ",[Container Type]='" & Me.cbxContType.Text & "'"
        Else
            UpStr &= ",[Container Type]=NULL"
        End If

        If Me.chkHazardous.Checked Then
            Fd &= ",[Hazardous]"
            Val &= ",1"
            UpStr &= ",[Hazardous]=1"
        Else
            UpStr &= ",[Hazardous]=0"
        End If

        If Me.radLD.Checked Then
            Fd &= ",[LD MT]"
            Val &= ",0"
            UpStr &= ",[LD MT]=0"
        ElseIf Me.radMT.Checked Then
            Fd &= ",[LD MT]"
            Val &= ",1"
            UpStr &= ",[LD MT]=1"
        Else
            UpStr &= ",[LD MT]=NULL"
        End If

        If Me.cbxPickup.SelectedIndex > 1 Then
            Dim rows() As DataRow = Me.myDsWo.Tables("Location").Select("[Location Name]='" & GS.FilterSingleQuote(Me.cbxPickup.Text) & "'")
            Dim LocID As String = rows(0).Item("Location ID").ToString
            Fd &= ",[PickUp Terminal]"
            Val &= "," & LocID
            UpStr &= ",[PickUp Terminal]=" & LocID
        Else
            UpStr &= ",[PickUp Terminal]=NULL"
        End If

        If Me.chkPickupDate.Checked Then
            Dim PupDate As String = CStr(Me.dtpPickup.Value.Date)
            Fd &= ",[PickUp Date]"
            Val &= ",'" & PupDate & "'"
            UpStr &= ",[PickUp Date]='" & PupDate & "'"
        Else
            UpStr &= ",[PickUp Date]=NULL"
        End If

        If Me.chkPrevMove.Checked Or Me.cbxType.SelectedIndex = 3 Then
            Fd &= ",[Prev_WO]"
            Val &= ",1"
            UpStr &= ",[Prev_WO]=1"
        Else
            If Me.txtOutTIR.Text.Length > 0 Then
                Fd &= ",[Out TIR]"
                Val &= ",'" & GS.FilterSingleQuote(Me.txtOutTIR.Text) & "'"
                UpStr &= ",[Out TIR]='" & GS.FilterSingleQuote(Me.txtOutTIR.Text) & "'"
            Else
                UpStr &= ",[Out TIR]=NULL"
            End If

            UpStr &= ",[Prev_WO]=0"

        End If

        If Me.cbxDropOff.SelectedIndex > 1 And Me.cbxType.SelectedIndex <> 3 Then
            Dim rows() As DataRow = Me.myDsWo.Tables("Location").Select("[Location Name]='" & GS.FilterSingleQuote(Me.cbxDropOff.Text) & "'")
            Dim DrStr As String = rows(0).Item("Location ID").ToString
            Fd &= ",[DropOff Terminal]"
            Val &= "," & DrStr
            UpStr &= ",[DropOff Terminal]=" & DrStr
        Else
            UpStr &= ",[DropOff Terminal]=NULL"
        End If

        If Me.chkDropOffDate.Checked And Me.cbxType.SelectedIndex <> 3 Then
            Dim DropOffDate As Date = Nothing
            Dim H As Integer = 0
            Dim M As Integer = 0

            If Me.cbxDropOffHour.SelectedIndex > 0 Then
                H = CInt(Me.cbxDropOffHour.Text)
                M = CInt(Me.cbxDropOffMinute.Text)

                If Me.cbxDropOffAMPM.SelectedIndex = 1 And H = 12 Then
                    H = 0
                ElseIf Me.cbxDropOffAMPM.SelectedIndex = 2 And H <> 12 Then
                    H += 12
                End If
            End If

            With Me.dtpDropOff.Value
                DropOffDate = New Date(.Year, .Month, .Day, H, M, 0)
            End With

            Fd &= ",[DropOff Date]"
            Val &= ",'" & DropOffDate.ToString & "'"
            UpStr &= ",[DropOff Date]='" & DropOffDate.ToString & "'"
        Else
            UpStr &= ",[DropOff Date]=NULL"
        End If

        If Me.chkSaveContainer.Checked Or Me.cbxType.SelectedIndex = 3 Then
            Fd &= ",[Future_WO]"
            Val &= ",1"
            UpStr &= ",[Future_WO]=1"
        Else
            If Me.txtInTIR.Text.Length > 0 Then
                Fd &= ",[In TIR]"
                Val &= ",'" & GS.FilterSingleQuote(Me.txtInTIR.Text) & "'"
                UpStr &= ",[In TIR]='" & GS.FilterSingleQuote(Me.txtInTIR.Text) & "'"
            Else
                UpStr &= ",[In TIR]=NULL"
            End If
            UpStr &= ",[Future_WO]=0"
        End If

        myRows = Me.myDsWo.Tables("Customers").Select("[Customer Name]='" & GS.FilterSingleQuote(Me.cbxCustomer.Text) & "'")
        CustomerID = myRows(0).Item("Customer ID").ToString

        myRows = Me.myDsWo.Tables("ShipTo").Select("[ShipTo Name]='" & GS.FilterSingleQuote(Me.cbxShipTo.Text) & _
            "' AND [Customer Name]='" & GS.FilterSingleQuote(Me.cbxCustomer.Text) & "'")
        ShipToID = myRows(0).Item("ShipTo ID").ToString

        MoveType = Me.cbxType.SelectedIndex.ToString

        If Me._mode = FormMode.CreateNew Then
            result = "INSERT INTO [WorkOrders] ([WorkOrder Date],[Customer ID],[ShipTo ID],[Move Type],[BK BL]" & Fd & ") " & _
                     "VALUES ('" & Now.ToString & "'," & CustomerID & "," & ShipToID & "," & MoveType & ",'" & GS.FilterSingleQuote(Me.txtBL.Text) & "'" & Val & ")"
        Else
            result = "UPDATE [WorkOrders] SET [Customer ID]=" & CustomerID & ",[ShipTo ID]=" & ShipToID & _
                ",[Move Type]=" & MoveType & ",[BK BL]='" & GS.FilterSingleQuote(Me.txtBL.Text) & "'" & UpStr & _
                " WHERE [WorkOrder ID]=" & Me._WorkOrderID.ToString
        End If

        Return result

    End Function

    Private Function ValidateFields() As Boolean

        Dim flag As Boolean = True
        Dim ErrMsg As String = String.Empty

        ' validate customers
        If Me.cbxCustomer.SelectedIndex <= 1 Then
            ErrMsg = "Please Select a Customer."
            Me.TabControl1.SelectedIndex = 0
            Me.cbxCustomer.Focus()
            flag = False
        ElseIf Me.cbxShipTo.SelectedIndex <= 1 Then
            ErrMsg = "Please Select a ShipTo."
            Me.TabControl1.SelectedIndex = 0
            Me.cbxShipTo.Focus()
            flag = False
        ElseIf Me.txtBL.Text.Length = 0 Then
            ErrMsg = "Please enter a valid BK/BL Number."
            Me.TabControl1.SelectedIndex = 0
            Me.txtBL.Focus()
            flag = False
        ElseIf Me.cbxType.SelectedIndex < 1 Then
            ErrMsg = "Please Select a Move Type."
            Me.TabControl1.SelectedIndex = 0
            Me.cbxType.Focus()
            flag = False
        ElseIf Not Regex.IsMatch(Me.txtContNum.Text, "(^([a-z]{4})(\d{6,7})$)|(^$)", RegexOptions.IgnoreCase) Then
            ErrMsg = "Please enter a valid Container Number."
            Me.TabControl1.SelectedIndex = 1
            Me.txtContNum.Focus()
            flag = False
        ElseIf Me.txtWeight.Text <> "" And Not IsNumeric(Me.txtWeight.Text) Then
            ErrMsg = "Invalid Weight."
            Me.TabControl1.SelectedIndex = 1
            Me.txtWeight.Focus()
            flag = False
        ElseIf Me.txtWeight.Text <> "" AndAlso (CLng(Me.txtWeight.Text) > 2147483647 Or CLng(Me.txtWeight.Text) < 0) Then
            ErrMsg = "The Weight value cannot be negative or greater than 2,147,483,647."
            Me.TabControl1.SelectedIndex = 1
            Me.txtWeight.Focus()
            flag = False
        ElseIf Me.chkDelDate.Checked And Not ((Me.cbxDelHour.SelectedIndex > 0 And Me.cbxDelMinute.SelectedIndex > 0 And Me.cbxDelAMPM.SelectedIndex > 0) Or _
            (Me.cbxDelHour.SelectedIndex <= 0 And Me.cbxDelMinute.SelectedIndex <= 0 And Me.cbxDelAMPM.SelectedIndex <= 0)) Then
            ErrMsg = "Invalid Delivery time."
            Me.TabControl1.SelectedIndex = 2
            Me.cbxDelHour.Focus()
            flag = False
        ElseIf Me.chkDropOffDate.Checked And Not ((Me.cbxDropOffHour.SelectedIndex > 0 And Me.cbxDropOffMinute.SelectedIndex > 0 And Me.cbxDropOffAMPM.SelectedIndex > 0) Or _
                    (Me.cbxDropOffHour.SelectedIndex <= 0 And Me.cbxDropOffMinute.SelectedIndex <= 0 And Me.cbxDropOffAMPM.SelectedIndex <= 0)) Then
            ErrMsg = "Invalid Drop Off time."
            Me.TabControl1.SelectedIndex = 2
            Me.cbxDelHour.Focus()
            flag = False
        ElseIf Me.chkPickupDate.Checked And Me.chkDropOffDate.Checked And Me.dtpPickup.Value.Date > Me.dtpDropOff.Value.Date Then
            ErrMsg = "The Drop Off date cannot be earlier than the Pick Up date."
            Me.TabControl1.SelectedIndex = 2
            Me.dtpPickup.Focus()
            flag = False
        ElseIf Me.chkPickupDate.Checked And Me.chkDelDate.Checked And Me.dtpPickup.Value.Date > Me.dtpDelDate.Value.Date Then
            ErrMsg = "The Delivery date cannot be earlier than the Pick Up date."
            Me.TabControl1.SelectedIndex = 2
            Me.dtpPickup.Focus()
            flag = False
        ElseIf Me.chkDropOffDate.Checked And Me.chkDelDate.Checked And Me.dtpDropOff.Value.Date < Me.dtpDelDate.Value.Date Then
            ErrMsg = "The Drop Off date cannot be earlier than the Delivery date."
            Me.TabControl1.SelectedIndex = 2
            Me.dtpDelDate.Focus()
            flag = False
        ElseIf Me.cbxType.SelectedIndex = 3 And Me.cbxPickup.SelectedIndex < 2 Then
            ErrMsg = "Please select a PickUp Terminal."
            Me.TabControl1.SelectedIndex = 2
            Me.cbxPickup.Focus()
            flag = False
        End If

        If Not flag Then
            MessageBox.Show(ErrMsg, "Invalid Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Return flag

    End Function

    Private Sub ResetControl(ByVal myControl As Control)
        Select Case UCase(myControl.GetType.Name)
            Case "CHECKBOX"
                Dim chk As CheckBox = CType(myControl, CheckBox)
                chk.Checked = False
            Case "TEXTBOX"
                Dim txt As TextBox = CType(myControl, TextBox)
                txt.Text = String.Empty
            Case "DATETIMEPICKER"
                Dim dtp As DateTimePicker = CType(myControl, DateTimePicker)
                dtp.Value = Now
            Case "COMBOBOX"
                Dim cbx As ComboBox = CType(myControl, ComboBox)
                If cbx.DropDownStyle = ComboBoxStyle.DropDown Then
                    cbx.Text = String.Empty
                Else
                    cbx.SelectedIndex = -1
                End If
            Case "GROUPBOX"
                Dim grp As GroupBox = CType(myControl, GroupBox)
                For Each c As Control In grp.Controls
                    ResetControl(c)
                Next
        End Select
    End Sub


    Friend Function FillDs(ByVal Table As FillTableType) As Boolean
        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDaCust As New SqlClient.SqlDataAdapter
        Dim CmdStrCust As String = String.Empty
        Dim myDaShipTo As New SqlClient.SqlDataAdapter
        Dim CmdStrShipTo As String = String.Empty
        Dim myDaLocation As New SqlClient.SqlDataAdapter
        Dim CmdStrLocation As String = String.Empty
        Dim myDaShippingLine As New SqlClient.SqlDataAdapter
        Dim CmdStrShippingLine As String = String.Empty
        Dim flag As Boolean = True

        ' customers
        CmdStrCust = "SELECT [Customer ID], [Customer Name] FROM Customers WHERE [Inactive]=0"
        If Me._mode <> FormMode.CreateNew Then
            CmdStrCust &= " OR [Customer ID]=(SELECT [Customer ID] FROM [WorkOrders] WHERE [WorkOrder ID]=" & Me._WorkOrderID.ToString & ")"
        End If
        CmdStrCust &= " ORDER BY [Customer Name]"

        ' ShipTo
        CmdStrShipTo = "SELECT [ShipTo].[ShipTo ID],[ShipTo].[ShipTo Name], [Customers].[Customer Name]," & _
            "[ShipTo].[Rate] FROM [ShipTo] JOIN [Customers] ON [ShipTo].[Customer ID] = [Customers].[Customer ID]" & _
            "WHERE ([ShipTo].[Inactive]=0 AND [Customers].[Inactive]=0)"
        If Me._mode <> FormMode.CreateNew Then
            CmdStrShipTo &= " OR [ShipTo].[ShipTo ID]=(SELECT [ShipTo ID] FROM [WorkOrders] WHERE [WorkOrder ID]=" & Me._WorkOrderID.ToString & ")"
        End If
        CmdStrShipTo &= " ORDER BY [ShipTo].[ShipTo Name]"

        ' Location
        CmdStrLocation = "SELECT [Location ID], [Location Name], [PickUp DropOff], [Inactive] FROM Location WHERE [Inactive]=0"
        If Me._mode <> FormMode.CreateNew Then
            CmdStrLocation &= "OR [Location ID]=(SELECT [PickUp Terminal] FROM [WorkOrders] WHERE [WorkOrder ID]=" & Me._WorkOrderID.ToString & ")" & _
                              "OR [Location ID]=(SELECT [DropOff Terminal] FROM [WorkOrders] WHERE [WorkOrder ID]=" & Me._WorkOrderID.ToString & ")"
        End If
        CmdStrLocation &= " ORDER BY [Location Name]"

        ' Shipping Line
        CmdStrShippingLine = "SELECT DISTINCT [Shipping Line] FROM [WorkOrders]"

        Try

            myConn.Open()

            myCmd.Connection = myConn

            If Table = FillTableType.All Or Table = FillTableType.Customers Then
                myCmd.CommandText = CmdStrCust
                myDaCust.SelectCommand = myCmd
                Me.myDsWo.Tables("Customers").Clear()
                myDaCust.Fill(Me.myDsWo, "Customers")
            End If

            If Table = FillTableType.All Or Table = FillTableType.ShipTo Then
                myCmd.CommandText = CmdStrShipTo
                myDaShipTo.SelectCommand = myCmd
                Me.myDsWo.Tables("ShipTo").Clear()
                myDaShipTo.Fill(Me.myDsWo, "ShipTo")
            End If

            If Table = FillTableType.All Or Table = FillTableType.Location Then
                myCmd.CommandText = CmdStrLocation
                myDaLocation.SelectCommand = myCmd
                Me.myDsWo.Tables("Location").Clear()
                myDaLocation.Fill(Me.myDsWo, "Location")
            End If

            If Table = FillTableType.All Or Table = FillTableType.ShippingLine Then
                myCmd.CommandText = CmdStrShippingLine
                myDaShippingLine.SelectCommand = myCmd
                Me.myDsWo.Tables("ShippingLine").Clear()
                myDaShippingLine.Fill(Me.myDsWo, "ShippingLine")
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDaCust) Then myDaCust.Dispose()
            If Not IsNothing(myDaShipTo) Then myDaShipTo.Dispose()
            If Not IsNothing(myDaLocation) Then myDaLocation.Dispose()
            If Not IsNothing(myDaShippingLine) Then myDaShippingLine.Dispose()
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
        End Try

        Return flag

    End Function

    Private Sub PopulateCustomersCBX()

        Me.cbxCustomer.Items.Clear()

        Me.cbxCustomer.Items.Add(String.Empty)
        Me.cbxCustomer.Items.Add("<Create New>")

        For Each Row As DataRow In Me.myDsWo.Tables("Customers").Rows
            Me.cbxCustomer.Items.Add(Row.Item("Customer Name").ToString)
        Next

    End Sub

    Private Sub PopulatePickUpDropoffCBX(ByVal InternalFreight As Boolean)

        Me.cbxPickup.Items.Clear()
        Me.cbxPickup.Items.Add(String.Empty)
        Me.cbxPickup.Items.Add("<Create New>")

        Me.cbxDropOff.Items.Clear()
        Me.cbxDropOff.Items.Add(String.Empty)
        Me.cbxDropOff.Items.Add("<Create New>")

        Dim Comp As String = String.Empty

        If InternalFreight Then
            Comp = "0"
        Else
            Comp = "1"
        End If

        Dim Rows As DataRow() = Me.myDsWo.Tables("Location").Select("[PickUp DropOff]=" & Comp)

        For Each Row As Data.DataRow In Rows
            Me.cbxPickup.Items.Add(Row.Item("Location Name"))
            Me.cbxDropOff.Items.Add(Row.Item("Location Name"))
        Next

    End Sub

    Private Sub PopulateShippingLineCBX()

        ' clear old items
        Me.cbxShippingLine.Items.Clear()

        For Each Row As DataRow In Me.myDsWo.Tables("ShippingLine").Rows
            Me.cbxShippingLine.Items.Add(Row.Item("Shipping Line"))
        Next

    End Sub

    Friend Property Mode() As FormMode
        Get
            Return Me._mode
        End Get
        Set(ByVal value As FormMode)

            If value = FormMode.Details Then _
                Throw New Exception("The mode 'Details' is not supported in this form.")

            Me._mode = value

        End Set
    End Property

    Friend Property WorkOrderID() As Integer
        Get
            Return Me._WorkOrderID
        End Get
        Set(ByVal value As Integer)
            Me._WorkOrderID = value
        End Set
    End Property

#End Region ' Methods and Properties

End Class