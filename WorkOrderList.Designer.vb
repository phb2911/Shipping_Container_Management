<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkOrderList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkOrderList))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbCreateNewWO = New System.Windows.Forms.ToolStripButton
        Me.tsbEditSelWO = New System.Windows.Forms.ToolStripButton
        Me.tsbDetails = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRefresh = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbFilter = New System.Windows.Forms.ToolStripButton
        Me.tsbShowAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbReport = New System.Windows.Forms.ToolStripSplitButton
        Me.tsmRptDelivery = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmWorkOrders = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmByCustomers = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmByShipTo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmNotBilledWorkOrders = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmReadyToBillWorkOrders = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbCloseWo = New System.Windows.Forms.ToolStripButton
        Me.tsbReopenWo = New System.Windows.Forms.ToolStripButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lsvWorkOrders = New System.Windows.Forms.ListView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmNewWO = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDetails = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmReports = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmRptDelivery2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmCloseWo = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmReopenWo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbCreateNewWO, Me.tsbEditSelWO, Me.tsbDetails, Me.ToolStripSeparator1, Me.tsbRefresh, Me.ToolStripSeparator2, Me.tsbFilter, Me.tsbShowAll, Me.ToolStripSeparator4, Me.tsbReport, Me.ToolStripSeparator5, Me.tsbCloseWo, Me.tsbReopenWo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(526, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.TabStop = True
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbCreateNewWO
        '
        Me.tsbCreateNewWO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCreateNewWO.Image = Global.Oceanne.My.Resources.Resources.icon6
        Me.tsbCreateNewWO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCreateNewWO.Name = "tsbCreateNewWO"
        Me.tsbCreateNewWO.Size = New System.Drawing.Size(23, 22)
        Me.tsbCreateNewWO.Text = "Create New Work Order"
        '
        'tsbEditSelWO
        '
        Me.tsbEditSelWO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEditSelWO.Image = Global.Oceanne.My.Resources.Resources.icon4
        Me.tsbEditSelWO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditSelWO.Name = "tsbEditSelWO"
        Me.tsbEditSelWO.Size = New System.Drawing.Size(23, 22)
        Me.tsbEditSelWO.Text = "Edit Selected Work Order"
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
        Me.tsbRefresh.Text = "Refresh List"
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
        'tsbShowAll
        '
        Me.tsbShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbShowAll.Image = Global.Oceanne.My.Resources.Resources.icon8
        Me.tsbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShowAll.Name = "tsbShowAll"
        Me.tsbShowAll.Size = New System.Drawing.Size(23, 22)
        Me.tsbShowAll.Text = "Show all Work Orders dated within the last 30 days."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbReport
        '
        Me.tsbReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmRptDelivery, Me.ToolStripSeparator7, Me.tsmWorkOrders, Me.tsmByCustomers, Me.tsmByShipTo, Me.ToolStripSeparator8, Me.tsmNotBilledWorkOrders, Me.tsmReadyToBillWorkOrders})
        Me.tsbReport.Image = Global.Oceanne.My.Resources.Resources.icon15
        Me.tsbReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReport.Name = "tsbReport"
        Me.tsbReport.Size = New System.Drawing.Size(32, 22)
        Me.tsbReport.Text = "Report"
        '
        'tsmRptDelivery
        '
        Me.tsmRptDelivery.Name = "tsmRptDelivery"
        Me.tsmRptDelivery.Size = New System.Drawing.Size(210, 22)
        Me.tsmRptDelivery.Text = "Delivery Order"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(207, 6)
        '
        'tsmWorkOrders
        '
        Me.tsmWorkOrders.Name = "tsmWorkOrders"
        Me.tsmWorkOrders.Size = New System.Drawing.Size(210, 22)
        Me.tsmWorkOrders.Tag = "1"
        Me.tsmWorkOrders.Text = "Work Orders"
        '
        'tsmByCustomers
        '
        Me.tsmByCustomers.Name = "tsmByCustomers"
        Me.tsmByCustomers.Size = New System.Drawing.Size(210, 22)
        Me.tsmByCustomers.Tag = "2"
        Me.tsmByCustomers.Text = "Work Orders by Customer"
        '
        'tsmByShipTo
        '
        Me.tsmByShipTo.Name = "tsmByShipTo"
        Me.tsmByShipTo.Size = New System.Drawing.Size(210, 22)
        Me.tsmByShipTo.Tag = "3"
        Me.tsmByShipTo.Text = "Work Orders by ShipTo"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(207, 6)
        '
        'tsmNotBilledWorkOrders
        '
        Me.tsmNotBilledWorkOrders.Name = "tsmNotBilledWorkOrders"
        Me.tsmNotBilledWorkOrders.Size = New System.Drawing.Size(210, 22)
        Me.tsmNotBilledWorkOrders.Tag = "4"
        Me.tsmNotBilledWorkOrders.Text = "Not Billed Work Orders"
        '
        'tsmReadyToBillWorkOrders
        '
        Me.tsmReadyToBillWorkOrders.Name = "tsmReadyToBillWorkOrders"
        Me.tsmReadyToBillWorkOrders.Size = New System.Drawing.Size(210, 22)
        Me.tsmReadyToBillWorkOrders.Tag = "5"
        Me.tsmReadyToBillWorkOrders.Text = "Ready To Bill Work Orders"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbCloseWo
        '
        Me.tsbCloseWo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCloseWo.Image = Global.Oceanne.My.Resources.Resources.icon3
        Me.tsbCloseWo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCloseWo.Name = "tsbCloseWo"
        Me.tsbCloseWo.Size = New System.Drawing.Size(23, 22)
        Me.tsbCloseWo.Text = "Close Work Order"
        '
        'tsbReopenWo
        '
        Me.tsbReopenWo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbReopenWo.Image = Global.Oceanne.My.Resources.Resources.icon38
        Me.tsbReopenWo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbReopenWo.Name = "tsbReopenWo"
        Me.tsbReopenWo.Size = New System.Drawing.Size(23, 22)
        Me.tsbReopenWo.Text = "Reopen Work Order"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 38)
        Me.Panel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(130, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "*"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Work Order List"
        '
        'lsvWorkOrders
        '
        Me.lsvWorkOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvWorkOrders.FullRowSelect = True
        Me.lsvWorkOrders.GridLines = True
        Me.lsvWorkOrders.HideSelection = False
        Me.lsvWorkOrders.Location = New System.Drawing.Point(0, 63)
        Me.lsvWorkOrders.MultiSelect = False
        Me.lsvWorkOrders.Name = "lsvWorkOrders"
        Me.lsvWorkOrders.Size = New System.Drawing.Size(526, 232)
        Me.lsvWorkOrders.TabIndex = 2
        Me.lsvWorkOrders.UseCompatibleStateImageBehavior = False
        Me.lsvWorkOrders.View = System.Windows.Forms.View.Details
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNewWO, Me.tsmEdit, Me.tsmDetails, Me.tsmReports, Me.ToolStripSeparator6, Me.tsmCloseWo, Me.tsmReopenWo, Me.ToolStripSeparator3, Me.tsmRefresh})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 170)
        '
        'tsmNewWO
        '
        Me.tsmNewWO.Image = Global.Oceanne.My.Resources.Resources.icon6
        Me.tsmNewWO.Name = "tsmNewWO"
        Me.tsmNewWO.Size = New System.Drawing.Size(181, 22)
        Me.tsmNewWO.Tag = "1"
        Me.tsmNewWO.Text = "New Work Order"
        '
        'tsmEdit
        '
        Me.tsmEdit.Image = Global.Oceanne.My.Resources.Resources.icon4
        Me.tsmEdit.Name = "tsmEdit"
        Me.tsmEdit.Size = New System.Drawing.Size(181, 22)
        Me.tsmEdit.Tag = "2"
        Me.tsmEdit.Text = "Edit"
        '
        'tsmDetails
        '
        Me.tsmDetails.Image = Global.Oceanne.My.Resources.Resources.icon2
        Me.tsmDetails.Name = "tsmDetails"
        Me.tsmDetails.Size = New System.Drawing.Size(181, 22)
        Me.tsmDetails.Tag = "3"
        Me.tsmDetails.Text = "View Details"
        '
        'tsmReports
        '
        Me.tsmReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmRptDelivery2})
        Me.tsmReports.Image = Global.Oceanne.My.Resources.Resources.icon15
        Me.tsmReports.Name = "tsmReports"
        Me.tsmReports.Size = New System.Drawing.Size(181, 22)
        Me.tsmReports.Text = "Reports"
        '
        'tsmRptDelivery2
        '
        Me.tsmRptDelivery2.Name = "tsmRptDelivery2"
        Me.tsmRptDelivery2.Size = New System.Drawing.Size(155, 22)
        Me.tsmRptDelivery2.Tag = "5"
        Me.tsmRptDelivery2.Text = "Delivery Order"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(178, 6)
        '
        'tsmCloseWo
        '
        Me.tsmCloseWo.Image = Global.Oceanne.My.Resources.Resources.icon3
        Me.tsmCloseWo.Name = "tsmCloseWo"
        Me.tsmCloseWo.Size = New System.Drawing.Size(181, 22)
        Me.tsmCloseWo.Tag = "6"
        Me.tsmCloseWo.Text = "Close Work Order"
        '
        'tsmReopenWo
        '
        Me.tsmReopenWo.Image = Global.Oceanne.My.Resources.Resources.icon38
        Me.tsmReopenWo.Name = "tsmReopenWo"
        Me.tsmReopenWo.Size = New System.Drawing.Size(181, 22)
        Me.tsmReopenWo.Tag = "7"
        Me.tsmReopenWo.Text = "Reopen Work Order"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(178, 6)
        '
        'tsmRefresh
        '
        Me.tsmRefresh.Image = Global.Oceanne.My.Resources.Resources.icon7
        Me.tsmRefresh.Name = "tsmRefresh"
        Me.tsmRefresh.Size = New System.Drawing.Size(181, 22)
        Me.tsmRefresh.Tag = "4"
        Me.tsmRefresh.Text = "Refresh"
        '
        'WorkOrderList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(526, 295)
        Me.Controls.Add(Me.lsvWorkOrders)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "WorkOrderList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Work Order List"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lsvWorkOrders As System.Windows.Forms.ListView
    Friend WithEvents tsbCreateNewWO As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditSelWO As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tsbDetails As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmNewWO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbReport As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents tsmRptDelivery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRptDelivery2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbCloseWo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbReopenWo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmCloseWo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReopenWo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmWorkOrders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmByCustomers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmByShipTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmNotBilledWorkOrders As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmReadyToBillWorkOrders As System.Windows.Forms.ToolStripMenuItem
End Class
