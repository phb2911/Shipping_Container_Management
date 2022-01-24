Public Class SelectRptMove

    Dim _okPressed As Boolean = False
    Dim _drvIdCol As New Collection
    Dim _errFlag As Boolean = False
    Dim _fromDt As Date
    Dim _toDt As Date
    Dim _drvs() As Integer
    Dim _locations() As String
    Dim _windowType As WindowType
    Dim _WoStatus As Integer

    Public Enum WindowType As Byte
        Driver
        WorkOrder
        Container
    End Enum

    Public Sub New(ByVal myType As WindowType)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._windowType = myType

    End Sub

    Private Sub SelectRptMoveDrv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Size = New Size(400, 213)
        Me.dtpFrom.Value = Now.AddDays(-7)

        If Me._windowType = WindowType.WorkOrder Then
            Me.GroupBox3.Location = Me.GroupBox2.Location
            Me.btnOk_Wo.Location = Me.btnOk.Location
            Me.GroupBox2.Visible = False
            Me.GroupBox3.Visible = True
            Me.btnOk.Visible = False
            Me.btnOk_Wo.Visible = True
        ElseIf Me._windowType = WindowType.Container Then
            Me.GroupBox2.Visible = False
            Me.GroupBox1.Visible = False
            Me.GroupBox4.Visible = True
            Me.btnOk.Visible = False
            Me.btnOk_Cont.Visible = True
            Me.GroupBox4.Location = Me.GroupBox2.Location
            Me.btnOk_Cont.Location = Me.btnOk.Location
            Me.PopulateLocLsv()
        Else
            Me.PopulateDrvLsv()
        End If

    End Sub

    Private Sub SelectRptMoveDrv_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If _errFlag Then Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub PopulateLocLsv()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa1 As New SqlClient.SqlDataAdapter
        Dim myDa2 As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet

        myCmd.Connection = myConn
        myCmd.CommandText = "SELECT [Location Name] FROM [Location] WHERE [Inactive]=0"

        Try
            myDa1.SelectCommand = myCmd
            myDa1.Fill(myDs, "Location")

            myCmd.CommandText = "SELECT DISTINCT([ShipTo].[ShipTo Name]) AS [Location Name] " & _
                "FROM [ShipTo] INNER JOIN [Customers] ON [ShipTo].[Customer ID]=[Customers].[Customer ID] " & _
                "WHERE [ShipTo].[Inactive]=0 AND [Customers].[Inactive]=0"

            myDa2.SelectCommand = myCmd
            myDa2.Fill(myDs, "Location")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            Me._errFlag = True
        Finally
            If myDa1 IsNot Nothing Then myDa1.Dispose()
            If myDa2 IsNot Nothing Then myDa2.Dispose()
        End Try

        If myDs.Tables("Location").Rows.Count = 0 Then
            MessageBox.Show("There are no active Locations in Database.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            Me._errFlag = True
        End If

        If Me._errFlag Then
            If myDs IsNot Nothing Then myDs.Dispose()
            Exit Sub
        End If

        For Each Row As DataRow In myDs.Tables("Location").Select("", "[Location Name]")
            Dim lsvItem As New ListViewItem(Row("Location Name").ToString)
            lsvItem.Checked = True
            Me.lsvLocations.Items.Add(lsvItem)
        Next

    End Sub

    Private Sub PopulateDrvLsv()

        Dim myDa As New SqlClient.SqlDataAdapter("SELECT [Driver ID],[Driver Name] FROM [Drivers] WHERE [Inactive]=0", _
                GS.ConnectionString)
        Dim myDs As New DataSet

        Try
            myDa.Fill(myDs, "Drivers")
        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            Me._errFlag = True
        Finally
            If myDa IsNot Nothing Then myDa.Dispose()
        End Try

        If myDs.Tables("Drivers").Rows.Count = 0 Then
            MessageBox.Show("There are no active drivers in Database.", "Error", MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            Me._errFlag = True
        End If

        If Me._errFlag Then
            If myDs IsNot Nothing Then myDs.Dispose()
            Exit Sub
        End If

        For Each row As DataRow In myDs.Tables("Drivers").Rows

            Me._drvIdCol.Add(row("Driver ID"), row("Driver Name").ToString)

            Dim lsvItem As New ListViewItem(row("Driver Name").ToString)
            lsvItem.Checked = True
            Me.lsvDrivers.Items.Add(lsvItem)

        Next

    End Sub

    ' chk box flag
    Dim chkFlag As Boolean = False

    Private Sub chkAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAll.Click

        chkFlag = True

        For Each it As ListViewItem In Me.lsvDrivers.Items
            it.Checked = Me.chkAll.Checked
        Next

        chkFlag = False

    End Sub

    Private Sub lsvDrivers_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lsvDrivers.ItemChecked

        If chkFlag Then Exit Sub

        Dim flag As Boolean = Me.lsvDrivers.Items(0).Checked

        For Each it As ListViewItem In Me.lsvDrivers.Items
            If it.Checked <> flag Then
                Me.chkAll.Checked = False
                Exit Sub
            End If
        Next

        Me.chkAll.Checked = flag
    End Sub

    Private Sub chkAllLoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllLoc.Click

        chkFlag = True

        For Each it As ListViewItem In Me.lsvLocations.Items
            it.Checked = Me.chkAllLoc.Checked
        Next

        chkFlag = False

    End Sub

    Private Sub lsvLocations_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lsvLocations.ItemChecked
        If chkFlag Then Exit Sub

        Dim flag As Boolean = Me.lsvLocations.Items(0).Checked

        For Each it As ListViewItem In Me.lsvLocations.Items()
            If it.Checked <> flag Then
                Me.chkAllLoc.Checked = False
                Exit Sub
            End If
        Next

        Me.chkAllLoc.Checked = flag
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click

        If Me.chkAll.Checked Then
            Me._drvs = New Integer() {}
        ElseIf Not Me.chkAll.Checked And Me.lsvDrivers.CheckedItems.Count = 0 Then
            MessageBox.Show("At least one driver must be selected.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Dim tempArr(Me.lsvDrivers.CheckedItems.Count - 1) As Integer

            For i As Integer = 0 To Me.lsvDrivers.CheckedItems.Count - 1
                tempArr(i) = CInt(Me._drvIdCol(Me.lsvDrivers.CheckedItems(i).Text))
            Next

            Me._drvs = tempArr

        End If

        Me._fromDt = Me.dtpFrom.Value.Date
        Me._toDt = Me.dtpTo.Value.Date
        Me._okPressed = True

        Me.Close()

    End Sub

    Private Sub btnOk_Cont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk_Cont.Click

        If Me.chkAllLoc.Checked Then
            Me._locations = New String() {}
        ElseIf Not Me.chkAllLoc.Checked And Me.lsvLocations.CheckedItems.Count = 0 Then
            MessageBox.Show("At least one location must be selected.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Else
            Dim tempArr(Me.lsvLocations.CheckedItems.Count - 1) As String

            For i As Integer = 0 To Me.lsvLocations.CheckedItems.Count - 1
                tempArr(i) = Me.lsvLocations.CheckedItems(i).Text
            Next

            Me._locations = tempArr

        End If

        Me._okPressed = True

        Me.Close()

    End Sub

    Private Sub btnOk_Wo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk_Wo.Click

        If Me.chkActive.Checked Then Me._WoStatus += 1
        If Me.chkInactive.Checked Then Me._WoStatus += 2
        If Me.chkClosed.Checked Then Me._WoStatus += 4

        If Me._WoStatus = 0 Then
            MessageBox.Show("At least one status must be selected.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Me._fromDt = Me.dtpFrom.Value.Date
        Me._toDt = Me.dtpTo.Value.Date
        Me._okPressed = True

        Me.Close()

    End Sub

    Private Sub dtpFrom_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.CloseUp
        If Me.dtpFrom.Value.Date > Me.dtpTo.Value.Date Then
            Me.dtpTo.Value = Me.dtpFrom.Value
        End If
    End Sub

    Private Sub dtpTo_CloseUp(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.CloseUp
        If Me.dtpFrom.Value.Date > Me.dtpTo.Value.Date Then
            Me.dtpFrom.Value = Me.dtpTo.Value
        End If
    End Sub

    Friend ReadOnly Property OkPressed() As Boolean
        Get
            Return Me._okPressed
        End Get
    End Property

    Friend ReadOnly Property StartDate() As Date
        Get
            Return Me._fromDt
        End Get
    End Property

    Friend ReadOnly Property EndDate() As Date
        Get
            Return Me._toDt
        End Get
    End Property

    Friend ReadOnly Property Drivers() As Integer()
        Get
            Return Me._drvs
        End Get
    End Property

    Friend ReadOnly Property WorkOrderStatus() As Integer
        Get
            Return Me._WoStatus
        End Get
    End Property

    Friend ReadOnly Property Locations() As String()
        Get
            Return Me._locations
        End Get
    End Property

End Class