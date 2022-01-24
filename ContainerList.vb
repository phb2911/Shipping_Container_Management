Public Class ContainerList

    Dim myMenu As ToolStripMenuItem
    Dim myDs As New DataSet
    Dim myLsvSorter As ListViewSorter
    Dim _filtered As Boolean = False
    Dim _criteria As String = String.Empty
    Dim _dateCriteria As String = "[WorkOrders].[WorkOrder Date]>='" & GS.ThirtyDaysAgo.ToString & "'"

#Region "Control Events"

    Private Sub ContainerList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' fixes error
        Me.ShowIcon = True

        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' set size
        Me.Size = GS.MdiWorkAreaSize

        ' create table
        Me.myDs.Tables.Add("WorkOrders")

        ' set image list
        Me.lsvContainers.SmallImageList = My.Forms.Form1.ImageList1

        Me.LoadHeaderSize()

        ' setup sorter
        Me.myLsvSorter = New ListViewSorter(Me.lsvContainers)
        Me.myLsvSorter.NumericColumns = New Integer() {0}
        Me.myLsvSorter.DateColumns = New Integer() {8}

        If Me.FillDs(Me._dateCriteria) Then
            Me.PopulateLsv(Me.myDs.Tables("WorkOrders").Select())
            Me.myLsvSorter.Sort(0, SortOrder.Descending)
        End If

    End Sub

    Private Sub lsvContainers_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvContainers.ColumnClick
        Me.myLsvSorter.Sort(e.Column)
    End Sub

    Private Sub ContainerList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)

    End Sub

    Private Sub ContainerList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

        Me.SaveHeaderSize()

    End Sub

    Friend Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.Cursor = Cursors.WaitCursor

        ' clear listview
        Me.lsvContainers.Items.Clear()
        ' fill ds
        If Me.FillDs(Me._dateCriteria) Then
            ' fill lsv
            Me.PopulateLsv(Me.myDs.Tables("WorkOrders").Select(Me._criteria))
            Me.myLsvSorter.Sort()
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbShowDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbShowDefault.Click
        Me.Label3.Visible = False
        Me._filtered = False
        Me._criteria = String.Empty
        Me._dateCriteria = "[WorkOrders].[WorkOrder Date]>='" & GS.ThirtyDaysAgo.ToString & "'"
        Me.tsbRefresh_Click(Nothing, Nothing)
    End Sub


    Private Sub tsbFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbFilter.Click
        Dim frm As New ContainerListFilter
        frm.Owner = Me
        frm.ShowDialog()

        If frm.OkClicked Then
            Me._filtered = True
            Me.Label3.Visible = True
            Me._criteria = frm.Criteria
            Me._dateCriteria = frm.DateCriteria
            Me.tsbRefresh_Click(Nothing, Nothing)
        End If

        frm.Dispose()

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Me.tsbRefresh_Click(Nothing, Nothing)
    End Sub

    Private Sub WorkOrderDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderDetailsToolStripMenuItem.Click
        My.Forms.Form1.OpenWorkOrderDetailsForm(CInt(Me.lsvContainers.SelectedItems(0).SubItems(0).Text))
    End Sub

    Private Sub lsvContainers_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvContainers.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.WorkOrderDetailsToolStripMenuItem_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub lsvContainers_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvContainers.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right And Me.lsvContainers.SelectedItems.Count > 0 Then
            Me.ContextMenuStrip1.Show(Me.lsvContainers, e.Location)
        End If
    End Sub

    Private Sub tsbReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReport.Click
        My.Forms.Form1.ContainerByLocationToolStripMenuItem_Click(Nothing, Nothing)
    End Sub

#End Region ' Control Events

