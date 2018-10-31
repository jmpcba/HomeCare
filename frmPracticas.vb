﻿Imports System.DateTime
Imports System.Configuration
Imports System.Collections.Specialized

Public Class frmPracticas
    Dim pac As Paciente
    Dim med As Prestador
    Dim prest As Prestacion
    Dim modu As Modulo
    Dim index As Integer
    Dim edicion As Boolean = False
    Dim cellVal
    Dim selectedRows As DataGridViewSelectedRowCollection
    Dim ut As utils
    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.SUBMODULO' Puede moverla o quitarla según sea necesario.
        Me.SUBMODULOTableAdapter.Fill(Me.HomeCareDataSet.SUBMODULO)
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.MODULO' Puede moverla o quitarla según sea necesario.
        Me.MODULOTableAdapter.Fill(Me.HomeCareDataSet.MODULO)
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PRESTADORES' Puede moverla o quitarla según sea necesario.
        Me.PRESTADORESTableAdapter.Fill(Me.HomeCareDataSet.PRESTADORES)
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PACIENTES' Puede moverla o quitarla según sea necesario.
        Me.PACIENTESTableAdapter.Fill(Me.HomeCareDataSet.PACIENTES)

        Me.PRESTACIONESTableAdapter.Fill(Me.HomeCareDataSet.PRESTACIONES)

        Me.WindowState = FormWindowState.Maximized

        Try


            cbMedico.SelectedIndex = -1
            CBPrestacion.SelectedIndex = -1
            cbPaciente.SelectedIndex = -1
            cbModulo.SelectedIndex = -1
            cbSubModulo.SelectedIndex = -1
            CBPrestacion.SelectedIndex = -1

            statusBar("CARGA INICIAL", False)

            DTFecha.CustomFormat = " MMMM - yyyy"
            lblMes.Text = MonthName(DTFecha.Value.Month).ToUpper

            ut = New utils
            pac = New Paciente()
            prest = New Prestacion()
            med = New Prestador()
            modu = New Modulo()

            cargarGrilla()

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

            med.cuit = cbMedico.SelectedValue.ToString
            Try

                txtMat.Text = med.cuit
                txtLocalidad.Text = med.especialidad
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
        Dim err = False
        Dim carga = False
        Try
            dgFechas.Columns("RESULTADO CARGA").ReadOnly = False

            If cbPaciente.SelectedIndex = -1 Then
                statusBar("SELECCIONE UN PACIENTE", True)
                cbPaciente.Focus()

            ElseIf cbMedico.SelectedIndex = -1 Then
                statusBar("SELECCIONE UN PRESTADOR", True)
                cbMedico.Focus()

            ElseIf cbModulo.SelectedIndex = -1 Then
                statusBar("SELECCIONE UN MODULO", True)
                cbModulo.Focus()

            ElseIf cbSubModulo.SelectedIndex = -1 Then
                statusBar("SELECCIONE UN SUB-MODULO", True)
                cbSubModulo.Focus()

            ElseIf CBPrestacion.SelectedIndex = -1 Then
                statusBar("SELECCIONE UNA PRESTACION", True)
                CBPrestacion.Focus()
            Else

                Dim practicas = New List(Of Practica)
                Dim obs = txtObservaciones.Text
                For Each r As DataGridViewRow In dgFechas.Rows
                    Dim horas As Integer
                    Dim dia As Integer

                    If IsDBNull(r.Cells("HORAS").Value) OrElse r.Cells("HORAS").Value = 0 OrElse r.Cells("HORAS").Value = "" Then
                        r.DefaultCellStyle.BackColor = Color.LightGray
                        Continue For
                    Else
                        horas = r.Cells("HORAS").Value
                        dia = r.Cells("DIA_H").Value

                        Dim fec = New Date(DTFecha.Value.Year.ToString, DTFecha.Value.Month.ToString, dia)
                        Dim practica = New Practica(med, pac, cbModulo.SelectedValue, cbSubModulo.SelectedValue, prest, fec, horas, obs)

                        Try
                            practica.insertar()
                            r.DefaultCellStyle.BackColor = Color.LightGreen
                            r.Cells("RESULTADO CARGA").Value = "Cargado"
                            carga = True

                        Catch ex As Exception
                            err = True
                            r.DefaultCellStyle.BackColor = Color.Red
                            r.DefaultCellStyle.ForeColor = Color.Black
                            If ex.Message.Contains("duplicate values in the index") Then
                                r.Cells("RESULTADO CARGA").Value = "Ya existe una practica igual para este dia"
                            Else
                                r.Cells("RESULTADO CARGA").Value = ex.Message
                            End If
                        End Try
                    End If
                Next
                If err Then
                    MessageBox.Show("Ocurrieron Errores durante la carga")
                ElseIf carga Then
                    MessageBox.Show("Datos Cargados exitosamente")
                Else
                    MessageBox.Show("No se cargaron horas para ningun dia")
                End If
                statusBar("TERMINADO", False)
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        Finally
            dgFechas.Columns("RESULTADO CARGA").ReadOnly = True

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

    Private Sub DTFecha_ValueChanged(sender As Object, e As EventArgs) Handles DTFecha.ValueChanged
        If edicion Then
            If MsgBox("Se perderan los datos que ya cargo" & vbCrLf & "Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cargarGrilla()
                lblMes.Text = MonthName(DTFecha.Value.Month)
                edicion = False
                lblHoras.Text = 0
                lblMonto.Text = 0
            Else
                DTFecha.Value = Today
            End If
        Else
            lblMes.Text = MonthName(DTFecha.Value.Month)
            cargarGrilla()
        End If
    End Sub

    Public Sub cargarGrilla()
        Dim month = DTFecha.Value.Month
        Dim year = DTFecha.Value.Year
        Dim days = DaysInMonth(year, month)
        Dim dt As New DataTable()

        dgFechas.DataSource = Nothing

        dt.Columns.Add("DIA")
        dt.Columns.Add("DIA_H")
        dt.Columns.Add("HORAS")
        dt.Columns.Add("RESULTADO CARGA")

        For i = 0 To days - 1
            Dim r = dt.NewRow
            Dim fecha = New Date(year, month, i + 1)
            r("DIA") = fecha.ToString("dddd - dd")
            r("DIA_H") = i + 1
            dt.Rows.Add(r)
        Next

        Dim chkclm As New DataGridViewCheckBoxColumn

        With chkclm
            .HeaderText = ""
            .Name = ""
        End With

        With dgFechas
            .Columns.Clear()
            .DataSource = dt
            .Columns("DIA").DefaultCellStyle.BackColor = Color.LightGray
            .Columns("DIA").DefaultCellStyle.Font = New Font("arial", 8)

            .Columns("RESULTADO CARGA").DefaultCellStyle.BackColor = Color.LightGray
            .Columns("RESULTADO CARGA").DefaultCellStyle.Font = New Font("arial", 8)

            .Columns("HORAS").DefaultCellStyle.Font = New Font("arial", 8)

            .Columns("DIA").ReadOnly = True
            .Columns("RESULTADO CARGA").ReadOnly = True

            .Columns.Insert(0, chkclm)

            .AutoResizeColumns()
            .AutoResizeRows()

            .Columns("DIA_H").Visible = False

        End With

        For Each r As DataGridViewRow In dgFechas.Rows
            Dim fecha = New Date(DTFecha.Value.Year, DTFecha.Value.Month, r.Cells("DIA_H").Value)
            If ut.esFindeOFeriado(fecha) Then
                r.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
    End Sub

    Private Sub dgFechas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgFechas.CellEndEdit
        Dim val = dgFechas.Rows(e.RowIndex).Cells("HORAS").Value
        Dim horas As Integer = 0
        Dim monto As Decimal = 0

        If IsDBNull(val) Then
            Exit Sub
        End If

        If IsNothing(med.cuit) Then
            MessageBox.Show("Seleccione un Prestador")
            dgFechas.Rows(e.RowIndex).Cells("HORAS").Value = Nothing
        ElseIf IsNothing(modu.codigo) Then
            MessageBox.Show("Seleccione un Modulo")
            dgFechas.Rows(e.RowIndex).Cells("HORAS").Value = Nothing
        Else
            If Not IsDBNull(val) Then
                edicion = True
                If Not IsNumeric(val) Then
                    MessageBox.Show("Debe ingresar un valor numerico")
                    dgFechas.Rows(e.RowIndex).Cells("HORAS").Value = Nothing
                ElseIf val > 24 Then
                    MessageBox.Show("No puede ingresar mas de 24hs en un dia")
                    dgFechas.Rows(e.RowIndex).Cells("HORAS").Value = Nothing
                End If
            End If


            For Each r As DataGridViewRow In dgFechas.Rows

                If r.Cells(0).Value = True Then
                    r.Cells("HORAS").Value = val
                    r.Cells(0).Value = False
                End If

                If IsDBNull(r.Cells("HORAS").Value) OrElse r.Cells("HORAS").Value = 0 OrElse r.Cells("HORAS").Value = "" Then
                    Continue For
                Else
                    Dim fecha = New Date(DTFecha.Value.Year, DTFecha.Value.Month, r.Cells("DIA_H").Value)

                    If ut.esFindeOFeriado(fecha) Then
                        monto += med.montoFeriado * r.Cells("HORAS").Value
                    Else
                        monto += med.montoNormal * r.Cells("HORAS").Value
                    End If

                    horas += r.Cells("HORAS").Value
                End If
            Next

            lblHoras.Text = horas
            lblMonto.Text = monto

            If horas > modu.tope(med.especialidad) Then
                lblHoras.ForeColor = Color.Red
            Else
                lblHoras.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub btnLimpiarGrilla_Click(sender As Object, e As EventArgs) Handles btnLimpiarGrilla.Click
        If MsgBox("Se perderan los datos que ya cargo" & vbCrLf & "Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            cargarGrilla()
            lblMes.Text = MonthName(DTFecha.Value.Month)
            edicion = False
            lblHoras.Text = 0
            lblMonto.Text = 0
        End If
    End Sub

    Private Sub dgFechas_SelectionChanged(sender As Object, e As EventArgs) Handles dgFechas.SelectionChanged
        selectedRows = dgFechas.SelectedRows

        If dgFechas.SelectedRows.Count > 1 Then
            Dim valor = dgFechas.SelectedRows(0).Cells("horas").Value

            If Not IsDBNull(valor) Then
                For Each r As DataGridViewRow In dgFechas.SelectedRows
                    r.Cells("horas") = valor
                Next
            End If

        End If
    End Sub

    Private Sub cbModulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModulo.SelectedIndexChanged
        If cbModulo.SelectedIndex <> -1 Then
            modu.codigo = cbModulo.SelectedValue
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
