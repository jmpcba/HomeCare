Public Class frmVisitas
    Dim pac As Paciente
    Dim med As Medico
    Dim prest As Prestacion
    Dim index As Integer
    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.VISITAS' Puede moverla o quitarla según sea necesario.
            Me.VISITASTableAdapter.Fill(Me.HomeCareDataSet.VISITAS)
            'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PRESTACIONES' Puede moverla o quitarla según sea necesario.
            Me.PRESTACIONESTableAdapter.Fill(Me.HomeCareDataSet.PRESTACIONES)
            'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.MEDICOS' Puede moverla o quitarla según sea necesario.
            Me.MEDICOSTableAdapter.Fill(Me.HomeCareDataSet.MEDICOS)
            'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PACIENTES' Puede moverla o quitarla según sea necesario.
            Me.PACIENTESTableAdapter.Fill(Me.HomeCareDataSet.PACIENTES)

            cbMedico.SelectedIndex = -1
            CBPrestacion.SelectedIndex = -1
            cbPaciente.SelectedIndex = -1
            statusBar("CARGA INICIAL", False)
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try

    End Sub

    Private Sub CBPrestacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPrestacion.SelectedIndexChanged
        If CBPrestacion.SelectedIndex <> -1 Then
            Try
                prest = New Prestacion(CBPrestacion.SelectedValue)
                statusBar("PRESTACION CARGADA", False)
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
                statusBar("MEDICO CARGADO", False)
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
                statusBar("PACIENTE CARGADO", False)
            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If IsNothing(pac) Then
                statusBar("SELECCIONE UN PACIENTE", True)

            ElseIf IsNothing(med) Then
                statusBar("SELECCIONE UN MEDICO", True)

            ElseIf IsNothing(prest) Then
                statusBar("SELECCIONE UNA PRESTACION", True)

            Else
                Dim visita = New Visita(med, pac, prest, DTFecha.Value)
                visita.insertar()
                Me.VISITASTableAdapter.Fill(Me.HomeCareDataSet.VISITAS)

            End If
        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try
    End Sub
    Public Sub statusBar(_msg As String, _error As Boolean)

        tsLbl.Text = _msg
        If _error Then
            tsLbl.ForeColor = Color.Red
        Else
            tsLbl.ForeColor = Color.Black
        End If
    End Sub

    Private Sub dgVisitas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        index = e.RowIndex

        If dgVisitas.SelectedRows.Count = 0 Then
            btnEliminarVisita.Enabled = False
        Else
            btnEliminarVisita.Enabled = True
        End If
    End Sub

    Private Sub btnEliminarVisita_Click(sender As Object, e As EventArgs) Handles btnEliminarVisita.Click
        Dim index As Integer
        Dim r As DataGridViewRow
        Dim idVisita As Integer
        Dim visita As Visita

        If dgVisitas.SelectedRows.Count = 0 Then
            statusBar("SELECCIONE UNA VISITA EN LA GRILLA", True)
        Else
            If MsgBox("DESEA ELIMINAR ESTA VISITA?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                r = dgVisitas.Rows(index)
                idVisita = r.Cells(0).Value
                visita = New Visita()
                visita.eliminar(idVisita)
                Me.VISITASTableAdapter.Fill(Me.HomeCareDataSet.VISITAS)
            End If
        End If

    End Sub

    Private Sub dgVisitas_SelectionChanged(sender As Object, e As EventArgs) Handles dgVisitas.SelectionChanged

    End Sub

    Private Sub dgVisitas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVisitas.CellClick
        index = e.RowIndex

        If dgVisitas.SelectedRows.Count = 0 Then
            btnEliminarVisita.Enabled = False
        Else
            btnEliminarVisita.Enabled = True
        End If
    End Sub
End Class
