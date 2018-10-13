Imports System.DateTime

Public Class frmPracticas
    Dim pac As Paciente
    Dim med As Prestador
    Dim prest As Prestacion
    Dim index As Integer
    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PRESTADORES' Puede moverla o quitarla según sea necesario.
        Me.PRESTADORESTableAdapter.Fill(Me.HomeCareDataSet.PRESTADORES)
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.MODULO_SUBMODULO' Puede moverla o quitarla según sea necesario.
        Me.MODULO_SUBMODULOTableAdapter.Fill(Me.HomeCareDataSet.MODULO_SUBMODULO)
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PACIENTES' Puede moverla o quitarla según sea necesario.
        Me.PACIENTESTableAdapter.Fill(Me.HomeCareDataSet.PACIENTES)

        Try


            cbMedico.SelectedIndex = -1
            CBPrestacion.SelectedIndex = -1
            cbPaciente.SelectedIndex = -1
            statusBar("CARGA INICIAL", False)

            DTFecha.CustomFormat = " MMMM - yyyy"
            cargarGrilla()

            pac = New Paciente()
            prest = New Prestacion()
            med = New Prestador()

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try

    End Sub

    Private Sub CBPrestacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPrestacion.SelectedIndexChanged
        If CBPrestacion.SelectedIndex <> -1 Then
            Try
                prest.codigo = CBPrestacion.SelectedValue
                statusBar("PRESTACION CARGADA", False)
            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectedIndexChanged

        If cbMedico.SelectedIndex <> -1 Then
            Try
                med.cuit = cbMedico.SelectedValue
                txtMat.Text = med.cuit
                txtPrestador.Text = med.especialidad
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
                pac.afiliado = cbPaciente.SelectedValue
                txtAfiliado.Text = pac.afiliado
                txtBeneficio.Text = pac.obraSocial
                statusBar("PACIENTE CARGADO", False)

            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(pac) Then
                statusBar("SELECCIONE UN PACIENTE", True)

            ElseIf IsNothing(med) Then
                statusBar("SELECCIONE UN MEDICO", True)

            ElseIf IsNothing(prest) Then
                statusBar("SELECCIONE UNA PRESTACION", True)

            Else
                ' Dim visita = New Visita(med, pac, prest, DTFecha.Value)
                'Visita.insertar()
                'Me.VISITASTableAdapter.Fill(Me.HomeCareDataSet.VISITAS)
                Dim practicas = New List(Of Practica)

                For Each r As DataGridViewRow In dgFechas.Rows
                    Dim cant As Integer
                    Dim dia As Integer

                    If IsDBNull(r.Cells("HORAS").Value) Then
                        Continue For
                    Else
                        cant = r.Cells("HORAS").Value
                        dia = r.Cells("DIA").Value

                        Dim fec = New Date(DTFecha.Value.Year.ToString, DTFecha.Value.Month.ToString, dia)
                        'Dim visita = New Practica(med, pac, prest, fec)
                        'practicas.Add(visita)
                    End If
                Next
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


    End Sub

    Private Sub btnEliminarVisita_Click(sender As Object, e As EventArgs)
        Dim index As Integer
        Dim r As DataGridViewRow
        Dim idVisita As Integer
        Dim visita As Practica

        If dgFechas.SelectedRows.Count = 0 Then
            statusBar("SELECCIONE UNA VISITA EN LA GRILLA", True)
        Else
            If MsgBox("DESEA ELIMINAR ESTA VISITA?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                r = dgFechas.Rows(index)
                idVisita = r.Cells(0).Value
                visita = New Practica()
                visita.eliminar(idVisita)
                'Me.VISITASTableAdapter.Fill(Me.HomeCareDataSet.VISITAS)
            End If
        End If

    End Sub

    Private Sub dgVisitas_SelectionChanged(sender As Object, e As EventArgs) Handles dgFechas.SelectionChanged

    End Sub

    Private Sub dgVisitas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFechas.CellClick
        index = e.RowIndex


    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub DTFecha_ValueChanged(sender As Object, e As EventArgs) Handles DTFecha.ValueChanged
        cargarGrilla()
    End Sub

    Public Sub cargarGrilla()
        Dim month = DTFecha.Value.Month
        Dim year = DTFecha.Value.Year
        Dim days = DaysInMonth(year, month)
        Dim dt As New DataTable()

        dgFechas.DataSource = Nothing

        dt.Columns.Add("DIA")
        dt.Columns.Add("HORAS")

        For i = 0 To days - 1
            Dim r = dt.NewRow
            r("DIA") = i + 1
            dt.Rows.Add(r)
        Next

        dt.Columns("DIA").ReadOnly = True
        dgFechas.DataSource = dt

    End Sub
End Class
