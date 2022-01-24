Public Class TruckList

    Dim myMenu As ToolStripMenuItem
    Dim myDs As New DataSet
    Dim myLsvSorter As ListViewSorter
    Dim _filtered As Boolean = False
    Dim _criteria As String = String.Empty

#Region "Control Events"

    Private Sub TruckList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' create tables
        Me.myDs.Tables.Add("Trucks")

        ' set size
        Me.Size = GS.MdiWorkAreaSize

        ' set image list
        Me.lsvTruck.SmallImageList = My.Forms.Form1.ImageList1

        ' create headers
        Me.CreateHeaders()

        ' setup sorter
        Me.myLsvSorter = New ListViewSorter(Me.lsvTruck)
        Me.myLsvSorter.NumericColumns = New Integer() {0, 6}

        If Me.FillDs Then
            Me.FillListView(Me.myDs.Tables("Trucks").Select("[Inactive]=0"))
            Me.myLsvSorter.Sort(0, SortOrder.Ascending)
        End If

    End Sub

    Private Sub TruckList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub TruckList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

        Me.SaveHeaderSize()

        ' clean up
        If Not IsNothing(Me.myDs) Then Me.myDs.Dispose()

    End Sub

    Private Sub lsvTruck_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvTruck.ColumnClick
        Me.myLsvSorter.Sort(e.Column)
    End Sub

    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click
        Dim frm As New NewTruck
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Me._criteria = String.Empty
        Me._filtered = False
        Me.Label3.Visible = False
        Me.txtSearch.Clear()
        Me.FillDs()
        Me.chkShowInactive_CheckedChanged(sender, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDetails.Click
        If Me.lsvTruck.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewTruck
            frm.TruckID = CInt(Me.lsvTruck.SelectedItems(0).SubItems(0).Text)
            frm.Mode = FormMode.Details
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If

    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        If Me.lsvTruck.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewTruck
            frm.TruckID = CInt(Me.lsvTruck.SelectedItems(0).SubItems(0).Text)
            frm.Mode = FormMode.Edit
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If
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

    Private Sub chkShowInactive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowInactive.CheckedChanged
        Dim myCriteria As String = String.Empty
        Dim AndFlag As Boolean = False

        If Not Me.chkShowInactive.Checked Then
            myCriteria &= "[Inactive]=0"
            AndFlag = True
        End If

        ' add parentesis to criteria if necessary
        If Me._filtered Then
            If AndFlag Then myCriteria &= " AND ("
            myCriteria &= Me._criteria
            If AndFlag Then myCriteria &= ")"
        End If

        Me.FillListView(Me.myDs.Tables("Trucks").Select(myCriteria))

        Me.myLsvSorter.Sort()

    End Sub

    Private Sub lsvTruck_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvTruck.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvTruck.SelectedItems.Count > 0 Then
            Me.tsbDetails_Click(sender, e)
        End If
    End Sub

    Private Sub lsvTruck_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvTruck.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim flag As Boolean = False

            If Me.lsvTruck.SelectedItems.Count > 0 Then flag = True

            Me.EditToolStripMenuItem.Enabled = flag
            Me.DetailsToolStripMenuItem.Enabled = flag

            Me.ContextMenuStrip1.Show(Me.lsvTruck, e.Location)

        End If
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        If e.KeyValue = 13 Then btnOk_Click(sender, e)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Cursor = Cursors.WaitCursor

        Me.txtSearch.Text = Trim(Me.txtSearch.Text)

        Dim orFlag As Boolean = False
        Dim tempCriteria As String = String.Empty

        If Me.txtSearch.Text.Length > 0 Then
            Dim ws() As String = Split(Me.txtSearch.Text, " ")

            For Each w As String In ws
                If w.Length > 0 Then
                    If orFlag Then
                        tempCriteria &= " OR "
                    End If
                    tempCriteria &= "[Truck Number] LIKE '%" & GS.FilterSingleQuote(w) & "%'"
                    orFlag = True
                End If
            Next

        End If

        If tempCriteria.Length > 0 Then
            Me._criteria = tempCriteria
            Me._filtered = True
            Me.Label3.Visible = True
            Me.chkShowInactive_CheckedChanged(sender, e)
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsbTrService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbTrService.Click
        Dim frm As New NewTruckService
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tbsTrMileage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbsTrMileage.Click
        Dim frm As New NewTruckMileage
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Friend Sub RefreshDataAndList()
        Me.Cursor = Cursors.WaitCursor
        Me.FillDs()
        Me.chkShowInactive_CheckedChanged(Nothing, Nothing)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillListView(ByVal Rows() As DataRow)

        Dim lsvItem As ListViewItem = Nothing

        ' clear old lsv data
        Me.lsvTruck.Items.Clear()

        For Each Row As DataRow In Rows
            lsvItem = New ListViewItem(Row.Item("Truck ID").ToString)
            lsvItem.SubItems.Add(Row.Item("Truck Number").ToString)
            lsvItem.SubItems.Add(Row.Item("Driver Name").ToString)
            lsvItem.SubItems.Add(Row.Item("Make").ToString)
            lsvItem.SubItems.Add(Row.Item("Plate").ToString)
            lsvItem.SubItems.Add(Row.Item("Color").ToString)
            lsvItem.SubItems.Add(Row.Item("Year").ToString)
            lsvItem.SubItems.Add(Row.Item("Ezpass Number").ToString)

            If IsDBNull(Row.Item("Owner Name")) Then
                lsvItem.SubItems.Add("Company")
            Else
                lsvItem.SubItems.Add(Row.Item("Owner Name").ToString)
            End If

            If CBool(Row.Item("Inactive")) Then
                lsvItem.SubItems.Add("Inactive")
            Else
                lsvItem.SubItems.Add("Active")
            End If

            Me.lsvTruck.Items.Add(lsvItem)

        Next

    End Sub

    Private Function FillDs() As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim flag As Boolean = True

        Me.myDs.Tables("Trucks").Clear()

        myCmd.CommandText = "SELECT [Trucks].[Truck ID], [Trucks].[Truck Number], [Trucks].[Make], " & _
            "[Trucks].[Plate], [Trucks].[Color], [Trucks].[Year], [Trucks].[Ezpass Number], " & _
            "[Trucks].[Owner], [Trucks].[Inactive], (SELECT [Drivers].[Driver Name] FROM " & _
            "[Drivers] WHERE [Drivers].[Driver ID]=[Trucks].[Owner]) AS [Owner Name], " & _
            "(SELECT (CASE (SELECT COUNT([Drivers].[Driver ID]) FROM [Drivers] WHERE " & _
            "[Drivers].[Truck ID]=[Trucks].[Truck ID] AND [Drivers].[Inactive]=0) WHEN 0 THEN NULL " & _
            "WHEN 1 THEN (SELECT [Drivers].[Driver Name] FROM [Drivers] WHERE " & _
            "[Drivers].[Truck ID]=[Trucks].[Truck ID] AND [Drivers].[Inactive]=0) ELSE 'Various' " & _
            "END)) AS [Driver Name] FROM Trucks"

        Try

            myCmd.Connection = myConn

            myConn.Open()

            myDa.SelectCommand = myCmd
            myDa.Fill(Me.myDs, "Trucks")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        Return flag

    End Function

    Private Sub CreateHeaders()
        Dim sz(9) As Integer

        sz(0) = CInt(GetSetting("Oceanne", "TruckList", "sz0", "60"))
        sz(1) = CInt(GetSetting("Oceanne", "TruckList", "sz1", "90"))
        sz(2) = CInt(GetSetting("Oceanne", "TruckList", "sz2", "130"))
        sz(3) = CInt(GetSetting("Oceanne", "TruckList", "sz2", "130"))
        sz(4) = CInt(GetSetting("Oceanne", "TruckList", "sz3", "90"))
        sz(5) = CInt(GetSetting("Oceanne", "TruckList", "sz4", "130"))
        sz(6) = CInt(GetSetting("Oceanne", "TruckList", "sz5", "90"))
        sz(7) = CInt(GetSetting("Oceanne", "TruckList", "sz6", "130"))
        sz(8) = CInt(GetSetting("Oceanne", "TruckList", "sz6", "130"))
        sz(9) = CInt(GetSetting("Oceanne", "TruckList", "sz7", "90"))

        GS.AddHeader(Me.lsvTruck, "ID", sz(0))
        GS.AddHeader(Me.lsvTruck, "Truck Number", sz(1))
        GS.AddHeader(Me.lsvTruck, "Driver", sz(2))
        GS.AddHeader(Me.lsvTruck, "Make", sz(3))
        GS.AddHeader(Me.lsvTruck, "Plate", sz(4))
        GS.AddHeader(Me.lsvTruck, "Color", sz(5))
        GS.AddHeader(Me.lsvTruck, "Year", sz(6), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvTruck, "EZ Pass", sz(7))
        GS.AddHeader(Me.lsvTruck, "Owner", sz(8))
        GS.AddHeader(Me.lsvTruck, "Status", sz(9))

    End Sub

    Private Sub SaveHeaderSize()
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvTruck.Columns.Count - 1
            key = "sz" & i.ToString
            SaveSetting("Oceanne", "TruckList", key, Me.lsvTruck.Columns(i).Width.ToString)
        Next
    End Sub

#End Region 'Methods & Properties

End Class