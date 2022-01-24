Option Explicit On
Option Strict On

Public Class BillingWO

#Region "Global Fields"

    Dim _Mode As Mode

    Public Enum Mode As Integer
        NotBilled
        ReadyToBill
    End Enum

#End Region ' Global Fields

#Region "Form Events"

    Public Sub New(ByVal BillingMode As Mode)

        InitializeComponent()

        Me._Mode = BillingMode

    End Sub

    Private Sub BillingWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CreateLsvHeader()

        If Me._Mode = Mode.NotBilled Then
            Me.Text = "Not Billed Work Orders"
            Me.Label1.Text = "Select the Work Orders to be marked as ""Ready To Bill"" and press the OK button."
        Else
            Me.Text = "Ready To Bill Work Orders"
            Me.Label1.Text = "Select the Work Orders to be marked as ""Billed"" and press the OK button."
        End If

        Me.PopulateLsv()

    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click, btnSelectNone.Click

        For Each lsv As ListViewItem In Me.ListView1.Items
            lsv.Checked = CBool(CType(sender, Button).Tag)
        Next

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Me.PopulateLsv()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If Me.ListView1.CheckedItems.Count = 0 Then
            MessageBox.Show("Please select at least one item.", "Billing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim orFlag As Boolean = False
        Dim ErrorFlag As Boolean = False
        Dim ErrMsg As String = ""

        myCmd.Connection = myConn
        myCmd.CommandText = "UPDATE [WorkOrders] SET [Billing] = "

        If Me._Mode = Mode.NotBilled Then
            myCmd.CommandText &= "2 WHERE "
        Else
            myCmd.CommandText &= "3 WHERE "
        End If

        For Each lsvItem As ListViewItem In Me.ListView1.CheckedItems

            If orFlag Then
                myCmd.CommandText &= " OR "
            End If

            myCmd.CommandText &= "[WorkOrder ID] = " & lsvItem.SubItems(1).Text

            orFlag = True

        Next

        Try

            myConn.Open()
            myCmd.ExecuteNonQuery()

        Catch ex As Exception
            ErrMsg = "Unable to update database." & vbCrLf & vbCrLf & "Error: " & ex.Message
            ErrorFlag = True
        Finally
            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
            myCmd.Dispose()
        End Try

        If ErrorFlag Then
            Me.Cursor = Cursors.Default
            MessageBox.Show(ErrMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else

            ' refresh WO list if open
            If GS.FormIsOpen(My.Forms.Form1.frmWrkOrderList) Then
                My.Forms.Form1.frmWrkOrderList.RefreshList()
            End If

            ' refresh WODetails if open
            For Each lsvItem As ListViewItem In Me.ListView1.CheckedItems

                If GS.DetailFormIsOpen(My.Forms.Form1.frmWoDetails, CInt(lsvItem.SubItems(1).Text)) Then
                    My.Forms.Form1.frmWoDetails.RefreshData()
                End If

            Next

            Me.Close()
        End If

    End Sub

#End Region ' Form Events

#Region "Methods & Properties"

    Private Sub CreateLsvHeader()

        Dim ColHd As New ColumnHeader
        ColHd.Text = ""
        ColHd.Width = 25
        Me.ListView1.Columns.Add(ColHd)

        ColHd = New ColumnHeader
        ColHd.Text = "No."
        ColHd.Width = 70
        Me.ListView1.Columns.Add(ColHd)

        ColHd = New ColumnHeader
        ColHd.Text = "Customer"
        ColHd.Width = 180
        Me.ListView1.Columns.Add(ColHd)

        ColHd = New ColumnHeader
        ColHd.Text = "Ship To"
        ColHd.Width = 180
        Me.ListView1.Columns.Add(ColHd)

        ColHd = New ColumnHeader
        ColHd.TextAlign = HorizontalAlignment.Right
        ColHd.Width = 150
        ColHd.Text = "Delivery Date"
        Me.ListView1.Columns.Add(ColHd)

    End Sub

    Private Sub PopulateLsv()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myRd As SqlClient.SqlDataReader = Nothing

        Me.ListView1.Items.Clear()

        myCmd.Connection = myConn
        myCmd.CommandText = "SELECT [WorkOrders].[WorkOrder ID], [WorkOrders].[Delivery Date], " & _
                            "[Customers].[Customer Name],[ShipTo].[ShipTo Name] FROM [WorkOrders] " & _
                            "JOIN [Customers] ON [WorkOrders].[Customer ID] = [Customers].[Customer ID] " & _
                            "JOIN [ShipTo] ON [WorkOrders].[ShipTo ID] = [ShipTo].[ShipTo ID] " & _
                            "WHERE [WorkOrders].[Billing] = "

        If Me._Mode = Mode.NotBilled Then
            myCmd.CommandText &= "1"
        Else
            myCmd.CommandText &= "2"
        End If

        Try

            myConn.Open()

            myRd = myCmd.ExecuteReader()

            While myRd.Read()

                Dim lsvItem As New ListViewItem

                lsvItem.SubItems.AddRange(New String() {myRd("WorkOrder ID").ToString, myRd("Customer Name").ToString, myRd("ShipTo Name").ToString, myRd("Delivery Date").ToString})
                Me.ListView1.Items.Add(lsvItem)

            End While

        Catch ex As Exception
            MessageBox.Show("Unable to retrieve data." & vbCrLf & vbCrLf & "Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.Dispose()
            myCmd.Dispose()
            myRd.Close()
        End Try

    End Sub

#End Region ' Methods & Properties

End Class