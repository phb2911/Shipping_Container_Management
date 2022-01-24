Public Class NewTruckMileage

    Dim myTruckCol As New Collection
    Dim myMaxMileageCol As New Collection
    Dim _OkPressed As Boolean = False

#Region "Control Events"

    Private Sub NewTruckMileage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PopulateTruckCBX()
    End Sub

    Private Sub NewTruckMileage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not _OkPressed And Me.lsvMileage.Items.Count > 0 Then
            If MessageBox.Show("The items added to the list were not saved to the Database and they will be lost." & _
                            vbCrLf & "Close it anyway?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cbxTruck_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxTruck.SelectedIndexChanged
        Me.btnTruckDetail.Enabled = (Me.cbxTruck.SelectedIndex > 0)
    End Sub

    Private Sub txtMiles_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMiles.KeyUp
        If e.KeyValue = 13 Then Me.btnAdd_Click(Nothing, Nothing)
    End Sub

    Private Sub txtMiles_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMiles.LostFocus
        If IsNumeric(Me.txtMiles.Text) Then
            Me.txtMiles.Text = Format(CDbl(Me.txtMiles.Text), "0")
        End If
    End Sub

    Private Sub btnTruckDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTruckDetail.Click
        Dim frm As New NewTruck
        frm.Owner = Me
        frm.Mode = FormMode.Details
        frm.TruckID = CInt(Me.myTruckCol.Item(Me.cbxTruck.Text))
        frm.ShowDialog()
        frm.Dispose()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If Me.lsvMileage.Items.Count = 0 Then
            MessageBox.Show("Please add at least one item to the list before pressing the Save button.", "Empty List", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If Me.InputData() Then

                'refresh list if open
                If GS.FormIsOpen(My.Forms.Form1.frmTruckMileageList) Then _
                    My.Forms.Form1.frmTruckMileageList.tsbRefresh_Click(Nothing, Nothing)

                Me._OkPressed = True
                Me.Close()
            End If
        End If

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.ValidateFields() Then

            If Not IsDBNull(Me.myMaxMileageCol(Me.cbxTruck.Text)) AndAlso _
                        CInt(Me.txtMiles.Text) < CInt(Me.myMaxMileageCol(Me.cbxTruck.Text)) Then

                If MessageBox.Show("The mileage for Truck # " & Me.cbxTruck.Text & " must be greater than or equals to " & _
                     Me.myMaxMileageCol(Me.cbxTruck.Text).ToString & "." & vbCrLf & "Continue anyway?", _
                     "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

            End If

            Dim lsvItem As New ListViewItem(Me.cbxTruck.Text)
            lsvItem.SubItems.Add(Me.dtpMileage.Value.ToShortDateString)
            lsvItem.SubItems.Add(Me.txtMiles.Text)
            Me.lsvMileage.Items.Add(lsvItem)

            Me.cbxTruck.SelectedIndex = 0
            Me.dtpMileage.Value = Now
            Me.txtMiles.Text = String.Empty
            Me.cbxTruck.Focus()

        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Me.lsvMileage.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select an item to be removed.", "Item not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            For Each li As ListViewItem In Me.lsvMileage.SelectedItems
                Me.lsvMileage.Items.Remove(li)
            Next
        End If
    End Sub

#End Region ' Control Events

#Region "Methods & Properties"

    Private Sub PopulateTruckCBX()

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False

        myCmd.CommandText = "SELECT [Truck ID],[Truck Number], " & _
            "(SELECT MAX([Mileage]) FROM [TruckMileage] " & _
            "WHERE [TruckMileage].[Truck ID]=[Trucks].[Truck ID]) [Max Mileage] " & _
            "FROM [Trucks] WHERE [Inactive]=0 ORDER BY [Truck Number]"
        myCmd.Connection = myConn

        Try

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "Trucks")

        Catch ex As Exception
            MessageBox.Show("An error occured while accessing the database." & _
                vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                "Check your connection and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
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
            Me.myMaxMileageCol.Add(Row.Item("Max Mileage"), Row.Item("Truck Number").ToString)
        Next

        If Not IsNothing(myDs) Then myDs.Dispose()

    End Sub

    Private Function InputData() As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim flag As Boolean = True

        Try
            myConn.Open()

            myCmd.Connection = myConn

            For Each lsvItem As ListViewItem In Me.lsvMileage.Items
                myCmd.CommandText = "INSERT INTO [TruckMileage] ([Truck ID],[Date],[Mileage]) VALUES (" & _
                         Me.myTruckCol(lsvItem.SubItems(0).Text).ToString & ",'" & lsvItem.SubItems(1).Text & "'," & _
                            lsvItem.SubItems(2).Text & ")"
                myCmd.ExecuteNonQuery()
            Next

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

#End Region 'Methods & Properties

End Class