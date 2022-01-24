Public Class DriverList

    Dim myMenu As ToolStripMenuItem
    Dim myDsDriverList As New DsDriverList
    Dim myLsvSorter As ListViewSorter
    Dim _filtered As Boolean = False
    Dim _criteria As String = String.Empty

#Region "Control Events"

    Private Sub DriverList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' step 1 of 3
        ' get reference to toolstripmenu
        myMenu = CType(Me.Tag, ToolStripMenuItem)

        ' set size
        Me.Size = GS.MdiWorkAreaSize

        ' select image list
        Me.lsvDrivers.SmallImageList = My.Forms.Form1.ImageList1

        ' create headers
        Me.CreateHeaders()

        ' setup sorter
        Me.myLsvSorter = New ListViewSorter(Me.lsvDrivers)
        Me.myLsvSorter.NumericColumns = New Integer() {0, 6}
        Me.myLsvSorter.DateColumns = New Integer() {4, 5, 7}

        If Me.FillDsDriverList() Then
            Me.FillListView(Me.myDsDriverList.Drivers.Select("[Inactive]=0"))
            Me.myLsvSorter.Sort(0, SortOrder.Ascending)
        End If

    End Sub

    Private Sub DriverList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        ' step 2 of 3
        My.Forms.Form1.CheckWindowMenu(myMenu)
    End Sub

    Private Sub DriverList_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' step 3 of 3
        My.Forms.Form1.RemoveWindowMenu(myMenu)

        Me.SaveHeaderSize()
    End Sub

    Private Sub lsvDrivers_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvDrivers.ColumnClick
        Me.myLsvSorter.Sort(e.Column)
    End Sub

    Private Sub tsbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNew.Click
        Dim frm As New NewDrivers
        frm.Owner = Me
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub tsbEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEdit.Click
        If Me.lsvDrivers.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewDrivers
            frm.DriverID = CInt(Me.lsvDrivers.SelectedItems(0).SubItems(0).Text)
            frm.Mode = FormMode.Edit
            frm.Owner = Me
            frm.ShowDialog()
            frm.Dispose()
        End If
    End Sub

    Private Sub tsbDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDetails.Click
        If Me.lsvDrivers.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a list item.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim frm As New NewDrivers
            frm.DriverID = CInt(Me.lsvDrivers.SelectedItems(0).SubItems(0).Text)
            frm.Mode = FormMode.Details
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
        Me.FillDsDriverList()
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

        Me.FillListView(Me.myDsDriverList.Drivers.Select(myCriteria))

        Me.myLsvSorter.Sort()
    End Sub

    Private Sub lsvDrivers_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvDrivers.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsvDrivers.SelectedItems.Count > 0 Then
            Me.tsbDetails_Click(sender, e)
        End If
    End Sub

    Private Sub lsvDrivers_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsvDrivers.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim flag As Boolean = False

            If Me.lsvDrivers.SelectedItems.Count > 0 Then flag = True

            Me.EditToolStripMenuItem.Enabled = flag
            Me.DetailsToolStripMenuItem.Enabled = flag

            Me.ContextMenuStrip1.Show(Me.lsvDrivers, e.Location)

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
                    tempCriteria &= "[Driver Name] LIKE '%" & GS.FilterSingleQuote(w) & "%'"
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

#End Region ' Control Events

