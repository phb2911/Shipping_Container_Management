
Imports System.Text.RegularExpressions

Public Class TrMilListFilter

    Dim _criteria As String = String.Empty
    Dim _dateCriteria As String = "[TruckMileage].[Date]>='" & GS.ThirtyDaysAgo.ToString & "'"
    Dim _OkClicked As Boolean = False

#Region "Control Events"

    Private Sub TrMilListFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkTruck_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTruck.CheckedChanged
        Dim flag As Boolean = Not Me.chkTruck.Checked
        Me.Label4.Enabled = flag
        Me.txtTruck.Enabled = flag
    End Sub
    Private Sub chkMileageID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMileageID.CheckedChanged
        Dim flag As Boolean = Not Me.chkMileageID.Checked
        Me.Label1.Enabled = flag
        Me.txtMileageId.Enabled = flag
    End Sub

    Private Sub radRange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radRange.CheckedChanged
        Dim flag As Boolean = Me.radRange.Checked
        Me.Label5.Enabled = flag
        Me.dtpFrom.Enabled = flag
        Me.Label8.Enabled = flag
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim tempCriteria As String = String.Empty
        Dim AndFlag As Boolean = False

        ' Mileage ID
        Me.txtMileageId.Text = Trim(Me.txtMileageId.Text)
        If Not Me.chkMileageID.Checked And Me.txtMileageId.Text.Length > 0 Then
            If Me.CreateIdCriteria(tempCriteria, Me.txtMileageId, "Mileage ID") Then
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

    Private Function CreateDateCriteria() As String
        Dim dtFrom As Date = Nothing
        Dim dtTo As Date = Nothing

        With Me.dtpFrom.Value
            dtFrom = New Date(.Year, .Month, .Day, 0, 0, 0)
        End With

        With Me.dtpTo.Value
            dtTo = New Date(.Year, .Month, .Day, 23, 59, 59)
        End With

        Return "[TruckMileage].[Date]>='" & dtFrom.ToString & "' AND [TruckMileage].[Date]<'" & dtTo.ToString & "'"

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

#End Region ' Methods & Properties

End Class