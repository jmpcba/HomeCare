Public Class frmVisitas
    Dim pac As Paciente
    Dim med As Medico
    Dim prest As Prestacion
    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PRESTACIONES' Puede moverla o quitarla según sea necesario.
            Me.PRESTACIONESTableAdapter.Fill(Me.HomeCareDataSet.PRESTACIONES)
            'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.MEDICOS' Puede moverla o quitarla según sea necesario.
            Me.MEDICOSTableAdapter.Fill(Me.HomeCareDataSet.MEDICOS)
            'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PACIENTES' Puede moverla o quitarla según sea necesario.
            Me.PACIENTESTableAdapter.Fill(Me.HomeCareDataSet.PACIENTES)

            cbMedico.SelectedIndex = -1
            CBPrestacion.SelectedIndex = -1
            cbPaciente.SelectedIndex = -1
            tsLbl.Text = "CARGA INICIAL"
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try

    End Sub

    Private Sub CBPrestacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPrestacion.SelectedIndexChanged
        If CBPrestacion.SelectedIndex <> -1 Then
            Try
                prest = New Prestacion(CBPrestacion.SelectedValue)
                tsLbl.Text = "PRESTACION CARGADA"
            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectedIndexChanged

        If cbMedico.SelectedIndex <> -1 Then
            Try
                med = New Medico(cbMedico.SelectedValue)
                txtMat.Text = med.matricula
                txtPrestador.Text = med.prestador
                tsLbl.Text = "MEDICO CARGADO"
            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cbPaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaciente.SelectedIndexChanged
        If cbPaciente.SelectedIndex <> -1 Then
            Try
                pac = New Paciente(cbPaciente.SelectedValue)
                txtDni.Text = pac.DNI
                txtBeneficio.Text = pac.beneficio
                tsLbl.Text = "PACIENTE CARGADO"
            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
    End Sub
End Class
