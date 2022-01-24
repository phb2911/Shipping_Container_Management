Public Class NewLocation

    Dim _cbxOwner As ComboBox
    Dim frmNewWorkOrder As NewWorkOrder
    Dim _OwnerFlag As Boolean = False
    Dim _OkPressed As Boolean = False
    Dim _LocationId As Integer = -1
    Dim _mode As FormMode = FormMode.CreateNew

#Region "Control Events"

    Private Sub NewLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Me.Owner.Name = "NewWorkOrder" Then
            Me.frmNewWorkOrder = CType(Me.Owner, NewWorkOrder)
            Me._OwnerFlag = True
        End If

        ' validate mode
        If Not Me._mode = FormMode.CreateNew And Me._LocationId < 0 Then _
            Throw New Exception("A 'Location ID' must be passed unless mode is 'CreateNew'.")

        If Me._mode = FormMode.Details Then
            Me.Text = "Location # " & Me._LocationId.ToString & " details"
            Me.DisableControls()
            Me.PopulateControls()
        ElseIf Me._mode = FormMode.Edit Then
            Me.Text = "Edit Location # " & Me._LocationId.ToString
            Me.PopulateControls()
        End If

    End Sub

    Private Sub NewLocation_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' select blanc index of ComboBoxOwner
        If Not IsNothing(Me._cbxOwner) And Not Me._OkPressed Then
            Me._cbxOwner.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Cursor = Cursors.WaitCursor

        Dim ErrMsg As String = String.Empty

        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox1)
        GS.TrimAllTextBoxesInGroupBox(Me.GroupBox2)

        ' validate name
        If Me.txtName.Text.Length = 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("Please enter a valid Location Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.txtName.Focus()
            Exit Sub
        End If

        If InputData(ErrMsg) Then

            If Me._OwnerFlag And Me.chkInactive.Checked Then
                ' if location is inactive
                ' select blank cbx index
                Me._cbxOwner.SelectedIndex = 0
            ElseIf Me._OwnerFlag Then

                If Me.frmNewWorkOrder.FillDs(NewWorkOrder.FillTableType.Location) Then

                    ' check Move Type before populating cbx
                    If (Me.frmNewWorkOrder.cbxType.SelectedIndex = 3 And Not Me.chkPupDroff.Checked) Or _
                       (Me.frmNewWorkOrder.cbxType.SelectedIndex <> 3 And Me.chkPupDroff.Checked) Then

                        ' populate cbx
                        Me.frmNewWorkOrder.cbxPickup.Items.Add(Me.txtName.Text)
                        Me.frmNewWorkOrder.cbxDropOff.Items.Add(Me.txtName.Text)
                        ' select last index of owner cbx
                        Me._cbxOwner.SelectedIndex = Me._cbxOwner.Items.Count - 1
                    Else
                        Me._cbxOwner.SelectedIndex = 0
                    End If

                End If

            End If

            If GS.FormIsOpen(My.Forms.Form1.frmLocationList) Then
                My.Forms.Form1.frmLocationList.RefreshDataAndList()
            End If

            Me._OkPressed = True
            Me.Close()

        Else

            Dim msg As String = String.Empty

            If ErrMsg = "1" Then
                msg = "The Location '" & Me.txtName.Text & "' already exists." & vbCrLf & _
                      "Please choose a different name and try again."
                Me.txtName.Focus()
            ElseIf ErrMsg = "2" Then
                msg = "The Location being edited no longer exists in database."
                Me.Close()
            Else
                msg = "An error occured while the data was being sent to the database." & _
                      vbCrLf & vbCrLf & "Details: " & ErrMsg & vbCrLf & vbCrLf & _
                      "Check your connection and try again."
            End If

            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        Me.Cursor = Cursors.Default

    End Sub

#End Region ' Control Events

#Region "Methods & Properties"

    Private Sub PopulateControls()
        Dim myConn As New SqlClient.SqlConnection(GS.ConnectionString)
        Dim myCmd As New SqlClient.SqlCommand("SELECT * FROM [Location] WHERE [Location].[Location ID]=" & Me._LocationId.ToString, myConn)
        Dim myDa As New SqlClient.SqlDataAdapter(myCmd)
        Dim myDs As New DataSet
        Dim ErrFlag As Boolean = False

        Try

            myDa.Fill(myDs, "Location")

        Catch ex As Exception
            MessageBox.Show("An error occurred while accessing the database." & vbCrLf & vbCrLf & _
                "Details: " & ex.Message & "Please check your connection and try again.", "Error", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrFlag = True
        Finally
            If Not IsNothing(myConn) Then
                If myConn.State = ConnectionState.Open Then myConn.Close()
                myConn.Dispose()
            End If
            If Not IsNothing(myCmd) Then myCmd.Dispose()
            If Not IsNothing(myDa) Then myDa.Dispose()
        End Try

        If ErrFlag Then
            Me.Close()
            Exit Sub
        End If

        Dim Row As DataRow = myDs.Tables("Location").Rows(0)

        Me.txtName.Text = Row.Item("Location Name").ToString
        Me.txtAddress1.Text = Row.Item("Address").ToString
        Me.txtAddress2.Text = Row.Item("Address2").ToString
        Me.txtCity.Text = Row.Item("City").ToString

        If Not IsDBNull(Row.Item("State")) Then _
            Me.cbxState.Text = USStates.GetStateName(Row.Item("State").ToString)

        Me.txtZipCode.Text = Row.Item("Zip Code").ToString
        Me.txtDirections.Text = Row.Item("Directions").ToString
        Me.txtContactName.Text = Row.Item("Contact Name").ToString
        Me.txtPhone.Text = Row.Item("Phone").ToString
        Me.txtFax.Text = Row.Item("Fax").ToString
        Me.txtEmail.Text = Row.Item("E-mail").ToString

        Me.chkPupDroff.Checked = CBool(Row.Item("PickUp DropOff"))
        Me.chkInactive.Checked = CBool(Row.Item("Inactive"))

    End Sub

    Private Sub DisableControls()
        For Each c As Control In Me.GroupBox2.Controls
            If c.GetType.Name = "TextBox" Then
                CType(c, TextBox).ReadOnly = True
            End If
        Next
        For Each c As Control In Me.GroupBox1.Controls
            If c.GetType.Name = "TextBox" Then
                CType(c, TextBox).ReadOnly = True
            End If
        Next
        Me.txtDirections.ReadOnly = True
        Me.cbxState.Enabled = False
        Me.chkPupDroff.Enabled = False
        Me.chkInactive.Enabled = False
        Me.btnOk.Visible = False
        Me.btnCancel.Text = "Close"
    End Sub

    Public Function InputData(ByRef ErrorMessage As String) As Boolean

        Dim myConn As New SqlClient.SqlConnection
        Dim myCmd As SqlClient.SqlCommand = Nothing
        Dim CmdStr As String = String.Empty
        Dim CmdStr2 As String = String.Empty
        Dim Fields As String = String.Empty
        Dim Values As String = String.Empty
        Dim UpdateStr As String = String.Empty
        Dim flag As Boolean = True

        If Me.txtAddress1.Text <> String.Empty Then
            Fields &= ",[Address]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtAddress1.Text) & "'"
            UpdateStr &= ",[Address]='" & GS.FilterSingleQuote(Me.txtAddress1.Text) & "'"
        Else
            UpdateStr &= ",[Address]=NULL"
        End If

        If Me.txtAddress2.Text <> String.Empty Then
            Fields &= ",[Address2]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtAddress2.Text) & "'"
            UpdateStr &= ",[Address2]='" & GS.FilterSingleQuote(Me.txtAddress2.Text) & "'"
        Else
            UpdateStr &= ",[Address2]=NULL"
        End If

        If Me.txtCity.Text <> String.Empty Then
            Fields &= ",[City]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtCity.Text) & "'"
            UpdateStr &= ",[City]='" & GS.FilterSingleQuote(Me.txtCity.Text) & "'"
        Else
            UpdateStr &= ",[City]=NULL"
        End If

        If Me.cbxState.SelectedIndex > 0 Then
            Fields &= ",[State]"
            Values &= ",'" & USStates.GetAbreviation(Me.cbxState.Text) & "'"
            UpdateStr &= ",[State]='" & USStates.GetAbreviation(Me.cbxState.Text) & "'"
        Else
            UpdateStr &= ",[State]=NULL"
        End If

        If Me.txtZipCode.Text <> String.Empty Then
            Fields &= ",[Zip Code]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtZipCode.Text) & "'"
            UpdateStr &= ",[Zip Code]='" & GS.FilterSingleQuote(Me.txtZipCode.Text) & "'"
        Else
            UpdateStr &= ",[Zip Code]=NULL"
        End If

        If Me.txtDirections.Text <> String.Empty Then
            Fields &= ",[Directions]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtDirections.Text) & "'"
            UpdateStr &= ",[Directions]='" & GS.FilterSingleQuote(Me.txtDirections.Text) & "'"
        Else
            UpdateStr &= ",[Directions]=NULL"
        End If

        If Me.txtContactName.Text <> String.Empty Then
            Fields &= ",[Contact Name]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtContactName.Text) & "'"
            UpdateStr &= ",[Contact Name]='" & GS.FilterSingleQuote(Me.txtContactName.Text) & "'"
        Else
            UpdateStr &= ",[Contact Name]=NULL"
        End If

        If Me.txtPhone.Text <> String.Empty Then
            Fields &= ",[Phone]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtPhone.Text) & "'"
            UpdateStr &= ",[Phone]='" & GS.FilterSingleQuote(Me.txtPhone.Text) & "'"
        Else
            UpdateStr &= ",[Phone]=NULL"
        End If

        If Me.txtFax.Text <> String.Empty Then
            Fields &= ",[Fax]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtFax.Text) & "'"
            UpdateStr &= ",[Fax]='" & GS.FilterSingleQuote(Me.txtFax.Text) & "'"
        Else
            UpdateStr &= ",[Fax]=NULL"
        End If

        If Me.txtEmail.Text <> String.Empty Then
            Fields &= ",[E-Mail]"
            Values &= ",'" & GS.FilterSingleQuote(Me.txtEmail.Text) & "'"
            UpdateStr &= ",[E-Mail]='" & GS.FilterSingleQuote(Me.txtEmail.Text) & "'"
        Else
            UpdateStr &= ",[E-Mail]=NULL"
        End If

        If Me.chkInactive.Checked Then
            Fields &= ",[Inactive]"
            Values &= ",1"
            UpdateStr &= ",[Inactive]=1"
        Else
            UpdateStr &= ",[Inactive]=0"
        End If

        If Me.chkPupDroff.Checked Then
            Fields &= ",[PickUp DropOff]"
            Values &= ",1"
            UpdateStr &= ",[PickUp DropOff]=1"
        Else
            UpdateStr &= ",[PickUp DropOff]=0"
        End If

        If Me._mode = FormMode.CreateNew Then
            CmdStr = "INSERT INTO [Location] ([Location Name]" & Fields & ") VALUES ('" & _
                     GS.FilterSingleQuote(Me.txtName.Text) & "'" & Values & ")"

            CmdStr2 = "IF EXISTS (SELECT * FROM [Location] WHERE [Location].[Location Name]='" & _
                GS.FilterSingleQuote(Me.txtName.Text) & "') SELECT '1' ELSE SELECT '0'"
        Else
            CmdStr = "UPDATE [Location] SET [Location Name]='" & GS.FilterSingleQuote(Me.txtName.Text) & _
                                        "'" & UpdateStr & " WHERE [Location ID]=" & Me._LocationId.ToString

            CmdStr2 = "IF EXISTS (SELECT * FROM [Location] WHERE [Location ID]=" & Me._LocationId.ToString & ") SELECT '1' ELSE SELECT '0'"
        End If

        Try

            myConn.ConnectionString = GS.ConnectionString
            myConn.Open()

            myCmd = New SqlClient.SqlCommand(CmdStr2, myConn)

            Dim ExFlag As Boolean = CBool(myCmd.ExecuteScalar())
            
            If Me._mode = FormMode.CreateNew And ExFlag Then
                ErrorMessage = "1"
                flag = False
            ElseIf Me._mode = FormMode.Edit And Not ExFlag Then
                ErrorMessage = "2"
                flag = False
            Else

                myCmd = New SqlClient.SqlCommand(CmdStr, myConn)
                myCmd.ExecuteNonQuery()

            End If

        Catch ex As Exception
            ErrorMessage = ex.Message
            flag = False
        Finally
            If Not IsNothing(myConn) AndAlso myConn.State = ConnectionState.Open Then myConn.Close()
            If Not IsNothing(myCmd) Then myCmd.Dispose()
        End Try

        Return flag

    End Function

    Friend Property PickUpDropOffLocation() As Boolean
        Get
            Return Me.chkPupDroff.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.chkPupDroff.Checked = value
        End Set
    End Property

    Friend Property ComboBoxOwner() As ComboBox
        Get
            Return Me._cbxOwner
        End Get
        Set(ByVal value As ComboBox)
            Me._cbxOwner = value
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

    Friend Property LocationID() As Integer
        Get
            Return Me._LocationId
        End Get
        Set(ByVal value As Integer)
            Me._LocationId = value
        End Set
    End Property

#End Region ' Methods & Properties

    
End Class