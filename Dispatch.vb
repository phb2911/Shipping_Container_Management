Public Class Dispatch

    Dim myMenu As ToolStripMenuItem
    Dim myDs As New DataSet
    Dim _woLsvSorter As ListViewSorter
    Dim TruckIdCol As New Collection
    Dim DriverIdCol As New Collection
    Dim docTruckIdCol As New Collection
    Dim docDriverIdCol As New Collection

#Region "Control Events"

    Private Sub Dispatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' fixes error
        Me.ShowIcon = True
        Me.tsMoves.Visible = True
        Me.tsWorkOrders.Visible = True

        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' set size
        Me.Size = GS.MdiWorkAreaSize

        Me.myDs.Tables.Add("WorkOrders")
        Me.myDs.Tables.Add("Moves")
        Me.myDs.Tables.Add("ReturnToPier")
        Me.myDs.Tables.Add("DeliverySchedule")
        Me.myDs.Tables.Add("DriverDocExp")
        Me.myDs.Tables.Add("TruckDocExp")

        ' setup WoLsv sorter
        Me.lsvWorkOrders.SmallImageList = My.Forms.Form1.ImageList1
        Me._woLsvSorter = New ListViewSorter(Me.lsvWorkOrders)
        Me._woLsvSorter.NumericColumns = New Integer() {0}
        Me._woLsvSorter.DateColumns = New Integer() {6}

        Me.RefreshMain()

    End Sub

    Private Sub Dispatch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub Dispatch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case Me.TabControl1.SelectedIndex
            Case 0 ' Main
                Me.RefreshMain()
            Case 1 ' Work Orders
                Me.tsbRefreshWo_Click(Nothing, Nothing)
            Case 2 ' moves
                Me.tsbRefresh_Click(Nothing, Nothing)
        End Select
    End Sub

#Region "Moves Controls"

    Private Sub cbxTrucks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTrucks.SelectedIndexChanged
        Me.btnTruckDetails.Enabled = (Me.cbxTrucks.SelectedIndex > 0)
        If Me.TabControlMoves.SelectedIndex = 1 Then _
            Me.PopulateMovesLsv()
    End Sub

    Private Sub cbxDrivers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDrivers.SelectedIndexChanged
        Me.btnDriverDetails.Enabled = (Me.cbxDrivers.SelectedIndex > 0)
        If Me.TabControlMoves.SelectedIndex = 2 Then _
            Me.PopulateMovesLsv()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim frm As New SelectWo
        frm.Owner = Me
        frm.ShowDialog()

        If frm.OkPressed Then
            Dim frm2 As New NewMove(frm.WorkOrderID)
            frm2.Owner = Me
            frm2.ShowDialog()
            frm2.Dispose()
        End If

        frm.Dispose()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.lsvMoves.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewMove(CInt(Me.lsvMoves.SelectedItems(0).SubItems(1).Text))
            frm.Owner = Me
            frm.Mode = FormMode.Edit
            frm.MoveID = CInt(Me.lsvMoves.SelectedItems(0).SubItems(0).Text)
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click, btnWoRemoveMove.Click

        Dim myLsv As ListView = Nothing
        Dim SenderTag As Integer = CInt(CType(sender, Button).Tag)

        If SenderTag = 0 Then
            myLsv = Me.lsvMoves
        Else
            myLsv = Me.lsvWoMoves
        End If

        If myLsv.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            Dim MvId As String = myLsv.SelectedItems(0).SubItems(0).Text
            Dim WoId As Integer = -1

            If SenderTag = 0 Then
                WoId = CInt(Me.lsvMoves.SelectedItems(0).SubItems(1).Text)
            Else
                WoId = CInt(Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text)
            End If

            If MessageBox.Show("Move ID # " & MvId & " will be permanently deleted." & vbCrLf & "Are you sure?", _
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Me.Cursor = Cursors.WaitCursor

                ' remove move from DB
                If GS.RemoveMoveFromDB(MvId) Then

                    ' refresh
                    Me.tsbRefresh_Click(Nothing, Nothing)

                    ' update WO details move list if open
                    Dim WoDtls As WoDetails = Nothing
                    If GS.DetailFormIsOpen(WoDtls, WoId) Then
                        WoDtls.FillMovesList()
                    End If

                    ' update Moves list if open
                    If GS.FormIsOpen(My.Forms.Form1.frmMoveList) Then
                        My.Forms.Form1.frmMoveList.tsbRefresh_Click(Nothing, Nothing)
                    End If

                    ' update container list if open
                    If GS.FormIsOpen(My.Forms.Form1.frmContainerList) Then
                        My.Forms.Form1.frmContainerList.tsbRefresh_Click(Nothing, Nothing)
                    End If

                End If

                Me.Cursor = Cursors.Default

            End If

        End If
    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click, _
        EditToolStripMenuItem.Click, RemoveToolStripMenuItem.Click

        Select Case CInt(CType(sender, ToolStripMenuItem).Tag)
            Case 1
                Me.btnAdd_Click(Nothing, Nothing)
            Case 2
                Me.btnEdit_Click(Nothing, Nothing)
            Case 3
                Me.btnRemove_Click(Nothing, Nothing)
        End Select

    End Sub

    Private Sub ToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAddMove.Click, _
        tsbRemoveMove.Click, tsbEditMove.Click

        Select Case CInt(CType(sender, ToolStripButton).Tag)
            Case 1
                Me.btnAdd_Click(Nothing, Nothing)
            Case 2
                Me.btnEdit_Click(Nothing, Nothing)
            Case 3
                Dim sndr As New Button
                sndr.Tag = 0
                Me.btnRemove_Click(sndr, Nothing)
        End Select

    End Sub

    Private Sub lsvMoves_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvMoves.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.cmsMoves.Show(Me.lsvMoves, e.Location)
        End If
    End Sub

    Private Sub btnTruckDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTruckDetails.Click
        Dim frm As New NewTruck
        frm.Owner = Me
        frm.Mode = FormMode.Details
        frm.TruckID = CInt(Me.TruckIdCol(Me.cbxTrucks.Text))
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub btnDriverDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDriverDetails.Click
        Dim frm As New NewDrivers
        frm.Owner = Me
        frm.Mode = FormMode.Details
        frm.DriverID = CInt(Me.DriverIdCol(Me.cbxDrivers.Text))
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub WorkOrderDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderDetailsToolStripMenuItem.Click
        My.Forms.Form1.OpenWorkOrderDetailsForm(CInt(Me.lsvMoves.SelectedItems(0).SubItems(1).Text))
    End Sub

    Private Sub TabControlMoves_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlMoves.SelectedIndexChanged

        Me.Cursor = Cursors.WaitCursor

        Me.TabControlMoves.SelectedTab.Controls.Add(Me.lsvMoves)
        Me.lsvMoves.BringToFront()

        Me.PopulateMovesLsv()

        Me.Cursor = Cursors.Default

    End Sub

    Friend Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click

        Me.Cursor = Cursors.WaitCursor

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)

        Try
            myConn.Open()
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            Exit Sub
        End Try

        Dim tr As String = Me.cbxTrucks.Text
        Dim dr As String = Me.cbxDrivers.Text

        If Me.FillDsMoves(myConn) AndAlso Me.FillCBXs(myConn) AndAlso Me.TabControlMoves.SelectedIndex = 0 Then
            Me.PopulateMovesLsv()
            Me.PopulateWoMovesLsv()
        End If

        Me.cbxTrucks.Text = tr
        Me.cbxDrivers.Text = dr

        If Not IsNothing(myConn) Then
            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub lsvMoves_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvMoves.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvMoves.SelectedItems.Count > 0 Then
            Me.btnEdit_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsbReportsMoves_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReportsMoves.ButtonClick
        Me.tsbReportsMoves.ShowDropDown()
    End Sub

    Private Sub tsmMovesRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmMovesByDriver.Click, tsmMovesByWorkOrder.Click
        Me.Cursor = Cursors.WaitCursor

        Select Case CInt(CType(sender, ToolStripMenuItem).Tag)
            Case 0
                My.Forms.Form1.MovesByDriverToolStripMenuItem_Click(Nothing, Nothing)
            Case 1
                My.Forms.Form1.MovesByWorkOrderToolStripMenuItem_Click(Nothing, Nothing)
        End Select


        Me.Cursor = Cursors.Default
    End Sub

