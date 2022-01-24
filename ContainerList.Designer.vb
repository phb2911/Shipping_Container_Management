<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContainerList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContainerList))
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lsvContainers = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbReport = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbFilter = New System.Windows.Forms.ToolStripButton
        Me.tsbShowDefault = New System.Windows.Forms.ToolStripButton
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.WorkOrderDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(864, 38)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(115, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "*"
        Me.Label3.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Container List"
        '
        'lsvContainers
        '
        Me.lsvContainers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lsvContainers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvContainers.FullRowSelect = True
        Me.lsvContainers.GridLines = True
        Me.lsvContainers.HideSelection = False
        Me.lsvContainers.Location = New System.Drawing.Point(0, 63)
        Me.lsvContainers.MultiSelect = False
        Me.lsvContainers.Name = "lsvContainers"
        Me.lsvContainers.Size = New System.Drawing.Size(864, 296)
        Me.lsvContainers.TabIndex = 1
        Me.lsvContainers.UseCompatibleStateImageBehavior = False
        Me.lsvContainers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Work Order ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Container Number"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Location"
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Shipping Line"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Chassis Number"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Size/Type"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "LD/MT"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Work Order Status"
        Me.ColumnHeader8.Width = 95
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Work Order Date"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 120
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbReport, Me.ToolStripSeparator1, Me.tsbRefresh, Me.ToolStripSeparator2, Me.tsbFilter, Me.tsbShowDefault})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(864, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbReport
        '
        Me.tsbReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbReport.Image = Global.Oceanne.My.Resources.Resources.icon15
        Me.tsbReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReport.Name = "tsbReport"
        Me.tsbReport.Size = New System.Drawing.Size(23, 22)
        Me.tsbReport.Text = "Create Report"
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
        'tsbShowDefault
        '
        Me.tsbShowDefault.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbShowDefault.Image = Global.Oceanne.My.Resources.Resources.icon8
        Me.tsbShowDefault.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShowDefault.Name = "tsbShowDefault"
        Me.tsbShowDefault.Size = New System.Drawing.Size(23, 22)
        Me.tsbShowDefault.Text = "Show all containers dated within the last 30 days"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WorkOrderDetailsToolStripMenuItem, Me.ToolStripSeparator3, Me.RefreshToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(177, 54)
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
        'ContainerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(864, 359)
        Me.Controls.Add(Me.lsvContainers)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ContainerList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Container List"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lsvContainers As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbReport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbShowDefault As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents WorkOrderDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
