
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class RptViwer

#Region "Gloval Vars"

    Dim myMenu As ToolStripMenuItem
    Dim _rptType As ReportType
    Dim _moveBy As MoveBy
    Dim _WoBy As WorkOrderBy
    Dim _WoId As Integer = -1
    Dim _startDate As Date
    Dim _endDate As Date
    Dim _drvs() As Integer
    Dim _locations() As String
    Dim _WoStatus As Integer
    Dim _BillingType As BillingRptType
    Dim _rpt As CrystalDecisions.CrystalReports.Engine.ReportClass

    Public Enum ReportType As Byte
        DeliveryOrder
        Move
        WorkOrder
        Container
        Billing
    End Enum

    Public Enum MoveBy As Byte
        Driver
        WorkOrder
    End Enum

    Public Enum WorkOrderBy As Byte
        WorkOrder
        Customer
        ShipTo
    End Enum

    Public Enum BillingRptType As Integer
        NotBilled = 1
        ReadyToBill = 2
    End Enum

#End Region ' Gloval Vars

#Region "Constructor"

    Public Sub New(ByVal myReportType As ReportType, ByVal FormTitle As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._rptType = myReportType
        Me.Text = "Report - " & FormTitle

    End Sub

    Public Sub New(ByVal Report As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal FormTitle As String)
        InitializeComponent()
        Me.Text = "Report - " & FormTitle
        Me._rpt = Report
    End Sub

#End Region ' Constructor

#Region "Control Events"

    Private Sub RptViwer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' fixes error
        Me.ShowIcon = True

        ' step 1 of 3
        ' get reference to toolstripmenu
        Me.myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' set window size
        Me.Size = GS.MdiWorkAreaSize

        ' if report passed through constructor, display it
        If Not IsNothing(Me._rpt) Then
            Me.CrystalReportViewer1.ReportSource = Me._rpt
            Exit Sub
        End If

        'RPT TMP
        'Me.Temp()
        'Exit Sub

        Me.ValidateReceivedData()

        'select and create report
        Select Case Me._rptType
            Case ReportType.DeliveryOrder
                Me.CreatDeliveryOrder()
            Case ReportType.Move
                Me.CreateMoveRpt()
            Case ReportType.WorkOrder
                Me.CreateWorkOrderRpt()
            Case ReportType.Container
                Me.CreateContainerRpt()
            Case ReportType.Billing
                Me.CreateBillingRpt()
        End Select

    End Sub

    'RPT TMP
    Private Sub Temp()
        Dim Conn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim Cmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDa2 As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim Rpt As New RptWoPrint

        Cmd.Connection = Conn
        Conn.Open()

        Cmd.CommandText = "SELECT [WorkOrders].*, [Customers].[Customer Name],[ShipTo].[ShipTo Name]," & _
            "(SELECT [Location].[Location Name] FROM [Location]" & _
            " WHERE [WorkOrders].[PickUp Terminal]=[Location].[Location ID]) [PickUp Term Name]," & _
            "(SELECT [Location].[Location Name] FROM [Location]" & _
            " WHERE [WorkOrders].[DropOff Terminal]=[Location].[Location ID]) [DropOff Term Name]" & _
            " FROM [WorkOrders]" & _
            " INNER JOIN [Customers] ON [WorkOrders].[Customer ID] = [Customers].[Customer ID]" & _
            " INNER JOIN [ShipTo] ON [WorkOrders].[ShipTo ID] = [ShipTo].[ShipTo ID]" & _
            " WHERE [WorkOrders].[WorkOrder ID]=" & Me._WoId

        myDa.SelectCommand = Cmd
        myDa.Fill(myDs, "WorkOrderPrint")

        Cmd.CommandText = "SELECT [Moves].[Move ID],[Moves].[Start Time],[Moves].[FromLocation],[Moves].[ToLocation]," & _
                            "(SELECT [Location].[Location Name] FROM [Location] " & _
                            "WHERE [Location].[Location ID]=[Moves].[FromLocation]) [FromLocation Name], " & _
                            "(SELECT [Location].[Location Name] FROM [Location] " & _
                            "WHERE [Location].[Location ID]=[Moves].[ToLocation]) [ToLocation Name], " & _
                            "[Drivers].[Driver Name],[Trucks].[Truck Number],[Moves].[End Time], " & _
                            "[Moves].[Complete] FROM [Moves] INNER JOIN " & _
                            "Drivers ON [Moves].[Driver ID] = [Drivers].[Driver ID] INNER JOIN " & _
                            "Trucks ON [Moves].[Truck ID] = [Trucks].[Truck ID] " & _
                            "WHERE [Moves].[WorkOrder ID]=" & Me._WoId & " ORDER BY [Moves].[Start Time]"

        myDa2.SelectCommand = Cmd
        myDa2.Fill(myDs, "WoPrintMoves")

        Conn.Close()
        Conn.Dispose()
        Cmd.Dispose()
        myDa.Dispose()
        myDa2.Dispose()

        Rpt.SetDataSource(myDs)
        Me.CrystalReportViewer1.ReportSource = Rpt

        myDs.Dispose()

    End Sub

    Private Sub RptViwer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub RptViwer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)
    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Private Sub CreateBillingRpt()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim myBillingRpt As New RptBilling
        Dim ErrFlag As Boolean = False
        Dim Parameters As New ParameterFields
        Dim Parameter As New ParameterField
        Dim ParameterValue As New ParameterDiscreteValue

        myCmd.Connection = myConn
        myCmd.CommandText = "SELECT [WorkOrders].[WorkOrder ID],[WorkOrders].[Delivery Date],[WorkOrders].[Billing], " & _
                    "[WorkOrders].[Rate],[Customers].[Customer Name],[ShipTo].[ShipTo Name] FROM [WorkOrders] " & _
                    "JOIN [Customers] ON [WorkOrders].[Customer ID] = [Customers].[Customer ID] " & _
                    "JOIN [ShipTo] ON [WorkOrders].[ShipTo ID] = [ShipTo].[ShipTo ID] " & _
                    "WHERE [WorkOrders].[Billing] = " & CInt(Me._BillingType).ToString

        myDa.SelectCommand = myCmd

        Try
            myDa.Fill(myDs, "Billing")
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            myConn.Dispose()
            myCmd.Dispose()
            myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
            Exit Sub
        End If

        ' add Parameters
        Parameter.Name = "BillingType"
        ParameterValue.Value = CInt(Me._BillingType)
        Parameter.CurrentValues.Add(ParameterValue)
        Parameters.Add(Parameter)

        Me.CrystalReportViewer1.ParameterFieldInfo = Parameters

        ' send data to report and send report to report viwer
        myBillingRpt.SetDataSource(myDs)
        Me.CrystalReportViewer1.ReportSource = myBillingRpt

        myDs.Dispose()

    End Sub

    Private Sub CreateContainerRpt()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim CmdStr As String = String.Empty
        Dim rptContByLocation As New RptContByLocation
        Dim ErrFlag As Boolean = False

        CmdStr = "SELECT [WorkOrders].[WorkOrder ID],[WorkOrders].[Container Number], " & _
            "[WorkOrders].[Shipping Line],[WorkOrders].[Container Size], " & _
            "[WorkOrders].[Container Type],[WorkOrders].[LD MT], " & _
            "[WorkOrders].[WorkOrder Date], (SELECT [Moves].[LD MT] FROM [Moves] WHERE " & _
            "[Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] AND " & _
            "[Moves].[Start Time]=(SELECT MAX([Moves].[Start Time]) FROM [Moves] WHERE " & _
            "[Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] AND ([Moves].[Complete]=1 OR " & _
            "[Moves].[Start Time]<'" & Now.ToString & "'))) [Act LD MT], (SELECT CASE [Moves].[ToLocation] " & _
            "WHEN 0 THEN (SELECT [ShipTo].[ShipTo Name] FROM [ShipTo] WHERE " & _
            "[ShipTo].[ShipTo ID]=(SELECT [WorkOrders].[ShipTo ID] FROM [WorkOrders] WHERE " & _
            "[WorkOrders].[WorkOrder ID]=[Moves].[WorkOrder ID])) ELSE (SELECT " & _
            "[Location].[Location Name] FROM [Location] WHERE [Location].[Location ID]=[Moves].[ToLocation]) " & _
            "END [ToLocation Name] FROM [Moves] WHERE [Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] " & _
            "AND [Moves].[Start Time]=(SELECT MAX([Moves].[Start Time]) FROM [Moves] WHERE " & _
            "[Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] AND ([Moves].[Complete]=1 OR " & _
            "[Moves].[Start Time]<'" & Now.ToString & "'))) [Act Location] FROM [WorkOrders] WHERE " & _
            "[WorkOrders].[Container Number] IS NOT NULL AND [WorkOrders].[Status]=0 " & _
            "ORDER BY [WorkOrders].[WorkOrder Date]"

        myCmd.Connection = myConn
        myCmd.CommandText = CmdStr

        myDa.SelectCommand = myCmd

        Try
            myDa.Fill(myDs, "Containers")
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
            Exit Sub
        End If

        ' filter data
        Dim Criteria As String = String.Empty
        Dim flag As Boolean = False

        ' selected locations
        For Each strLocation As String In Me._locations
            If flag Then Criteria &= " OR "
            Criteria &= "[Act Location]='" & strLocation & "'"
            flag = True
        Next

        ' all locations except the null ones
        If Not flag Then Criteria = "[Act Location] IS NOT NULL"

        Dim LocTable As DataTable = myDs.Tables("Containers").Clone()

        LocTable.Rows.Clear()

        For Each Row As DataRow In myDs.Tables("Containers").Select(Criteria)
            LocTable.ImportRow(Row)
        Next

        rptContByLocation.SetDataSource(LocTable)
        Me.CrystalReportViewer1.ReportSource = rptContByLocation

        If myDs IsNot Nothing Then myDs.Dispose()

    End Sub

    Private Sub CreateWorkOrderRpt()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim CmdStr As String = String.Empty
        Dim rptWorkOrders As RptWO = Nothing
        Dim rptWoByCustomer As RptWoByCustomer = Nothing
        Dim rptWoByShipTo As RptWoByShipTo = Nothing
        Dim ErrFlag As Boolean = False
        Dim Parameters As New ParameterFields
        Dim Parameter As New ParameterField
        Dim ParameterValue As New ParameterDiscreteValue
        Dim Parameter2 As New ParameterField
        Dim ParameterValue2 As New ParameterDiscreteValue

        CmdStr = "SELECT [WorkOrders].[WorkOrder ID],[WorkOrders].[WorkOrder Date], " & _
            "[WorkOrders].[Container Number],(CASE [WorkOrders].[Move Type] WHEN 1 THEN " & _
            "'Import' WHEN 2 THEN 'Export' WHEN 3 THEN 'Internal Freight' END) AS [Move Type], " & _
            "(CASE [WorkOrders].[Status] WHEN 0 THEN 'Active' WHEN 1 THEN 'Inactive' WHEN 2 " & _
            "THEN 'Closed' END) AS [Status],[Customers].[Customer Name],[ShipTo].[ShipTo Name] " & _
            "FROM [WorkOrders] INNER JOIN [Customers] ON [WorkOrders].[Customer ID]= " & _
            "[Customers].[Customer ID] INNER JOIN [ShipTo] ON [WorkOrders].[ShipTo ID]= " & _
            "[ShipTo].[ShipTo ID] WHERE [WorkOrders].[WorkOrder Date]>='" & Me._startDate.ToShortDateString & _
            " 00:00:00' AND [WorkOrders].[WorkOrder Date]<'" & Me._endDate.ToShortDateString & " 23:59:59' "


        If Me._WoStatus > 0 Then
            Dim OrFlag As Boolean = False
            Dim st As Integer = Me._WoStatus

            CmdStr &= "AND ("

            If st >= 4 Then
                CmdStr &= "[WorkOrders].[Status]=2"
                OrFlag = True
                st -= 4
            End If

            If st >= 2 Then
                If OrFlag Then CmdStr &= " OR "
                CmdStr &= "[WorkOrders].[Status]=1"
                OrFlag = True
                st -= 2
            End If

            If st >= 1 Then
                If OrFlag Then CmdStr &= " OR "
                CmdStr &= "[WorkOrders].[Status]=0"
            End If

            CmdStr &= ") "

        End If

        CmdStr &= "ORDER BY [WorkOrders].[WorkOrder Date]"

        myCmd.Connection = myConn
        myCmd.CommandText = CmdStr

        myDa.SelectCommand = myCmd

        Try
            myDa.Fill(myDs, "WorkOrders")
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
            Exit Sub
        End If

        ' add Parameters
        Parameter.Name = "StartDate"
        ParameterValue.Value = Me._startDate
        Parameter.CurrentValues.Add(ParameterValue)
        Parameters.Add(Parameter)
        Parameter2.Name = "EndDate"
        ParameterValue2.Value = Me._endDate
        Parameter2.CurrentValues.Add(ParameterValue2)
        Parameters.Add(Parameter2)

        Me.CrystalReportViewer1.ParameterFieldInfo = Parameters

        Select Case Me._WoBy
            Case WorkOrderBy.WorkOrder
                rptWorkOrders = New RptWO
                rptWorkOrders.SetDataSource(myDs)
                Me.CrystalReportViewer1.ReportSource = rptWorkOrders
            Case WorkOrderBy.Customer
                rptWoByCustomer = New RptWoByCustomer
                rptWoByCustomer.SetDataSource(myDs)
                Me.CrystalReportViewer1.ReportSource = rptWoByCustomer
            Case WorkOrderBy.ShipTo
                rptWoByShipTo = New RptWoByShipTo
                rptWoByShipTo.SetDataSource(myDs)
                Me.CrystalReportViewer1.ReportSource = rptWoByShipTo
        End Select

        If myDs IsNot Nothing Then myDs.Dispose()

    End Sub

    Private Sub CreateMoveRpt()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim CmdStr As String = String.Empty
        Dim rptMovesByDr As RptMovesByDriver = Nothing
        Dim rptMovesByWo As RptMovesByWO = Nothing
        Dim ErrFlag As Boolean = False
        Dim Parameters As New ParameterFields
        Dim Parameter As New ParameterField
        Dim ParameterValue As New ParameterDiscreteValue
        Dim Parameter2 As New ParameterField
        Dim ParameterValue2 As New ParameterDiscreteValue

        CmdStr = "SELECT [Moves].[Move ID],[Moves].[WorkOrder ID],[Moves].[Start Time],[Moves].[End Time], " & _
            "[WorkOrders].[Container Number],[Drivers].[Driver Name],[Trucks].[Truck Number], " & _
            "(CASE [Moves].[LD MT] WHEN 0 THEN 'LD' ELSE 'MT' END) AS [LD MT], " & _
            "(CASE [Moves].[FromLocation] WHEN 0 THEN " & _
            "  (SELECT [ShipTo].[ShipTo Name] FROM [ShipTo] WHERE " & _
            "  [ShipTo].[ShipTo ID]=[WorkOrders].[ShipTo ID]) " & _
            " ELSE (SELECT [Location].[Location Name] FROM [Location] WHERE " & _
            "     [Location].[Location ID]=[Moves].[FromLocation]) END) AS [FromLocation Name], " & _
            " (CASE [Moves].[ToLocation] WHEN 0 THEN " & _
            "  (SELECT [ShipTo].[ShipTo Name] FROM [ShipTo] " & _
            "  WHERE [ShipTo].[ShipTo ID]=[WorkOrders].[ShipTo ID]) " & _
            "ELSE (SELECT [Location].[Location Name] FROM [Location] WHERE " & _
            "     [Location].[Location ID]=[Moves].[ToLocation]) END) AS [ToLocation Name] " & _
            "FROM [Moves] INNER JOIN [WorkOrders] ON [Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] " & _
            "INNER JOIN [Drivers] ON [Moves].[Driver ID]=[Drivers].[Driver ID] " & _
            "INNER JOIN [Trucks] ON [Moves].[Truck ID]=[Trucks].[Truck ID] " & _
            "WHERE [Moves].[Start Time]>='" & Me._startDate.ToShortDateString & " 00:00:00' AND [Moves].[Start Time]<'" & _
            Me._endDate.ToShortDateString & " 23:59:59' "

        Select Case Me._moveBy
            Case MoveBy.Driver
                If Me._drvs.Length > 0 Then
                    Dim OrFlag As Boolean = False
                    CmdStr &= "AND ("
                    For Each drv As Integer In Me._drvs
                        If OrFlag Then CmdStr &= " OR "
                        CmdStr &= "[Moves].[Driver ID]=" & drv.ToString
                        OrFlag = True
                    Next
                    CmdStr &= ") "
                End If
            Case MoveBy.WorkOrder
                If Me._WoStatus > 0 Then
                    Dim OrFlag As Boolean = False
                    Dim st As Integer = Me._WoStatus

                    CmdStr &= "AND ("

                    If st >= 4 Then
                        CmdStr &= "[WorkOrders].[Status]=2"
                        OrFlag = True
                        st -= 4
                    End If

                    If st >= 2 Then
                        If OrFlag Then CmdStr &= " OR "
                        CmdStr &= "[WorkOrders].[Status]=1"
                        OrFlag = True
                        st -= 2
                    End If

                    If st >= 1 Then
                        If OrFlag Then CmdStr &= " OR "
                        CmdStr &= "[WorkOrders].[Status]=0"
                    End If

                    CmdStr &= ") "

                End If
        End Select

        CmdStr &= "ORDER BY [Moves].[Start Time]"

        myCmd.Connection = myConn
        myCmd.CommandText = CmdStr

        myDa.SelectCommand = myCmd

        Try
            myDa.Fill(myDs, "Moves")
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
            Exit Sub
        End If

        ' add Parameters
        Parameter.Name = "StartDate"
        ParameterValue.Value = Me._startDate
        Parameter.CurrentValues.Add(ParameterValue)
        Parameters.Add(Parameter)
        Parameter2.Name = "EndDate"
        ParameterValue2.Value = Me._endDate
        Parameter2.CurrentValues.Add(ParameterValue2)
        Parameters.Add(Parameter2)

        Me.CrystalReportViewer1.ParameterFieldInfo = Parameters

        Select Case Me._moveBy
            Case MoveBy.Driver
                rptMovesByDr = New RptMovesByDriver
                rptMovesByDr.SetDataSource(myDs)
                Me.CrystalReportViewer1.ReportSource = rptMovesByDr
            Case MoveBy.WorkOrder
                rptMovesByWo = New RptMovesByWO
                rptMovesByWo.SetDataSource(myDs)
                Me.CrystalReportViewer1.ReportSource = rptMovesByWo
        End Select

        If myDs IsNot Nothing Then myDs.Dispose()

    End Sub

    Private Sub CreatDeliveryOrder()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim rpt As New RptDelOrder
        Dim rpt2 As New RptDelOrder2
        Dim ErrFlag As Boolean = False
        Dim MoveType As Integer = 0

        Try

            myConn.Open()

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [Move Type] FROM [WorkOrders] WHERE [WorkOrder ID]=" & Me._WoId.ToString

            MoveType = CInt(myCmd.ExecuteScalar())

            If MoveType = 3 Then

                myCmd.CommandText = "SELECT WorkOrders.[WorkOrder ID], WorkOrders.Commodity, WorkOrders.[Delivery Date], WorkOrders.[Container Number], " & _
                    "WorkOrders.[BK BL], WorkOrders.[Container Size], WorkOrders.[Container Type], ShipTo.[ShipTo Name], ShipTo.Address, ShipTo.Address2, " & _
                    "ShipTo.City, ShipTo.State, ShipTo.[Zip Code], ShipTo.[Contact Name], ShipTo.Phone, [WorkOrders].[Load Weight],[WorkOrders].[Hazardous], " & _
                    "Location.[Location Name] AS [PickUp Name], Location.Address AS [PickUp Address], Location.Address2 AS [PickUp Address2], " & _
                    "Location.City AS [PickUp City], Location.[State] AS [PickUp State],Location.[Zip Code] AS [PickUp Zip Code], Location.[Contact Name] AS " & _
                    "[PickUp Contact Name], Location.Phone AS [PickUp Phone] FROM WorkOrders INNER JOIN ShipTo ON WorkOrders.[ShipTo ID] = ShipTo.[ShipTo ID] " & _
                    "LEFT JOIN Location ON WorkOrders.[PickUp Terminal]=Location.[Location ID] WHERE WorkOrders.[WorkOrder ID]=" & Me._WoId.ToString

                myDa.SelectCommand = myCmd
                myDa.Fill(myDs, "WorkOrders2")

            Else

                myCmd.CommandText = "SELECT WorkOrders.[WorkOrder ID], WorkOrders.[Commodity], WorkOrders.[Delivery Date], WorkOrders.[Container Number], " & _
                    "WorkOrders.[BK BL], WorkOrders.[Container Size], WorkOrders.[Container Type], ShipTo.[ShipTo Name], ShipTo.Address, ShipTo.Address2, " & _
                    "ShipTo.City, ShipTo.State, ShipTo.[Zip Code], ShipTo.[Contact Name], ShipTo.Phone, [WorkOrders].[Load Weight],[WorkOrders].[Hazardous] " & _
                    "FROM WorkOrders INNER JOIN ShipTo ON WorkOrders.[ShipTo ID] = ShipTo.[ShipTo ID] WHERE WorkOrders.[WorkOrder ID]=" & Me._WoId.ToString

                myDa.SelectCommand = myCmd
                myDa.Fill(myDs, "WorkOrders")

            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
            Exit Sub
        End If

        If MoveType = 3 Then
            rpt2.SetDataSource(myDs)
            Me.CrystalReportViewer1.ReportSource = rpt2
        Else
            rpt.SetDataSource(myDs)
            Me.CrystalReportViewer1.ReportSource = rpt
        End If

        If myDs IsNot Nothing Then myDs.Dispose()

    End Sub

    Private Sub ValidateReceivedData()

        Dim ErrFlag As Boolean = False
        Dim msg As String = String.Empty

        Select Case Me._rptType
            Case ReportType.DeliveryOrder

                If Me._WoId < 0 Then
                    msg = "Work Order ID is required for report type 'DeliveryOrder'."
                    ErrFlag = True
                End If

            Case ReportType.Move

                If IsNothing(Me._moveBy) Then
                    msg = "To set up a report of type Move please use one of the folowing methods:" & vbCrLf & _
                        "SetMoveByDriver, SetMoveByWorkOrder"
                    ErrFlag = True
                End If

            Case ReportType.WorkOrder

                If IsNothing(Me._WoBy) Then
                    msg = "To set up a report of type WorkOrder please use one of the folowing methods:" & vbCrLf & _
                        "SetWorkOrderRpt, SetWorkOrderByCustomer, SetWorkOrderByShipTo"
                    ErrFlag = True
                End If

            Case ReportType.Container

                If IsNothing(Me._locations) Then
                    msg = "To set up a report of type Container By Location please use one of the folowing methods:" & vbCrLf & _
                        "SetContainerByLocation"
                    ErrFlag = True
                End If

            Case ReportType.Billing

                If IsNothing(Me._BillingType) Then
                    msg = "The BillingType property has to be set for Billing Reports."
                    ErrFlag = True
                End If

        End Select

        If ErrFlag Then Throw New Exception(msg)

    End Sub

    Friend Property WorkOrderID() As Integer
        Get
            Return Me._WoId
        End Get
        Set(ByVal value As Integer)
            Me._WoId = value
        End Set
    End Property

    Friend Property BillingType() As BillingRptType
        Get
            Return Me._BillingType
        End Get
        Set(ByVal value As BillingRptType)
            Me._BillingType = value
        End Set
    End Property

    Friend Sub SetMoveByDriver(ByVal StartDate As Date, ByVal EndDate As Date)
        Dim emptyArr() As Integer = {}
        Me.SetMoveByDriver(StartDate, EndDate, emptyArr)
    End Sub

    Friend Sub SetMoveByDriver(ByVal StartDate As Date, ByVal EndDate As Date, ByVal DriverNumbers() As Integer)
        Me._moveBy = MoveBy.Driver
        Me._startDate = StartDate
        Me._endDate = EndDate
        Me._drvs = DriverNumbers
    End Sub

    Friend Sub SetMoveByWorkOrder(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Status As Integer)
        Me._moveBy = MoveBy.WorkOrder
        Me._startDate = StartDate
        Me._endDate = EndDate
        Me._WoStatus = Status
    End Sub

    Friend Sub SetWorkOrderRpt(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Status As Integer)
        Me._WoBy = WorkOrderBy.WorkOrder
        Me._startDate = StartDate
        Me._endDate = EndDate
        Me._WoStatus = Status
    End Sub

    Friend Sub SetWorkOrderByCustomer(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Status As Integer)
        Me._WoBy = WorkOrderBy.Customer
        Me._startDate = StartDate
        Me._endDate = EndDate
        Me._WoStatus = Status
    End Sub

    Friend Sub SetWorkOrderByShipTo(ByVal StartDate As Date, ByVal EndDate As Date, ByVal Status As Integer)
        Me._WoBy = WorkOrderBy.ShipTo
        Me._startDate = StartDate
        Me._endDate = EndDate
        Me._WoStatus = Status
    End Sub

    Friend Sub SetContainerByLocation(ByVal Locations As String())
        Me._locations = Locations
    End Sub

#End Region ' Methods & Properties

End Class