
Imports System.Text.RegularExpressions

Public Class MoveListFilter

    Dim _OkClicked As Boolean = False
    Dim _criteria As String = String.Empty
    Dim _dateCriteria As String = String.Empty

#Region "Control Events"

    Private Sub MoveListFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' default date criteria
        Me._dateCriteria = "[Moves].[Start Time]>='" & GS.ThirtyDaysAgo.ToString & "'"

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub chkDriver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDriver.CheckedChanged
        Dim flag As Boolean = Not Me.chkDriver.Checked
        Me.Label3.Enabled = flag
        Me.txtDriver.Enabled = flag
    End Sub

    Private Sub chkTruck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTruck.CheckedChanged
        Dim flag As Boolean = Not Me.chkTruck.Checked
        Me.Label4.Enabled = flag
        Me.txtTruck.Enabled = flag
    End Sub

    Private Sub chkCont_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCont.CheckedChanged
        Dim flag As Boolean = Not Me.chkCont.Checked
        Me.Label6.Enabled = flag
        Me.txtCont.Enabled = flag
    End Sub

    Private Sub chkWoId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWoId.CheckedChanged
        Dim flag As Boolean = Not Me.chkWoId.Checked
        Me.Label2.Enabled = flag
        Me.txtWoId.Enabled = flag
    End Sub

    Private Sub chkMoveID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMoveID.CheckedChanged
        Dim flag As Boolean = Not Me.chkMoveID.Checked
        Me.Label1.Enabled = flag
        Me.txtMoveId.Enabled = flag
    End Sub

    Private Sub radRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radRange.CheckedChanged
        Dim flag As Boolean = Me.radRange.Checked
        Me.Label5.Enabled = flag
        Me.dtpFrom.Enabled = flag
        Me.Label8.Enabled = flag
        Me.dtpTo.Enabled = flag
    End Sub

    Private Sub dtpTo_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.CloseUp
        If Me.dtpFrom.Value.Date > Me.dtpTo.Value.Date Then
            Me.dtpFrom.Value = Me.dtpTo.Value
        End If
    End Sub

    Private Sub dtpFrom_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.CloseUp
        If Me.dtpFrom.Value.Date > Me.dtpTo.Value.Date Then
            Me.dtpTo.Value = Me.dtpFrom.Value
        End If
    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim tempCriteria As String = String.Empty
        Dim AndFlag As Boolean = False

        ' Move ID
        Me.txtMoveId.Text = Trim(Me.txtMoveId.Text)
        If Not Me.chkMoveID.Checked And Me.txtMoveId.Text.Length > 0 Then
            If Me.CreateIdCriteria(tempCriteria, Me.txtMoveId, "Move ID") Then
                AndFlag = True
            Else
                Exit Sub
            End If
        End If

        ' WorkOrder Id
        Me.txtWoId.Text = Trim(Me.txtWoId.Text)
        If Not Me.chkWoId.Checked And Me.txtWoId.Text.Length > 0 Then
            If AndFlag Then tempCriteria &= " AND "
            If Me.CreateIdCriteria(tempCriteria, Me.txtWoId, "WorkOrder ID") Then
                AndFlag = True
            Else
                Exit Sub
            End If
        End If

        ' truck number
        Me.txtTruck.Text = Trim(Me.txtTruck.Text)
        If Not Me.chkTruck.Checked And Me.txtTruck.Text.Length > 0 Then
            If AndFlag Then tempCriteria &= " AND "
            If Me.CreateIdCriteria(tempCriteria, Me.txtTruck, "Truck Number") Then
                AndFlag = True
            Else
                Exit Sub
            End If
        End If

        ' container number
        Me.txtCont.Text = Trim(Me.txtCont.Text)
        If Not Me.chkCont.Checked And Me.txtCont.Text.Length > 0 Then
            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= Me.CreateStringCriteria(Me.txtCont.Text, "Container Number")
            AndFlag = True
        End If

        ' driver name
        Me.txtDriver.Text = Trim(Me.txtDriver.Text)
        If Not Me.chkDriver.Checked And Me.txtDriver.Text.Length > 0 Then
            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= Me.CreateStringCriteria(Me.txtDriver.Text, "Driver Name")
            AndFlag = True
        End If

        ' date
        If Me.radRange.Checked Then
            Me._dateCriteria = Me.CreateDateCriteria()
        End If

        Me._OkClicked = True
        Me._criteria = tempCriteria

        Me.Close()

    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Private Function CreateStringCriteria(ByVal TextString As String, ByVal ColumnName As String) As String
        Dim pts() As String = Split(TextString, " ")
        Dim LCr As String = String.Empty
        Dim flag As Boolean = False

        For Each pt As String In pts

            If pt.Length > 0 Then

                If flag Then LCr &= " OR "

                LCr &= "[" & ColumnName & "] LIKE '%" & GS.FilterSingleQuote(pt) & "%'"

                flag = True

            End If

        Next

        If flag Then
            LCr = "(" & LCr & ")"
        End If

        Return LCr

    End Function

    Private Function CreateIdCriteria(ByRef CriteriaString As String, ByRef myTextBox As TextBox, ByVal ColumnName As String) As Boolean
        Dim ds() As String = Split(myTextBox.Text, ",")
        Dim flag As Boolean = False

        For Each d As String In ds

            d = Trim(d)

            ' validate ids
            If Not Regex.IsMatch(d, "^((\d)+|(\d+-\d+)|())$") Then
                MessageBox.Show("Invalid ID Number format.", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                myTextBox.Focus()
                Return False
            End If

            If Regex.IsMatch(d, "^(\d+)$") Then

                If flag Then
                    CriteriaString &= " OR "
                Else
                    CriteriaString &= "("
                End If

                CriteriaString &= " [" & ColumnName & "]=" & d & " "

                flag = True

            ElseIf Regex.IsMatch(d, "^(\d+-\d+)$") Then

                Dim sd() As String = Split(d, "-")

                If flag Then
                    CriteriaString &= " OR "
                Else
                    CriteriaString &= "("
                End If

                CriteriaString &= " ([" & ColumnName & "]>=" & sd(0) & " AND [" & ColumnName & "]<=" & sd(1) & ")"

                flag = True

            End If


        Next

        If flag Then CriteriaString &= ")"

        Return True

    End Function

    Private Function CreateDateCriteria() As String
        Dim dtFrom As Date = Nothing
        Dim dtTo As Date = Nothing

        With Me.dtpFrom.Value
            dtFrom = New Date(.Year, .Month, .Day, 0, 0, 0)
        End With

        With Me.dtpTo.Value
            dtTo = New Date(.Year, .Month, .Day, 23, 59, 59)
        End With

        Return "[Moves].[Start Time]>='" & dtFrom.ToString & "' AND [Moves].[Start Time]<'" & dtTo.ToString & "'"

    End Function

    Friend ReadOnly Property OkClicked() As Boolean
        Get
            Return Me._OkClicked
        End Get
    End Property

    Friend ReadOnly Property Criteria() As String
        Get
            Return Me._criteria
        End Get
    End Property

    Friend ReadOnly Property DateCriteria() As String
        Get
            Return Me._dateCriteria
        End Get
    End Property

#End Region 'Methods & Properties

End Class