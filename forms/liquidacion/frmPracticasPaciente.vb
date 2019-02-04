Public Class frmPracticasPaciente
    Dim ut As New utils
    Dim dt As New DataTable

    Private Sub PracticasPacientevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtMes.Value = Today.AddMonths(-1)
        llenarGrilla()
    End Sub

    Public Sub llenarGrilla()
        Try
            Dim db As New DB()
            Dim mes = dtMes.Value

            dt = db.getLiquidacion(mes, DB.tiposLiquidacion.paciente)

            grPacientes.DataSource = dt
            grPacientes.ClearSelection()

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub grPacientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grPacientes.CellDoubleClick
        Dim r As DataGridViewRow
        If e.RowIndex <> -1 Then
            r = grPacientes.Rows(e.RowIndex)
            Dim afiliado = r.Cells("AFILIADO").Value
            Dim fecha = dtMes.Value
            Dim frm As New frmPracticaPacienteDetalle(afiliado, fecha, Me)
            frm.ShowDialog()
        End If
    End Sub

    Private Sub dtMes_ValueChanged(sender As Object, e As EventArgs) Handles dtMes.ValueChanged
        llenarGrilla()
    End Sub

    Private Sub frmPracticasPaciente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        dt.DefaultView.RowFilter = String.Format("[APELLIDO PACIENTE] LIKE '%{0}%'", txtFiltro.Text.Trim)
        grPacientes.Refresh()
    End Sub
End Class