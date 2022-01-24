Public Class EditTruckMileage

    Dim _mileageId As Integer = -1
    Dim myTruckCol As New Collection

    Public Sub New(ByVal MileageID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me._mileageId = MileageID

    End Sub

#Region "Control Events"

    Private Sub EditTruckMileage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me._mileageId < 0 Then Throw New Exception("Mileage ID cannot be negative.")

        Me.Text &= Me._mileageId

        Me.PopulateTruckCBX()

    End Sub

    Private Sub cbxTruck_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTruck.SelectedIndexChanged
        Me.btnTruckDetail.Enabled = (Me.cbxTruck.SelectedIndex > 0)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnTruckDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTruckDetail.Click
        Dim frm As New NewTruck
        frm.Owner = Me
        frm.Mode = FormMode.Details
        frm.TruckID = CInt(Me.myTruckCol.Item(Me.cbxTruck.Text))
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub txtMiles_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMiles.LostFocus
        If IsNumeric(Me.txtMiles.Text) Then
            Me.txtMiles.Text = Format(CDbl(Me.txtMiles.Text), "0")
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If Me.ValidateFields AndAlso InputData() Then

            'refresh list if open
            If GS.FormIsOpen(My.Forms.Form1.frmTruckMileageList) Then _
                My.Forms.Form1.frmTruckMileageList.tsbRefresh_Click(Nothing, Nothing)

            Me.Close()

        End If

    End Sub

#End Region 'Control Events

#Region "Methods & Properties"

    Private Function InputData() As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim flag As Boolean = True

        myCmd.Connection = myConn
        myCmd.CommandText = "UPDATE [TruckMileage] SET [Truck ID]=" & Me.myTruckCol(Me.cbxTruck.Text).ToString & _
            ",[Date]='" & Me.dtpMileage.Value.ToShortDateString & "',[Mileage]=" & Me.txtMiles.Text & _
            " WHERE [Mileage ID]=" & Me._mileageId.ToString

        Try
            myConn.Open()
            myCmd.ExecuteNonQuery()
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
        End Try

        Return flag

    End Function

    Private Sub PopulateTruckCBX()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa1 As New SqlClient.SqlDataAdapter
        Dim myDa2 As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False

        myCmd.Connection = myConn

        Try

            myCmd.CommandText = "SELECT [TruckMileage].*,[Trucks].[Truck Number] FROM [TruckMileage] " & _
                "INNER JOIN [Trucks] ON [TruckMileage].[Truck ID]=[Trucks].[Truck ID] WHERE " & _
                "[TruckMileage].[Mileage ID]=" & Me._mileageId.ToString

            myDa2.SelectCommand = myCmd
            myDa2.Fill(myDs, "TruckMileage")

            myCmd.CommandText = "SELECT [Truck ID],[Truck Number] FROM [Trucks] WHERE [Inactive]=0 OR [Truck ID]=" & _
                myDs.Tables("TruckMileage").Rows(0).Item("Truck ID").ToString & " ORDER BY [Truck Number]"

            myDa1.SelectCommand = myCmd
            myDa1.Fill(myDs, "Trucks")

        Catch ex As Exception
            MessageBox.Show("An error occured while accessing the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa1) Then myDa1.Dispose()
            If Not IsNothing(myDa2) Then myDa2.Dispose()
        End Try

        If ErrFlag Then
            If Not IsNothing(myDs) Then myDs.Dispose()
            Me.Close()
            Exit Sub
        End If

        Me.cbxTruck.Items.Add(String.Empty)

        For Each Row As DataRow In myDs.Tables("Trucks").Rows
            Me.cbxTruck.Items.Add(Row.Item("Truck Number").ToString)
            Me.myTruckCol.Add(Row.Item("Truck ID"), Row.Item("Truck Number").ToString)
        Next

        With myDs.Tables("TruckMileage").Rows(0)

            Me.cbxTruck.Text = .Item("Truck Number").ToString
            Me.dtpMileage.Value = CDate(.Item("Date"))
            Me.txtMiles.Text = .Item("Mileage").ToString

        End With

        If Not IsNothing(myDs) Then myDs.Dispose()

    End Sub

    Private Function ValidateFields() As Boolean

        Dim flag As Boolean = True
        Dim msg As String = String.Empty

        If Me.cbxTruck.SelectedIndex < 1 Then
            msg = "Please select a Truck Number."
            Me.cbxTruck.Focus()
            flag = False
        ElseIf Not IsNumeric(Me.txtMiles.Text) Then
            msg = "Invalid Mileage."
            Me.txtMiles.Focus()
            flag = False
        ElseIf CLng(Me.txtMiles.Text) > 2147483647 Then
            msg = "Mileage value is too big."
            Me.txtMiles.Focus()
            flag = False
        ElseIf CInt(Me.txtMiles.Text) < 0 Then
            msg = "Mileage value can't be negative."
            Me.txtMiles.Focus()
            flag = False
        End If

        If Not flag Then _
            MessageBox.Show(msg, "Invalid Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Return flag

    End Function

#End Region ' Methods & Properties

End Class