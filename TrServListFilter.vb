
Imports System.Text.RegularExpressions

Public Class TrServListFilter

    Dim _criteria As String
    Dim _okpressed As Boolean

    Private Sub TrServListFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me._criteria = String.Empty
        Me._okpressed = False

        Me.PopulateTruckCBX()

    End Sub

    Private Sub PopulateTruckCBX()
        Dim myDa As New SqlClient.SqlDataAdapter("SELECT [Truck Number] FROM [Trucks]", GS.ConnectionString)
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False

        Try
            myDa.Fill(myDs, "Trucks")
        Catch ex As Exception
            MessageBox.Show("Unable to load 'Truck Number' field.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If Not ErrFlag Then
            For Each Row As DataRow In myDs.Tables("Trucks").Rows
                Me.cbxTruck.Items.Add(Row.Item("Truck Number").ToString)
            Next
        End If

        If Not IsNothing(myDs) Then myDs.Dispose()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If Me.CreateCriteria(Me._criteria) Then
            Me._okpressed = True
            Me.Close()
        Else
            Me._criteria = String.Empty
        End If

    End Sub

    Private Function CreateCriteria(ByRef CriteriaString As String) As Boolean

        Dim AndFlag As Boolean = False
        Dim tempCriteria As String = String.Empty

        ' Service ID
        Me.txtId.Text = Trim(Me.txtId.Text)
        If Not Me.chkIdShowAll.Checked And Me.txtId.Text.Length > 0 Then
            Dim ds() As String = Split(Me.txtId.Text, ",")
            Dim flag As Boolean = False
            Dim orFlag As Boolean = False

            For Each d As String In ds

                d = Trim(d)

                ' validate ids
                If Not Regex.IsMatch(d, "^((\d)+|(\d+-\d+)|())$") Then
                    MessageBox.Show("Invalid ID Number.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txtId.Focus()
                    Return False
                End If

                If Regex.IsMatch(d, "^(\d+)$") Then

                    If Not flag Then tempCriteria &= "("
                    If orFlag Then tempCriteria &= " OR "

                    tempCriteria &= " [Service ID]=" & d & " "

                    flag = True
                    orFlag = True
                    AndFlag = True

                ElseIf Regex.IsMatch(d, "^(\d+-\d+)$") Then

                    Dim sd() As String = Split(d, "-")

                    If Not flag Then tempCriteria &= "("
                    If orFlag Then tempCriteria &= " OR "

                    tempCriteria &= " ([Service ID]>=" & sd(0) & " AND [Service ID]<=" & sd(1) & ")"


                    flag = True
                    orFlag = True
                    AndFlag = True

                End If


            Next

            If flag Then tempCriteria &= ")"

        End If

        If Not Me.chkShowAllTrucks.Checked And Me.cbxTruck.Text.Length > 0 Then
            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= "[Truck Number]='" & Me.cbxTruck.Text & "'"
            AndFlag = True
        End If

        If Not Me.chkShowAllDates.Checked Then
            Dim dtFrom As Date = Nothing
            Dim dtTo As Date = Nothing

            With Me.dtpDateFrom.Value
                dtFrom = New Date(.Year, .Month, .Day, 0, 0, 0)
            End With

            With Me.dtpDateTo.Value
                dtTo = New Date(.Year, .Month, .Day, 23, 59, 59)
            End With

            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= "([Service Date]>='" & dtFrom.ToString & "' AND [Service Date]<='" & dtTo.ToString & "')"
            AndFlag = True
        End If

        If Me.radSatusOpen.Checked Then
            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= "[Paid]=0"
        ElseIf Me.radStatusPaid.Checked Then
            If AndFlag Then tempCriteria &= " AND "
            tempCriteria &= "[Paid]=1"
        End If

        CriteriaString = tempCriteria

        Return True

    End Function

    Friend Property OkPressed() As Boolean
        Get
            Return Me._okpressed
        End Get
        Set(ByVal value As Boolean)
            Me._okpressed = value
        End Set
    End Property

    Friend Property FilteringCriteria() As String
        Get
            Return Me._criteria
        End Get
        Set(ByVal value As String)
            Me._criteria = value
        End Set
    End Property

    Private Sub chkIdShowAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIdShowAll.CheckedChanged
        Dim flag As Boolean = Not Me.chkIdShowAll.Checked
        Me.Label1.Enabled = flag
        Me.txtId.Enabled = flag
    End Sub

    Private Sub chkShowAllTrucks_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowAllTrucks.CheckedChanged
        Dim flag As Boolean = Not Me.chkShowAllTrucks.Checked
        Me.Label3.Enabled = flag
        Me.cbxTruck.Enabled = flag
    End Sub

    Private Sub chkShowAllDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowAllDates.CheckedChanged
        Dim flag As Boolean = Not Me.chkShowAllDates.Checked
        Me.Label2.Enabled = flag
        Me.Label8.Enabled = flag
        Me.dtpDateFrom.Enabled = flag
        Me.dtpDateTo.Enabled = flag
    End Sub

    Private Sub dtpDateFrom_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateFrom.CloseUp
        If Me.dtpDateFrom.Value.Date > Me.dtpDateTo.Value.Date Then
            Me.dtpDateTo.Value = Me.dtpDateFrom.Value
        End If
    End Sub

    Private Sub dtpDateTo_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateTo.CloseUp
        If Me.dtpDateFrom.Value.Date > Me.dtpDateTo.Value.Date Then
            Me.dtpDateFrom.Value = Me.dtpDateTo.Value
        End If
    End Sub
End Class