#End Region ' Moves Controls

#Region "WorkOrders Controls"

    Private Sub ToolStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNewWO.Click, _
        tsmEditWo.Click, tsmDetailsWo.Click, tsmRptDelivery2Wo.Click, tsmCloseWo.Click, tsmRefreshWo.Click, tsmAddMove.Click

        Select Case CInt(CType(sender, ToolStripMenuItem).Tag)
            Case 1
                Me.tsbNewWo_Click(Nothing, Nothing)
            Case 2
                Me.tsbEditWo_Click(Nothing, Nothing)
            Case 3
                Me.tsbDetailsWo_Click(Nothing, Nothing)
            Case 4
                Me.tsbRefreshWo_Click(Nothing, Nothing)
            Case 5
                Me.tsmDelOrderReptWo_Click(Nothing, Nothing)
            Case 6
                Me.tsbCloseWo_Click(Nothing, Nothing)
            Case 7
                Me.btnWoAddMove_Click(Nothing, Nothing)
        End Select

    End Sub

    Private Sub lsvWorkOrders_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvWorkOrders.ColumnClick
        Me._woLsvSorter.Sort(e.Column)
    End Sub

    Private Sub lsvWorkOrders_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvWorkOrders.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvWorkOrders.SelectedItems.Count > 0 Then
            Me.tsbEditWo_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub lsvWorkOrders_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvWorkOrders.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim flag As Boolean = (Me.lsvWorkOrders.SelectedItems.Count > 0)

            Me.tsmEditWo.Enabled = flag
            Me.tsmDetailsWo.Enabled = flag
            Me.tsmRptDelivery2Wo.Enabled = flag
            Me.tsmCloseWo.Enabled = flag

            Me.cmsWorkOrders.Show(Me.lsvWorkOrders, e.Location)
        End If
    End Sub

    Friend Sub tsbRefreshWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefreshWo.Click
        Me.Cursor = Cursors.WaitCursor

        ' referenct to selected wo
        Dim SelWoRef As String = String.Empty

        If Me.lsvWorkOrders.SelectedItems.Count > 0 Then _
            SelWoRef = Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)

        Try
            myConn.Open()
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            Exit Sub
        End Try

        Me.lsvWorkOrders.Items.Clear()
        Me.lsvWoMoves.Items.Clear()

        If Me.FillDsWorkOrder(myConn) AndAlso Me.FillDsMoves(myConn) Then
            Me.PopulateWorkOrdersLsv()
            Me.PopulateWoMovesLsv()
        End If

        If myConn IsNot Nothing Then
            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
        End If

        ' sort lsv
        Me._woLsvSorter.Sort()

        ' select previously selected wo through reference
        For Each lsvItem As ListViewItem In Me.lsvWorkOrders.Items
            If lsvItem.SubItems(0).Text = SelWoRef Then
                lsvItem.Selected = True
                lsvItem.Focused = True
                Exit For
            End If
        Next

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbCloseWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCloseWo.Click
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    Me.tsbRefreshWo_Click(Nothing, Nothing)

                    ' fixes unwanted result
                    Me.lsvWorkOrders.Refresh()

                    ' refresh WO Details if open
                    Dim DtFrm As WoDetails = Nothing
                    If GS.DetailFormIsOpen(DtFrm, WoId) Then
                        DtFrm.RefreshData()
                    End If

                    ' refresh WO if open
                    If GS.FormIsOpen(My.Forms.Form1.frmWrkOrderList) Then
                        My.Forms.Form1.frmWrkOrderList.RefreshList()
                    End If

                End If

            End If

        End If
    End Sub

    Private Sub tsbDetailsWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDetailsWo.Click
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            My.Forms.Form1.OpenWorkOrderDetailsForm(CInt(Me.lsvWorkOrders.SelectedItems.Item(0).SubItems(0).Text))
        End If
    End Sub

    Private Sub tsbEditWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEditWo.Click
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewWorkOrder
            frm.Owner = Me
            frm.Mode = FormMode.Edit
            frm.WorkOrderID = CInt(Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text)
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub tsbNewWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNewWo.Click
        Dim frm As New NewWorkOrder
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tsmDelOrderReptWo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDelOrderReptWo.Click
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

    Private Sub btnWoEditMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWoEditMove.Click
        If Me.lsvWoMoves.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a Move.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewMove(CInt(Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text))
            frm.Owner = Me
            frm.Mode = FormMode.Edit
            frm.MoveID = CInt(Me.lsvWoMoves.SelectedItems(0).SubItems(0).Text)
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub btnWoAddMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWoAddMove.Click
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a Work Order.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewMove(CInt(Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text))
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub lsvWorkOrders_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsvWorkOrders.SelectedIndexChanged
        Me.PopulateWoMovesLsv()
    End Sub

    Private Sub lsvWoMoves_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvWoMoves.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And Me.lsvWoMoves.SelectedItems.Count > 0 Then
            Me.cmsWoMoves.Show(Me.lsvWoMoves, e.Location)
        End If
    End Sub

    Private Sub lsvWoMoves_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvWoMoves.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvWoMoves.SelectedItems.Count > 0 Then
            Me.btnWoEditMove_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tsmWoMoves_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmWoMovesEdit.Click, tsmWoMovesRemove.Click

        Select Case CInt(CType(sender, ToolStripMenuItem).Tag)
            Case 1
                Me.btnWoEditMove_Click(Nothing, Nothing)
            Case 2
                Dim SndBtn As New Button
                SndBtn.Tag = 1
                Me.btnRemove_Click(SndBtn, Nothing)
        End Select

    End Sub

    Private Sub tsmWorkOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmWorkOrders.Click, tsmWorkOrders2.Click
        Me.Cursor = Cursors.WaitCursor
        My.Forms.Form1.WorkOrdersToolStripMenuItem1_Click(Nothing, Nothing)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsmWorkOrdersByCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmWorkOrdersByCustomer.Click, tsmWorkOrdersByCustomers2.Click
        Me.Cursor = Cursors.WaitCursor
        My.Forms.Form1.WorkOrdersByCustomerToolStripMenuItem_Click(Nothing, Nothing)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsmWorkOrdersByShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmWorkOrdersByShipTo.Click, tsmWorkOrdersByShipTo2.Click
        Me.Cursor = Cursors.WaitCursor
        My.Forms.Form1.WorkOrdersByShipToToolStripMenuItem_Click(Nothing, Nothing)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsmRptBilling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNotBilledWorkOrders.Click, tsmReadyToBillWorkOrders.Click, _
        tsmNotBilledWorkOrders2.Click, tsmReadyToBillWorkOrders2.Click

        Me.Cursor = Cursors.WaitCursor
        My.Forms.Form1.RptBillingToolStripMenuItem_Click(sender, e)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub tsbReportsWo_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReportsWo.ButtonClick
        Me.tsbReportsWo.ShowDropDown()
    End Sub

