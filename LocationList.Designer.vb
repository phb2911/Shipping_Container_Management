<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LocationList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocationList))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbNew = New System.Windows.Forms.ToolStripButton
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton
        Me.tsbDetails = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.chkShowInactive = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lsvLocation = New System.Windows.Forms.ListView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CreateNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbEdit, Me.tsbDetails, Me.ToolStripSeparator1, Me.tsbRefresh})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(593, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNew
        '
        Me.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNew.Image = Global.Oceanne.My.Resources.Resources.icon6
        Me.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNew.Name = "tsbNew"
        Me.tsbNew.Size = New System.Drawing.Size(23, 22)
        Me.tsbNew.Text = "Create New"
        '
        'tsbEdit
        '
        Me.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEdit.Image = Global.Oceanne.My.Resources.Resources.icon4
        Me.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(23, 22)
        Me.tsbEdit.Text = "Edit"
        '
        'tsbDetails
        '
        Me.tsbDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDetails.Image = Global.Oceanne.My.Resources.Resources.icon2
        Me.tsbDetails.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDetails.Name = "tsbDetails"
        Me.tsbDetails.Size = New System.Drawing.Size(23, 22)
        Me.tsbDetails.Text = "Details"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbRefresh
        '
        Me.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRefresh.Image = Global.Oceanne.My.Resources.Resources.icon7
        Me.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefresh.Name = "tsbRefresh"
        Me.tsbRefresh.Size = New System.Drawing.Size(23, 22)
        Me.tsbRefresh.Text = "Refresh"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.chkShowInactive)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.MinimumSize = New System.Drawing.Size(400, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 50)
        Me.Panel1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(107, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "*"
        Me.Label3.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Controls.Add(Me.btnOk)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(357, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(236, 50)
        Me.Panel2.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Search Location"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(93, 23)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 20)
        Me.txtSearch.TabIndex = 2
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(199, 21)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(30, 23)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'chkShowInactive
        '
        Me.chkShowInactive.AutoSize = True
        Me.chkShowInactive.Location = New System.Drawing.Point(15, 29)
        Me.chkShowInactive.Name = "chkShowInactive"
        Me.chkShowInactive.Size = New System.Drawing.Size(94, 17)
        Me.chkShowInactive.TabIndex = 1
        Me.chkShowInactive.Text = "Show Inactive"
        Me.chkShowInactive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Location List"
        '
        'lsvLocation
        '
        Me.lsvLocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvLocation.FullRowSelect = True
        Me.lsvLocation.GridLines = True
        Me.lsvLocation.HideSelection = False
        Me.lsvLocation.Location = New System.Drawing.Point(0, 75)
        Me.lsvLocation.MultiSelect = False
        Me.lsvLocation.Name = "lsvLocation"
        Me.lsvLocation.Size = New System.Drawing.Size(593, 191)
        Me.lsvLocation.TabIndex = 7
        Me.lsvLocation.UseCompatibleStateImageBehavior = False
        Me.lsvLocation.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateNewToolStripMenuItem, Me.EditToolStripMenuItem, Me.DetailsToolStripMenuItem, Me.ToolStripSeparator2, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(143, 98)
        '
        'CreateNewToolStripMenuItem
        '
        Me.CreateNewToolStripMenuItem.Image = Global.Oceanne.My.Resources.Resources.icon6
        Me.CreateNewToolStripMenuItem.Name = "CreateNewToolStripMenuItem"
        Me.CreateNewToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.CreateNewToolStripMenuItem.Tag = "1"
        Me.CreateNewToolStripMenuItem.Text = "Create New"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.Oceanne.My.Resources.Resources.icon4
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.EditToolStripMenuItem.Tag = "2"
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Image = Global.Oceanne.My.Resources.Resources.icon2
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.DetailsToolStripMenuItem.Tag = "3"
        Me.DetailsToolStripMenuItem.Text = "Details"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(139, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = Global.Oceanne.My.Resources.Resources.icon7
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.RefreshToolStripMenuItem.Tag = "4"
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'LocationList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(593, 266)
        Me.Controls.Add(Me.lsvLocation)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LocationList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Location List"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDetails As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents chkShowInactive As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lsvLocation As System.Windows.Forms.ListView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CreateNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
