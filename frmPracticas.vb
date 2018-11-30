Imports System.DateTime
Imports System.Configuration
Imports System.Collections.Specialized

Public Class frmPracticas
    Dim pac As Paciente
    Dim med As Prestador
    ' Dim prest As Prestacion
    Dim modu As Modulo
    Dim subModu As subModulo
    Dim index As Integer
    Dim edicion As Boolean = False
    Dim sel As Boolean = False
    Dim cellVal
    Dim selectedRows As DataGridViewSelectedRowCollection
    Dim ut As utils
    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        Try
            dgFechas.Columns.Clear()
            DTFecha.CustomFormat = "MMMM - yyyy"
            lblMes.Text = MonthName(DTFecha.Value.Month).ToUpper

            ut = New utils
            pac = New Paciente()
            ' prest = New Prestacion()
            med = New Prestador()
            subModu = New subModulo
            modu = New Modulo()

            pac.llenarcombo(cbPaciente)
            med.llenarcombo(cbMedico)
            modu.llenarcombo(cbModulo)
            subModu.llenarcombo(cbSubModulo)
            ' prest.llenarcombo(CBPrestacion)

            txtAfiliado.Text = ""
            txtBeneficio.Text = ""
            txtEspecialidad.Text = ""
            txtLocalidad.Text = ""
            txtMat.Text = ""
            txtObservaciones.Text = ""
            lblHoras.Text = ""
            lblMonto.Text = ""
            cargarGrilla()

            dgFechas.AutoResizeColumns()
            dgFechas.AutoResizeRows()

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cbPaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaciente.SelectionChangeCommitted
        If cbPaciente.SelectedIndex <> -1 Then
            Try
                pac.afiliado = cbPaciente.SelectedValue
                txtAfiliado.Text = pac.afiliado
                txtBeneficio.Text = pac.obrasocial

            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            End Try
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim err = False
        Dim carga = False
        ut = New utils
        Try
            btnGuardar.Enabled = False
            dgFechas.Columns("RESULTADO").ReadOnly = False

            If cbPaciente.SelectedIndex = -1 Then
                ut.mensaje("SELECCIONE UN PACIENTE", utils.mensajes.err)
                cbPaciente.Focus()

            ElseIf cbMedico.SelectedIndex = -1 Then
                ut.mensaje("SELECCIONE UN PRESTADOR", utils.mensajes.err)
                cbMedico.Focus()

            ElseIf cbModulo.SelectedIndex = -1 Then
                ut.mensaje("SELECCIONE UN MODULO", utils.mensajes.err)
                cbModulo.Focus()

            ElseIf cbSubModulo.SelectedIndex = -1 Then
                ut.mensaje("SELECCIONE UN SUB-MODULO", utils.mensajes.err)
                cbSubModulo.Focus()
            Else

                If ut.validarLiquidacion(cbMedico.SelectedValue, DTFecha.Value) Then
                    Throw New Exception("LIQUIDACION CERRADA PARA ESTE PRESTADOR - MES")
                Else
                    Dim obs = txtObservaciones.Text
                    For Each r As DataGridViewRow In dgFechas.Rows
                        Dim horas As Integer
                        Dim dia As Integer

                        If IsDBNull(r.Cells("PRACTICAS-HS").Value) OrElse r.Cells("PRACTICAS-HS").Value = 0 OrElse r.Cells("PRACTICAS-HS").Value = "" Then
                            r.DefaultCellStyle.BackColor = Color.LightGray
                            Continue For
                        Else
                            horas = r.Cells("PRACTICAS-HS").Value
                            dia = r.Cells("DIA_H").Value

                            Dim fec = New Date(DTFecha.Value.Year.ToString, DTFecha.Value.Month.ToString, dia)
                            Dim practica = New Practica(med, pac, cbModulo.SelectedValue, cbSubModulo.SelectedValue, fec, horas, obs)

                            Try
                                practica.insertar()
                                r.DefaultCellStyle.BackColor = Color.LightGreen
                                r.Cells("RESULTADO").Value = "Cargado"
                                carga = True

                            Catch ex As Exception
                                err = True
                                r.DefaultCellStyle.BackColor = Color.Red
                                r.DefaultCellStyle.ForeColor = Color.Black
                                If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                                    r.Cells("RESULTADO").Value = "Ya existe una practica igual para este dia"
                                Else
                                    r.Cells("RESULTADO").Value = ex.Message
                                End If
                            End Try
                        End If
                    Next
                    If err Then
                        ut.mensaje("Ocurrieron Errores durante la carga", utils.mensajes.err)
                    ElseIf carga Then
                        ut.mensaje("Datos Cargados exitosamente", utils.mensajes.info)
                    Else
                        ut.mensaje("No se cargaron horas para ningun dia", utils.mensajes.err)
                    End If
                End If
            End If

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            btnGuardar.Enabled = True
            iniciarControles()
            With dgFechas
                .Columns("RESULTADO").ReadOnly = True
                .AutoResizeColumns()
                .AutoResizeRows()
            End With

        End Try
    End Sub
    Private Sub btnSelec_Click(sender As Object, e As EventArgs) Handles btnSelec.Click
        sel = Not sel

        If sel Then
            btnSelec.Text = "Des-sel"
        Else
            btnSelec.Text = "Todos"
        End If

        For Each r As DataGridViewRow In dgFechas.Rows
            r.Cells(0).Value = sel
        Next
    End Sub

    Private Sub DTFecha_ValueChanged(sender As Object, e As EventArgs) Handles DTFecha.ValueChanged
        If edicion Then
            If ut.mensaje("Se perderan los datos que ya cargo" & vbCrLf & "Desea continuar?", utils.mensajes.preg) = MsgBoxResult.Yes Then
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

        dt.Clear()
        dgFechas.DataSource = Nothing
        dgFechas.Refresh()

        dt.Columns.Add("DIA")
        dt.Columns.Add("DIA_H")
        dt.Columns.Add("PRACTICAS-HS")
        dt.Columns.Add("RESULTADO")

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

            .Columns("RESULTADO").DefaultCellStyle.BackColor = Color.LightGray
            .Columns("RESULTADO").DefaultCellStyle.Font = New Font("arial", 8)

            .Columns("PRACTICAS-HS").DefaultCellStyle.Font = New Font("arial", 8)

            .Columns("DIA").ReadOnly = True
            .Columns("RESULTADO").ReadOnly = True

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
        Dim val = dgFechas.Rows(e.RowIndex).Cells("PRACTICAS-HS").Value
        Dim horas As Integer = 0
        Dim monto As Decimal = 0

        If IsNothing(med.cuit) Then
            ut.mensaje("Seleccione un Prestador", utils.mensajes.err)
            dgFechas.Rows(e.RowIndex).Cells("PRACTICAS-HS").Value = Nothing
            cbMedico.Focus()
        ElseIf IsNothing(modu.codigo) Then
            ut.mensaje("Seleccione un Modulo", utils.mensajes.err)
            dgFechas.Rows(e.RowIndex).Cells("PRACTICAS-HS").Value = Nothing
            cbModulo.Focus()
        Else
            If Not IsDBNull(val) Then
                edicion = True
                If Not IsNumeric(val) Then
                    ut.mensaje("Debe ingresar un valor numerico", utils.mensajes.err)
                    dgFechas.Rows(e.RowIndex).Cells("PRACTICAS-HS").Value = Nothing
                ElseIf val > 24 Then
                    ut.mensaje("No puede ingresar mas de 24hs en un dia", utils.mensajes.err)
                    dgFechas.Rows(e.RowIndex).Cells("PRACTICAS-HS").Value = Nothing
                End If
            End If

            'SI SE MODIFICO LA COLUMNA HORAS (ES 3 PORQUE hay una columna oculta)
            If e.ColumnIndex = 3 Then
                For Each r As DataGridViewRow In dgFechas.Rows

                    If r.Cells(0).Value = True Then
                        r.Cells("PRACTICAS-HS").Value = val
                        r.Cells(0).Value = False
                    End If

                    If IsDBNull(r.Cells("PRACTICAS-HS").Value) OrElse r.Cells("PRACTICAS-HS").Value = 0 OrElse r.Cells("PRACTICAS-HS").Value = "" Then
                        Continue For
                    Else
                        Dim fecha = New Date(DTFecha.Value.Year, DTFecha.Value.Month, r.Cells("DIA_H").Value)
                        Dim hs = r.Cells("PRACTICAS-HS").Value
                        If ut.esFindeOFeriado(fecha) Then
                            If med.montoFeriado = 0 Then
                                ut.mensaje("Este prestador no trabaja fines de semana o feriados", utils.mensajes.err)
                                hs = 0
                                r.Cells("PRACTICAS-HS").Value = Nothing
                            Else
                                monto += med.montoFeriado * r.Cells("PRACTICAS-HS").Value
                            End If
                        Else
                            monto += med.montoNormal * r.Cells("PRACTICAS-HS").Value
                        End If
                        horas += hs
                    End If
                Next
            End If

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
        If ut.mensaje("Se perderan los datos que ya cargo" & vbCrLf & "Desea continuar?", utils.mensajes.preg) = MsgBoxResult.Yes Then
            cargarGrilla()
            lblMes.Text = MonthName(DTFecha.Value.Month)
            edicion = False
            lblHoras.Text = 0
            lblMonto.Text = 0
        End If
    End Sub
    Private Sub iniciarControles()

        dgFechas.Columns.Clear()
        DTFecha.CustomFormat = "MMMM - yyyy"
        lblMes.Text = MonthName(DTFecha.Value.Month).ToUpper
        cbModulo.SelectedIndex = -1
        cbSubModulo.SelectedIndex = -1
        cbMedico.SelectedIndex = -1
        cbPaciente.SelectedIndex = -1
        txtAfiliado.Text = ""
        txtBeneficio.Text = ""
        txtEspecialidad.Text = ""
        txtLocalidad.Text = ""
        txtMat.Text = ""
        txtObservaciones.Text = ""
        lblHoras.Text = ""
        lblMonto.Text = ""
        cargarGrilla()
        lblMes.Text = MonthName(DTFecha.Value.Month)
        edicion = False
        lblHoras.Text = 0
        lblMonto.Text = 0

        dgFechas.AutoResizeColumns()
        dgFechas.AutoResizeRows()

    End Sub

    Private Sub cbModulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModulo.SelectionChangeCommitted
        If cbModulo.SelectedIndex <> -1 Then
            modu.codigo = cbModulo.SelectedValue
        End If

    End Sub

    Private Sub txtLocalidad_TextChanged(sender As Object, e As EventArgs) Handles txtLocalidad.TextChanged

    End Sub

    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectionChangeCommitted
        If cbMedico.SelectedIndex <> -1 Then

            med.id = cbMedico.SelectedValue.ToString
            Try
                txtMat.Text = med.cuit
                txtLocalidad.Text = med.localidad
                txtEspecialidad.Text = med.especialidad
                txtServicio.Text = med.obraSocial
            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            End Try
        End If
    End Sub
End Class
