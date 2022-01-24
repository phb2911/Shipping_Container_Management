<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MoveList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MoveList))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbNewMove = New System.Windows.Forms.ToolStripButton
        Me.tsbEditMove = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbReports = New System.Windows.Forms.ToolStripSplitButton
        Me.MovesByDriverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MovesByWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbFilter = New System.Windows.Forms.ToolStripButton
        Me.tsbShowActive = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lsvMoves = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WorkOrderDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewMoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNewMove, Me.tsbEditMove, Me.ToolStripSeparator4, Me.tsbReports, Me.ToolStripSeparator1, Me.tsbRefresh, Me.ToolStripSeparator2, Me.tsbFilter, Me.tsbShowActive})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(917, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNewMove
        '
        Me.tsbNewMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewMove.Image = Global.Oceanne.My.Resources.Resources.icon21
        Me.tsbNewMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewMove.Name = "tsbNewMove"
        Me.tsbNewMove.Size = New System.Drawing.Size(23, 22)
        Me.tsbNewMove.Tag = ""
        Me.tsbNewMove.Text = "New Move"
        '
        'tsbEditMove
        '
        Me.tsbEditMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEditMove.Image = Global.Oceanne.My.Resources.Resources.icon4
        Me.tsbEditMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditMove.Name = "tsbEditMove"
        Me.tsbEditMove.Size = New System.Drawing.Size(23, 22)
        Me.tsbEditMove.Text = "Edit Selected Move"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbReports
        '
        Me.tsbReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MovesByDriverToolStripMenuItem, Me.MovesByWorkOrderToolStripMenuItem})
        Me.tsbReports.Image = Global.Oceanne.My.Resources.Resources.icon15
        Me.tsbReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReports.Name = "tsbReports"
        Me.tsbReports.Size = New System.Drawing.Size(32, 22)
        Me.tsbReports.Text = "Reports"
        '
        'MovesByDriverToolStripMenuItem
        '
        Me.MovesByDriverToolStripMenuItem.Name = "MovesByDriverToolStripMenuItem"
        Me.MovesByDriverToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.MovesByDriverToolStripMenuItem.Text = "Moves By Driver"
        '
        'MovesByWorkOrderToolStripMenuItem
        '
        Me.MovesByWorkOrderToolStripMenuItem.Name = "MovesByWorkOrderToolStripMenuItem"
        Me.MovesByWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.MovesByWorkOrderToolStripMenuItem.Text = "Moves By Work Order"
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'tsbShowActive
        '
        Me.tsbShowActive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbShowActive.Image = Global.Oceanne.My.Resources.Resources.icon8
        Me.tsbShowActive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShowActive.Name = "tsbShowActive"
        Me.tsbShowActive.Size = New System.Drawing.Size(23, 22)
        Me.tsbShowActive.Text = "Show all Moves within the last 30 days"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.MinimumSize = New System.Drawing.Size(400, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(917, 37)
        Me.Panel1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(83, 9)
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
        Me.Label1.Size = New System.Drawing.Size(77, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Move List"
        '
        'lsvMoves
        '
        Me.lsvMoves.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader8, Me.ColumnHeader3, Me.ColumnHeader9, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.lsvMoves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvMoves.FullRowSelect = True
        Me.lsvMoves.GridLines = True
        Me.lsvMoves.HideSelection = False
        Me.lsvMoves.Location = New System.Drawing.Point(0, 62)
        Me.lsvMoves.MultiSelect = False
        Me.lsvMoves.Name = "lsvMoves"
        Me.lsvMoves.Size = New System.Drawing.Size(917, 298)
        Me.lsvMoves.TabIndex = 10
        Me.lsvMoves.UseCompatibleStateImageBehavior = False
        Me.lsvMoves.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Work Order ID"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 88
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Container Number"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Start"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "End"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "From"
        Me.ColumnHeader4.Width = 120
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "To"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Driver"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Truck Number"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMoveToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolStripSeparator5, Me.WorkOrderDetailsToolStripMenuItem, Me.ToolStripSeparator3, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(177, 126)
        '
        'WorkOrderDetailsToolStripMenuItem
        '
        Me.WorkOrderDetailsToolStripMenuItem.Image = Global.Oceanne.My.Resources.Resources.icon2
        Me.WorkOrderDetailsToolStripMenuItem.Name = "WorkOrderDetailsToolStripMenuItem"
        Me.WorkOrderDetailsToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.WorkOrderDetailsToolStripMenuItem.Text = "Work Order Details"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(173, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Image = Global.Oceanne.My.Resources.Resources.icon7
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'NewMoveToolStripMenuItem
        '
        Me.NewMoveToolStripMenuItem.Image = Global.Oceanne.My.Resources.Resources.icon21
        Me.NewMoveToolStripMenuItem.Name = "NewMoveToolStripMenuItem"
        Me.NewMoveToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.NewMoveToolStripMenuItem.Tag = "1"
        Me.NewMoveToolStripMenuItem.Text = "New Move"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(173, 6)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.Oceanne.My.Resources.Resources.icon4
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.EditToolStripMenuItem.Tag = "2"
        Me.EditToolStripMenuItem.Text = "Edit Move"
        '
        'MoveList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(917, 360)
        Me.Controls.Add(Me.lsvMoves)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MoveList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Move List"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents lsvMoves As System.Windows.Forms.ListView
    Friend WithEvents tsbShowActive As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents WorkOrderDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsbReports As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents MovesByDriverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MovesByWorkOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbNewMove As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditMove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewMoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
End Class