#Region "Methods & Properties"

    Friend Sub RefreshDataAndList()
        Me.Cursor = Cursors.WaitCursor
        Me.FillDsDriverList()
        Me.chkShowInactive_CheckedChanged(Nothing, Nothing)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillListView(ByVal Rows() As DataRow)
        Dim lsvItem As ListViewItem = Nothing
        Dim Address As String = String.Empty
        Dim AdrFlag As Boolean = False

        ' clear old lsv data
        Me.lsvDrivers.Items.Clear()

        For Each Row As DataRow In Rows
            Address = String.Empty
            AdrFlag = False

            lsvItem = New ListViewItem(Row.Item("Driver ID").ToString)
            lsvItem.SubItems.Add(Row.Item("Driver Name").ToString)

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

            lsvItem.SubItems.Add(Row.Item("Phone").ToString)

            If Not IsDBNull(Row.Item("DL Exp")) Then
                Dim dt As Date = CDate(Row.Item("DL Exp"))
                lsvItem.SubItems.Add(dt.ToShortDateString)
            Else
                lsvItem.SubItems.Add(String.Empty)
            End If

            If Not IsDBNull(Row.Item("MedCard Exp")) Then
                Dim dt As Date = CDate(Row.Item("MedCard Exp"))
                lsvItem.SubItems.Add(dt.ToShortDateString)
            Else
                lsvItem.SubItems.Add(String.Empty)
            End If

            lsvItem.SubItems.Add(Row.Item("SeaLink").ToString)

            If Not IsDBNull(Row.Item("SeaLink Exp")) Then
                Dim dt As Date = CDate(Row.Item("SeaLink Exp"))
                lsvItem.SubItems.Add(dt.ToShortDateString)
            Else
                lsvItem.SubItems.Add(String.Empty)
            End If

            lsvItem.SubItems.Add(Row.Item("Truck Number").ToString)

            If CBool(Row.Item("Owner Operator")) Then
                lsvItem.SubItems.Add("Yes")
            Else
                lsvItem.SubItems.Add(String.Empty)
            End If

            If CBool(Row.Item("Hazmat")) Then
                lsvItem.SubItems.Add("Yes")
            Else
                lsvItem.SubItems.Add(String.Empty)
            End If

            If CBool(Row.Item("Inactive")) Then
                lsvItem.SubItems.Add("Inactive")
            Else
                lsvItem.SubItems.Add("Active")
            End If

            Me.lsvDrivers.Items.Add(lsvItem)
        Next

    End Sub


    Private Function FillDsDriverList() As Boolean

        Dim myTaDrvList As New DsDriverListTableAdapters.DriversTableAdapter
        Dim flag As Boolean = True

        Try
            myTaDrvList.Connection.ConnectionString = GS.ConnectionString
            myTaDrvList.Fill(Me.myDsDriverList.Drivers)
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myTaDrvList) Then myTaDrvList.Dispose()
        End Try

        Return flag

    End Function

    Private Sub CreateHeaders()
        Dim sz(11) As Integer

        sz(0) = CInt(GetSetting("Oceanne", "DriverList", "sz0", "60"))
        sz(1) = CInt(GetSetting("Oceanne", "DriverList", "sz1", "130"))
        sz(2) = CInt(GetSetting("Oceanne", "DriverList", "sz2", "250"))
        sz(3) = CInt(GetSetting("Oceanne", "DriverList", "sz3", "130"))
        sz(4) = CInt(GetSetting("Oceanne", "DriverList", "sz4", "130"))
        sz(5) = CInt(GetSetting("Oceanne", "DriverList", "sz5", "130"))
        sz(6) = CInt(GetSetting("Oceanne", "DriverList", "sz6", "130"))
        sz(7) = CInt(GetSetting("Oceanne", "DriverList", "sz7", "130"))
        sz(8) = CInt(GetSetting("Oceanne", "DriverList", "sz8", "90"))
        sz(9) = CInt(GetSetting("Oceanne", "DriverList", "sz9", "90"))
        sz(10) = CInt(GetSetting("Oceanne", "DriverList", "sz10", "90"))
        sz(11) = CInt(GetSetting("Oceanne", "DriverList", "sz11", "90"))

        GS.AddHeader(Me.lsvDrivers, "ID", sz(0))
        GS.AddHeader(Me.lsvDrivers, "Driver Name", sz(1))
        GS.AddHeader(Me.lsvDrivers, "Address", sz(2))
        GS.AddHeader(Me.lsvDrivers, "Phone Number", sz(3))
        GS.AddHeader(Me.lsvDrivers, "DL Expiration", sz(4), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvDrivers, "Med. Card Expiration", sz(5), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvDrivers, "SeaLink", sz(6), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvDrivers, "SeaLink Expiration", sz(7), HorizontalAlignment.Right)
        GS.AddHeader(Me.lsvDrivers, "Truck Number", sz(8))
        GS.AddHeader(Me.lsvDrivers, "Owner Operator", sz(9))
        GS.AddHeader(Me.lsvDrivers, "Hazmat", sz(10))
        GS.AddHeader(Me.lsvDrivers, "Status", sz(11))

    End Sub

    Private Sub SaveHeaderSize()
        Dim key As String = String.Empty
        For i As Integer = 0 To Me.lsvDrivers.Columns.Count - 1
            key = "sz" & i.ToString
            SaveSetting("Oceanne", "DriverList", key, Me.lsvDrivers.Columns(i).Width.ToString)
        Next
    End Sub

#End Region 'Methods & Properties
    
End Class