Public Class frmPrincipal
    Private Sub btnVisita_Click(sender As Object, e As EventArgs) Handles btnVisita.Click
        frmPracticas.Show()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmReporte.Show()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Item("HomeCareConnectionString") = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", My.Settings.DBPath)


    End Sub

    Private Sub BaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BaseDeDatosToolStripMenuItem.Click
        Try
            Dim ut = New utils
            ut.setDB()
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try

    End Sub

    Private Sub btnLiquidacion_Click(sender As Object, e As EventArgs) Handles btnLiquidacion.Click
        frmLiquidacion.Show()
    End Sub
End Class