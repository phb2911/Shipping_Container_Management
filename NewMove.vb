Public Class NewMove

    Dim _woId As Integer = -1
    Dim _moveId As Integer = -1
    Dim _mode As FormMode = FormMode.CreateNew
    Dim myDs As New DataSet
    Dim myOwner As WoDetails = Nothing
    Dim _myOwnerFlag As Boolean = False
    Dim DrHaz As New Collection

    Public Sub New(ByVal WorkOrderID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._woId = WorkOrderID

    End Sub

#Region "Control Events"

    Private Sub NewMove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me._woId < 0 Then Throw New Exception("Work Order ID cannot negative.")
        If Me._moveId < 0 And Me._mode <> FormMode.CreateNew Then _
            Throw New Exception("A ""Move ID"" must be passed unless mode is ""Create New"".")

        ' create WoDetails object
        If Me.Owner.Name = "WoDetails" Then
            Me.myOwner = CType(Me.Owner, WoDetails)
            Me._myOwnerFlag = True
        End If

        Me.txtWoNum.Text = Me._woId.ToString

        Me.cbxHour.SelectedIndex = 11
        Me.cbxMinute.SelectedIndex = 0
        Me.cbxAMPM.SelectedIndex = 0
        Me.cbxEndHour.SelectedIndex = 11
        Me.cbxEndMinute.SelectedIndex = 0
        Me.cbxEndAmPm.SelectedIndex = 0

        If Me._mode = FormMode.Edit Then
            Me.Text = "Edit Move # " & Me._moveId.ToString
        End If

        Me.FillDsAndCBXs()

    End Sub

    Private Sub NewMove_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' clean up
        If Not IsNothing(myDs) Then myDs.Dispose()
    End Sub

    Private Sub chkStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStart.CheckedChanged
        Dim flag As Boolean = Me.chkStart.Checked
        Me.dtpStart.Enabled = flag
        Me.cbxHour.Enabled = flag
        Me.Label14.Enabled = flag
        Me.cbxMinute.Enabled = flag
        Me.cbxAMPM.Enabled = flag
    End Sub

    Private Sub chkEnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnd.CheckedChanged
        Dim flag As Boolean = Me.chkEnd.Checked
        Me.dtpEnd.Enabled = flag
        Me.cbxEndHour.Enabled = flag
        Me.cbxEndMinute.Enabled = flag
        Me.cbxEndAmPm.Enabled = flag
        Me.Label6.Enabled = flag
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Me.ValidateFields() Then
            Dim MvId As String = String.Empty
            If InputData(MvId) Then

                Dim MvDate As Date = Nothing

                With Me.dtpStart.Value
                    Dim h As Integer = CInt(Me.cbxHour.Text)
                    Dim m As Integer = CInt(Me.cbxMinute.Text)

                    If Me.cbxAMPM.SelectedIndex = 0 And h = 12 Then
                        h = 0
                    ElseIf Me.cbxAMPM.SelectedIndex = 1 And h <> 12 Then
                        h += 12
                    End If

                    MvDate = New Date(.Year, .Month, .Day, h, m, 0)

                End With

                ' refresh WO list if open
                If GS.FormIsOpen(My.Forms.Form1.frmWrkOrderList) Then
                    My.Forms.Form1.frmWrkOrderList.RefreshList()
                End If

                ' update WO details if open
                Dim WoDtls As WoDetails = Nothing
                If GS.DetailFormIsOpen(WoDtls, Me._woId) Then
                    WoDtls.RefreshData()
                End If

                ' update Moves list if open
                If GS.FormIsOpen(My.Forms.Form1.frmMoveList) Then
                    My.Forms.Form1.frmMoveList.tsbRefresh_Click(Nothing, Nothing)
                End If

                ' update container list if open
                If GS.FormIsOpen(My.Forms.Form1.frmContainerList) Then
                    My.Forms.Form1.frmContainerList.tsbRefresh_Click(Nothing, Nothing)
                End If

                ' update dispatch window if open
                If GS.FormIsOpen(My.Forms.Form1.frmDispatch) Then
                    My.Forms.Form1.frmDispatch.tsbRefresh_Click(Nothing, Nothing)
                End If

                Me.Close()

            End If
        End If
    End Sub

    Private Sub cbxDriver_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDriver.SelectedIndexChanged

        If Me.cbxDriver.SelectedIndex > 0 Then
            Dim Rows() As DataRow = Me.myDs.Tables("Drivers").Select("[Driver Name]='" & Me.cbxDriver.Text & "'")
            If IsDBNull(Rows(0).Item("Truck Number")) Then
                Me.cbxTruck.SelectedIndex = 0
            Else
                Me.cbxTruck.Text = Rows(0).Item("Truck Number").ToString
            End If
        Else
            Me.cbxTruck.SelectedIndex = 0
        End If

        Me.btnDriverDetails.Enabled = (Me.cbxDriver.SelectedIndex > 0)

    End Sub

    Private Sub cbxFrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxFrom.SelectedIndexChanged
        Me.btnFromDetails.Enabled = (Me.cbxFrom.SelectedIndex > 1)
    End Sub

    Private Sub cbxTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTo.SelectedIndexChanged
        Me.btnToDetails.Enabled = (Me.cbxTo.SelectedIndex > 1)
    End Sub

    Private Sub cbxTruck_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTruck.SelectedIndexChanged
        Me.btnTruckDetails.Enabled = (Me.cbxTruck.SelectedIndex > 0)
    End Sub

    Private Sub btnLocDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromDetails.Click, btnToDetails.Click

        Dim CbxRef As ComboBox = Nothing

        If CInt(CType(sender, Button).Tag) = 1 Then
            CbxRef = Me.cbxFrom
        Else
            CbxRef = Me.cbxTo
        End If

        Dim Rows() As DataRow = Me.myDs.Tables("Location").Select("[Location Name]='" & GS.FilterSingleQuote(CbxRef.Text) & "'")

        Dim frm As New NewLocation
        frm.Owner = Me
        frm.Mode = FormMode.Details
        frm.LocationID = CInt(Rows(0).Item("Location ID"))
        frm.ShowDialog()
        frm.Dispose()

    End Sub

    Private Sub btnDriverDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDriverDetails.Click
        Dim Rows() As DataRow = Me.myDs.Tables("Drivers").Select("[Driver Name]='" & GS.FilterSingleQuote(Me.cbxDriver.Text) & "'")

        Dim frm As New NewDrivers
        frm.Owner = Me
        frm.Mode = FormMode.Details
        frm.DriverID = CInt(Rows(0).Item("Driver ID"))
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub btnTruckDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTruckDetails.Click
        Dim Rows() As DataRow = Me.myDs.Tables("Trucks").Select("[Truck Number]='" & GS.FilterSingleQuote(Me.cbxTruck.Text) & "'")

        Dim frm As New NewTruck
        frm.Owner = Me
        frm.Mode = FormMode.Details
        frm.TruckID = CInt(Rows(0).Item("Truck ID"))
        frm.ShowDialog()
        frm.Dispose()
    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Private Function FillDsAndCBXs() As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDaWo As New SqlClient.SqlDataAdapter
        Dim myDaLoc As New SqlClient.SqlDataAdapter
        Dim myDaDrv As New SqlClient.SqlDataAdapter
        Dim myDaTrk As New SqlClient.SqlDataAdapter
        Dim myDaMv As New SqlClient.SqlDataAdapter
        Dim myDaMvDt As New SqlClient.SqlDataAdapter
        Dim CsWo As String = String.Empty
        Dim CsLoc As String = String.Empty
        Dim CsDrv As String = String.Empty
        Dim CsTrk As String = String.Empty
        Dim CsMv As String = String.Empty
        Dim CsMvDt As String = String.Empty
        Dim flag As Boolean = True
        Dim mvRow As DataRow = Nothing

        CsMv = "SELECT [Moves].[Start Time],[Moves].[FromLocation],[Moves].[ToLocation]," & _
                "[Moves].[Complete],[Moves].[LD MT],[Moves].[End Time]," & _
                "(SELECT [Location].[Location Name] FROM [Location] " & _
                "WHERE [Location].[Location ID]=[Moves].[FromLocation]) [FromLocation Name], " & _
                "(SELECT [Location].[Location Name] FROM [Location] " & _
                "WHERE [Location].[Location ID]=[Moves].[ToLocation]) [ToLocation Name], " & _
                "[Drivers].[Driver Name],[Trucks].[Truck Number] " & _
                "FROM [Moves] INNER JOIN " & _
                "Drivers ON [Moves].[Driver ID] = [Drivers].[Driver ID] INNER JOIN " & _
                "Trucks ON [Moves].[Truck ID] = [Trucks].[Truck ID] " & _
                "WHERE [Moves].[Move ID]=" & Me._moveId.ToString


        Try
            myConn.Open()
            myCmd.Connection = myConn

            If Me._mode = FormMode.Edit Then
                myCmd.CommandText = CsMv
                myDaMv.SelectCommand = myCmd
                myDaMv.Fill(Me.myDs, "Moves")

                mvRow = Me.myDs.Tables("Moves").Rows(0)
            End If

            ' get all move dates and LD MT for this wo
            CsMvDt = "SELECT [Start Time],[End Time],[LD MT] FROM [Moves] WHERE [WorkOrder ID]=" & Me._woId.ToString
            If Me._mode = FormMode.Edit Then
                CsMvDt &= " AND [Move ID]<>" & Me._moveId.ToString
            End If
            CsMvDt &= " ORDER BY [Start Time]"
            myCmd.CommandText = CsMvDt
            myDaMvDt.SelectCommand = myCmd
            myDaMvDt.Fill(myDs, "MoveDates")

            CsWo = "SELECT [LD MT],[Hazardous],[Billing] FROM [WorkOrders] WHERE [WorkOrder ID]=" & Me._woId.ToString
            myCmd.CommandText = CsWo
            myDaWo.SelectCommand = myCmd
            myDaWo.Fill(myDs, "WorkOrders")

            CsLoc = "SELECT [Location ID],[Location Name],[PickUp DropOff] FROM [Location] WHERE [Inactive]=0 "
            If Me._mode = FormMode.Edit Then
                If CBool(mvRow.Item("FromLocation")) Then
                    CsLoc &= "OR [Location Name]='" & mvRow.Item("FromLocation Name").ToString & "' "
                End If
                If CBool(mvRow.Item("ToLocation")) Then
                    CsLoc &= "OR [Location Name]='" & mvRow.Item("ToLocation Name").ToString & "' "
                End If
            End If
            CsLoc &= "ORDER BY [Location Name]"

            myCmd.CommandText = CsLoc
            myDaLoc.SelectCommand = myCmd
            myDaLoc.Fill(Me.myDs, "Location")

            CsDrv = "SELECT [Drivers].[Driver ID],[Drivers].[Driver Name],[Drivers].[Hazmat]," & _
                "[Trucks].[Truck Number] FROM [Drivers] LEFT OUTER JOIN [Trucks] ON " & _
                "[Drivers].[Truck ID]=[Trucks].[Truck ID] WHERE [Drivers].[Inactive]=0 "
            If Me._mode = FormMode.Edit Then
                CsDrv &= "OR [Driver Name]='" & mvRow.Item("Driver Name").ToString & "' "
            End If
            CsDrv &= "ORDER BY [Drivers].[Driver Name]"

            myCmd.CommandText = CsDrv
            myDaDrv.SelectCommand = myCmd
            myDaDrv.Fill(Me.myDs, "Drivers")

            CsTrk = "SELECT [Truck ID],[Truck Number] FROM [Trucks] WHERE [Inactive]=0 "
            If Me._mode = FormMode.Edit Then
                CsTrk &= "OR [Truck Number]='" & mvRow.Item("Truck Number").ToString & "' "
            End If
            CsTrk &= "ORDER BY [Truck Number]"

            myCmd.CommandText = CsTrk
            myDaTrk.SelectCommand = myCmd
            myDaTrk.Fill(Me.myDs, "Trucks")

        Catch ex As Exception
            MessageBox.Show("An error occured while accessing the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDaWo) Then myDaWo.Dispose()
            If Not IsNothing(myDaLoc) Then myDaLoc.Dispose()
            If Not IsNothing(myDaDrv) Then myDaDrv.Dispose()
            If Not IsNothing(myDaTrk) Then myDaTrk.Dispose()
            If Not IsNothing(myDaMv) Then myDaMv.Dispose()
        End Try

        If Not flag Then Return False

        Me.cbxFrom.Items.Add(String.Empty)
        Me.cbxFrom.Items.Add("Delivery Location")
        Me.cbxTo.Items.Add(String.Empty)
        Me.cbxTo.Items.Add("Delivery Location")

        For Each row As DataRow In Me.myDs.Tables("Location").Rows
            Me.cbxFrom.Items.Add(row.Item("Location Name").ToString)
            Me.cbxTo.Items.Add(row.Item("Location Name").ToString)
        Next

        Me.cbxDriver.Items.Add(String.Empty)

        For Each row As DataRow In Me.myDs.Tables("Drivers").Rows
            Me.cbxDriver.Items.Add(row.Item("Driver Name").ToString)
            Me.DrHaz.Add(row.Item("Hazmat"), row.Item("Driver Name").ToString)
        Next

        Me.cbxTruck.Items.Add(String.Empty)

        For Each row As DataRow In Me.myDs.Tables("Trucks").Rows
            Me.cbxTruck.Items.Add(row.Item("Truck Number").ToString)
        Next

        ' original LD MT state from WorkOrders table
        If Not IsDBNull(myDs.Tables("WorkOrders").Rows(0).Item("LD MT")) Then
            If CBool(myDs.Tables("WorkOrders").Rows(0).Item("LD MT")) Then
                Me.radMT.Checked = True
            Else
                Me.radLD.Checked = True
            End If
        End If

        ' get LD MT status from last move if any
        Dim RowCount As Integer = Me.myDs.Tables("MoveDates").Rows.Count
        If RowCount > 0 Then
            ' get last move's state
            If CBool(Me.myDs.Tables("MoveDates").Rows(RowCount - 1).Item("LD MT")) Then
                Me.radMT.Checked = True
            Else
                Me.radLD.Checked = True
            End If

        End If

        ' Set Billing Status
        Me.chkReadyToBill.Enabled = (CInt(Me.myDs.Tables("WorkOrders").Rows(0)("Billing")) = 1)
        Me.chkReadyToBill.Checked = (CInt(Me.myDs.Tables("WorkOrders").Rows(0)("Billing")) = 2)

        ' populate fields
        If Me._mode = FormMode.Edit Then
            Me.dtpStart.Value = CDate(mvRow.Item("Start Time"))
            Me.chkStart.Checked = True

            Dim h As Integer = Me.dtpStart.Value.Hour

            If h > 11 Then
                h -= 12
                Me.cbxAMPM.SelectedIndex = 1
                If h = 0 Then h = 12
            End If

            Me.cbxHour.Text = Format(h, "00")
            Me.cbxMinute.Text = Format(Me.dtpStart.Value.Minute, "00")

            If Not IsDBNull(mvRow.Item("End Time")) Then
                Me.dtpEnd.Value = CDate(mvRow.Item("End Time"))
                Me.chkEnd.Checked = True

                Dim eh As Integer = Me.dtpEnd.Value.Hour

                If eh > 11 Then
                    eh -= 12
                    Me.cbxEndAmPm.SelectedIndex = 1
                    If eh = 0 Then eh = 12
                End If

                Me.cbxEndHour.Text = Format(eh, "00")
                Me.cbxEndMinute.Text = Format(Me.dtpEnd.Value.Minute, "00")

            End If

            If CBool(mvRow.Item("FromLocation")) Then
                Me.cbxFrom.Text = mvRow.Item("FromLocation Name").ToString
            Else
                Me.cbxFrom.SelectedIndex = 1
            End If

            If CBool(mvRow.Item("ToLocation")) Then
                Me.cbxTo.Text = mvRow.Item("ToLocation Name").ToString
            Else
                Me.cbxTo.SelectedIndex = 1
            End If

            Me.cbxDriver.Text = mvRow.Item("Driver Name").ToString
            Me.cbxTruck.Text = mvRow.Item("Truck Number").ToString

            If CBool(mvRow.Item("LD MT")) Then
                Me.radMT.Checked = True
            Else
                Me.radLD.Checked = True
            End If

            Me.chkComplete.Checked = CBool(mvRow.Item("Complete"))

        End If

        Return flag

    End Function

    Friend Property MoveID() As Integer
        Get
            Return Me._moveId
        End Get
        Set(ByVal value As Integer)
            Me._moveId = value
        End Set
    End Property

    Friend Property Mode() As FormMode
        Get
            Return Me._mode
        End Get
        Set(ByVal value As FormMode)
            Me._mode = value
        End Set
    End Property

    Private Function InputData(ByRef MoveId As String) As Boolean
        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim CmdStr As String = String.Empty
        Dim FrLoc As String = String.Empty
        Dim ToLoc As String = String.Empty
        Dim DrId As String = String.Empty
        Dim TrId As String = String.Empty
        Dim StartTime As Date = Nothing
        Dim EndTime As String = String.Empty
        Dim Cmpl As String = "0"
        Dim LdMt As String = "NULL"
        Dim Rows() As DataRow = Nothing
        Dim flag As Boolean = True

        If Me.cbxFrom.SelectedIndex = 1 Then
            FrLoc = "0"
        Else
            Rows = Me.myDs.Tables("Location").Select("[Location Name]='" & GS.FilterSingleQuote(Me.cbxFrom.Text) & "'")
            FrLoc = Rows(0).Item("Location ID").ToString
        End If

        If Me.cbxTo.SelectedIndex = 1 Then
            ToLoc = "0"
        Else
            Rows = Me.myDs.Tables("Location").Select("[Location Name]='" & GS.FilterSingleQuote(Me.cbxTo.Text) & "'")
            ToLoc = Rows(0).Item("Location ID").ToString
        End If

        Rows = Me.myDs.Tables("Drivers").Select("[Driver Name]='" & GS.FilterSingleQuote(Me.cbxDriver.Text) & "'")
        DrId = Rows(0).Item("Driver ID").ToString

        Rows = Me.myDs.Tables("Trucks").Select("[Truck Number]='" & GS.FilterSingleQuote(Me.cbxTruck.Text) & "'")
        TrId = Rows(0).Item("Truck ID").ToString

        With Me.dtpStart.Value
            Dim h As Integer = CInt(Me.cbxHour.Text)
            Dim m As Integer = CInt(Me.cbxMinute.Text)

            If Me.cbxAMPM.SelectedIndex = 0 And h = 12 Then
                h = 0
            ElseIf Me.cbxAMPM.SelectedIndex = 1 And h <> 12 Then
                h += 12
            End If

            StartTime = New Date(.Year, .Month, .Day, h, m, 0)

        End With

        If Me.chkEnd.Checked Then
            With Me.dtpEnd.Value
                Dim h As Integer = CInt(Me.cbxEndHour.Text)
                Dim m As Integer = CInt(Me.cbxEndMinute.Text)
                Dim tempDate As Date = Nothing

                If Me.cbxEndAmPm.SelectedIndex = 0 And h = 12 Then
                    h = 0
                ElseIf Me.cbxEndAmPm.SelectedIndex = 1 And h <> 12 Then
                    h += 12
                End If

                tempDate = New Date(.Year, .Month, .Day, h, m, 0)
                EndTime = "'" & tempDate.ToString & "'"

            End With
        Else
            EndTime = "NULL"
        End If

        If Me.chkComplete.Checked Then Cmpl = "1"

        If Me.radLD.Checked Then
            LdMt = "0"
        ElseIf Me.radMT.Checked Then
            LdMt = "1"
        End If

        If Me._mode = FormMode.CreateNew Then

            CmdStr = "INSERT INTO [Moves] ([WorkOrder ID],[Start Time],[End Time],[FromLocation],[ToLocation],[Driver ID],[Truck ID],[Complete],[LD MT]) VALUES " & _
                     "(" & Me._woId.ToString & ",'" & StartTime.ToString & "'," & EndTime & "," & FrLoc & "," & ToLoc & _
                     "," & DrId & "," & TrId & "," & Cmpl & "," & LdMt & ")"

        Else

            CmdStr = "UPDATE [Moves] SET [Start Time]='" & StartTime.ToString & "',[End Time]=" & EndTime & ",[FromLocation]=" & FrLoc & _
                ",[ToLocation]=" & ToLoc & ",[Driver ID]=" & DrId & ",[Truck ID]=" & TrId & ",[Complete]=" & _
                Cmpl & ",[LD MT]=" & LdMt & " WHERE [Move ID]=" & _
                Me._moveId.ToString

        End If

        Try

            myConn.Open()

            myCmd.CommandText = CmdStr
            myCmd.Connection = myConn
            myCmd.ExecuteNonQuery()

            If Me._mode = FormMode.CreateNew Then
                myCmd.CommandText = "SELECT @@identity"
                MoveId = myCmd.ExecuteScalar.ToString

                Dim tempFlag As Integer = -1

                If Me.radLD.Checked Then
                    tempFlag = 0
                ElseIf Me.radMT.Checked Then
                    tempFlag = 1
                End If

            End If

            ' Change Billing Status to Ready To Bill
            If Me.chkReadyToBill.Enabled And Me.chkReadyToBill.Checked Then

                myCmd.CommandText = "UPDATE [WorkOrders] SET [Billing] = 2 WHERE [WorkOrder ID] = " & Me._woId.ToString
                myCmd.ExecuteNonQuery()

            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                            "Details: " & ex.Message & "Please check your connection and try again.", "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
        End Try

        Return flag

    End Function

    Private Function ValidateFields() As Boolean

        Dim flag As Boolean = True
        Dim msg As String = String.Empty
        Dim mvStart As Date = Nothing
        Dim mvEnd As Date = Nothing

        With Me.dtpStart.Value
            Dim h As Integer = CInt(Me.cbxHour.Text)
            Dim m As Integer = CInt(Me.cbxMinute.Text)

            If Me.cbxAMPM.SelectedIndex = 0 And h = 12 Then
                h = 0
            ElseIf Me.cbxAMPM.SelectedIndex = 1 And h <> 12 Then
                h += 12
            End If

            mvStart = New Date(.Year, .Month, .Day, h, m, 0)

        End With

        With Me.dtpEnd.Value
            Dim h As Integer = CInt(Me.cbxEndHour.Text)
            Dim m As Integer = CInt(Me.cbxEndMinute.Text)

            If Me.cbxEndAmPm.SelectedIndex = 0 And h = 12 Then
                h = 0
            ElseIf Me.cbxEndAmPm.SelectedIndex = 1 And h <> 12 Then
                h += 12
            End If

            mvEnd = New Date(.Year, .Month, .Day, h, m, 0)

        End With

        For Each r As DataRow In Me.myDs.Tables("MoveDates").Rows
            Dim myDate As Date = CDate(r.Item("Start Time"))
            If mvStart = myDate Then
                MessageBox.Show("The selected Work Order has a move scheduled for the same time you are trying to schedule this move." & _
                    vbCrLf & "Please choose a different date/time and try again.", "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Next

        If Not Me.chkStart.Checked Then
            msg = "Please choose a date."
            flag = False
        ElseIf Me.chkEnd.Checked And mvStart >= mvEnd Then
            msg = "The Start Time must be earlier than the End Time."
            Me.dtpEnd.Focus()
            flag = False
        ElseIf Me.cbxFrom.Text = Me.cbxTo.Text Then
            msg = "Pleas select a diferent Location."
            Me.cbxTo.Focus()
            flag = False
        ElseIf Me.cbxFrom.SelectedIndex <= 0 Then
            msg = "Please select a From Location."
            Me.cbxFrom.Focus()
            flag = False
        ElseIf Me.cbxTo.SelectedIndex <= 0 Then
            msg = "Please select a To Location."
            Me.cbxTo.Focus()
            flag = False
        ElseIf Me.cbxDriver.SelectedIndex <= 0 Then
            msg = "Please select a Driver."
            Me.cbxDriver.Focus()
            flag = False
        ElseIf Me.cbxTruck.SelectedIndex <= 0 Then
            msg = "Please select a Truck Number."
            Me.cbxTruck.Focus()
            flag = False
        ElseIf CBool(Me.myDs.Tables("WorkOrders").Rows(0).Item("Hazardous")) And Not CBool(Me.DrHaz(Me.cbxDriver.Text)) _
            And Me.radLD.Checked Then
            msg = "The driver selected is not allowed to do this move because his driver license does not have " & _
                "'Hazard Material' endorsement."
            Me.cbxDriver.Focus()
            flag = False
        ElseIf Not Me.radLD.Checked And Not Me.radMT.Checked Then
            msg = "Please select LD or MT option."
            flag = False
        ElseIf Me.chkComplete.Checked And Not Me.chkEnd.Checked Then
            msg = "To mark the move as Complete an End Time must be entered."
            flag = False
        End If

        If Not flag Then
            MessageBox.Show(msg, "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

#End Region 'Methods & Properties

End Class