Public Class MoveList

    Dim myMenu As ToolStripMenuItem
    Dim myDs As New DataSet
    Dim myLsvSorter As ListViewSorter
    Dim _criteria As String = String.Empty
    Dim _dateCriteria As String = "[Moves].[Start Time]>='" & GS.ThirtyDaysAgo.ToString & "'"

#Region "Control Events"

    Private Sub MoveList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' create ds table
        Me.myDs.Tables.Add("Moves")

        ' set size
        Me.Size = GS.MdiWorkAreaSize

        ' set image list
        Me.lsvMoves.SmallImageList = My.Forms.Form1.ImageList1

        ' load header size
        Me.LoadHeaderSize()

        ' setup sorter
        Me.myLsvSorter = New ListViewSorter(Me.lsvMoves)
        Me.myLsvSorter.NumericColumns = New Integer() {0, 1}
        Me.myLsvSorter.DateColumns = New Integer() {3, 4}

        If Me.FillDs(Me._dateCriteria) Then
            Me.PopulateLsv(Me.myDs.Tables("Moves").Select())
            Me.myLsvSorter.Sort(3, SortOrder.Descending)
        End If

    End Sub

    Private Sub MoveList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub MoveList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

        Me.SaveHeaderSize()

    End Sub

    Friend Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        ' clear listview
        Me.lsvMoves.Items.Clear()
        ' fill ds
        If Me.FillDs(Me._dateCriteria) Then
            ' fill lsv
            Me.PopulateLsv(Me.myDs.Tables("Moves").Select(Me._criteria))
            Me.myLsvSorter.Sort()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lsvMoves_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvMoves.ColumnClick
        Me.myLsvSorter.Sort(e.Column)
    End Sub

    Private Sub tsbShowActive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShowActive.Click
        Me.Label3.Visible = False
        Me._criteria = String.Empty
        Me._dateCriteria = "[Moves].[Start Time]>='" & GS.ThirtyDaysAgo.ToString & "'"
        Me.tsbRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub tsbFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFilter.Click
        Dim frm As New MoveListFilter
        frm.Owner = Me
        frm.ShowDialog()

        If frm.OkClicked Then
            Me.Label3.Visible = True
            Me._criteria = frm.Criteria

            ' if date criteria changed, repopulate myDs
            If Me._dateCriteria = frm.DateCriteria Then
                Me.PopulateLsv(Me.myDs.Tables("Moves").Select(Me._criteria))
                Me.myLsvSorter.Sort()
            Else
                Me._dateCriteria = frm.DateCriteria
                Me.tsbRefresh_Click(Nothing, Nothing)
            End If
        End If

        frm.Dispose()

    End Sub

    Private Sub lsvMoves_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvMoves.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvMoves.SelectedItems.Count > 0 Then _
            Me.tsbEditMove_Click(Nothing, Nothing)
    End Sub

    Private Sub lsvMoves_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvMoves.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right And Me.lsvMoves.SelectedItems.Count > 0 Then
            Me.ContextMenuStrip1.Show(Me.lsvMoves, e.Location)
        End If
    End Sub

    Private Sub WorkOrderDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderDetailsToolStripMenuItem.Click
        My.Forms.Form1.OpenWorkOrderDetailsForm(CInt(Me.lsvMoves.SelectedItems(0).SubItems(1).Text))
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.tsbRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub MovesByDriverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovesByDriverToolStripMenuItem.Click
        My.Forms.Form1.MovesByDriverToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub MovesByWorkOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovesByWorkOrderToolStripMenuItem.Click
        My.Forms.Form1.MovesByWorkOrderToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub tsbReports_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReports.ButtonClick
        Me.tsbReports.ShowDropDown()
    End Sub

    Private Sub tsbNewMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNewMove.Click
        My.Forms.Form1.NewMoveToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Private Sub tsbEditMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditMove.Click
        If Me.lsvMoves.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim frm As New NewMove(CInt(Me.lsvMoves.SelectedItems(0).SubItems(1).Text))
            frm.Owner = Me
            frm.Mode = FormMode.Edit
            frm.MoveID = CInt(Me.lsvMoves.SelectedItems(0).SubItems(0).Text)
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMoveToolStripMenuItem.Click, _
        EditToolStripMenuItem.Click

        Select Case CInt(CType(sender, ToolStripMenuItem).Tag)
            Case 1
                Me.tsbNewMove_Click(Nothing, Nothing)
            Case 2
                Me.tsbEditMove_Click(Nothing, Nothing)
        End Select

    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Private Sub PopulateLsv(ByVal Rows() As DataRow)

        ' clear lsv
        Me.lsvMoves.Items.Clear()

        For Each Row As DataRow In Rows
            Dim lsvItem As New ListViewItem(Row.Item("Move ID").ToString)
            lsvItem.SubItems.Add(Row.Item("WorkOrder ID").ToString)
            lsvItem.SubItems.Add(Row.Item("Container Number").ToString)

            If IsDBNull(Row.Item("Start Time")) Then
                lsvItem.SubItems.Add(String.Empty)
            Else
                lsvItem.SubItems.Add(CDate(Row.Item("Start Time")).ToString)
            End If

            If IsDBNull(Row.Item("End Time")) Then
                lsvItem.SubItems.Add(String.Empty)
            Else
                lsvItem.SubItems.Add(CDate(Row.Item("End Time")).ToString)
            End If

            lsvItem.SubItems.Add(Row.Item("FromLocation Name").ToString)
            lsvItem.SubItems.Add(Row.Item("ToLocation Name").ToString)
            lsvItem.SubItems.Add(Row.Item("Driver Name").ToString)
            lsvItem.SubItems.Add(Row.Item("Truck Number").ToString)

            Me.lsvMoves.Items.Add(lsvItem)

        Next

    End Sub

    Private Function FillDs(ByVal DateFilterExpression As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim flag As Boolean = True

        ' clear old data
        Me.myDs.Tables("Moves").Clear()

        Try

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [Moves].[Move ID],[Moves].[WorkOrder ID],[Moves].[Start Time],[Moves].[End Time]," & _
                " [WorkOrders].[Container Number],[Drivers].[Driver Name],[Trucks].[Truck Number]," & _
                " (CASE [Moves].[FromLocation] WHEN 0 THEN" & _
                "  (SELECT [ShipTo].[ShipTo Name] FROM [ShipTo] WHERE" & _
                "  [ShipTo].[ShipTo ID]=[WorkOrders].[ShipTo ID])" & _
                " ELSE (SELECT [Location].[Location Name] FROM [Location] WHERE" & _
                "     [Location].[Location ID]=[Moves].[FromLocation]) END) AS [FromLocation Name]," & _
                " (CASE [Moves].[ToLocation] WHEN 0 THEN" & _
                "  (SELECT [ShipTo].[ShipTo Name] FROM [ShipTo]" & _
                "  WHERE [ShipTo].[ShipTo ID]=[WorkOrders].[ShipTo ID])" & _
                " ELSE (SELECT [Location].[Location Name] FROM [Location] WHERE" & _
                "     [Location].[Location ID]=[Moves].[ToLocation]) END) AS [ToLocation Name]" & _
                " FROM [Moves] INNER JOIN [WorkOrders] ON [Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID]" & _
                " INNER JOIN [Drivers] ON [Moves].[Driver ID]=[Drivers].[Driver ID]" & _
                " INNER JOIN [Trucks] ON [Moves].[Truck ID]=[Trucks].[Truck ID]" & _
                " WHERE " & DateFilterExpression

            myDa.SelectCommand = myCmd

            myDa.Fill(myDs, "Moves")

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

    Private Sub SaveHeaderSize()
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvMoves.Columns.Count - 1
            key = "sz" & i.ToString
            SaveSetting("Oceanne", "MovesList", key, Me.lsvMoves.Columns(i).Width.ToString)
        Next
    End Sub

    Private Sub LoadHeaderSize()
        Dim DefSize() As Integer = {60, 60, 100, 120, 120, 120, 120, 100, 60}
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvMoves.Columns.Count - 1
            key = "sz" & i.ToString
            Me.lsvMoves.Columns(i).Width = CInt(GetSetting("Oceanne", "MovesList", key, DefSize(i).ToString))
        Next
    End Sub

#End Region ' Methods & Properties

End Class