#Region "Properties & Methods"

    Private Sub PopulateLsv(ByVal Rows() As DataRow)

        For Each Row As DataRow In Rows

            Dim lsvItem As New ListViewItem(Row.Item("WorkOrder ID").ToString)
            lsvItem.SubItems.Add(Row.Item("Container Number").ToString)
            lsvItem.SubItems.Add(Row.Item("Act Location").ToString)
            lsvItem.SubItems.Add(Row.Item("Shipping Line").ToString)
            lsvItem.SubItems.Add(Row.Item("Chassis Number").ToString)

            Dim ItStr As String = String.Empty
            Dim flag As Boolean = False

            If Not IsDBNull(Row.Item("Container Size")) Then
                ItStr = Row.Item("Container Size").ToString
                flag = True
            End If

            If Not IsDBNull(Row.Item("Container Type")) Then
                If flag Then ItStr &= "/"
                ItStr &= Row.Item("Container Type").ToString
            End If

            lsvItem.SubItems.Add(ItStr)

            ItStr = String.Empty

            If IsDBNull(Row.Item("Act LD MT")) Then

                If Not IsDBNull(Row.Item("LD MT")) Then
                    If CBool(Row.Item("LD MT")) Then
                        ItStr = "MT"
                    Else
                        ItStr = "LD"
                    End If
                End If

            Else

                If CBool(Row.Item("Act LD MT")) Then
                    ItStr = "MT"
                Else
                    ItStr = "LD"
                End If

            End If

            lsvItem.SubItems.Add(ItStr)

            ItStr = String.Empty

            Select Case CInt(Row.Item("Status"))
                Case 0
                    ItStr = "Active"
                Case 1
                    ItStr = "Inactive"
                Case 2
                    ItStr = "Closed"
            End Select

            lsvItem.SubItems.Add(ItStr)

            lsvItem.SubItems.Add(Row.Item("WorkOrder Date").ToString)

            Me.lsvContainers.Items.Add(lsvItem)

        Next

    End Sub

    Private Function FillDs(ByVal DateFilterExpression As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim flag As Boolean = True

        ' clear old data
        Me.myDs.Tables("WorkOrders").Clear()

        Try

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT [WorkOrders].[WorkOrder ID],[WorkOrders].[Container Number], " & _
                "[WorkOrders].[Shipping Line],[WorkOrders].[Chassis Number],[WorkOrders].[Container Size], " & _
                "[WorkOrders].[Container Type],[WorkOrders].[LD MT],[WorkOrders].[Status], " & _
                "[WorkOrders].[WorkOrder Date], (SELECT [Moves].[LD MT] FROM [Moves] WHERE " & _
                "[Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] AND " & _
                "[Moves].[Start Time]=(SELECT MAX([Moves].[Start Time]) FROM [Moves] WHERE " & _
                "[Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] AND ([Moves].[Complete]=1 OR " & _
                "[Moves].[Start Time]<'" & Now().ToString & "'))) [Act LD MT], (SELECT CASE [Moves].[ToLocation] " & _
                "WHEN 0 THEN (SELECT [ShipTo].[ShipTo Name] FROM [ShipTo] WHERE " & _
                "[ShipTo].[ShipTo ID]=(SELECT [WorkOrders].[ShipTo ID] FROM [WorkOrders] WHERE " & _
                "[WorkOrders].[WorkOrder ID]=[Moves].[WorkOrder ID])) ELSE (SELECT " & _
                "[Location].[Location Name] FROM [Location] WHERE [Location].[Location ID]=[Moves].[ToLocation]) " & _
                "END [ToLocation Name] FROM [Moves] WHERE [Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] " & _
                "AND [Moves].[Start Time]=(SELECT MAX([Moves].[Start Time]) FROM [Moves] WHERE " & _
                "[Moves].[WorkOrder ID]=[WorkOrders].[WorkOrder ID] AND ([Moves].[Complete]=1 OR " & _
                "[Moves].[Start Time]<'" & Now().ToString & "'))) [Act Location] FROM [WorkOrders] WHERE " & _
                "[WorkOrders].[Container Number] IS NOT NULL " & _
                "AND " & DateFilterExpression

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "WorkOrders")

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
        For i As Integer = 0 To Me.lsvContainers.Columns.Count - 1
            key = "sz" & i.ToString
            SaveSetting("Oceanne", "ContainerList", key, Me.lsvContainers.Columns(i).Width.ToString)
        Next
    End Sub

    Private Sub LoadHeaderSize()
        Dim DefSize() As Integer = {60, 120, 120, 100, 100, 100, 60, 90, 120}
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvContainers.Columns.Count - 1
            key = "sz" & i.ToString
            Me.lsvContainers.Columns(i).Width = CInt(GetSetting("Oceanne", "ContainerList", key, DefSize(i).ToString))
        Next
    End Sub

#End Region ' Properties & Methods

End Class