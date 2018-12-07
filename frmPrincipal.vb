Public Class frmPrincipal
    Dim ut As New utils
    Private Sub btnVisita_Click(sender As Object, e As EventArgs) Handles btnVisita.Click
        frmPracticas.Show()
    End Sub
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmReporte.ShowDialog()
    End Sub
    Private Sub btnInformes_Click(sender As Object, e As EventArgs) Handles btnInformes.Click
        frmInformes.ShowDialog()
    End Sub
    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) 
        frmVerificar.ShowDialog()
    End Sub
    Private Sub btnNvaLiq_Click(sender As Object, e As EventArgs) Handles btnNvaLiq.Click
        frmLiquidar.ShowDialog()
    End Sub
    Private Sub btnCierreLiq_Click(sender As Object, e As EventArgs) Handles btnCierreLiq.Click
        frmCierreLiq.ShowDialog()
    End Sub
    Private Sub btnPrestadores_Click(sender As Object, e As EventArgs) Handles btnPrestadores.Click
        frmPrestadores.ShowDialog()
    End Sub
    Private Sub btnPacientes_Click(sender As Object, e As EventArgs) Handles btnPacientes.Click
        frmPacientes.ShowDialog()
    End Sub
    Private Sub btnModulo_Click(sender As Object, e As EventArgs) Handles btnModulo.Click
        frmModulo.ShowDialog()
    End Sub
    Private Sub btnSubMod_Click(sender As Object, e As EventArgs) Handles btnSubMod.Click
        frmSubMod.ShowDialog()
    End Sub
    Private Sub btnPrestacion_Click(sender As Object, e As EventArgs) 
        frmPrestacion.ShowDialog()
    End Sub
    Private Sub btnFeriados_Click(sender As Object, e As EventArgs) Handles btnFeriados.Click
        FrmFeriados.ShowDialog()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Item("HomeCareConnectionString") = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", My.Settings.DBPath)
    End Sub

    Private Sub BaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BaseDeDatosToolStripMenuItem.Click
        Try

            ut.setDB()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Application.Exit()
        End
    End Sub

    Private Sub BaseDeDatosToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub MailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MailToolStripMenuItem.Click
        frmEmail.ShowDialog()
    End Sub

    Private Sub frmPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class