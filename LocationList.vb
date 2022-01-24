Public Class LocationList

    Dim myMenu As ToolStripMenuItem
    Dim myDsLocationList As New DsLocationList
    Dim myLsvSorter As ListViewSorter
    Dim _filtered As Boolean = False
    Dim _criteria As String = String.Empty

#Region "Control Events"

    Private Sub LocationList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' set size
        Me.Size = GS.MdiWorkAreaSize

        ' set image list
        Me.lsvLocation.SmallImageList = My.Forms.Form1.ImageList1

        ' create headers
        Me.CreateHeaders()

        ' setup sorter
        Me.myLsvSorter = New ListViewSorter(Me.lsvLocation)
        Me.myLsvSorter.NumericColumns = New Integer() {0}

        If Me.FillDsLocationList() Then
            Me.FillListView(Me.myDsLocationList.Location.Select("[Inactive]=0"))
            Me.myLsvSorter.Sort(0, SortOrder.Ascending)
        End If

    End Sub

    Private Sub LocationList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub LocationList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

        Me.SaveHeaderSize()

    End Sub

    Private Sub lsvLocation_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvLocation.ColumnClick
        Me.myLsvSorter.Sort(e.Column)
    End Sub

    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click
        Dim frm As New NewLocation
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        If Me.lsvLocation.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewLocation
            frm.Mode = FormMode.Edit
            frm.LocationID = CInt(Me.lsvLocation.SelectedItems(0).SubItems(0).Text)
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub tsbDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDetails.Click
        If Me.lsvLocation.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewLocation
            frm.Mode = FormMode.Details
            frm.LocationID = CInt(Me.lsvLocation.SelectedItems(0).SubItems(0).Text)
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub tsbRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefresh.Click
        Me.Cursor = Cursors.WaitCursor
        Me._criteria = String.Empty
        Me._filtered = False
        Me.Label3.Visible = False
        Me.txtSearch.Clear()
        Me.FillDsLocationList()
        Me.chkShowInactive_CheckedChanged(sender, e)
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

        Me.FillListView(Me.myDsLocationList.Location.Select(myCriteria))

        Me.myLsvSorter.Sort()
    End Sub

    Private Sub lsvLocation_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvLocation.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvLocation.SelectedItems.Count > 0 Then
            Me.tsbDetails_Click(sender, e)
        End If
    End Sub

    Private Sub lsvLocation_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvLocation.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim flag As Boolean = False

            If Me.lsvLocation.SelectedItems.Count > 0 Then flag = True

            Me.EditToolStripMenuItem.Enabled = flag
            Me.DetailsToolStripMenuItem.Enabled = flag

            Me.ContextMenuStrip1.Show(Me.lsvLocation, e.Location)

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
                    tempCriteria &= "[Location Name] LIKE '%" & GS.FilterSingleQuote(w) & "%'"
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

#End Region 'Control Events

#Region "Methods & Properties"

    Friend Sub RefreshDataAndList()
        Me.Cursor = Cursors.WaitCursor
        Me.FillDsLocationList()
        Me.chkShowInactive_CheckedChanged(Nothing, Nothing)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillListView(ByVal Rows() As DataRow)
        Dim lsvItem As ListViewItem = Nothing
        Dim Address As String = String.Empty
        Dim AdrFlag As Boolean = False

        ' clear old lsv data
        Me.lsvLocation.Items.Clear()

        For Each Row As DataRow In Rows
            Address = String.Empty
            AdrFlag = False

            lsvItem = New ListViewItem(Row.Item("Location ID").ToString)
            lsvItem.SubItems.Add(Row.Item("Location Name").ToString)

            If Not IsDBNull(Row.Item("Address")) Or Not IsDBNull(Row.Item("Address2")) Then
                Address &= Row.Item("Address").ToString & " " & Row.Item("Address2").ToString
                AdrFlag = True
            End If

            If Not IsDBNull(Row.Item("City")) Then
                If AdrFlag Then Address &= ", "
                Address &= Row.Item("City").ToString
                AdrFlag = True
            End If

            If Not IsDBNull(Row.Item("State")) Then
                If AdrFlag Then Address &= ", "
                Address &= Row.Item("State").ToString
                AdrFlag = True
            End If

            Address &= " " & Row.Item("Zip Code").ToString

            lsvItem.SubItems.Add(Address)

            lsvItem.SubItems.Add(Row.Item("Contact Name").ToString)
            lsvItem.SubItems.Add(Row.Item("Phone").ToString)
            lsvItem.SubItems.Add(Row.Item("Fax").ToString)
            lsvItem.SubItems.Add(Row.Item("E-Mail").ToString)

            If CInt(Row.Item("PickUp DropOff")) = 1 Then
                lsvItem.SubItems.Add("Yes")
            Else
                lsvItem.SubItems.Add(String.Empty)
            End If

            If CInt(Row.Item("Inactive")) = 0 Then
                lsvItem.SubItems.Add("Active")
            Else
                lsvItem.SubItems.Add("Inactive")
            End If

            Me.lsvLocation.Items.Add(lsvItem)
        Next

    End Sub

    Private Function FillDsLocationList() As Boolean

        Dim myTaLocationList As New DsLocationListTableAdapters.LocationTableAdapter
        Dim flag As Boolean = True

        Try
            myTaLocationList.Connection.ConnectionString = GS.ConnectionString
            myTaLocationList.Fill(Me.myDsLocationList.Location)
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myTaLocationList) Then myTaLocationList.Dispose()
        End Try

        Return flag

    End Function

    Private Sub CreateHeaders()
        Dim sz(8) As Integer

        sz(0) = CInt(GetSetting("Oceanne", "LocationList", "sz0", "60"))
        sz(1) = CInt(GetSetting("Oceanne", "LocationList", "sz1", "130"))
        sz(2) = CInt(GetSetting("Oceanne", "LocationList", "sz2", "250"))
        sz(3) = CInt(GetSetting("Oceanne", "LocationList", "sz3", "130"))
        sz(4) = CInt(GetSetting("Oceanne", "LocationList", "sz4", "130"))
        sz(5) = CInt(GetSetting("Oceanne", "LocationList", "sz5", "130"))
        sz(6) = CInt(GetSetting("Oceanne", "LocationList", "sz6", "130"))
        sz(7) = CInt(GetSetting("Oceanne", "LocationList", "sz7", "90"))
        sz(8) = CInt(GetSetting("Oceanne", "LocationList", "sz8", "90"))

        GS.AddHeader(Me.lsvLocation, "ID", sz(0))
        GS.AddHeader(Me.lsvLocation, "Location Name", sz(1))
        GS.AddHeader(Me.lsvLocation, "Address", sz(2))
        GS.AddHeader(Me.lsvLocation, "Contact Name", sz(3))
        GS.AddHeader(Me.lsvLocation, "Phone Number", sz(4))
        GS.AddHeader(Me.lsvLocation, "Fax Number", sz(5))
        GS.AddHeader(Me.lsvLocation, "E-Mail Address", sz(6))
        GS.AddHeader(Me.lsvLocation, "PickUp Drop Off", sz(7))
        GS.AddHeader(Me.lsvLocation, "Status", sz(8))

    End Sub

    Private Sub SaveHeaderSize()
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvLocation.Columns.Count - 1
            key = "sz" & i.ToString
            SaveSetting("Oceanne", "LocationList", key, Me.lsvLocation.Columns(i).Width.ToString)
        Next
    End Sub

#End Region 'Methods & Properties

End Class