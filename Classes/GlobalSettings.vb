Module GS

    Public Enum FormMode As Byte
        CreateNew
        Edit
        Details
    End Enum

    Friend Function ReportNumberOfPages(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportClass) As Integer
        Return rpt.FormatEngine.GetLastPageNumber(New CrystalDecisions.Shared.ReportPageRequestContext)
    End Function

    Friend Sub ResetPrintDialog(ByRef myPrintDialog As PrintDialog, ByVal MaximumPage As Integer)

        Static prDia As New PrintDialog

        myPrintDialog = prDia

        With myPrintDialog
            .UseEXDialog = True
            .AllowSomePages = True
            .AllowPrintToFile = False
            .PrinterSettings.MaximumPage = MaximumPage
            .PrinterSettings.MinimumPage = 1
            .PrinterSettings.FromPage = 1
            .PrinterSettings.ToPage = 1
            .PrinterSettings.Copies = 1
            .PrinterSettings.Collate = True
            .PrinterSettings.PrintRange = Printing.PrintRange.AllPages
        End With

    End Sub

#Region "AddHeader"

    Public Sub AddHeader(ByRef lsv As ListView, ByVal Text As String, ByVal Width As Integer, ByVal TextAlign As HorizontalAlignment)

        Dim ColHd As New ColumnHeader
        ColHd.Name = Text
        ColHd.Text = Text
        ColHd.Width = Width
        ColHd.TextAlign = TextAlign
        lsv.Columns.Add(ColHd)

    End Sub

    Public Sub AddHeader(ByRef lsv As ListView, ByVal Text As String)
        AddHeader(lsv, Text, 60, HorizontalAlignment.Left)
    End Sub

    Public Sub AddHeader(ByRef lsv As ListView, ByVal Text As String, ByVal Width As Integer)
        AddHeader(lsv, Text, Width, HorizontalAlignment.Left)
    End Sub

    Public Sub AddHeader(ByRef lsv As ListView, ByVal Text As String, ByVal TextAlign As HorizontalAlignment)
        AddHeader(lsv, Text, 60, TextAlign)
    End Sub

