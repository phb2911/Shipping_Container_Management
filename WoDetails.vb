Public Class WoDetails

    Dim myMenu As ToolStripMenuItem
    Dim _woId As Integer = -1
    Dim _isActive As Boolean = False

#Region "Control Events"

    Private Sub WoDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me._woId < 0 Then Throw New Exception("Work Order ID cannot be negative.")

        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        Me.Text = "Work Order # " & Me._woId.ToString & " Details."

        Me.PopulateDs()

    End Sub

    Private Sub WoDetails_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        ' fixes unwanted result
        Me.TableLayoutPanel1.Width = Me.lsvMoves.Width

        ' set size
        Me.Size = GS.MdiWorkAreaSize

    End Sub

    Private Sub WoDetails_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)

    End Sub

    Private Sub WoDetails_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

    End Sub

    Private Sub Panel2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel2.Resize
        Me.Panel1.Width = Me.Panel2.Width
        Me.Panel3.Width = Me.Panel2.Width
        Me.Panel4.Width = Me.Panel2.Width
    End Sub

    Private Sub Panel3_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.Resize
        Me.Panel1.Width = Me.Panel3.Width
        Me.Panel2.Width = Me.Panel3.Width
        Me.Panel4.Width = Me.Panel3.Width
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        Dim frm As New NewWorkOrder
        frm.Mode = FormMode.Edit
        frm.WorkOrderID = Me._woId
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Me.RefreshData()
        Me.Cursor = Cursors.Default
    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Friend Sub RefreshData()

        ' make panels invisible
        For Each c As Control In Me.Controls
            If c.GetType Is GetType(Panel) Then
                CType(c, Panel).Visible = False
            End If
        Next

        ' clear all writable lbls
        Me.ClearLabelsFromControl(Me.Panel2)
        Me.ClearLabelsFromControl(Me.Panel3)
        Me.ClearLabelsFromControl(Me.TableLayoutPanel1)

        ' clear list view
        Me.lsvMoves.Items.Clear()

        ' get data and repopulate fields
        If Not Me.PopulateDs() Then Me.Close()

        ' make panels visible
        For Each c As Control In Me.Controls
            If c.GetType.Name = "Panel" Then
                CType(c, Panel).Visible = True
            End If
        Next

    End Sub

    Private Sub ClearLabelsFromControl(ByVal myControl As Control)
        For Each c As Control In myControl.Controls
            If c.GetType.Name = "Label" Then
                Dim myLbl As Label = CType(c, Label)
                If CInt(myLbl.Tag) = 1 Then
                    myLbl.Text = String.Empty
                End If
            End If
        Next
    End Sub

    Private Function PopulateDs() As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa1 As New SqlClient.SqlDataAdapter
        Dim CmdStr1 As String = String.Empty
        Dim myDa2 As New SqlClient.SqlDataAdapter
        Dim CmdStr2 As String = String.Empty
        Dim myDs As New DataSet
        Dim flag As Boolean = True

        CmdStr1 = "SELECT [WorkOrders].*, [Customers].[Customer Name]," & _
            "(SELECT [Location].[Location Name] FROM [Location]" & _
            " WHERE [WorkOrders].[PickUp Terminal]=[Location].[Location ID]) [PickUp Term Name]," & _
            "(SELECT [Location].[Location Name] FROM [Location]" & _
            " WHERE [WorkOrders].[DropOff Terminal]=[Location].[Location ID]) [DropOff Term Name]" & _
            " FROM [WorkOrders]" & _
            " INNER JOIN [Customers] ON [WorkOrders].[Customer ID] = [Customers].[Customer ID]" & _
            " WHERE [WorkOrders].[WorkOrder ID]=" & Me._woId

        Try

            myConn.Open()

            myCmd.CommandText = CmdStr1
            myCmd.Connection = myConn

            myDa1.SelectCommand = myCmd
            myDa1.Fill(myDs, "WorkOrders")

            Dim r As DataRow = myDs.Tables("WorkOrders").Rows(0)

            CmdStr2 = "SELECT [ShipTo ID], [ShipTo Name], [Address], [Address2], [City], [State], [Zip Code]" & _
            " FROM [ShipTo] WHERE [ShipTo ID]=" & r.Item("ShipTo ID").ToString

            myCmd.CommandText = CmdStr2

            myDa2.SelectCommand = myCmd
            myDa2.Fill(myDs, "ShipTo")

            Me.FillMovesList(myConn)

        Catch ex As Exception
            MessageBox.Show("Unable to load Work Order # " & Me._woId.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If myDa1 IsNot Nothing Then myDa1.Dispose()
            If myDa2 IsNot Nothing Then myDa2.Dispose()
            If myCmd IsNot Nothing Then myCmd.Dispose()
            If myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
        End Try

        If Not flag Then Return flag

        If myDs.Tables("WorkOrders").Rows.Count = 0 Then
            MessageBox.Show("Work Order # " & Me._woId.ToString & " can't be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If myDs IsNot Nothing Then myDs.Dispose()
            Return False
        End If

        Dim Row As DataRow = myDs.Tables("WorkOrders").Rows(0)
        Dim Row2 As DataRow = myDs.Tables("ShipTo").Rows(0)

        Me.lblCustomer.Text = Row.Item("Customer Name").ToString
        Me.lblShipTo.Text = Row2.Item("ShipTo Name").ToString

        Dim CrLfFlag As Boolean = False
        Dim CommaFlag As Boolean = False

        If Not IsDBNull(Row2.Item("Address")) Then
            Me.lblShipToAddress.Text &= Row2.Item("Address").ToString
            CrLfFlag = True
        End If

        If Not IsDBNull(Row2.Item("Address2")) Then
            If CrLfFlag Then Me.lblShipToAddress.Text &= vbCrLf
            Me.lblShipToAddress.Text &= Row2.Item("Address2").ToString
            CrLfFlag = True
        End If

        If Not IsDBNull(Row2.Item("City")) Then
            If CrLfFlag Then Me.lblShipToAddress.Text &= vbCrLf
            Me.lblShipToAddress.Text &= Row2.Item("City").ToString
            CommaFlag = True
        End If

        If Not IsDBNull(Row2.Item("State")) Or Not IsDBNull(Row2.Item("Zip Code")) Then
            If CommaFlag Then Me.lblShipToAddress.Text &= ", "
            Me.lblShipToAddress.Text &= Row2.Item("State").ToString & " " & Row2.Item("Zip Code").ToString
        End If

        Me.lblConsignee.Text = Row.Item("Consignee").ToString
        Me.lblReference.Text = Row.Item("Reference").ToString

        Select Case CInt(Row.Item("Move Type"))
            Case 1
                Me.lblMoveType.Text = "Import"
            Case 2
                Me.lblMoveType.Text = "Export"
            Case 3
                Me.lblMoveType.Text = "Internal Freight"
        End Select

        Me.lblContNumber.Text = Row.Item("Container Number").ToString
        Me.lblBKBL.Text = Row.Item("BK BL").ToString
        Me.lblShippingLine.Text = Row.Item("Shipping Line").ToString
        Me.lblChNum.Text = Row.Item("Chassis Number").ToString
        Me.lblCommodity.Text = Row.Item("Commodity").ToString

        If Not IsDBNull(Row.Item("Load Weight")) Then
            Me.lblWeight.Text = Format(CInt(Row.Item("Load Weight")), "#,###,###,###")
        End If

        If Not IsDBNull(Row.Item("Container Size")) And Not IsDBNull(Row.Item("Container Type")) Then
            Me.lblContSizeType.Text = Row.Item("Container Size").ToString & "/" & Row.Item("Container Type").ToString
        Else
            Me.lblContSizeType.Text = Row.Item("Container Size").ToString & Row.Item("Container Type").ToString
        End If

        If CBool(Row.Item("Hazardous")) Then
            Me.lblHazmat.Text = "Yes"
        Else
            Me.lblHazmat.Text = "No"
        End If

        Me.lblDelDate.Text = Row.Item("Delivery Date").ToString
        Me.lblPickUpTerminal.Text = Row.Item("PickUp Term Name").ToString

        If Not IsDBNull(Row.Item("PickUp Date")) Then
            Me.lblPickUpDate.Text = CDate(Row.Item("PickUp Date")).ToShortDateString
        End If

        If CBool(Row.Item("Prev_WO")) Then
            Me.lblOutTIR.Text = "N/A"
        Else
            Me.lblOutTIR.Text = Row.Item("Out TIR").ToString
        End If

        Me.lblDrOffTerminal.Text = Row.Item("DropOff Term Name").ToString
        Me.lblDrOffDate.Text = Row.Item("DropOff Date").ToString

        If CBool(Row.Item("Future_WO")) Then
            Me.lblInTIR.Text = "N/A"
        Else
            Me.lblInTIR.Text = Row.Item("In TIR").ToString
        End If

        Me._isActive = False

        Select Case CInt(Row.Item("Status"))
            Case 0
                Me.lblStatus.Text = "Active"
                Me._isActive = True
            Case 1
                Me.lblStatus.Text = "Inactive"
            Case 2
                Me.lblStatus.Text = "Closed"
        End Select

        Me.lblRemarks.Text = Row.Item("Remarks").ToString

        If Not IsDBNull(Row.Item("WorkOrder Date")) Then
            Me.lblWoDate.Text = CDate(Row.Item("WorkOrder Date")).ToShortDateString
        End If

        Select Case CInt(Row.Item("Billing"))
            Case 0
                Me.lblBillingStatus.Text = "Not Billable"
            Case 1
                Me.lblBillingStatus.Text = "Not Billed"
            Case 2
                Me.lblBillingStatus.Text = "Ready to Bill"
            Case 3
                Me.lblBillingStatus.Text = "Billed"
        End Select

        ' populate rate lsv
        GS.FillRateListView(Me.lsvRate, Row.Item("Rate").ToString)
        Me.CalculateRateTotal()

        ' clean up 
        If Not IsNothing(myDs) Then myDs.Dispose()

        Return flag

    End Function

    Private Sub CalculateRateTotal()

        If Me.lsvRate.Items.Count = 0 Then Exit Sub

        Dim RateTotal As Double = 0

        For Each lsvItem As ListViewItem In Me.lsvRate.Items
            RateTotal += CDbl(lsvItem.SubItems(1).Text)
        Next

        Me.txtTotal.Text = Format(RateTotal, "Standard")

    End Sub

    Friend Sub FillMovesList()
        Me.FillMovesList(Nothing)
    End Sub

    Friend Sub FillMovesList(ByRef Connection As SqlClient.SqlConnection)
        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False
        Dim OutConn As Boolean = False

        Try
            If Not IsNothing(Connection) AndAlso Connection.State = ConnectionState.Open Then
                myConn = Connection
                OutConn = True
            Else
                myConn = New SqlClient.SqlConnection(GS.ConnectionString)
            End If

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [Moves].[Move ID],[Moves].[Start Time],[Moves].[FromLocation],[Moves].[ToLocation]," & _
                            "(SELECT [Location].[Location Name] FROM [Location] " & _
                            "WHERE [Location].[Location ID]=[Moves].[FromLocation]) [FromLocation Name], " & _
                            "(SELECT [Location].[Location Name] FROM [Location] " & _
                            "WHERE [Location].[Location ID]=[Moves].[ToLocation]) [ToLocation Name], " & _
                            "[Drivers].[Driver Name],[Trucks].[Truck Number],[Moves].[End Time], " & _
                            "[Moves].[Complete] FROM [Moves] INNER JOIN " & _
                            "Drivers ON [Moves].[Driver ID] = [Drivers].[Driver ID] INNER JOIN " & _
                            "Trucks ON [Moves].[Truck ID] = [Trucks].[Truck ID] " & _
                            "WHERE [Moves].[WorkOrder ID]=" & Me._woId & " ORDER BY [Moves].[Start Time]"

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "Moves")

        Catch ex As Exception
            MessageBox.Show("Unable to load Work Order # " & Me._woId.ToString, "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) And Not OutConn Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        'clear old data
        Me.lsvMoves.Items.Clear()

        If Not ErrFlag Then

            ' fill moves lsv
            For Each mvRow As DataRow In myDs.Tables("Moves").Rows

                Dim lsvItem As New ListViewItem(mvRow.Item("Move ID").ToString)

                If CInt(mvRow.Item("FromLocation")) = 0 Then
                    lsvItem.SubItems.Add("Delivery Location")
                Else
                    lsvItem.SubItems.Add(mvRow.Item("FromLocation Name").ToString)
                End If

                If CInt(mvRow.Item("ToLocation")) = 0 Then
                    lsvItem.SubItems.Add("Delivery Location")
                Else
                    lsvItem.SubItems.Add(mvRow.Item("ToLocation Name").ToString)
                End If

                lsvItem.SubItems.Add(CDate(mvRow.Item("Start Time")).ToString)

                If Not IsDBNull(mvRow.Item("End Time")) Then
                    lsvItem.SubItems.Add(CDate(mvRow.Item("End Time")).ToString)
                Else
                    lsvItem.SubItems.Add(String.Empty)
                End If

                lsvItem.SubItems.Add(mvRow.Item("Driver Name").ToString)
                lsvItem.SubItems.Add(mvRow.Item("Truck Number").ToString)

                If CBool(mvRow.Item("Complete")) Then
                    lsvItem.SubItems.Add("Yes")
                Else
                    lsvItem.SubItems.Add(String.Empty)
                End If

                Me.lsvMoves.Items.Add(lsvItem)

            Next

        End If

        If Not IsNothing(myDs) Then myDs.Dispose()

    End Sub

    Friend Property WorkOrderID() As Integer
        Get
            Return Me._woId
        End Get
        Set(ByVal value As Integer)
            Me._woId = value
        End Set
    End Property

#End Region 'Methods & Properties

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDa2 As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim Rpt As New RptWoPrint
        Dim ErrFlag As Boolean = False
        Dim NumOfPages As Integer = 0
        Dim pd As PrintDialog = Nothing

        Try

            myCmd.Connection = myConn
            myConn.Open()

            myCmd.CommandText = "SELECT [WorkOrders].*, [Customers].[Customer Name],[ShipTo].[ShipTo Name]," & _
                "(SELECT [Location].[Location Name] FROM [Location]" & _
                " WHERE [WorkOrders].[PickUp Terminal]=[Location].[Location ID]) [PickUp Term Name]," & _
                "(SELECT [Location].[Location Name] FROM [Location]" & _
                " WHERE [WorkOrders].[DropOff Terminal]=[Location].[Location ID]) [DropOff Term Name]" & _
                " FROM [WorkOrders]" & _
                " INNER JOIN [Customers] ON [WorkOrders].[Customer ID] = [Customers].[Customer ID]" & _
                " INNER JOIN [ShipTo] ON [WorkOrders].[ShipTo ID] = [ShipTo].[ShipTo ID]" & _
                " WHERE [WorkOrders].[WorkOrder ID]=" & Me._woId

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "WorkOrderPrint")

            myCmd.CommandText = "SELECT [Moves].[Move ID],[Moves].[Start Time],[Moves].[FromLocation],[Moves].[ToLocation]," & _
                                "(SELECT [Location].[Location Name] FROM [Location] " & _
                                "WHERE [Location].[Location ID]=[Moves].[FromLocation]) [FromLocation Name], " & _
                                "(SELECT [Location].[Location Name] FROM [Location] " & _
                                "WHERE [Location].[Location ID]=[Moves].[ToLocation]) [ToLocation Name], " & _
                                "[Drivers].[Driver Name],[Trucks].[Truck Number],[Moves].[End Time], " & _
                                "[Moves].[Complete] FROM [Moves] INNER JOIN " & _
                                "Drivers ON [Moves].[Driver ID] = [Drivers].[Driver ID] INNER JOIN " & _
                                "Trucks ON [Moves].[Truck ID] = [Trucks].[Truck ID] " & _
                                "WHERE [Moves].[WorkOrder ID]=" & Me._woId & " ORDER BY [Moves].[Start Time]"

            myDa2.SelectCommand = myCmd
            myDa2.Fill(myDs, "WoPrintMoves")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
            myCmd.Dispose()
            myDa.Dispose()
            myDa2.Dispose()
        End Try

        If ErrFlag Then
            myDs.Dispose()
            Exit Sub
        End If

        Rpt.SetDataSource(myDs)

        '-----------------------
        'Dim rptv As New RptViwer(Rpt, "Test")
        'rptv.Tag = My.Forms.Form1.CreateWindowMenu(rptv)
        'rptv.MdiParent = My.Forms.Form1
        'rptv.Show()
        'Exit Sub
        '-----------------------

        NumOfPages = GS.ReportNumberOfPages(Rpt)
        GS.ResetPrintDialog(pd, NumOfPages)

        With pd

            If Not .ShowDialog() = Windows.Forms.DialogResult.Cancel Then

                'Rpt.PrintOptions.CopyFrom(.PrinterSettings, .PrinterSettings.DefaultPageSettings)
                Rpt.PrintOptions.PrinterName = .PrinterSettings.PrinterName

                Try
                    If .PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                        Rpt.PrintToPrinter(.PrinterSettings.Copies, .PrinterSettings.Collate, .PrinterSettings.FromPage, .PrinterSettings.ToPage)
                    Else
                        Rpt.PrintToPrinter(.PrinterSettings.Copies, .PrinterSettings.Collate, 1, NumOfPages)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Unable to print", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try

            End If

        End With

        myDs.Dispose()

    End Sub

End Class