Public Class frmPrincipal
    Dim ut As New utils
    Private Sub btnVisita_Click(sender As Object, e As EventArgs) Handles btnVisita.Click
        Me.Hide()
        frmPracticas.Show()
    End Sub
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Me.Hide()
        frmPracticasPaciente.ShowDialog()
    End Sub
    Private Sub btnInformes_Click(sender As Object, e As EventArgs) Handles btnInformes.Click
        Me.Hide()
        frmInformes.ShowDialog()
    End Sub
    Private Sub btnVerificar_Click(sender As Object, e As EventArgs)
        Me.Hide()
        frmVerificar.ShowDialog()
    End Sub
    Private Sub btnNvaLiq_Click(sender As Object, e As EventArgs) Handles btnNvaLiq.Click
        Me.Hide()
        frmLiquidar.ShowDialog()
    End Sub
    Private Sub btnCierreLiq_Click(sender As Object, e As EventArgs) Handles btnCierreLiq.Click
        Me.Hide()
        frmCierreLiq.ShowDialog()
    End Sub
    Private Sub btnPrestadores_Click(sender As Object, e As EventArgs) Handles btnPrestadores.Click
        Me.Hide()
        frmPrestadores.ShowDialog()
    End Sub
    Private Sub btnPacientes_Click(sender As Object, e As EventArgs) Handles btnPacientes.Click
        Me.Hide()
        frmPacientes.ShowDialog()
    End Sub
    Private Sub btnModulo_Click(sender As Object, e As EventArgs) Handles btnModulo.Click
        Me.Hide()
        frmModulo.ShowDialog()
    End Sub
    Private Sub btnSubMod_Click(sender As Object, e As EventArgs) Handles btnSubMod.Click
        Me.Hide()
        frmSubMod.ShowDialog()
    End Sub
    Private Sub btnPrestacion_Click(sender As Object, e As EventArgs)
        Me.Hide()
        frmPrestacion.ShowDialog()
    End Sub
    Private Sub btnFeriados_Click(sender As Object, e As EventArgs) Handles btnFeriados.Click
        Me.Hide()
        FrmFeriados.ShowDialog()
    End Sub
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Me.Hide()
        frmUsuarios.ShowDialog()
    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        My.Settings.Item("HomeCareConnectionString") = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", My.Settings.DBPath)

        If My.Settings.nivel > 0 Then
            MenuStrip2.Enabled = False
        End If

        If My.Settings.nivel > 0 Then
            btnUsuarios.Visible = False
        Else
            btnUsuarios.Visible = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Application.Exit()
        End
    End Sub


    Private Sub MailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MailToolStripMenuItem.Click
        frmEmail.ShowDialog()
    End Sub

    Private Sub frmPrincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub InfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoToolStripMenuItem.Click
        frmInfo.Show()
    End Sub

    Private Sub UbicacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UbicacionToolStripMenuItem.Click
        Try
            ut.setDB()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub CopiasDeSeguridadToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopiasDeSeguridadToolStripMenuItem1.Click
        Try
            ut.setBackupPath()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub
End Class