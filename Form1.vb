Public Class Form1

#Region "Global Fields"

    Friend myUser As User

    ' children forms
    Friend frmLogin As Login
    Friend frmContainerList As ContainerList
    Friend frmWrkOrderList As WorkOrderList
    Friend frmCustomerList As CustomerList
    Friend frmShipToList As ShipToList
    Friend frmLocationList As LocationList
    Friend frmDriverList As DriverList
    Friend frmTruckList As TruckList
    Friend frmTruckServiceList As TruckServiceList
    Friend frmWoDetails As WoDetails
    Friend frmMoveList As MoveList
    Friend frmTruckMileageList As TruckMileageList
    Friend frmDispatch As Dispatch

#End Region ' Global Fields

#Region "Form Events"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' get form settings
        Me.Width = Me.FormWidth
        Me.Height = Me.FormHeight
        Me.WindowState = Me.myWindowState

        ' hide menus
        Me.WindowToolStripMenuItem.Visible = False

        ' Login dialog
        Me.LogInToolStripMenuItem_Click(Nothing, Nothing)

        ''temp
        'Dim frm As New BillingWO(BillingWO.Mode.NotBilled)
        'frm.ShowDialog()
        'frm.Dispose()

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' save settings
        Me.myWindowState = Me.WindowState
        If Me.WindowState = FormWindowState.Normal Then
            Me.FormWidth = Me.Width
            Me.FormHeight = Me.Height
        End If
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.frmLogin IsNot Nothing Then _
            Me.frmLogin.Activate()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Friend Sub ContainerListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContainersToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(frmContainerList) Then
            If Me.frmContainerList.WindowState = FormWindowState.Minimized Then _
                Me.frmContainerList.WindowState = FormWindowState.Normal
            Me.frmContainerList.Activate()
        Else
            Me.frmContainerList = New ContainerList
            Me.frmContainerList.MdiParent = Me
            Me.frmContainerList.Tag = Me.CreateWindowMenu(Me.frmContainerList)
            Me.frmContainerList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub CustomersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomersToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmCustomerList) Then
            If Me.frmCustomerList.WindowState = FormWindowState.Minimized Then _
                Me.frmCustomerList.WindowState = FormWindowState.Normal
            Me.frmCustomerList.Activate()
        Else
            Me.frmCustomerList = New CustomerList
            Me.frmCustomerList.MdiParent = Me
            Me.frmCustomerList.Tag = Me.CreateWindowMenu(Me.frmCustomerList)
            Me.frmCustomerList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub ShipTosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShipTosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmShipToList) Then
            If Me.frmShipToList.WindowState = FormWindowState.Minimized Then _
                Me.frmShipToList.WindowState = FormWindowState.Normal
            Me.frmShipToList.Activate()
        Else
            Me.frmShipToList = New ShipToList
            Me.frmShipToList.MdiParent = Me
            Me.frmShipToList.Tag = Me.CreateWindowMenu(Me.frmShipToList)
            Me.frmShipToList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub WorkOrdersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrdersToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmWrkOrderList) Then
            If Me.frmWrkOrderList.WindowState = FormWindowState.Minimized Then _
                Me.frmWrkOrderList.WindowState = FormWindowState.Normal
            Me.frmWrkOrderList.Activate()
        Else
            Me.frmWrkOrderList = New WorkOrderList
            Me.frmWrkOrderList.MdiParent = Me
            Me.frmWrkOrderList.Tag = Me.CreateWindowMenu(Me.frmWrkOrderList)
            Me.frmWrkOrderList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub LocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmLocationList) Then
            If Me.frmLocationList.WindowState = FormWindowState.Minimized Then _
                Me.frmLocationList.WindowState = FormWindowState.Normal
            Me.frmLocationList.Activate()
        Else
            Me.frmLocationList = New LocationList
            Me.frmLocationList.MdiParent = Me
            Me.frmLocationList.Tag = Me.CreateWindowMenu(Me.frmLocationList)
            Me.frmLocationList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub TruckListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruckListToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmTruckList) Then
            If Me.frmTruckList.WindowState = FormWindowState.Minimized Then _
                Me.frmTruckList.WindowState = FormWindowState.Normal
            Me.frmTruckList.Activate()
        Else
            Me.frmTruckList = New TruckList
            Me.frmTruckList.MdiParent = Me
            Me.frmTruckList.Tag = Me.CreateWindowMenu(Me.frmTruckList)
            Me.frmTruckList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub DriversToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DriversToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmDriverList) Then
            If Me.frmDriverList.WindowState = FormWindowState.Minimized Then _
                Me.frmDriverList.WindowState = FormWindowState.Normal
            Me.frmDriverList.Activate()
        Else
            Me.frmDriverList = New DriverList
            Me.frmDriverList.MdiParent = Me
            Me.frmDriverList.Tag = Me.CreateWindowMenu(Me.frmDriverList)
            Me.frmDriverList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub TruckServicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruckServicesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmTruckServiceList) Then
            If Me.frmTruckServiceList.WindowState = FormWindowState.Minimized Then _
                Me.frmTruckServiceList.WindowState = FormWindowState.Normal
            Me.frmTruckServiceList.Activate()
        Else
            Me.frmTruckServiceList = New TruckServiceList
            Me.frmTruckServiceList.MdiParent = Me
            Me.frmTruckServiceList.Tag = Me.CreateWindowMenu(Me.frmTruckServiceList)
            Me.frmTruckServiceList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub MovesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovesToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmMoveList) Then
            If Me.frmMoveList.WindowState = FormWindowState.Minimized Then _
                Me.frmMoveList.WindowState = FormWindowState.Normal
            Me.frmMoveList.Activate()
        Else
            Me.frmMoveList = New MoveList
            Me.frmMoveList.MdiParent = Me
            Me.frmMoveList.Tag = Me.CreateWindowMenu(Me.frmMoveList)
            Me.frmMoveList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub TruckMileageListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TruckMileageListToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmTruckMileageList) Then
            If Me.frmTruckMileageList.WindowState = FormWindowState.Minimized Then _
                Me.frmTruckMileageList.WindowState = FormWindowState.Normal
            Me.frmTruckMileageList.Activate()
        Else
            Me.frmTruckMileageList = New TruckMileageList
            Me.frmTruckMileageList.MdiParent = Me
            Me.frmTruckMileageList.Tag = Me.CreateWindowMenu(Me.frmTruckMileageList)
            Me.frmTruckMileageList.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub DispatchWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DispatchWindowToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If GS.FormIsOpen(Me.frmDispatch) Then
            If Me.frmDispatch.WindowState = FormWindowState.Minimized Then _
                Me.frmDispatch.WindowState = FormWindowState.Normal
            Me.frmDispatch.Activate()
        Else
            Me.frmDispatch = New Dispatch
            Me.frmDispatch.MdiParent = Me
            Me.frmDispatch.Tag = Me.CreateWindowMenu(Me.frmDispatch)
            Me.frmDispatch.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close All MDI Forms
        For Each myChild As Form In Me.MdiChildren
            myChild.Close()
        Next
    End Sub

    Friend Sub NewWorkOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewWorkOrderToolStripMenuItem.Click

        Dim frm As New NewWorkOrder
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()

    End Sub

    Friend Sub NewCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewCustomerToolStripMenuItem.Click
        Dim frmNewCustomer As New NewCustomer
        frmNewCustomer.Owner = Me
        frmNewCustomer.ShowDialog()
        frmNewCustomer.Dispose()
    End Sub

    Friend Sub NewLocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewLocationToolStripMenuItem.Click
        Dim frmNewLocation As New NewLocation
        frmNewLocation.Owner = Me
        frmNewLocation.ShowDialog()
        frmNewLocation.Dispose()
    End Sub

    Friend Sub NewShipToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewShipToToolStripMenuItem.Click
        Dim frm As New SelectCustomer
        frm.Owner = Me
        frm.ShowDialog()

        If Not frm.Cancelled Then
            Dim frm2 As New NewShipTo(frm.CustomerID, frm.CustomerName)
            frm2.Owner = Me
            frm2.ShowDialog()
            frm2.Dispose()
        End If

        frm.Dispose()
    End Sub

    Friend Sub NewTruckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTruckToolStripMenuItem.Click
        Dim frm As New NewTruck
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Friend Sub NewDriverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewDriverToolStripMenuItem.Click
        Dim frm As New NewDrivers
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Friend Sub NewTruckServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTruckServiceToolStripMenuItem.Click
        Dim frm As New NewTruckService
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Friend Sub NewTruckMileageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTruckMileageToolStripMenuItem.Click
        Dim frm As New NewTruckMileage
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Friend Sub NewMoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMoveToolStripMenuItem.Click
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

    Private Sub DeliveryOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryOrderToolStripMenuItem.Click
        Dim frm As New SelectWo
        frm.Owner = Me
        frm.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        If frm.OkPressed Then
            Dim rptFrm As New RptViwer(RptViwer.ReportType.DeliveryOrder, "Delivery Order")
            rptFrm.WorkOrderID = frm.WorkOrderID
            rptFrm.MdiParent = Me
            rptFrm.Tag = Me.CreateWindowMenu(rptFrm)
            rptFrm.Show()
        End If

        frm.Dispose()

        Me.Cursor = Cursors.Default

    End Sub

    Friend Sub MovesByDriverToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovesByDriverToolStripMenuItem.Click

        Dim frm As New SelectRptMove(SelectRptMove.WindowType.Driver)
        frm.Owner = Me
        frm.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        If frm.OkPressed Then
            Dim frm2 As New RptViwer(RptViwer.ReportType.Move, "Moves")
            frm2.SetMoveByDriver(frm.StartDate, frm.EndDate, frm.Drivers)
            frm2.MdiParent = Me
            frm2.Tag = Me.CreateWindowMenu(frm2)
            frm2.Show()
        End If

        frm.Dispose()

        Me.Cursor = Cursors.Default

    End Sub

    Friend Sub MovesByWorkOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovesByWorkOrderToolStripMenuItem.Click

        Dim frm As New SelectRptMove(SelectRptMove.WindowType.WorkOrder)
        frm.Owner = Me
        frm.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        If frm.OkPressed Then
            Dim frm2 As New RptViwer(RptViwer.ReportType.Move, "Moves")
            frm2.SetMoveByWorkOrder(frm.StartDate, frm.EndDate, frm.WorkOrderStatus)
            frm2.MdiParent = Me
            frm2.Tag = Me.CreateWindowMenu(frm2)
            frm2.Show()
        End If

        frm.Dispose()

        Me.Cursor = Cursors.Default

    End Sub

    Friend Sub WorkOrdersToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrdersToolStripMenuItem1.Click
        Dim frm As New SelectRptMove(SelectRptMove.WindowType.WorkOrder)
        frm.Owner = Me
        frm.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        If frm.OkPressed Then
            Dim frm2 As New RptViwer(RptViwer.ReportType.WorkOrder, "Work Orders")
            frm2.SetWorkOrderRpt(frm.StartDate, frm.EndDate, frm.WorkOrderStatus)
            frm2.MdiParent = Me
            frm2.Tag = Me.CreateWindowMenu(frm2)
            frm2.Show()
        End If

        frm.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub WorkOrdersByCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrdersByCustomerToolStripMenuItem.Click
        Dim frm As New SelectRptMove(SelectRptMove.WindowType.WorkOrder)
        frm.Owner = Me
        frm.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        If frm.OkPressed Then
            Dim frm2 As New RptViwer(RptViwer.ReportType.WorkOrder, "Work Orders")
            frm2.SetWorkOrderByCustomer(frm.StartDate, frm.EndDate, frm.WorkOrderStatus)
            frm2.MdiParent = Me
            frm2.Tag = Me.CreateWindowMenu(frm2)
            frm2.Show()
        End If

        frm.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub WorkOrdersByShipToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrdersByShipToToolStripMenuItem.Click
        Dim frm As New SelectRptMove(SelectRptMove.WindowType.WorkOrder)
        frm.Owner = Me
        frm.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        If frm.OkPressed Then
            Dim frm2 As New RptViwer(RptViwer.ReportType.WorkOrder, "Work Orders")
            frm2.SetWorkOrderByShipTo(frm.StartDate, frm.EndDate, frm.WorkOrderStatus)
            frm2.MdiParent = Me
            frm2.Tag = Me.CreateWindowMenu(frm2)
            frm2.Show()
        End If

        frm.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub ContainerByLocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContainerByLocationToolStripMenuItem.Click
        Dim frm As New SelectRptMove(SelectRptMove.WindowType.Container)
        frm.Owner = Me
        frm.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        If frm.OkPressed Then
            Dim frm2 As New RptViwer(RptViwer.ReportType.Container, "Containers")
            frm2.SetContainerByLocation(frm.Locations)
            frm2.MdiParent = Me
            frm2.Tag = Me.CreateWindowMenu(frm2)
            frm2.Show()
        End If

        frm.Dispose()

        Me.Cursor = Cursors.Default
    End Sub

    Friend Sub RptBillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotBilledToolStripMenuItem.Click, ReadyToBillToolStripMenuItem.Click

        Me.Cursor = Cursors.WaitCursor

        Dim frm As New RptViwer(RptViwer.ReportType.Billing, "Billing")
        frm.BillingType = CType(CInt(CType(sender, ToolStripMenuItem).Tag), RptViwer.BillingRptType)
        frm.MdiParent = Me
        frm.Tag = Me.CreateWindowMenu(frm)
        frm.Show()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim frm As New Settings
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub LogInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogInToolStripMenuItem.Click
        Me.frmLogin = New Login
        frmLogin.Owner = Me
        frmLogin.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        Me.LogOut(True)
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Dim frm As New DbBackup
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub RestoreBackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreBackupToolStripMenuItem.Click

        If Me.myUser.Name.ToUpper() = "SA" Then

            Dim frm As New DbRestoreBackup
            frm.ShowDialog()
            frm.Dispose()

        Else
            MessageBox.Show("You must be logged in as System Administrator in order to start the Backup Restore Utility.", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frm As New About
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub BillingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotBilledWorkOrdersToolStripMenuItem.Click, ReadyToBillWorkOrdersToolStripMenuItem.Click

        Dim tsmi As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim bm As BillingWO.Mode = BillingWO.Mode.NotBilled

        If CInt(tsmi.Tag) = 1 Then
            bm = BillingWO.Mode.ReadyToBill
        End If

        Dim frm As New BillingWO(bm)

        frm.ShowDialog()
        frm.Dispose()

    End Sub

#End Region ' Form Events

#Region "Properties & methods"

    Friend Sub LogIn(ByVal User As User)
        Me.myUser = User
        Me.EnableMenus(True, (User.Name.ToUpper = "SA"))
        Me.DispatchWindowToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

    Friend Sub LogOut(ByVal WithConfirmation As Boolean)
        If Not WithConfirmation OrElse MessageBox.Show("Are you Sure?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Cursor = Cursors.WaitCursor
            Me.CloseAllToolStripMenuItem_Click(Nothing, Nothing)
            Me.EnableMenus(False)
            Me.myUser.Destroy()
            Me.Cursor = Cursors.Default
            Me.LogInToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub EnableMenus(ByVal Enable As Boolean)
        Me.EnableMenus(Enable, False)
    End Sub

    Private Sub EnableMenus(ByVal Enable As Boolean, ByVal UserIsSa As Boolean)

        Me.ViewToolStripMenuItem.Enabled = Enable
        Me.CreateToolStripMenuItem.Enabled = Enable
        Me.DatabaseToolStripMenuItem.Enabled = Enable
        Me.ReportsToolStripMenuItem.Enabled = Enable
        Me.LogOutToolStripMenuItem.Enabled = Enable
        Me.LogInToolStripMenuItem.Enabled = Not Enable
        Me.RestoreBackupToolStripMenuItem.Enabled = Enable And UserIsSa

    End Sub

    Friend Sub OpenWorkOrderDetailsForm(ByVal WorkOrderID As Integer)
        Me.Cursor = Cursors.WaitCursor
        If GS.DetailFormIsOpen(Me.frmWoDetails, WorkOrderID) Then
            If Me.frmWoDetails.WindowState = FormWindowState.Minimized Then _
                Me.frmWoDetails.WindowState = FormWindowState.Normal
            Me.frmWoDetails.Activate()
        Else
            Me.frmWoDetails = New WoDetails
            Me.frmWoDetails.MdiParent = Me
            Me.frmWoDetails.WorkOrderID = WorkOrderID
            Me.frmWoDetails.Tag = Me.CreateWindowMenu(Me.frmWoDetails, "Work Order # " & WorkOrderID.ToString & " Details.")
            Me.frmWoDetails.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Friend Function CreateWindowMenu(ByVal FormRef As Form) As ToolStripMenuItem
        Return CreateWindowMenu(FormRef, FormRef.Text)
    End Function

    Friend Function CreateWindowMenu(ByVal FormRef As Form, ByVal AltText As String) As ToolStripMenuItem

        Dim NewMenuItem As New System.Windows.Forms.ToolStripMenuItem
        NewMenuItem.Name = AltText & "ToolStripMenuItem"
        NewMenuItem.Text = AltText
        NewMenuItem.Tag = FormRef

        Me.WindowToolStripMenuItem.DropDownItems.Add(NewMenuItem)

        ' point to click event
        AddHandler NewMenuItem.Click, AddressOf NewMenuItem_Click

        ' enable dropdown menu in case it is not
        Me.WindowToolStripMenuItem.Visible = True

        Return NewMenuItem

    End Function

    Private Sub NewMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Click Event of the menu items created at runtime
        Dim Item As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        Dim myFrm As Form = CType(Item.Tag, Form)
        If myFrm.WindowState = FormWindowState.Minimized Then _
            myFrm.WindowState = FormWindowState.Normal
        myFrm.Activate()
    End Sub

    Friend Sub RemoveWindowMenu(ByRef Item As ToolStripMenuItem)
        Me.WindowToolStripMenuItem.DropDownItems.Remove(Item)
        If Me.WindowToolStripMenuItem.DropDownItems.Count < 3 Then
            Me.WindowToolStripMenuItem.Visible = False
        End If
    End Sub

    Friend Sub CheckWindowMenu(ByRef MenuItem As ToolStripMenuItem)
        For i As Integer = 0 To Me.WindowToolStripMenuItem.DropDownItems.Count - 1
            If Me.WindowToolStripMenuItem.DropDownItems.Item(i).GetType.ToString = "System.Windows.Forms.ToolStripMenuItem" Then
                Dim it As ToolStripMenuItem = CType(Me.WindowToolStripMenuItem.DropDownItems.Item(i), ToolStripMenuItem)
                it.Checked = False
            End If
            MenuItem.Checked = True
        Next
    End Sub

    Private Property myWindowState() As FormWindowState
        Get
            Return CType(CInt(GetSetting("Oceanne", "Settings", "WindowState", "0")), FormWindowState)
        End Get
        Set(ByVal value As FormWindowState)
            If value = FormWindowState.Minimized Then value = FormWindowState.Normal
            SaveSetting("Oceanne", "Settings", "WindowState", CInt(value).ToString)
        End Set
    End Property

    Private Property FormWidth() As Integer
        Get
            Return CInt(GetSetting("Oceanne", "Settings", "FormWidth", "750"))
        End Get
        Set(ByVal value As Integer)
            If value < 750 Then value = 750
            SaveSetting("Oceanne", "Settings", "FormWidth", value.ToString)
        End Set
    End Property

    Private Property FormHeight() As Integer
        Get
            Return CInt(GetSetting("Oceanne", "Settings", "FormHeight", "500"))
        End Get
        Set(ByVal value As Integer)
            If value < 500 Then value = 500
            SaveSetting("Oceanne", "Settings", "FormHeight", value.ToString)
        End Set
    End Property

#End Region ' Properties & methods

End Class
