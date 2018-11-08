Public Class frmPrincipal
    Private Sub btnVisita_Click(sender As Object, e As EventArgs) Handles btnVisita.Click
        frmPracticas.Show()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmReporte.Show()
    End Sub
    Private Sub btnInformes_Click(sender As Object, e As EventArgs) Handles btnInformes.Click
        frmInformes.Show()
    End Sub
    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        frmVerificar.Show()
    End Sub
    Private Sub btnNvaLiq_Click(sender As Object, e As EventArgs) Handles btnNvaLiq.Click
        frmLiquidar.Show()
    End Sub
    Private Sub btnCierreLiq_Click(sender As Object, e As EventArgs) Handles btnCierreLiq.Click
        frmCierreLiq.Show()
    End Sub




    Private Sub btnPrestadores_Click(sender As Object, e As EventArgs) Handles btnPrestadores.Click
        frmPrestadores.Show()
    End Sub
    Private Sub btnPacientes_Click(sender As Object, e As EventArgs) Handles btnPacientes.Click
        frmPacientes.Show()
    End Sub
    Private Sub btnModulo_Click(sender As Object, e As EventArgs) Handles btnModulo.Click
        frmModulo.Show()
    End Sub
    Private Sub btnSubMod_Click(sender As Object, e As EventArgs) Handles btnSubMod.Click
        frmSubMod.Show()
    End Sub
    Private Sub btnPrestacion_Click(sender As Object, e As EventArgs) Handles btnPrestacion.Click
        frmPrestacion.Show()
    End Sub
    Private Sub btnFeriados_Click(sender As Object, e As EventArgs) Handles btnFeriados.Click
        FrmFeriados.Show()
    End Sub


    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Item("HomeCareConnectionString") = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", My.Settings.DBPath)
    End Sub

    Private Sub BaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim ut = New utils
            ut.setDB()
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        ' Me.Close()
        End
    End Sub



End Class