<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingWO
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnSelectNone = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(675, 118)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(116, 20)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(675, 144)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(116, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.CheckBoxes = True
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(15, 31)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(654, 174)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(675, 31)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(116, 23)
        Me.btnSelectAll.TabIndex = 1
        Me.btnSelectAll.Tag = "1"
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnSelectNone
        '
        Me.btnSelectNone.Location = New System.Drawing.Point(675, 60)
        Me.btnSelectNone.Name = "btnSelectNone"
        Me.btnSelectNone.Size = New System.Drawing.Size(116, 23)
        Me.btnSelectNone.TabIndex = 2
        Me.btnSelectNone.Tag = "0"
        Me.btnSelectNone.Text = "Select None"
        Me.btnSelectNone.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(675, 89)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(116, 23)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh Data"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'BillingWO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 217)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnSelectNone)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BillingWO"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BillingWO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnSelectNone As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class
