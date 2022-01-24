Public Class SelectCustomer

    Dim myDs As New DataSet
    Dim _custName As String = String.Empty
    Dim _custId As Integer = -1
    Dim _canceled As Boolean = True

    Private Sub SelectCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myDa As New SqlClient.SqlDataAdapter("SELECT [Customer ID],[Customer Name] FROM [Customers] WHERE [Inactive]=0 ORDER BY [Customer Name]", myConn)
        Dim flag As Boolean = False

        Try

            myDa.Fill(myDs, "Customers")

        Catch ex As Exception
            MessageBox.Show("An error occurred while connecting to the database." & _
                            vbCrLf & vbCrLf & "Details: " & ex.Message & vbCrLf & vbCrLf & _
                            "Please check your connection and try again.", "Error", MessageBoxButtons.OK, _
                            MessageBoxIcon.Error)
            flag = True
        Finally
            If Not IsNothing(myConn) Then myConn.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If flag Then
            Me.Close()
            Exit Sub
        End If

        For Each Row As DataRow In myDs.Tables("Customers").Rows
            Me.lsbSelect.Items.Add(Row.Item("Customer Name"))
        Next

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Me.lsbSelect.SelectedItems.Count = 0 Then
            MessageBox.Show("Pleas select a Customer.", "Customer not selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Me._custName = Me.lsbSelect.SelectedItem.ToString
            Dim Rows() As DataRow = Me.myDs.Tables("Customers").Select("[Customer Name]='" & Me._custName & "'")
            Me._custId = CInt(Rows(0).Item("Customer ID"))
            Me._canceled = False
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lsbSelect_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lsbSelect.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left And Me.lsbSelect.SelectedItems.Count > 0 Then
            Me.btnOk_Click(sender, e)
        End If
    End Sub

    Friend ReadOnly Property CustomerName() As String
        Get
            Return Me._custName
        End Get
    End Property

    Friend ReadOnly Property CustomerID() As Integer
        Get
            Return Me._custId
        End Get
    End Property

    Friend ReadOnly Property Cancelled() As Boolean
        Get
            Return Me._canceled
        End Get
    End Property

End Class