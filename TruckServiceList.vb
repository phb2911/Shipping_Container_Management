Public Class TruckServiceList

    Dim myMenu As ToolStripMenuItem
    Dim myDsTruckServiceList As New DsTruckServiceList
    Dim myLsvSorter As ListViewSorter
    Dim _criteria As String = "[Paid]=0"

#Region "Control Events"

    Private Sub TruckServiceList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' set size
        Me.Size = GS.MdiWorkAreaSize

        'set image list
        Me.lsvTruckService.SmallImageList = My.Forms.Form1.ImageList1

        ' create headers
        Me.CreateHeaders()

        ' setup sorter
        Me.myLsvSorter = New ListViewSorter(Me.lsvTruckService)
        Me.myLsvSorter.NumericColumns = New Integer() {0, 4}
        Me.myLsvSorter.DateColumns = New Integer() {2}

        If Me.FillDsTruckServiceList() Then
            Me.FillListView()
            Me.myLsvSorter.Sort(0, SortOrder.Ascending)
        End If

    End Sub

    Private Sub TruckServiceList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub TruckServiceList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

        Me.SaveHeaderSize()

        ' clean up
        If Not IsNothing(Me.myDsTruckServiceList) Then Me.myDsTruckServiceList.Dispose()

    End Sub

    Private Sub lsvTruckService_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvTruckService.ColumnClick
        Me.myLsvSorter.Sort(e.Column)
    End Sub

    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click
        Dim frm As New NewTruckService
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        If Me.lsvTruckService.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewTruckService
            frm.Mode = FormMode.Edit
            frm.TruckServiceID = CInt(Me.lsvTruckService.SelectedItems(0).SubItems(0).Text)
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub tsbDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDetails.Click
        If Me.lsvTruckService.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewTruckService
            frm.Mode = FormMode.Details
            frm.TruckServiceID = CInt(Me.lsvTruckService.SelectedItems(0).SubItems(0).Text)
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Friend Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        If Me.FillDsTruckServiceList() Then
            Me.FillListView()
        Else
            Me.lsvTruckService.Items.Clear()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateNewToolStripMenuItem.Click, _
            EditToolStripMenuItem.Click, DetailsToolStripMenuItem.Click, RefreshToolStripMenuItem.Click

        Select Case CInt(CType(sender, ToolStripMenuItem).Tag)
            Case 1
                Me.tsbNew_Click(sender, e)
            Case 2
                Me.tsbEdit_Click(sender, e)
            Case 3
                Me.tsbDetails_Click(sender, e)
            Case 4
                Me.tsbRefresh_Click(sender, e)
        End Select

    End Sub

    Private Sub tsbFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFilter.Click
        Dim frm As New TrServListFilter
        frm.Owner = Me
        frm.ShowDialog()

        If frm.OkPressed Then
            Me._criteria = frm.FilteringCriteria
            Me.FillListView()
            Me.Label3.Visible = True
        End If

        frm.Dispose()
    End Sub

    Private Sub tsbAllUnpaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAllUnpaid.Click
        Me._criteria = "[Paid]=0"
        Me.Label3.Visible = False
        Me.FillListView()
    End Sub

    Private Sub lsvTruckService_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvTruckService.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvTruckService.SelectedItems.Count > 0 Then
            Me.tsbDetails_Click(sender, e)
        End If
    End Sub

    Private Sub lsvTruckService_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvTruckService.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim flag As Boolean = False

            If Me.lsvTruckService.SelectedItems.Count > 0 Then flag = True

            Me.EditToolStripMenuItem.Enabled = flag
            Me.DetailsToolStripMenuItem.Enabled = flag

            Me.ContextMenuStrip1.Show(Me.lsvTruckService, e.Location)

        End If
    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Private Sub FillListView()

        Dim Rows() As DataRow = Me.myDsTruckServiceList.TruckServices.Select(Me._criteria)

        Dim lsvItem As ListViewItem = Nothing

        ' clear old lsv data
        Me.lsvTruckService.Items.Clear()

        For Each Row As DataRow In Rows
            lsvItem = New ListViewItem(Row.Item("Service ID").ToString)
            lsvItem.SubItems.Add(Row.Item("Truck Number").ToString)

            If Not IsDBNull(Row.Item("Service Date")) Then
                Dim dt As Date = CDate(Row.Item("Service Date"))
                lsvItem.SubItems.Add(dt.ToShortDateString)
            End If

            lsvItem.SubItems.Add(Row.Item("PO Number").ToString)
            lsvItem.SubItems.Add(Format(Row.Item("Total").ToString, "Fixed"))

            If CBool(Row.Item("Paid")) Then
                lsvItem.SubItems.Add("Paid")
            Else
                lsvItem.SubItems.Add("Open")
            End If

            Me.lsvTruckService.Items.Add(lsvItem)

        Next
    End Sub

    Private Function FillDsTruckServiceList() As Boolean

        Dim myTaTrServLst As New DsTruckServiceListTableAdapters.TruckServicesTableAdapter
        Dim flag As Boolean = True

        Try
            myTaTrServLst.Connection.ConnectionString = GS.ConnectionString
            myTaTrServLst.Fill(Me.myDsTruckServiceList.TruckServices)
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myTaTrServLst) Then myTaTrServLst.Dispose()
        End Try

        Return flag

    End Function

    Private Sub CreateHeaders()

        Dim sz(5) As Integer

        sz(0) = CInt(GetSetting("Oceanne", "TruckServiceList", "sz0", "60"))
        sz(1) = CInt(GetSetting("Oceanne", "TruckServiceList", "sz1", "130"))
        sz(2) = CInt(GetSetting("Oceanne", "TruckServiceList", "sz2", "130"))
        sz(3) = CInt(GetSetting("Oceanne", "TruckServiceList", "sz3", "130"))
        sz(4) = CInt(GetSetting("Oceanne", "TruckServiceList", "sz4", "90"))
        sz(5) = CInt(GetSetting("Oceanne", "TruckServiceList", "sz5", "90"))

        GS.AddHeader(Me.lsvTruckService, "ID", sz(0))
        GS.AddHeader(Me.lsvTruckService, "Truck Number", sz(1))
        GS.AddHeader(Me.lsvTruckService, "Service Date", sz(2), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvTruckService, "PO Number", sz(3))
        GS.AddHeader(Me.lsvTruckService, "Total", sz(4), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvTruckService, "Status", sz(5))

    End Sub

    Private Sub SaveHeaderSize()
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvTruckService.Columns.Count - 1
            key = "sz" & i.ToString
            SaveSetting("Oceanne", "TruckServiceList", key, Me.lsvTruckService.Columns(i).Width.ToString)
        Next
    End Sub

#End Region 'Methods & Properties

End Class