Public Class visitas
    Dim pac As Paciente
    Dim med As Medico
    Dim prest As Prestacion
    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pac = New Paciente(29188989, "Juan Manuel Palacios", 0)
        txtPaciente.Text = pac.nombre
    End Sub

    Private Sub CBPrestacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPrestacion.SelectedIndexChanged

    End Sub

    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectedIndexChanged
        med = New Medico(123, cbMedico.SelectedValue, "prestador")
        txtMat.Text = med.matricula
        txtPrestador.Text = med.prestador
    End Sub
End Class
