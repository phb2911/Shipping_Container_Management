Public Class About

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = "Container Management System (" & My.Application.Info.Version.ToString & ")"

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim Y As Integer = 284

        Dim myPen As New System.Drawing.Pen(Color.Gray)
        Dim myPen2 As New System.Drawing.Pen(Color.White)
        Dim formGraphics As System.Drawing.Graphics = Me.CreateGraphics()
        Dim W As Integer = Me.Width

        formGraphics.DrawLine(myPen, 0, Y, W, Y)
        formGraphics.DrawLine(myPen2, 0, Y + 1, W, Y + 1)

        myPen.Dispose()
        myPen2.Dispose()
        formGraphics.Dispose()

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("mailto:phb2911@hotmail.com")
    End Sub
End Class