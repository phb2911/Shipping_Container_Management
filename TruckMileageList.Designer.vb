<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TruckMileageList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TruckMileageList))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbNew = New System.Windows.Forms.ToolStripButton
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbFilter = New System.Windows.Forms.ToolStripButton
        Me.tsbAll30days = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lsvTruckMileage = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CreateNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNew, Me.tsbEdit, Me.ToolStripSeparator1, Me.tsbRefresh, Me.ToolStripSeparator3, Me.tsbFilter, Me.tsbAll30days})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(571, 25)
        Me.ToolStrip1.TabIndex = 5
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbFilter
        '
        Me.tsbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbFilter.Image = Global.Oceanne.My.Resources.Resources.icon9
        Me.tsbFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFilter.Name = "tsbFilter"
        Me.tsbFilter.Size = New System.Drawing.Size(23, 22)
        Me.tsbFilter.Text = "Filter"
        '
        'tsbAll30days
        '
        Me.tsbAll30days.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAll30days.Image = Global.Oceanne.My.Resources.Resources.icon8
        Me.tsbAll30days.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAll30days.Name = "tsbAll30days"
        Me.tsbAll30days.Size = New System.Drawing.Size(23, 22)
        Me.tsbAll30days.Text = "See All Mileages dated within the last 30 days"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.MinimumSize = New System.Drawing.Size(400, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(571, 39)
        Me.Panel1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(147, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 17)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "*"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Truck Mileage List"
        '
        'lsvTruckMileage
        '
        Me.lsvTruckMileage.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvTruckMileage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvTruckMileage.FullRowSelect = True
        Me.lsvTruckMileage.GridLines = True
        Me.lsvTruckMileage.HideSelection = False
        Me.lsvTruckMileage.Location = New System.Drawing.Point(0, 64)
        Me.lsvTruckMileage.MultiSelect = False
        Me.lsvTruckMileage.Name = "lsvTruckMileage"
        Me.lsvTruckMileage.Size = New System.Drawing.Size(571, 289)
        Me.lsvTruckMileage.TabIndex = 11
        Me.lsvTruckMileage.UseCompatibleStateImageBehavior = False
        Me.lsvTruckMileage.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Truck Number"
        Me.ColumnHeader2.Width = 90
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 90
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Mileage"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 90
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateNewToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolStripSeparator2, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(143, 76)
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
        Me.RefreshToolStripMenuItem.Tag = "3"
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'TruckMileageList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(571, 353)
        Me.Controls.Add(Me.lsvTruckMileage)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TruckMileageList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Truck Mileage List"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAll30days As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lsvTruckMileage As System.Windows.Forms.ListView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CreateNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
End Class
