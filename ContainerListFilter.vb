
Imports System.Text.RegularExpressions

Public Class ContainerListFilter

    Dim _OkClicked As Boolean = False
    Dim _criteria As String = String.Empty
    Dim _dateCriteria As String = String.Empty

#Region "Control Events"

    Private Sub ContainerListFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'default date criteria
        Me._dateCriteria = "[WorkOrders].[WorkOrder Date]>='" & GS.ThirtyDaysAgo.ToString & "'"

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub chkWoId_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWoId.CheckedChanged
        Dim flag As Boolean = Not Me.chkWoId.Checked
        Me.Label2.Enabled = flag
        Me.txtWoId.Enabled = flag
    End Sub

    Private Sub chkCont_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCont.CheckedChanged
        Dim flag As Boolean = Not Me.chkCont.Checked
        Me.Label6.Enabled = flag
        Me.txtCont.Enabled = flag
    End Sub

    Private Sub chkLocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLocation.CheckedChanged
        Dim flag As Boolean = Not Me.chkLocation.Checked
        Me.Label1.Enabled = flag
        Me.txtLocation.Enabled = flag
    End Sub

    Private Sub radRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radRange.CheckedChanged
        Dim flag As Boolean = Me.radRange.Checked
        Me.Label8.Enabled = flag
        Me.Label5.Enabled = flag
        Me.dtpFrom.Enabled = flag
        Me.dtpTo.Enabled = flag
    End Sub

    Private Sub dtpFrom_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.CloseUp
        If Me.dtpFrom.Value.Date > Me.dtpTo.Value.Date Then
            Me.dtpTo.Value = Me.dtpFrom.Value
        End If
    End Sub

    Private Sub dtpTo_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.CloseUp
        If Me.dtpFrom.Value.Date > Me.dtpTo.Value.Date Then
            Me.dtpFrom.Value = Me.dtpTo.Value
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim tempCriteria As String = String.Empty
        Dim AndFlag As Boolean = False

        ' WorkOrder ID
        Me.txtWoId.Text = Trim(Me.txtWoId.Text)
        If Not Me.chkWoId.Checked And Me.txtWoId.Text.Length > 0 Then
            If Me.CreateIdCriteria(tempCriteria, Me.txtWoId, "WorkOrder ID") Then
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

        ' Location
        Me.txtLocation.Text = Trim(Me.txtLocation.Text)
        If Not Me.chkLocation.Checked And Me.txtLocation.Text.Length > 0 Then
            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= Me.CreateStringCriteria(Me.txtLocation.Text, "Act Location")
            AndFlag = True
        End If

        'status
        If Not Me.ChkStatusActive.Checked And Not Me.chkStatusInactive.Checked And Not Me.chkStatusClosed.Checked Then
            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= "[Status] IS NULL"
            AndFlag = True
        ElseIf Not Me.ChkStatusActive.Checked Or Not Me.chkStatusInactive.Checked Or Not Me.chkStatusClosed.Checked Then

            Dim SCF As String = String.Empty
            Dim orFlag As Boolean = False

            If Me.ChkStatusActive.Checked Then
                SCF &= "[Status]=0"
                orFlag = True
            End If

            If Me.chkStatusInactive.Checked Then
                If orFlag Then SCF &= " OR "
                SCF &= "[Status]=1"
                orFlag = True
            End If

            If Me.chkStatusClosed.Checked Then
                If orFlag Then SCF &= " OR "
                SCF &= "[Status]=2"
                orFlag = True
            End If

            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= "(" & SCF & ")"
            AndFlag = True

        End If

        ' date
        If Me.radRange.Checked Then
            Me._dateCriteria = Me.CreateDateCriteria()
        End If

        Me._criteria = tempCriteria
        Me._OkClicked = True

        Me.Close()

    End Sub

#End Region 'Control Events

#Region "Methoes & Properties"

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

        Return "[WorkOrders].[WorkOrder Date]>='" & dtFrom.ToString & "' AND [WorkOrders].[WorkOrder Date]<'" & dtTo.ToString & "'"

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

#End Region 'Methoes & Properties

End Class