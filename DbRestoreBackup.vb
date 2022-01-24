Public Class DbRestoreBackup

    Private Sub DbRestoreBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Dim myFileDialog As New OpenFileDialog

        myFileDialog.Filter = "Oceanne Backup File (*.obf)|*.obf|All Files (*.*)|*.*"

        If myFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtFilePath.Text = myFileDialog.FileName
        End If

        myFileDialog.Dispose()

    End Sub
End Class