Public Class SelectWo

    Dim _OkPressed As Boolean = False
    Dim _WoId As Integer = -1
    Dim myDs As New DataSet

    Private Sub SelectWo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SelectWo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(Me.myDs) Then Me.myDs.Dispose()
    End Sub

    Private Sub SelectWo_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Not Me.FillDs() Then
            Me.Close()
        Else
            ' fill cbx
            Me.cbxWorkOrder.Items.Add(String.Empty)
            For Each Row As DataRow In Me.myDs.Tables("WorkOrders").Rows
                Me.cbxWorkOrder.Items.Add(Format(CInt(Row("WorkOrder ID")), "0000"))
            Next
        End If
    End Sub

    Private Function FillDs() As Boolean

        Dim flag As Boolean = True
        Dim CmdTxt As String = "SELECT [WorkOrders].[WorkOrder ID],[WorkOrders].[BK BL],[WorkOrders].[Container Number], " & _
            "[Customers].[Customer Name],[ShipTo].[ShipTo Name] FROM [WorkOrders] INNER JOIN " & _
            "[Customers] ON [WorkOrders].[Customer ID]=[Customers].[Customer ID] INNER JOIN " & _
            "[ShipTo] ON [WorkOrders].[ShipTo ID]=[ShipTo].[ShipTo ID] WHERE " & _
            "[WorkOrders].[Status]=0 ORDER BY [WorkOrders].[WorkOrder ID]"
        Dim myDa As New SqlClient.SqlDataAdapter(CmdTxt, GS.ConnectionString)

        Try
            myDa.Fill(Me.myDs, "WorkOrders")
        Catch ex As Exception
            MessageBox.Show("Unable to access Database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        Return flag

    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Friend ReadOnly Property OkPressed() As Boolean
        Get
            Return Me._OkPressed
        End Get
    End Property

    Friend ReadOnly Property WorkOrderID() As Integer
        Get
            Return Me._WoId
        End Get
    End Property

    Private Sub cbxWorkOrder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxWorkOrder.SelectedIndexChanged

        Dim flag As Boolean = (Me.cbxWorkOrder.SelectedIndex > 0)

        Me.btnOK.Enabled = flag

        Me.txtContainer.Text = String.Empty
        Me.txtBkBl.Text = String.Empty
        Me.txtCustomer.Text = String.Empty
        Me.txtShipTo.Text = String.Empty

        If flag Then
            Dim Row As DataRow = Me.myDs.Tables("WorkOrders").Select("[WorkOrder ID]=" & CInt(Me.cbxWorkOrder.Text).ToString)(0)

            Me.txtContainer.Text = Row("Container Number").ToString
            Me.txtBkBl.Text = Row("BK BL").ToString
            Me.txtCustomer.Text = Row("Customer Name").ToString
            Me.txtShipTo.Text = Row("ShipTo Name").ToString
        End If

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me._OkPressed = True
        Me._WoId = CInt(Me.cbxWorkOrder.Text)
        Me.Close()
    End Sub
End Class