#End Region ' AddHeader

    Friend Sub FillRateListView(ByRef RateListView As ListView, ByVal RateString As String)

        ' clear old data
        RateListView.Items.Clear()

        ' empty string
        If RateString.Length = 0 Then Exit Sub

        Dim Rates() As String = Split(RateString, "::")

        For Each Rate As String In Rates

            If Rate.Length > 0 Then
                Dim It() As String = Split(Rate, "||")
                Dim lsvItem As New ListViewItem(It(0))
                lsvItem.SubItems.Add(It(1))

                RateListView.Items.Add(lsvItem)
            End If

        Next

    End Sub

    Friend Function ReopenWorkOrder(ByVal WorkOrderID As Integer) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim flag As Boolean = True

        Try
            myConn.Open()

            myCmd.Connection = myConn
            myCmd.CommandText = "IF EXISTS(SELECT [WorkOrder ID] FROM [WorkOrders] WHERE [WorkOrder ID]=" & WorkOrderID & _
                " AND [Status]=2) SELECT 1 ELSE SELECT 0"

            If CBool(myCmd.ExecuteScalar()) Then
                myCmd.CommandText = "UPDATE [WorkOrders] SET [Status]=0 WHERE [WorkOrder ID]=" & WorkOrderID.ToString
                myCmd.ExecuteNonQuery()
            Else
                MessageBox.Show("The selected Work Order can't be reopen.", "Can't Reopen", MessageBoxButtons.OK, _
                    MessageBoxIcon.Exclamation)
                flag = False
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                "Details: " & ex.Message & "Please check your connection and try again.", "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        Finally
            If myConn IsNot Nothing Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If myCmd IsNot Nothing Then myCmd.Dispose()
        End Try

        Return flag

    End Function

    Friend Function RemoveMoveFromDB(ByVal MoveId As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim flag As Boolean = True

        Try

            myConn.Open()

            myCmd.CommandText = "DELETE FROM [Moves] WHERE [Move ID]=" & MoveId
            myCmd.Connection = myConn

            myCmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Unable to remove Move # " & MoveId & vbCrLf & "Please chekc your connection and try again.", _
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Friend Function ThirtyDaysAgo() As Date
        Return CDate(Now.AddDays(-30).ToShortDateString & " 12:00:00 AM")
    End Function

    Friend Function CloseWorkOrder(ByVal WorkOrderID As Integer) As Boolean
        Dim CmdStr As String = ""
        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim ErrMsg As String = ""
        Dim flag As Boolean = True
        Dim IsNotBilled As Boolean = False

        Try
            myConn.Open()

            myCmd.Connection = myConn
            myCmd.CommandText = "SELECT CASE [Billing] WHEN 1 THEN 1 ELSE 0 END FROM [WorkOrders] WHERE [WorkOrder ID] = " & WorkOrderID.ToString

            IsNotBilled = CBool(myCmd.ExecuteScalar())

            myConn.Close()

            CmdStr = "UPDATE [WorkOrders] SET [Status]=2 "

            If IsNotBilled AndAlso MessageBox.Show("Would you like to set the Work Order you are about to close as ""Ready To Bill""?", _
            "Billing Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CmdStr &= ",[Billing]=2 "
            End If

            CmdStr &= "WHERE [WorkOrder ID]=" & WorkOrderID.ToString

            myConn.Open()

            myCmd.CommandText = CmdStr
            myCmd.ExecuteNonQuery()

        Catch ex As Exception
            ErrMsg = ex.Message
            flag = False
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
        End Try

        If Not flag Then
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                "Details: " & ErrMsg & "Please check your connection and try again.", "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return flag

    End Function

    Friend Function WorkOrderIsClosable(ByVal WorkOrderID As Integer) As Boolean

        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand
        Dim myDa As New SqlClient.SqlDataAdapter
        Dim myDs As New DataSet
        'Dim objLdMt As Object = Nothing
        Dim OpenMoveFlag As Boolean = False
        Dim flag As Boolean = True

        Try

            myConn.Open()
            myCmd.Connection = myConn

            myCmd.CommandText = "SELECT [In TIR],[Future_WO],[Move Type],[Status]" & _
                "FROM [WorkOrders] WHERE [WorkOrder ID]=" & WorkOrderID

            myDa.SelectCommand = myCmd
            myDa.Fill(myDs, "WorkOrders")

            'myCmd.CommandText = "SELECT [LD MT] FROM [Moves] WHERE [WorkOrder ID]=" & WorkOrderID & _
            '    " AND [Start Time]=(SELECT MAX([Start Time]) FROM [Moves]" & _
            '    " WHERE [WorkOrder ID]=" & WorkOrderID & ")"

            'objLdMt = myCmd.ExecuteScalar()

            myCmd.CommandText = "IF EXISTS(SELECT [Move ID] FROM [Moves] WHERE [WorkOrder ID]=" & WorkOrderID & _
                " AND [Complete]=0) SELECT 1 ELSE SELECT 0"

            OpenMoveFlag = CBool(myCmd.ExecuteScalar())

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
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        'Or IsNothing(objLdMt)
        If Not flag Or OpenMoveFlag Then
            If Not IsNothing(myDs) Then myDs.Dispose()
            Return False
        End If

        'Dim LdMtFlag As Boolean = CBool(objLdMt)
        Dim WoRow As DataRow = myDs.Tables("WorkOrders").Rows(0)
        Dim x As Integer = CInt(WoRow.Item("Move Type"))

        If CInt(WoRow.Item("Status")) <> 0 Then
            flag = False
        ElseIf (Not CBool(WoRow.Item("Future_WO")) And IsDBNull(WoRow.Item("In TIR"))) Then
            flag = False
            'ElseIf CInt(WoRow.Item("Move Type")) = 1 And Not LdMtFlag Then
            '    flag = False
            'ElseIf CInt(WoRow.Item("Move Type")) = 2 And LdMtFlag Then
            '    flag = False
        End If

        If Not IsNothing(myDs) Then myDs.Dispose()

        Return flag

    End Function

    Friend Function DetailFormIsOpen(ByRef FormName As WoDetails, ByVal WorkOrderID As Integer) As Boolean

        For Each Frm As Form In My.Forms.Form1.MdiChildren
            If Frm.Name = "WoDetails" Then
                Dim myWoDetails As WoDetails = CType(Frm, WoDetails)
                If myWoDetails.WorkOrderID = WorkOrderID Then
                    FormName = myWoDetails
                    Return True
                End If
            End If
        Next

        Return False

    End Function

    Public Function FormIsOpen(ByVal myForm As Form) As Boolean

        ' check if window is already open
        If IsNothing(myForm) Then Return False

        For Each myChild As Form In My.Forms.Form1.MdiChildren

            If myChild.Name = myForm.Name Then _
                Return True

        Next

        Return False

    End Function

    Friend ReadOnly Property ConnectionString() As String
        Get

            Dim Result As String = ""

            If My.Computer.Name.ToUpper() = "PHB2911-LAPTOP" Then
                Result = "user id=sa; data source=phb2911-laptop\sqlexpress; password=pert22; initial catalog=oceanne"
            ElseIf My.Computer.Name.ToUpper() = "RECEPTION" Or My.Computer.Name.ToUpper() = "OCEANNE-PC1" Then
                Result = "user id=sa; data source=PDC; password=pert22; initial catalog=oceanne"
            Else
                Throw New Exception("Cannot generate Connection String. Unknown Computer.")
            End If

            Return Result

        End Get
    End Property

    Public Function FilterSingleQuote(ByVal TextString As String) As String
        Return TextString.Replace("'", "''")
    End Function

    Public Sub TrimAllTextBoxesInGroupBox(ByRef myGroupBox As GroupBox)
        For Each ctl As Control In myGroupBox.Controls
            If ctl.GetType.ToString = "System.Windows.Forms.TextBox" Then
                ctl.Text = Trim(ctl.Text)
            End If
        Next
    End Sub

    Friend ReadOnly Property GlobalKey() As String
        Get
            Return "khUkl6Kg9qi98kj"
        End Get
    End Property

    Friend ReadOnly Property MdiWorkAreaSize() As Size
        Get
            Return New Size(My.Forms.Form1.ClientSize.Width - 8, My.Forms.Form1.ClientSize.Height - 54)
        End Get
    End Property

End Module
