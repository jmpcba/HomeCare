Public Class frmPrincipal
    Dim ut As New utils
    Private Sub btnVisita_Click(sender As Object, e As EventArgs) Handles btnVisita.Click
        Try
            Me.Hide()
            frmPracticas.Show()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Me.Hide()
            frmPracticasPaciente.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnInformes_Click(sender As Object, e As EventArgs) Handles btnInformes.Click
        Try
            Me.Hide()
            frmReporte.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnVerificar_Click(sender As Object, e As EventArgs)
        Try
            Me.Hide()
            frmVerificar.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnNvaLiq_Click(sender As Object, e As EventArgs) Handles btnNvaLiq.Click
        Try
            Me.Hide()
            Dim frm = New frmLiquidar(frmLiquidar.liquidaciones.abiertas)
            frm.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnCierreLiq_Click(sender As Object, e As EventArgs) Handles btnCierreLiq.Click
        Try
            Me.Hide()
            Dim frm = New frmLiquidar(frmLiquidar.liquidaciones.cerradas)
            frm.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnPrestadores_Click(sender As Object, e As EventArgs) Handles btnPrestadores.Click
        Try
            Me.Hide()
            frmPrestadores.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnPacientes_Click(sender As Object, e As EventArgs) Handles btnPacientes.Click
        Try
            Me.Hide()
            frmPacientes.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnModulo_Click(sender As Object, e As EventArgs) Handles btnModulo.Click
        Try
            Me.Hide()
            frmModulo.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnSubMod_Click(sender As Object, e As EventArgs) Handles btnSubMod.Click
        Try
            Me.Hide()
            frmSubMod.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnPrestacion_Click(sender As Object, e As EventArgs)
        Try
            Me.Hide()
            frmPrestacion.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnFeriados_Click(sender As Object, e As EventArgs) Handles btnFeriados.Click
        Try
            Me.Hide()
            FrmFeriados.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        Try
            Me.Hide()
            frmUsuarios.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
    End Sub
    Private Sub btnZonas_Click(sender As Object, e As EventArgs) Handles btnZonas.Click
        Try
            Me.Hide()
            frmZonas.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            Me.Show()
        End Try
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

    Private Sub UbicacionDeCopiasDeSeguridadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UbicacionDeCopiasDeSeguridadToolStripMenuItem.Click
        Try
            ut.setBackupPath()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub CopiarBaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarBaseDeDatosToolStripMenuItem.Click
        Try
            If ut.mensaje("Desea crear una copiar de su base de datos?" & vbCrLf & "En el paso siguiente debera elegir una carpeta donde guardar la copia", utils.mensajes.preg) = MsgBoxResult.Yes Then
                ut.copiarDB()
            End If

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub RestaurarBaseDeDatosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaurarBaseDeDatosToolStripMenuItem.Click
        Try
            If ut.mensaje("Se reemplazara la base de datos con una version anterior?" & vbCrLf & "En el paso siguiente debera elegir un archivo de base de datos" & vbCrLf & "Desea continuar?", utils.mensajes.preg) = MsgBoxResult.Yes Then
                ut.restaurarDB()
            End If

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub
End Class