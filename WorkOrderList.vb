Public Class WorkOrderList

#Region "Global Fields"

    Dim myMenu As ToolStripMenuItem
    Dim myDs As New DataSet
    Dim myLsvSorter As ListViewSorter
    Dim DefCriteria As String = "[WorkOrders].[Status]=0 OR ([WorkOrders].[WorkOrder Date]>='" & GS.ThirtyDaysAgo.ToString & _
        "' AND [WorkOrders].[Status]=2)"
    Dim _filterCriteria As String = DefCriteria

#End Region ' Global Fields

#Region "Control Events"

    Private Sub WorkOrderList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' fixes error
        Me.ShowIcon = True

        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' create ds table
        Me.myDs.Tables.Add("WorkOrders")

        ' set window size
        Me.Size = GS.MdiWorkAreaSize

        ' set lsv imagelist
        Me.lsvWorkOrders.SmallImageList = My.Forms.Form1.ImageList1

        ' create lsv headers
        Me.CreateHeaders()

        ' setup list view sorter object
        Me.myLsvSorter = New ListViewSorter(Me.lsvWorkOrders)
        Me.myLsvSorter.NumericColumns = New Integer() {0}
        Me.myLsvSorter.DateColumns = New Integer() {7, 8, 9}

        ' fill Data Set
        If FillDsWorkOrderList(Me._filterCriteria) Then
            Me.FillListView()
            Me.myLsvSorter.Sort(0, SortOrder.Descending)
        End If

    End Sub

    Private Sub WorkOrderList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub WorkOrderList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

        Me.SaveHeaderSize()

        ' clean up
        If Not IsNothing(Me.myDs) Then Me.myDs.Dispose()

    End Sub

    Private Sub lsvWorkOrders_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvWorkOrders.ColumnClick

        Me.myLsvSorter.Sort(e.Column)

    End Sub

    Private Sub tsbCreateNewWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCreateNewWO.Click
        Me.Cursor = Cursors.WaitCursor
        My.Forms.Form1.NewWorkOrderToolStripMenuItem_Click(sender, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.RefreshList()
    End Sub

    Private Sub tsbFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFilter.Click

        Dim frm As New WoListFilter
        frm.Owner = Me
        frm.ShowDialog()

        If frm.OkButtonPressed AndAlso Me._filterCriteria <> frm.FilteringCriteria Then
            Me._filterCriteria = frm.FilteringCriteria
            Me.Label2.Visible = True
            Me.RefreshList()
        End If

        frm.Dispose()

    End Sub

    Private Sub tsbShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShowAll.Click

        Me._filterCriteria = Me.DefCriteria

        If Me.FillDsWorkOrderList(Me._filterCriteria) Then
            Me.FillListView()
            Me.Label2.Visible = False
            Me.myLsvSorter.Sort()
        End If

    End Sub

    Private Sub TSM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNewWO.Click, tsmRefresh.Click, _
        tsmEdit.Click, tsmDetails.Click, tsmRptDelivery2.Click, tsmCloseWo.Click, tsmReopenWo.Click
        Select Case CInt(CType(sender, ToolStripMenuItem).Tag)
            Case 1
                Me.tsbCreateNewWO_Click(sender, e)
            Case 2
                Me.tsbEditSelWO_Click(sender, e)
            Case 3
                Me.tsbDetails_Click(sender, e)
            Case 4
                Me.tsbRefresh_Click(sender, e)
            Case 5
                Me.tsmRptDelivery_Click(sender, e)
            Case 6
                Me.tsbCloseWo_Click(sender, e)
            Case 7
                Me.tsbReopenWo_Click(sender, e)
        End Select
    End Sub

    Private Sub lsvWorkOrders_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvWorkOrders.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.tsbEditSelWO_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub lsvWorkOrders_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvWorkOrders.MouseUp

        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim flag As Boolean = (Me.lsvWorkOrders.SelectedItems.Count > 0)

            If flag Then
                Me.tsmCloseWo.Enabled = (Me.lsvWorkOrders.SelectedItems(0).SubItems(6).Text = "Active")
                Me.tsmReopenWo.Enabled = (Me.lsvWorkOrders.SelectedItems(0).SubItems(6).Text = "Closed")
            End If

            Me.tsmEdit.Enabled = flag
            Me.tsmDetails.Enabled = flag
            Me.tsmReports.Enabled = flag

            Me.ContextMenuStrip1.Show(Me.lsvWorkOrders, e.Location)

        End If

    End Sub

    Private Sub tsbEditSelWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditSelWO.Click
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            Dim frm As New NewWorkOrder
            frm.Mode = FormMode.Edit
            frm.WorkOrderID = CInt(Me.lsvWorkOrders.SelectedItems.Item(0).SubItems(0).Text)
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()

        End If

    End Sub

    Private Sub tsbDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDetails.Click
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            My.Forms.Form1.OpenWorkOrderDetailsForm(CInt(Me.lsvWorkOrders.SelectedItems.Item(0).SubItems(0).Text))
        End If
    End Sub

    Private Sub tsmRptDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmRptDelivery.Click

        'RPT TMP
        'Dim rpt As New RptViwer(RptViwer.ReportType.Container, "title")
        'rpt.WorkOrderID = CInt(Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text)
        'rpt.MdiParent = My.Forms.Form1
        'rpt.Tag = My.Forms.Form1.CreateWindowMenu(rpt)
        'rpt.Show()
        'Exit Sub

        Me.Cursor = Cursors.WaitCursor

        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' open report
            Dim WoId As Integer = CInt(Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text)
            Dim frmRpt As New RptViwer(RptViwer.ReportType.DeliveryOrder, "Delivery Order")
            frmRpt.WorkOrderID = WoId
            frmRpt.MdiParent = My.Forms.Form1
            frmRpt.Tag = My.Forms.Form1.CreateWindowMenu(frmRpt)
            frmRpt.Show()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub tsbCloseWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCloseWo.Click
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Me.lsvWorkOrders.SelectedItems(0).SubItems(6).Text <> "Active" Then
            MessageBox.Show("Only Work Order marked as Active can be closed.", "Can't Close", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            Dim WoId As Integer = CInt(Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text)

            If Not GS.WorkOrderIsClosable(WoId) Then
                MessageBox.Show("The Work Order # " & WoId.ToString & " can't be closed for one of the following reasons:" & vbCrLf & vbCrLf & _
                    "   - The Work Order is not Active." & vbCrLf & _
                    "   - The Work Order has no moves attached to it." & vbCrLf & _
                    "   - The Work Order has moves attached to it that are not complete yet." & vbCrLf & _
                    "   - The Work Order has no 'In TIR' number.", _
                    "Can't Close", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If MessageBox.Show("The Work Order # " & WoId.ToString & " will be closed." & vbCrLf & "Are you sure?", _
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                If GS.CloseWorkOrder(WoId) Then
                    ' refresh own list
                    Me.RefreshList()

                    ' fixes unwanted result
                    Me.lsvWorkOrders.Refresh()

                    ' refresh WO Details if open
                    Dim DtFrm As WoDetails = Nothing
                    If GS.DetailFormIsOpen(DtFrm, WoId) Then
                        DtFrm.RefreshData()
                    End If

                    ' refresh Work Order List from Dispatch window if open
                    If GS.FormIsOpen(My.Forms.Form1.frmDispatch) Then
                        My.Forms.Form1.frmDispatch.tsbRefreshWo_Click(Nothing, Nothing)
                    End If

                End If

            End If

        End If

    End Sub

    Private Sub tsbReopenWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReopenWo.Click
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Me.lsvWorkOrders.SelectedItems(0).SubItems(6).Text <> "Closed" Then
            MessageBox.Show("Only Work Order marked as Closed can be reopen.", "Can't Reopen", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            Dim WoId As Integer = CInt(Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text)

            If MessageBox.Show("The Work Order # " & WoId.ToString & " will be reopen." & vbCrLf & "Are you sure?", _
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

                If GS.ReopenWorkOrder(WoId) Then
                    Me.RefreshList()

                    ' fixes unwanted result
                    Me.lsvWorkOrders.Refresh()

                    ' refresh WO Details if open
                    Dim DtFrm As WoDetails = Nothing
                    If GS.DetailFormIsOpen(DtFrm, WoId) Then
                        DtFrm.RefreshData()
                    End If
                End If

            End If


        End If
    End Sub

    Private Sub tsbReport_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReport.ButtonClick
        Me.tsbReport.ShowDropDown()
    End Sub

    Private Sub tsmWorkOrderRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmWorkOrders.Click, _
        tsmByCustomers.Click, tsmByShipTo.Click, tsmNotBilledWorkOrders.Click, tsmReadyToBillWorkOrders.Click

        Dim tsmTag As Integer = CInt(CType(sender, ToolStripMenuItem).Tag)

        With My.Forms.Form1

            Select Case tsmTag
                Case 1
                    .WorkOrdersToolStripMenuItem1_Click(Nothing, Nothing)
                Case 2
                    .WorkOrdersByCustomerToolStripMenuItem_Click(Nothing, Nothing)
                Case 3
                    .WorkOrdersByShipToToolStripMenuItem_Click(Nothing, Nothing)
                Case 4, 5
                    Dim myTsm As New ToolStripMenuItem
                    myTsm.Tag = tsmTag - 3
                    .RptBillingToolStripMenuItem_Click(myTsm, Nothing)
            End Select

        End With

    End Sub

#End Region ' Control Events

#Region "Methods & Properties"

    Friend Sub RefreshList()

        Me.Cursor = Cursors.WaitCursor
        
        If Me.FillDsWorkOrderList(Me._filterCriteria) Then Me.FillListView()

        Me.myLsvSorter.Sort()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FillListView()

        Dim lsvItem As ListViewItem = Nothing

        ' Clear old data
        Me.lsvWorkOrders.Items.Clear()

        For Each Row As DataRow In Me.myDs.Tables("WorkOrders").Rows

            lsvItem = New ListViewItem(Row.Item("WorkOrder ID").ToString)
            lsvItem.SubItems.Add(Row.Item("Customer Name").ToString)
            lsvItem.SubItems.Add(Row.Item("ShipTo Name").ToString)
            lsvItem.SubItems.Add(Row.Item("Reference").ToString)
            lsvItem.SubItems.Add(Row.Item("Container Number").ToString)
            lsvItem.SubItems.Add(Row.Item("BK BL").ToString)
            lsvItem.SubItems.Add(Row.Item("Status").ToString)
            lsvItem.SubItems.Add(Row.Item("Delivery Date").ToString)
            lsvItem.SubItems.Add(Format(Row.Item("PickUp Date").ToString, "Short Date"))
            lsvItem.SubItems.Add(Row.Item("DropOff Date").ToString)

            Me.lsvWorkOrders.Items.Add(lsvItem)

        Next

    End Sub

    Private Function FillDsWorkOrderList(ByVal FilteringCriteria As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim flag As Boolean = True

        Me.myDs.Tables("WorkOrders").Clear()

        myCmd.Connection = myConn
        myCmd.CommandText = "SELECT [WorkOrders].[WorkOrder ID], [Customers].[Customer Name], [ShipTo].[ShipTo Name], " & _
            "[WorkOrders].[Reference], [WorkOrders].[Container Number], [WorkOrders].[BK BL], " & _
            "[WorkOrders].[Delivery Date], [WorkOrders].[PickUp Date], [WorkOrders].[DropOff Date], " & _
            "(CASE [WorkOrders].[Status] WHEN 0 THEN 'Active' WHEN 1 THEN 'Inactive' WHEN 2 THEN 'Closed' " & _
            "ELSE NULL END) AS [Status] FROM [WorkOrders] " & _
            "JOIN [Customers] ON [WorkOrders].[Customer ID]=[Customers].[Customer ID] " & _
            "JOIN [ShipTo] ON [WorkOrders].[ShipTo ID]=[ShipTo].[ShipTo ID] WHERE " & FilteringCriteria

        Try

            myConn.Open()

            myDa.SelectCommand = myCmd
            myDa.Fill(Me.myDs, "WorkOrders")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myConn) AndAlso myConn.State = ConnectionState.Open Then myConn.Close()
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        Return flag

    End Function

    Private Sub CreateHeaders()

        Dim sz(9) As Integer

        sz(0) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz0", "50"))
        sz(1) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz1", "130"))
        sz(2) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz2", "130"))
        sz(3) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz3", "120"))
        sz(4) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz4", "125"))
        sz(5) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz5", "120"))
        sz(6) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz6", "100"))
        sz(7) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz6", "140"))
        sz(8) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz6", "100"))
        sz(9) = CInt(GetSetting("Oceanne", "WorkOrderList", "sz6", "140"))

        GS.AddHeader(Me.lsvWorkOrders, "ID", sz(0))
        GS.AddHeader(Me.lsvWorkOrders, "Customer", sz(1))
        GS.AddHeader(Me.lsvWorkOrders, "ShipTo", sz(2))
        GS.AddHeader(Me.lsvWorkOrders, "Reference", sz(3))
        GS.AddHeader(Me.lsvWorkOrders, "Container Number", sz(4))
        GS.AddHeader(Me.lsvWorkOrders, "BK/BL", sz(5))
        GS.AddHeader(Me.lsvWorkOrders, "Status", sz(6))
        GS.AddHeader(Me.lsvWorkOrders, "Delivery Date", sz(7), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvWorkOrders, "PickUp Date", sz(8), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvWorkOrders, "DropOff Date", sz(9), HorizontalAlignment.Right)


    End Sub

    Private Sub SaveHeaderSize()
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvWorkOrders.Columns.Count - 1
            key = "sz" & i.ToString
            SaveSetting("Oceanne", "WorkOrderList", key, Me.lsvWorkOrders.Columns(i).Width.ToString)
        Next
    End Sub

#End Region 'Methods & Properties

End Class