#End Region ' WorkOrders Controls

#Region "Main Controls"

    Private Sub ListsLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked, LinkLabel2.LinkClicked, _
        LinkLabel3.LinkClicked, LinkLabel4.LinkClicked, LinkLabel5.LinkClicked, LinkLabel6.LinkClicked, LinkLabel7.LinkClicked, LinkLabel8.LinkClicked, LinkLabel9.LinkClicked, LinkLabel10.LinkClicked

        Select Case CInt(CType(sender, LinkLabel).Tag)
            Case 0
                My.Forms.Form1.WorkOrdersToolStripMenuItem_Click(Nothing, Nothing)
            Case 1
                My.Forms.Form1.ContainerListToolStripMenuItem_Click(Nothing, Nothing)
            Case 2
                My.Forms.Form1.MovesToolStripMenuItem_Click(Nothing, Nothing)
            Case 3
                My.Forms.Form1.CustomersToolStripMenuItem_Click(Nothing, Nothing)
            Case 4
                My.Forms.Form1.ShipTosToolStripMenuItem_Click(Nothing, Nothing)
            Case 5
                My.Forms.Form1.LocationToolStripMenuItem_Click(Nothing, Nothing)
            Case 6
                My.Forms.Form1.DriversToolStripMenuItem_Click(Nothing, Nothing)
            Case 7
                My.Forms.Form1.TruckListToolStripMenuItem_Click(Nothing, Nothing)
            Case 8
                My.Forms.Form1.TruckServicesToolStripMenuItem_Click(Nothing, Nothing)
            Case 9
                My.Forms.Form1.TruckMileageListToolStripMenuItem_Click(Nothing, Nothing)
        End Select

    End Sub

    Private Sub CreateNewLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked, LinkLabel12.LinkClicked, _
        LinkLabel13.LinkClicked, LinkLabel14.LinkClicked, LinkLabel15.LinkClicked, LinkLabel16.LinkClicked, LinkLabel17.LinkClicked, LinkLabel18.LinkClicked, LinkLabel20.LinkClicked

        Select Case CInt(CType(sender, LinkLabel).Tag)
            Case 0
                My.Forms.Form1.NewWorkOrderToolStripMenuItem_Click(Nothing, Nothing)
            Case 2
                My.Forms.Form1.NewMoveToolStripMenuItem_Click(Nothing, Nothing)
            Case 3
                My.Forms.Form1.NewCustomerToolStripMenuItem_Click(Nothing, Nothing)
            Case 4
                My.Forms.Form1.NewShipToToolStripMenuItem_Click(Nothing, Nothing)
            Case 5
                My.Forms.Form1.NewLocationToolStripMenuItem_Click(Nothing, Nothing)
            Case 6
                My.Forms.Form1.NewDriverToolStripMenuItem_Click(Nothing, Nothing)
            Case 7
                My.Forms.Form1.NewTruckToolStripMenuItem_Click(Nothing, Nothing)
            Case 8
                My.Forms.Form1.NewTruckServiceToolStripMenuItem_Click(Nothing, Nothing)
            Case 9
                My.Forms.Form1.NewTruckMileageToolStripMenuItem_Click(Nothing, Nothing)
        End Select

    End Sub

    Private Sub MainLsvs_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _
        lsvReturnToPier.MouseDoubleClick, lsvDelSchedule.MouseDoubleClick

        Dim myLsv As ListView = CType(sender, ListView)

        If e.Button = Windows.Forms.MouseButtons.Left And myLsv.SelectedItems.Count > 0 Then

            Me.TabControl1.SelectedIndex = 1

            For Each lsvItem As ListViewItem In Me.lsvWorkOrders.Items
                If lsvItem.Text = myLsv.SelectedItems(0).SubItems(0).Text Then
                    lsvItem.Selected = True
                    lsvItem.Focused = True
                    Exit For
                End If
            Next

        End If

    End Sub

    Private Sub lsvDocExp_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvDocExp.MouseDoubleClick

        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvDocExp.SelectedItems.Count > 0 Then

            If CInt(Me.lsvDocExp.SelectedItems(0).Tag) = 1 Then
                Dim frm As New NewDrivers
                frm.Owner = Me
                frm.Mode = FormMode.Edit
                frm.DriverID = CInt(Me.docDriverIdCol(Me.lsvDocExp.SelectedItems(0).SubItems(0).Text))
                frm.ShowDialog()
                frm.Dispose()
            Else
                Dim frm As New NewTruck
                frm.Owner = Me
                frm.Mode = FormMode.Edit
                frm.TruckID = CInt(Me.docTruckIdCol(Me.lsvDocExp.SelectedItems(0).SubItems(0).Text))
                frm.ShowDialog()
                frm.Dispose()
            End If

        End If

    End Sub

