Public Class TruckMileageList

    Dim myMenu As ToolStripMenuItem
    Dim myDs As New DataSet
    Dim myLsvSorter As ListViewSorter
    Dim _criteria As String = String.Empty
    Dim _dateCriteria As String = "[TruckMileage].[Date]>='" & GS.ThirtyDaysAgo.ToString & "'"

#Region "Control Events"

    Private Sub TruckMileageList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' add table
        Me.myDs.Tables.Add("TruckMileage")

        ' set size
        Me.Size = GS.MdiWorkAreaSize

        'set image list
        Me.lsvTruckMileage.SmallImageList = My.Forms.Form1.ImageList1

        ' load header size
        Me.LoadHeaderSize()

        ' setup sorter
        Me.myLsvSorter = New ListViewSorter(Me.lsvTruckMileage)
        Me.myLsvSorter.NumericColumns = New Integer() {0, 3}
        Me.myLsvSorter.DateColumns = New Integer() {2}

        If Me.FillDs() Then
            Me.PopulateLsv(Me.myDs.Tables("TruckMileage").Select())
            Me.myLsvSorter.Sort(2, SortOrder.Descending)
        End If

    End Sub

    Private Sub TruckMileageList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub TruckMileageList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

        Me.SaveHeaderSize()

    End Sub

    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click
        Dim frm As New NewTruckMileage
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        If Me.lsvTruckMileage.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select an item from the list.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New EditTruckMileage(CInt(Me.lsvTruckMileage.SelectedItems(0).SubItems(0).Text))
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If

    End Sub

    Friend Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        ' fill list
        If Me.FillDs() Then
            Me.PopulateLsv(Me.myDs.Tables("TruckMileage").Select(Me._criteria))
            Me.myLsvSorter.Sort()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFilter.Click
        Dim frm As New TrMilListFilter
        frm.Owner = Me
        frm.ShowDialog()

        If frm.OkClicked Then

            Me.Label3.Visible = True
            Me._criteria = frm.Criteria

            ' if date criteria changed, repopulate myDs
            If Me._dateCriteria = frm.DateCriteria Then
                Me.PopulateLsv(Me.myDs.Tables("TruckMileage").Select(Me._criteria))
                Me.myLsvSorter.Sort()
            Else
                Me._dateCriteria = frm.DateCriteria
                Me.tsbRefresh_Click(Nothing, Nothing)
            End If

        End If

        frm.Dispose()
    End Sub

    Private Sub tsbAll30days_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAll30days.Click
        Me.Label3.Visible = False
        Me._criteria = String.Empty
        Me._dateCriteria = "[TruckMileage].[Date]>='" & GS.ThirtyDaysAgo.ToString & "'"
        Me.tsbRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click, _
        CreateNewToolStripMenuItem.Click, RefreshToolStripMenuItem.Click

        Select Case CInt(CType(sender, ToolStripMenuItem).Tag)
            Case 1
                Me.tsbNew_Click(Nothing, Nothing)
            Case 2
                Me.tsbEdit_Click(Nothing, Nothing)
            Case 3
                Me.tsbRefresh_Click(Nothing, Nothing)
        End Select

    End Sub

    Private Sub lsvTruckMileage_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvTruckMileage.ColumnClick
        Me.myLsvSorter.Sort(e.Column)
    End Sub

    Private Sub lsvTruckMileage_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvTruckMileage.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Me.EditToolStripMenuItem.Enabled = (Me.lsvTruckMileage.SelectedItems.Count > 0)

            Me.ContextMenuStrip1.Show(Me.lsvTruckMileage, e.Location)

        End If
    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Private Function FillDs() As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim flag As Boolean = True

        'clear old data
        Me.myDs.Tables("TruckMileage").Clear()

        Try
            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [TruckMileage].*,[Trucks].[Truck Number] FROM [TruckMileage] " & _
                "INNER JOIN [Trucks] ON [TruckMileage].[Truck ID]=[Trucks].[Truck ID] WHERE " & Me._dateCriteria

            myDa.SelectCommand = myCmd
            myDa.Fill(Me.myDs, "TruckMileage")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        Return flag

    End Function

    Private Sub PopulateLsv(ByVal Rows() As DataRow)

        ' clear old data
        Me.lsvTruckMileage.Items.Clear()

        For Each Row As DataRow In Rows

            Dim lsvItem As New ListViewItem(Row.Item("Mileage ID").ToString)
            lsvItem.SubItems.Add(Row.Item("Truck Number").ToString)
            lsvItem.SubItems.Add(CDate(Row.Item("Date")).ToShortDateString)
            lsvItem.SubItems.Add(Row.Item("Mileage").ToString)

            Me.lsvTruckMileage.Items.Add(lsvItem)

        Next

    End Sub

    Private Sub SaveHeaderSize()
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvTruckMileage.Columns.Count - 1
            key = "sz" & i.ToString
            SaveSetting("Oceanne", "TruckMileageList", key, Me.lsvTruckMileage.Columns(i).Width.ToString)
        Next
    End Sub

    Private Sub LoadHeaderSize()
        Dim DefSize() As Integer = {60, 90, 90, 90}
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvTruckMileage.Columns.Count - 1
            key = "sz" & i.ToString
            Me.lsvTruckMileage.Columns(i).Width = CInt(GetSetting("Oceanne", "TruckMileageList", key, DefSize(i).ToString))
        Next
    End Sub

#End Region 'Methods & Properties

End Class