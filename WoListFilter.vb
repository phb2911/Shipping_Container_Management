
Imports System.Text.RegularExpressions

Public Class WoListFilter

    Dim _OkPressed As Boolean = False
    Dim _FilteringStr As String = ""

    Private Sub WoListFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkIdShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIdShowAll.CheckedChanged
        Dim flag As Boolean = Not Me.chkIdShowAll.Checked
        Me.Label1.Enabled = flag
        Me.txtWoId.Enabled = flag
    End Sub

    Private Sub ChkCustShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkCustShowAll.CheckedChanged
        Dim flag As Boolean = Not Me.ChkCustShowAll.Checked
        Me.Label3.Enabled = flag
        Me.txtCustomer.Enabled = flag
    End Sub

    Private Sub chkShToShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShToShowAll.CheckedChanged
        Dim flag As Boolean = Not Me.chkShToShowAll.Checked
        Me.Label4.Enabled = flag
        Me.txtShipTo.Enabled = flag
    End Sub

    Private Sub chkRefShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRefShowAll.CheckedChanged
        Dim flag As Boolean = Not Me.chkRefShowAll.Checked
        Me.Label5.Enabled = flag
        Me.txtRef.Enabled = flag
    End Sub

    Private Sub chkContShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkContShowAll.CheckedChanged
        Dim flag As Boolean = Not Me.chkContShowAll.Checked
        Me.Label6.Enabled = flag
        Me.txtCont.Enabled = flag
    End Sub

    Private Sub chkBKBLShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBKBLShowAll.CheckedChanged
        Dim flag As Boolean = Not Me.chkBKBLShowAll.Checked
        Me.Label7.Enabled = flag
        Me.txtBkBl.Enabled = flag
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim ErrMsg As String = String.Empty
        Dim Criteria As String = String.Empty

        ' trim all textboxes
        For Each ct As Control In Me.Controls
            If ct.GetType.Name = "GroupBox" Then GS.TrimAllTextBoxesInGroupBox(CType(ct, GroupBox))
        Next

        If Me.CreateCriteria(Criteria, ErrMsg) Then

            Me._FilteringStr = Criteria
            Me._OkPressed = True

            Me.Close()

        Else
            MessageBox.Show(ErrMsg, "Invalid Criteria", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Function CreateCriteria(ByRef CriteriaString As String, ByRef ErrorMessage As String) As Boolean

        Dim AndFlag As Boolean = False

        If Not Me.ChkStatusActive.Checked And Not Me.chkStatusClosed.Checked And Not Me.chkStatusInactive.Checked Then

            ErrorMessage = "Invalid Status."
            Return False

        ElseIf Not Me.chkBillingNotBillable.Checked And Me.chkBillingNotBilled.Checked And _
            Not Me.chkBillingReadyToBill.Checked And Not Me.chkBillingBilled.Checked Then

            ErrorMessage = "Invalid Billing Status."
            Return False

        End If

        ' WO ID
        If Not Me.chkIdShowAll.Checked And Me.txtWoId.Text.Length > 0 Then
            Dim ds() As String = Split(Me.txtWoId.Text, ",")
            Dim flag As Boolean = False
            Dim orFlag As Boolean = False

            For Each d As String In ds

                d = Trim(d)

                ' validate ids
                If Not Regex.IsMatch(d, "^((\d)+|(\d+-\d+)|())$") Then
                    ErrorMessage = "Invalid ID Number."
                    Me.txtWoId.Focus()
                    Return False
                End If

                If Regex.IsMatch(d, "^(\d+)$") Then

                    If Not flag Then CriteriaString &= "("
                    If orFlag Then CriteriaString &= " OR "

                    CriteriaString &= " [WorkOrders].[WorkOrder ID]=" & d & " "

                    flag = True
                    orFlag = True
                    AndFlag = True

                ElseIf Regex.IsMatch(d, "^(\d+-\d+)$") Then

                    Dim sd() As String = Split(d, "-")

                    If Not flag Then CriteriaString &= "("
                    If orFlag Then CriteriaString &= " OR "

                    CriteriaString &= " ([WorkOrders].[WorkOrder ID]>=" & sd(0) & " AND [WorkOrders].[WorkOrder ID]<=" & sd(1) & ")"


                    flag = True
                    orFlag = True
                    AndFlag = True

                End If


            Next

            If flag Then CriteriaString &= ")"

        End If

        ' Customer Name
        If Not Me.ChkCustShowAll.Checked And Me.txtCustomer.Text.Length > 0 Then
            Me.StringCriteria(Me.txtCustomer, "[Customers].[Customer Name]", CriteriaString, AndFlag)
        End If

        ' ShipTo
        If Not Me.chkShToShowAll.Checked And Me.txtShipTo.Text.Length > 0 Then
            Me.StringCriteria(Me.txtShipTo, "[ShipTo].[ShipTo Name]", CriteriaString, AndFlag)
        End If

        ' reference
        If Not Me.chkRefShowAll.Checked And Me.txtRef.Text.Length > 0 Then
            Me.StringCriteria(Me.txtRef, "[WorkOrders].[Reference]", CriteriaString, AndFlag)
        End If

        ' container
        If Not Me.chkContShowAll.Checked And Me.txtCont.Text.Length > 0 Then
            Me.StringCriteria(Me.txtCont, "[WorkOrders].[Container Number]", CriteriaString, AndFlag)
        End If

        ' BK/BL
        If Not Me.chkBKBLShowAll.Checked And Me.txtBkBl.Text.Length > 0 Then
            Me.StringCriteria(Me.txtBkBl, "[WorkOrders].[BK BL]", CriteriaString, AndFlag)
        End If

        ' delivery date
        If Me.radDelRange.Checked Then
            Me.DateCriteria(Me.dtpDelDateFrom, Me.dtpDelDateTo, "[WorkOrders].[Delivery Date]", CriteriaString, AndFlag)
        ElseIf Me.radDelUns.Checked Then
            If AndFlag Then CriteriaString &= " AND "
            CriteriaString &= "[WorkOrders].[Delivery Date] IS NULL"
            AndFlag = True
        End If

        ' pup date
        If Me.radPupRange.Checked Then
            Me.DateCriteria(Me.dtpPupFrom, Me.dtpPupTo, "[WorkOrders].[PickUp Date]", CriteriaString, AndFlag)
        ElseIf Me.radPupUns.Checked Then
            If AndFlag Then CriteriaString &= " AND "
            CriteriaString &= "[WorkOrders].[PickUp Date] IS NULL"
            AndFlag = True
        End If

        ' dropoff date
        If Me.radDropRange.Checked Then
            Me.DateCriteria(Me.dtpDropFrom, Me.dtpDropTo, "[WorkOrders].[DropOff Date]", CriteriaString, AndFlag)
        ElseIf Me.radDropUns.Checked Then
            If AndFlag Then CriteriaString &= " AND "
            CriteriaString &= "[WorkOrders].[DropOff Date] IS NULL"
            AndFlag = True
        End If

        ' wo date
        If Me.radWoDateRange.Checked Then
            Me.DateCriteria(Me.dtpWoFrom, Me.dtpWoTo, "[WorkOrders].[WorkOrder Date]", CriteriaString, AndFlag)
        Else
            If AndFlag Then CriteriaString &= " AND "
            CriteriaString &= "[WorkOrders].[WorkOrder Date]>='" & GS.ThirtyDaysAgo.ToString & "'"
            AndFlag = True
        End If

        ' Billing Status

        If Not (Me.chkBillingNotBillable.Checked And Me.chkBillingNotBilled.Checked And Me.chkBillingReadyToBill.Checked And Me.chkBillingBilled.Checked) Then

            Dim BilAndFlag As Boolean = False

            If AndFlag Then CriteriaString &= " AND "

            CriteriaString &= "("

            If Not Me.chkBillingNotBillable.Checked Then
                CriteriaString &= "[WorkOrders].[Billing]<>0"
                BilAndFlag = True
            End If

            If Not Me.chkBillingNotBilled.Checked Then
                If BilAndFlag Then CriteriaString &= " AND "
                CriteriaString &= "[WorkOrders].[Billing]<>1"
                BilAndFlag = True
            End If

            If Not Me.chkBillingReadyToBill.Checked Then
                If BilAndFlag Then CriteriaString &= " AND "
                CriteriaString &= "[WorkOrders].[Billing]<>2"
                BilAndFlag = True
            End If

            If Not Me.chkBillingBilled.Checked Then
                If BilAndFlag Then CriteriaString &= " AND "
                CriteriaString &= "[WorkOrders].[Billing]<>3"
            End If

            CriteriaString &= ")"

        End If

        ' Status
        Dim StOrFlag As Boolean = False

        If AndFlag Then CriteriaString &= " AND "

        CriteriaString &= "("

        If Me.ChkStatusActive.Checked Then
            CriteriaString &= "[WorkOrders].[Status]=0"
            StOrFlag = True
        End If

        If Me.chkStatusInactive.Checked Then
            If StOrFlag Then CriteriaString &= " OR "
            CriteriaString &= "[WorkOrders].[Status]=1"
            StOrFlag = True
        End If

        If Me.chkStatusClosed.Checked Then
            If StOrFlag Then CriteriaString &= " OR "
            CriteriaString &= "[WorkOrders].[Status]=2"
            StOrFlag = True
        End If

        CriteriaString &= ")"

        Return True

    End Function

    Private Sub DateCriteria(ByVal myDtpFrom As DateTimePicker, ByVal myDtpTo As DateTimePicker, ByVal ColumnName As String, ByRef Criteria As String, ByRef AndFlag As Boolean)
        Dim dtFrom As Date = Nothing
        Dim dtTo As Date = Nothing

        With myDtpFrom.Value
            dtFrom = New Date(.Year, .Month, .Day, 0, 0, 0)
        End With

        With myDtpTo.Value
            dtTo = New Date(.Year, .Month, .Day, 23, 59, 59)
        End With

        If AndFlag Then Criteria &= " AND "
        Criteria &= ColumnName & ">='" & dtFrom.ToString & "' AND " & ColumnName & "<'" & dtTo.ToString & "'"
        AndFlag = True
    End Sub


    Private Sub StringCriteria(ByVal myTextBox As TextBox, ByVal ColumnName As String, ByRef Criteria As String, ByRef AndFlag As Boolean)
        Dim pts() As String = Split(myTextBox.Text, " ")
        Dim LCr As String = String.Empty
        Dim flag As Boolean = False
        Dim orFlag As Boolean = False

        For Each pt As String In pts

            If pt.Length > 0 Then

                If orFlag Then LCr &= " OR "

                LCr &= ColumnName & " LIKE '%" & GS.FilterSingleQuote(pt) & "%'"

                flag = True
                orFlag = True
            End If

        Next

        If flag Then
            If AndFlag Then Criteria &= " AND "
            Criteria &= "(" & LCr & ")"
            AndFlag = True
        End If
    End Sub

    Friend ReadOnly Property OkButtonPressed() As Boolean
        Get
            Return Me._OkPressed
        End Get
    End Property

    Friend ReadOnly Property FilteringCriteria() As String
        Get
            Return Me._FilteringStr
        End Get
    End Property

    Private Sub radDelRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDelRange.CheckedChanged
        Dim flag As Boolean = Me.radDelRange.Checked
        Me.dtpDelDateFrom.Enabled = flag
        Me.dtpDelDateTo.Enabled = flag
        Me.Label2.Enabled = flag
        Me.Label8.Enabled = flag
    End Sub

    Private Sub radPupRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radPupRange.CheckedChanged
        Dim flag As Boolean = Me.radPupRange.Checked
        Me.dtpPupFrom.Enabled = flag
        Me.dtpPupTo.Enabled = flag
        Me.Label10.Enabled = flag
        Me.Label9.Enabled = flag
    End Sub

    Private Sub radDropRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDropRange.CheckedChanged
        Dim flag As Boolean = Me.radDropRange.Checked
        Me.dtpDropFrom.Enabled = flag
        Me.dtpDropTo.Enabled = flag
        Me.Label12.Enabled = flag
        Me.Label11.Enabled = flag
    End Sub

    Private Sub dtpDelDateFrom_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDelDateFrom.CloseUp
        If Me.dtpDelDateFrom.Value.Date > Me.dtpDelDateTo.Value.Date Then
            Me.dtpDelDateTo.Value = Me.dtpDelDateFrom.Value
        End If
    End Sub

    Private Sub dtpDelDateTo_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDelDateTo.CloseUp
        If Me.dtpDelDateFrom.Value.Date > Me.dtpDelDateTo.Value.Date Then
            Me.dtpDelDateFrom.Value = Me.dtpDelDateTo.Value
        End If
    End Sub

    Private Sub dtpPupFrom_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPupFrom.CloseUp
        If Me.dtpPupFrom.Value.Date > Me.dtpPupTo.Value.Date Then
            Me.dtpPupTo.Value = Me.dtpPupFrom.Value
        End If
    End Sub

    Private Sub dtpPupTo_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPupTo.CloseUp
        If Me.dtpPupFrom.Value.Date > Me.dtpPupTo.Value.Date Then
            Me.dtpPupFrom.Value = Me.dtpPupTo.Value
        End If
    End Sub

    Private Sub dtpDropFrom_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDropFrom.CloseUp
        If Me.dtpDropFrom.Value.Date > Me.dtpDropTo.Value.Date Then
            Me.dtpDropTo.Value = Me.dtpDropFrom.Value
        End If
    End Sub

    Private Sub dtpDropTo_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDropTo.CloseUp
        If Me.dtpDropFrom.Value.Date > Me.dtpDropTo.Value.Date Then
            Me.dtpDropFrom.Value = Me.dtpDropTo.Value
        End If
    End Sub

    Private Sub dtpWoFrom_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpWoFrom.CloseUp
        If Me.dtpWoFrom.Value.Date > Me.dtpWoTo.Value.Date Then
            Me.dtpWoTo.Value = Me.dtpWoFrom.Value
        End If
    End Sub

    Private Sub dtpWoTo_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpWoTo.CloseUp
        If Me.dtpWoFrom.Value.Date > Me.dtpWoTo.Value.Date Then
            Me.dtpWoFrom.Value = Me.dtpWoTo.Value
        End If
    End Sub

    Private Sub radWoDateRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radWoDateRange.CheckedChanged
        Dim flag As Boolean = Me.radWoDateRange.Checked
        Me.dtpWoFrom.Enabled = flag
        Me.dtpWoTo.Enabled = flag
        Me.Label13.Enabled = flag
        Me.Label14.Enabled = flag
    End Sub
End Class