#End Region ' Main Controls

#End Region ' Control Events

#Region "Methoes & Properties"

    Friend Sub RefreshMain()

        Me.Cursor = Cursors.WaitCursor

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)

        Try
            myConn.Open()
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            If myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.lsvReturnToPier.Items.Clear()
        Me.lsvDelSchedule.Items.Clear()
        Me.lsvDocExp.Items.Clear()

        If Me.FillDsReturnToPier(myConn) AndAlso Me.FillDsDeliverySchedule(myConn) AndAlso Me.FillDsExpDoc(myConn) Then
            Me.PopulateMainLsvs()
        End If

        If myConn IsNot Nothing Then
            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PopulateMainLsvs()

        ' Return to pier
        For Each Row As DataRow In Me.myDs.Tables("ReturnToPier").Rows

            Dim dt As Date = CDate(Row("Date"))

            If CInt(Row("Move Type")) = 1 Then
                If dt.DayOfWeek <> DayOfWeek.Friday Then
                    dt = dt.AddDays(2)
                End If
            End If

            If dt.Date < Now.AddDays(1) Then

                Dim lsvItem As New ListViewItem(Row("WorkOrder ID").ToString)
                lsvItem.SubItems.Add(Row("Container Number").ToString)
                lsvItem.SubItems.Add(dt.ToString)

                If dt.Date = Now.Date Then
                    lsvItem.BackColor = Color.Yellow
                ElseIf dt.Date < Now.Date Then
                    lsvItem.BackColor = Color.Red
                End If

                lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)

                Me.lsvReturnToPier.Items.Add(lsvItem)

            End If

        Next

        'delivery schedule
        For Each Row As DataRow In Me.myDs.Tables("DeliverySchedule").Rows

            Dim lsvItem As New ListViewItem(Row("WorkOrder ID").ToString)
            lsvItem.SubItems.Add(Row("Container Number").ToString)
            lsvItem.SubItems.Add(Row("Delivery Date").ToString)

            If CDate(Row("Delivery Date")).Date = Now.Date Then
                lsvItem.BackColor = Color.Yellow
            End If

            lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)

            Me.lsvDelSchedule.Items.Add(lsvItem)

        Next

        Dim dt30 As Date = Now.AddDays(30)

        Me.docDriverIdCol.Clear()

        ' document expiration
        For Each Row As DataRow In Me.myDs.Tables("DriverDocExp").Rows

            Me.docDriverIdCol.Add(Row("Driver ID"), Row("Driver Name").ToString)

            If Not IsDBNull(Row("DL Exp")) AndAlso CDate(Row("DL Exp")).Date <= dt30.Date Then

                Dim DlExp As Date = CDate(Row("DL Exp"))
                Dim lsvItem As New ListViewItem(Row("Driver Name").ToString)
                lsvItem.SubItems.Add("Driver License")
                lsvItem.SubItems.Add(DlExp.ToShortDateString)

                If DlExp.Date = Now.Date Then
                    lsvItem.BackColor = Color.Yellow
                ElseIf DlExp.Date < Now.Date Then
                    lsvItem.BackColor = Color.Red
                End If

                lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                lsvItem.Tag = 1

                Me.lsvDocExp.Items.Add(lsvItem)

            End If

            If Not IsDBNull(Row("MedCard Exp")) AndAlso CDate(Row("MedCard Exp")).Date <= dt30.Date Then

                Dim McExp As Date = CDate(Row("MedCard Exp"))
                Dim lsvItem As New ListViewItem(Row("Driver Name").ToString)
                lsvItem.SubItems.Add("Medical Card")
                lsvItem.SubItems.Add(McExp.ToShortDateString)

                If McExp.Date = Now.Date Then
                    lsvItem.BackColor = Color.Yellow
                ElseIf McExp.Date < Now.Date Then
                    lsvItem.BackColor = Color.Red
                End If

                lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                lsvItem.Tag = 1

                Me.lsvDocExp.Items.Add(lsvItem)

            End If

            If Not IsDBNull(Row("SeaLink Exp")) AndAlso CDate(Row("SeaLink Exp")).Date <= dt30.Date Then

                Dim SlExp As Date = CDate(Row("SeaLink Exp"))
                Dim lsvItem As New ListViewItem(Row("Driver Name").ToString)
                lsvItem.SubItems.Add("SeaLink")
                lsvItem.SubItems.Add(SlExp.ToShortDateString)

                If SlExp.Date = Now.Date Then
                    lsvItem.BackColor = Color.Yellow
                ElseIf SlExp.Date < Now.Date Then
                    lsvItem.BackColor = Color.Red
                End If

                lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                lsvItem.Tag = 1

                Me.lsvDocExp.Items.Add(lsvItem)

            End If

        Next

        Me.docTruckIdCol.Clear()

        For Each Row As DataRow In Me.myDs.Tables("TruckDocExp").Rows

            Me.docTruckIdCol.Add(Row("Truck ID"), Row("Truck Number").ToString)

            If Not IsDBNull(Row("Registration Exp")) AndAlso CDate(Row("Registration Exp")).Date <= dt30.Date Then

                Dim RgExp As Date = CDate(Row("Registration Exp"))
                Dim lsvItem As New ListViewItem(Row("Truck Number").ToString)
                lsvItem.SubItems.Add("Registration")
                lsvItem.SubItems.Add(RgExp.ToShortDateString)

                If RgExp.Date = Now.Date Then
                    lsvItem.BackColor = Color.Yellow
                ElseIf RgExp.Date < Now.Date Then
                    lsvItem.BackColor = Color.Red
                End If

                lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                lsvItem.Tag = 2

                Me.lsvDocExp.Items.Add(lsvItem)

            End If

            If Not IsDBNull(Row("DOT Insp Exp")) AndAlso CDate(Row("DOT Insp Exp")).Date <= dt30.Date Then

                Dim DiExp As Date = CDate(Row("DOT Insp Exp"))
                Dim lsvItem As New ListViewItem(Row("Truck Number").ToString)
                lsvItem.SubItems.Add("DOT Inspection")
                lsvItem.SubItems.Add(DiExp.ToShortDateString)

                If DiExp.Date = Now.Date Then
                    lsvItem.BackColor = Color.Yellow
                ElseIf DiExp.Date < Now.Date Then
                    lsvItem.BackColor = Color.Red
                End If

                lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                lsvItem.Tag = 2

                Me.lsvDocExp.Items.Add(lsvItem)

            End If

            If Not IsDBNull(Row("Emission Insp Exp")) AndAlso CDate(Row("Emission Insp Exp")).Date <= dt30.Date Then

                Dim EiExp As Date = CDate(Row("Emission Insp Exp"))
                Dim lsvItem As New ListViewItem(Row("Truck Number").ToString)
                lsvItem.SubItems.Add("Emission Inspection")
                lsvItem.SubItems.Add(EiExp.ToShortDateString)

                If EiExp.Date = Now.Date Then
                    lsvItem.BackColor = Color.Yellow
                ElseIf EiExp.Date < Now.Date Then
                    lsvItem.BackColor = Color.Red
                End If

                lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                lsvItem.Tag = 2

                Me.lsvDocExp.Items.Add(lsvItem)

            End If

            If Not IsDBNull(Row("IFTA Exp")) AndAlso CDate(Row("IFTA Exp")).Date <= dt30.Date Then

                Dim EiExp As Date = CDate(Row("IFTA Exp"))
                Dim lsvItem As New ListViewItem(Row("Truck Number").ToString)
                lsvItem.SubItems.Add("IFTA")
                lsvItem.SubItems.Add(EiExp.ToShortDateString)

                If EiExp.Date = Now.Date Then
                    lsvItem.BackColor = Color.Yellow
                ElseIf EiExp.Date < Now.Date Then
                    lsvItem.BackColor = Color.Red
                End If

                lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                lsvItem.Tag = 2

                Me.lsvDocExp.Items.Add(lsvItem)

            End If

        Next

    End Sub

    Private Sub PopulateWoMovesLsv()


        ' clear old data
        Me.lsvWoMoves.Items.Clear()

        ' no wo selected
        If Me.lsvWorkOrders.SelectedItems.Count = 0 Then Exit Sub

        For Each Row As DataRow In Me.myDs.Tables("Moves").Select("[WorkOrder ID]=" & Me.lsvWorkOrders.SelectedItems(0).SubItems(0).Text)
            Dim lsvItem As New ListViewItem(Row.Item("Move ID").ToString)
            lsvItem.SubItems.Add(Row.Item("FromLocation Name").ToString)
            lsvItem.SubItems.Add(Row.Item("ToLocation Name").ToString)
            lsvItem.SubItems.Add(Row.Item("Start Time").ToString)
            lsvItem.SubItems.Add(Row.Item("End Time").ToString)
            lsvItem.SubItems.Add(Row.Item("Driver Name").ToString)
            lsvItem.SubItems.Add(Row.Item("Truck Number").ToString)

            If CBool(Row.Item("Complete")) Then
                lsvItem.SubItems.Add("Yes")
            Else
                lsvItem.SubItems.Add(String.Empty)
            End If

            Me.lsvWoMoves.Items.Add(lsvItem)
        Next

    End Sub

    Private Sub PopulateWorkOrdersLsv()

        ' clear old data
        Me.lsvWorkOrders.Items.Clear()

        For Each Row As DataRow In Me.myDs.Tables("WorkOrders").Rows

            Dim lsvItem As New ListViewItem(Row("WorkOrder ID").ToString)
            lsvItem.SubItems.Add(Row("Customer Name").ToString)
            lsvItem.SubItems.Add(Row("ShipTo Name").ToString)
            lsvItem.SubItems.Add(Row("BK BL").ToString)
            lsvItem.SubItems.Add(Row("Container Number").ToString)
            lsvItem.SubItems.Add(Row("Reference").ToString)
            lsvItem.SubItems.Add(Row("Delivery Date").ToString)
            lsvItem.SubItems.Add(Row("PickUp Terminal Name").ToString)
            lsvItem.SubItems.Add(Row("DropOff Terminal Name").ToString)

            lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)

            Me.lsvWorkOrders.Items.Add(lsvItem)

        Next

    End Sub

    Private Sub PopulateMovesLsv()

        Dim Crt As String = "[Complete]=0"

        Select Case Me.TabControlMoves.SelectedIndex
            Case 1 ' trucks
                If Trim(Me.cbxTrucks.Text) = String.Empty Then
                    Crt &= " AND [Truck Number] IS NULL"
                Else
                    Crt &= " AND [Truck Number]='" & GS.FilterSingleQuote(Me.cbxTrucks.Text) & "'"
                End If
            Case 2 ' drivers
                If Trim(Me.cbxDrivers.Text) = String.Empty Then
                    Crt &= " AND [Driver Name] IS NULL"
                Else
                    Crt &= " AND [Driver Name]='" & GS.FilterSingleQuote(Me.cbxDrivers.Text) & "'"
                End If
        End Select

        Dim Rows() As DataRow = Me.myDs.Tables("Moves").Select(Crt)

        ' clear lsv
        Me.lsvMoves.Items.Clear()

        For Each Row As DataRow In Rows
            Dim lsvItem As New ListViewItem(Row("Move ID").ToString)
            lsvItem.SubItems.Add(Row("WorkOrder ID").ToString)
            lsvItem.SubItems.Add(Row("Container Number").ToString)
            lsvItem.SubItems.Add(Row("FromLocation Name").ToString)
            lsvItem.SubItems.Add(Row("ToLocation Name").ToString)
            lsvItem.SubItems.Add(Row("Start Time").ToString)

            If IsDBNull(Row("End Time")) Then
                lsvItem.SubItems.Add(String.Empty)
            Else
                lsvItem.SubItems.Add(Row("End Time").ToString)
            End If

            lsvItem.SubItems.Add(Row("Driver Name").ToString)
            lsvItem.SubItems.Add(Row("Truck Number").ToString)

            If CBool(Row("LD MT")) Then
                lsvItem.SubItems.Add("MT")
            Else
                lsvItem.SubItems.Add("LD")
            End If

            If CDate(Row("Start Time")) < Now Then
                lsvItem.SubItems.Add("In Progress")
            Else
                lsvItem.SubItems.Add("Scheduled")
            End If

            lsvItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)

            Me.lsvMoves.Items.Add(lsvItem)

        Next

    End Sub

    Friend Function FillDsExpDoc() As Boolean
        Return Me.FillDsExpDoc(Nothing)
    End Function

    Friend Function FillDsExpDoc(ByRef Connection As SqlClient.SqlConnection) As Boolean
        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDaDrivers As New SqlClient.SqlDataAdapter
        Dim myDaTrucks As New SqlClient.SqlDataAdapter
        Dim OutConn As Boolean = (Not IsNothing(Connection) AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True
        Dim dtStr As String = Now.AddDays(30).ToShortDateString & " 23:59:59"

        ' clear old data
        Me.myDs.Tables("DriverDocExp").Clear()
        Me.myDs.Tables("TruckDocExp").Clear()

        Try
            If OutConn Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
            End If

            myCmd.Connection = myConn

            myCmd.CommandText = "SELECT [Driver ID],[Driver Name],[DL Exp],[MedCard Exp],[SeaLink Exp] FROM [Drivers] " & _
                "WHERE ([DL Exp]<'" & dtStr & "' OR [MedCard Exp]<'" & dtStr & "' OR " & _
                "[SeaLink Exp]<'" & dtStr & "') AND [Inactive]=0"

            myDaDrivers.SelectCommand = myCmd
            myDaDrivers.Fill(Me.myDs, "DriverDocExp")

            myCmd.CommandText = "SELECT [Truck ID],('Truck # ' + [Truck Number]) AS [Truck Number],[Registration Exp], " & _
                "[DOT Insp Exp],[Emission Insp Exp],[IFTA Exp] FROM [Trucks] WHERE [Inactive]=0 AND " & _
                "([Registration Exp]<'" & dtStr & "' OR [DOT Insp Exp]<'" & dtStr & "' OR " & _
                "[Emission Insp Exp]<'" & dtStr & "' OR [IFTA Exp]<'" & dtStr & "')"

            myDaTrucks.SelectCommand = myCmd
            myDaTrucks.Fill(Me.myDs, "TruckDocExp")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConn And Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDaDrivers) Then myDaDrivers.Dispose()
            If Not IsNothing(myDaTrucks) Then myDaTrucks.Dispose()
        End Try

        Return flag

    End Function

    Friend Function FillDsDeliverySchedule() As Boolean
        Return Me.FillDsDeliverySchedule(Nothing)
    End Function

    Friend Function FillDsDeliverySchedule(ByRef Connection As SqlClient.SqlConnection) As Boolean

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim OutConn As Boolean = (Not IsNothing(Connection) AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True

        ' clear old data
        Me.myDs.Tables("DeliverySchedule").Clear()

        Try
            If OutConn Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [WorkOrder ID],[Container Number],[Delivery Date] FROM [WorkOrders] " & _
                "WHERE [Delivery Date]>='" & Now.ToShortDateString & " 00:00:00' AND [Delivery Date]<'" & _
                Now.AddDays(1).ToShortDateString & " 23:59:59' AND [Status]=0 ORDER BY [Delivery Date]"

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "DeliverySchedule")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConn And Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        Return flag

    End Function

    Friend Function FillDsReturnToPier() As Boolean
        Return Me.FillDsReturnToPier(Nothing)
    End Function

    Friend Function FillDsReturnToPier(ByRef Connection As SqlClient.SqlConnection) As Boolean

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim OutConn As Boolean = (Not IsNothing(Connection) AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True

        ' clear old data
        Me.myDs.Tables("ReturnToPier").Clear()

        Try
            If OutConn Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [WorkOrder ID],[Container Number],[Move Type], " & _
                "(SELECT CASE [Move Type] WHEN 1 THEN DATEADD(day,4,[PickUp Date]) WHEN 2 THEN [DropOff Date] " & _
                "END) [Date] FROM [WorkOrders] WHERE ([Move Type]=1 OR [Move Type]=2) " & _
                "AND [Status]=0 AND (SELECT CASE [Move Type] WHEN 1 THEN " & _
                "DATEADD(day,4,[PickUp Date]) WHEN 2 THEN [DropOff Date] END)<'" & _
                Now.AddDays(1).ToShortDateString & " 23:59:59' ORDER BY [Date]"

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "ReturnToPier")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConn And Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        Return flag

    End Function

    Friend Function FillDsWorkOrder() As Boolean
        Return Me.FillDsWorkOrder(Nothing)
    End Function

    Friend Function FillDsWorkOrder(ByRef Connection As SqlClient.SqlConnection) As Boolean

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim OutConn As Boolean = (Not IsNothing(Connection) AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True

        ' clear old data
        Me.myDs.Tables("WorkOrders").Clear()

        Try
            If OutConn Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [WorkOrders].[WorkOrder ID],[WorkOrders].[BK BL],[WorkOrders].[Container Number], " & _
                "[WorkOrders].[Reference],[WorkOrders].[Delivery Date], [Customers].[Customer Name], " & _
                "[ShipTo].[ShipTo Name],(SELECT [Location].[Location Name] FROM [Location] WHERE " & _
                "[Location].[Location ID]=[WorkOrders].[PickUp Terminal]) [PickUp Terminal Name], " & _
                "(SELECT [Location].[Location Name] FROM [Location] WHERE " & _
                "[Location].[Location ID]=[WorkOrders].[DropOff Terminal]) [DropOff Terminal Name] " & _
                "FROM [WorkOrders] INNER JOIN [Customers] ON [WorkOrders].[Customer ID]=[Customers].[Customer ID] " & _
                "INNER JOIN [ShipTo] ON [WorkOrders].[ShipTo ID]=[ShipTo].[ShipTo ID] WHERE " & _
                "[WorkOrders].[Status]=0 ORDER BY [WorkOrders].[WorkOrder ID]"

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "WorkOrders")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConn And Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        Return flag

    End Function

    Friend Function FillDsMoves() As Boolean
        Return Me.FillDsMoves(Nothing)
    End Function

    Friend Function FillDsMoves(ByRef Connection As SqlClient.SqlConnection) As Boolean

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim OutConn As Boolean = (Not IsNothing(Connection) AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True

        ' clear old data
        Me.myDs.Tables("Moves").Clear()

        Try
            If OutConn Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [Moves].[Move ID],[Moves].[WorkOrder ID],[Moves].[Start Time],[Moves].[End Time]," & _
                " [WorkOrders].[Container Number],[Drivers].[Driver Name],[Trucks].[Truck Number],[Moves].[LD MT]," & _
                " [Moves].[Complete],(CASE [Moves].[FromLocation] WHEN 0 THEN" & _
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
                " WHERE [WorkOrders].[Status]=0 ORDER BY [Moves].[Start Time]"

            myDa.SelectCommand = myCmd
            myDa.Fill(Me.myDs, "Moves")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConn And Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        Return flag

    End Function

    Private Function FillCBXs() As Boolean
        Return Me.FillCBXs(Nothing)
    End Function

    Private Function FillCBXs(ByRef Connection As SqlClient.SqlConnection) As Boolean

        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDaTr As New SqlClient.SqlDataAdapter
        Dim myDaDr As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim OutConn As Boolean = (Not IsNothing(Connection) AndAlso Connection.State = ConnectionState.Open)
        Dim flag As Boolean = True

        Me.cbxTrucks.Items.Clear()
        Me.TruckIdCol.Clear()

        Me.cbxDrivers.Items.Clear()
        Me.DriverIdCol.Clear()

        Try
            If OutConn Then
                myConn = Connection
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [Truck ID],[Truck Number] FROM [Trucks] WHERE [Inactive]=0 ORDER BY [Truck Number]"

            myDaTr.SelectCommand = myCmd
            myDaTr.Fill(myDs, "Trucks")

            myCmd.CommandText = "SELECT [Driver ID],[Driver Name] FROM [Drivers] WHERE [Inactive]=0 ORDER BY [Driver Name]"

            myDaDr.SelectCommand = myCmd
            myDaDr.Fill(myDs, "Drivers")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            flag = False
        Finally
            If Not OutConn And Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDaTr) Then myDaTr.Dispose()
            If Not IsNothing(myDaDr) Then myDaDr.Dispose()
        End Try

        Me.cbxTrucks.Items.Add(String.Empty)
        Me.cbxDrivers.Items.Add(String.Empty)

        If flag Then
            ' fill trucks cbx
            For Each Row As DataRow In myDs.Tables("Trucks").Rows
                Me.cbxTrucks.Items.Add(Row.Item("Truck Number"))
                Me.TruckIdCol.Add(Row.Item("Truck ID"), Row.Item("Truck Number").ToString)
            Next
            ' fill drivers cbx
            For Each Row As DataRow In myDs.Tables("Drivers").Rows
                Me.cbxDrivers.Items.Add(Row.Item("Driver Name"))
                Me.DriverIdCol.Add(Row.Item("Driver ID"), Row.Item("Driver Name").ToString)
            Next
        End If

        If Not IsNothing(myDs) Then myDs.Dispose()

        Return flag

    End Function

#End Region 'Methoes & Properties

End Class