Imports System.DateTime
Imports System.Configuration
Imports System.Collections.Specialized

Public Class frmPracticas
    Dim pac As New Paciente
    Dim med As New Prestador
    Dim modu As New Modulo
    Dim subModu As New subModulo
    Dim index As Integer
    Dim edicion As Boolean = False
    Dim sel As Boolean = False
    Dim cellVal
    Dim selectedRows As DataGridViewSelectedRowCollection
    Dim ut As utils
    Dim carga As Boolean
    Dim pc As PracticaControl

    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pc = New PracticaControl(DTFecha.Value.Year)
        ut = New utils
        Me.WindowState = FormWindowState.Maximized
        carga = True
        Try
            dgFechas.Columns.Clear()
            DTFecha.Value = DateTime.Today.AddMonths(-1)
            DTFecha.CustomFormat = "MMMM - yyyy"
            lblMes.Text = MonthName(DTFecha.Value.Month).ToUpper

            pac.llenarcombo(cbPaciente)
            med.llenarcombo(cbMedico)
            modu.llenarcombo(cbModulo)
            subModu.llenarcombo(cbSubModulo)

            txtAfiliado.Text = ""
            txtBeneficio.Text = ""
            txtEspecialidad.Text = ""
            txtLocalidadPrest.Text = ""
            txtMat.Text = ""
            txtObservacionPac.Text = ""
            txtObservacionPre.Text = ""
            lblHoras.Text = ""
            lblMonto.Text = ""
            lblPaciente.Text = ""
            lblMed.Text = ""
            cargarGrilla()

            dgFechas.AutoResizeColumns()
            dgFechas.AutoResizeRows()

            PracticasPacienteToolStripMenuItem.Enabled = False
            PracticasPrestadorToolStripMenuItem.Enabled = False

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            carga = False
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cbPaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaciente.SelectedIndexChanged
        If Not carga Then
            If cbPaciente.SelectedIndex <> -1 Then
                Try
                    pac.id = cbPaciente.SelectedValue
                    lblPaciente.Text = String.Format("{0} {1}", pac.apellido, pac.nombre)
                    txtAfiliado.Text = pac.afiliado
                    txtBeneficio.Text = pac.obra_social
                    txtLocalidadPac.Text = pac.localidad
                    txtObservacionPac.Text = pac.observacion
                    cbModulo.SelectedValue = pac.modulo
                    cbSubModulo.SelectedValue = pac.sub_modulo
                    PracticasPacienteToolStripMenuItem.Enabled = True

                Catch ex As Exception
                    ut.mensaje(ex.Message, utils.mensajes.err)
                End Try
            Else
                PracticasPacienteToolStripMenuItem.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim err = False
        Dim carga = False
        Dim practicas As New List(Of Practica)

        ut = New utils

        Try
            Cursor.Current = Cursors.WaitCursor
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
                    Dim obsPac = txtObservacionPac.Text
                    Dim obsPre = txtObservacionPre.Text
                    Dim obs = txtObservaciones.Text
                    'Dim gp = New GestorPracticas()

                    For Each r As DataGridViewRow In dgFechas.Rows

                        Dim horas As Integer
                        Dim horasLaV As Integer
                        Dim horasFer As Integer
                        Dim horasDif As Integer
                        Dim dia As Integer

                        If (IsDBNull(r.Cells("PRACTICAS-HS").Value) OrElse r.Cells("PRACTICAS-HS").Value = 0 OrElse r.Cells("PRACTICAS-HS").Value = "") And
                           (IsDBNull(r.Cells("DIFERENCIAL-HS").Value) OrElse r.Cells("DIFERENCIAL-HS").Value = 0 OrElse r.Cells("DIFERENCIAL-HS").Value = "") Then
                            r.DefaultCellStyle.BackColor = Color.LightGray
                            Continue For
                        Else
                            dia = r.Cells("DIA_H").Value

                            Dim fec = New Date(DTFecha.Value.Year.ToString, DTFecha.Value.Month.ToString, dia)

                            If IsDBNull(r.Cells("DIFERENCIAL-HS").Value) Then
                                horasDif = 0
                            Else
                                horasDif = r.Cells("DIFERENCIAL-HS").Value
                            End If

                            If IsDBNull(r.Cells("PRACTICAS-HS").Value) Then
                                horas = 0
                            Else
                                horas = r.Cells("PRACTICAS-HS").Value
                            End If

                            pc.addPractica(med, pac, modu, subModu, horas, horasDif, fec, obs, obsPac, obsPre)
                            r.DefaultCellStyle.BackColor = Color.LightGreen
                            r.Cells("RESULTADO").Value = "Cargado"
                            carga = True
                        End If
                    Next

                    Dim re = pc.InsertarPracticas()

                    If carga Then
                        'gp.guardar()
                    End If

                    If re.Rows.Count > 0 Then
                        err = True
                        For Each r In re.Rows
                            'TODO como gestionar los errores
                        Next
                    End If

                    If err Then
                        ut.mensaje("Ocurrieron Errores durante la carga", utils.mensajes.err)
                    ElseIf carga Then
                        ut.mensaje("Datos Cargados exitosamente", utils.mensajes.info)
                    Else
                        ut.mensaje("No se cargaron horas para ningun dia", utils.mensajes.err)
                    End If

                    'ACTUALIZAR PACIENTE PRESTADOR
                    If cbModulo.SelectedValue <> pac.modulo Then
                        pac.modulo = cbModulo.SelectedValue
                    End If

                    If cbSubModulo.SelectedValue <> pac.sub_modulo Then
                        pac.sub_modulo = cbSubModulo.SelectedValue
                    End If

                    If txtObservacionPac.Text <> pac.observacion Then
                        pac.observacion = txtObservacionPac.Text
                    End If

                    If txtObservacionPre.Text.Trim <> med.comentario Then
                        med.comentario = txtObservacionPre.Text.Trim
                    End If

                    Try
                        If med.getModificado Then
                            med.actualizar()
                            med.refrescar()
                        End If

                        If pac.getModificado Then
                            pac.actualizar()
                            pac.refrescar()
                        End If
                    Catch ex As Exception
                        Dim msg = "OCURRIO EL SIGUIENTE ERROR ACTUALIZANDO LOS DATOS DEL PACIENTE/PRESTADOR" & vbCrLf & "SE CONTINUARA CON LA CARGA DE PRACTICAS" & vbCrLf & ex.Message
                        ut.mensaje(msg, utils.mensajes.err)
                    End Try
                End If
            End If

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally

            btnGuardar.Enabled = True
            Cursor.Current = Cursors.Default

            If carga Then
                iniciarControles()
                With dgFechas
                    .Columns("RESULTADO").ReadOnly = True
                    .AutoResizeColumns()
                    .AutoResizeRows()
                End With
            End If
        End Try
    End Sub
    Private Sub btnSelec_Click(sender As Object, e As EventArgs) Handles btnSelec.Click
        sel = Not sel

        If sel Then
            btnSelec.Text = "NINGUNO"
        Else
            btnSelec.Text = "TODOS"
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
        dt.Columns.Add("DIFERENCIAL-HS")
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
            .Columns("RESULTADO").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            .Columns("PRACTICAS-HS").DefaultCellStyle.Font = New Font("arial", 8)
            .Columns("DIFERENCIAL-HS").DefaultCellStyle.Font = New Font("arial", 8)

            .Columns("DIA").ReadOnly = True
            .Columns("RESULTADO").ReadOnly = True

            .Columns.Insert(0, chkclm)

            .AutoResizeColumns()
            .AutoResizeRows()

            .Columns("DIA_H").Visible = False
        End With

        For Each r As DataGridViewRow In dgFechas.Rows
            Dim fecha = New Date(DTFecha.Value.Year, DTFecha.Value.Month, r.Cells("DIA_H").Value)
            If pc.findeFeriado(fecha) Then
                r.DefaultCellStyle.ForeColor = Color.Red
            End If
        Next

    End Sub

    Private Sub dgFechas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgFechas.CellEndEdit
        calcularTotales(e)

    End Sub

    Private Sub calcularTotales(e As DataGridViewCellEventArgs)
        Dim val = dgFechas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
        Dim horas As Integer = 0
        Dim monto As Decimal = 0

        If IsNothing(med.CUIT) Then
            ut.mensaje("Seleccione un Prestador", utils.mensajes.err)
            dgFechas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
            cbMedico.Focus()
        ElseIf IsNothing(modu.codigo) Then
            ut.mensaje("Seleccione un Modulo", utils.mensajes.err)
            dgFechas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
            cbModulo.Focus()
        Else
            If Not IsDBNull(val) Then
                edicion = True
                If Not IsNumeric(val) And e.ColumnIndex <> 0 Then
                    ut.mensaje("Debe ingresar un valor numerico", utils.mensajes.err)
                    dgFechas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                ElseIf val > 24 Then
                    ut.mensaje("No puede ingresar mas de 24hs en un dia", utils.mensajes.err)
                    dgFechas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Nothing
                End If
            End If

            If Not IsDBNull(dgFechas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                If dgFechas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value <> 0 Then
                    If e.ColumnIndex = 3 Then
                        dgFechas.Rows(e.RowIndex).Cells(4).Value = Nothing
                    ElseIf e.ColumnIndex = 4 Then
                        dgFechas.Rows(e.RowIndex).Cells(3).Value = Nothing
                    End If
                End If
            End If

            'SI SE MODIFICO LA COLUMNA HORAS (ES 3 PORQUE hay una columna oculta)
            If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then

                For Each r As DataGridViewRow In dgFechas.Rows

                    If r.Cells(0).Value = True Then
                        r.Cells(e.ColumnIndex).Value = val
                        r.Cells(0).Value = False

                        If e.ColumnIndex = 3 Then
                            dgFechas.Rows(r.Index).Cells(4).Value = Nothing
                        ElseIf e.ColumnIndex = 4 Then
                            dgFechas.Rows(r.Index).Cells(3).Value = Nothing
                        End If
                    End If


                    If (IsDBNull(r.Cells(3).Value) OrElse r.Cells(3).Value = 0 OrElse r.Cells(3).Value = "") And
                            (IsDBNull(r.Cells(4).Value) OrElse r.Cells(4).Value = 0 OrElse r.Cells(4).Value = "") Then
                        Continue For
                    Else
                        Dim fecha = New Date(DTFecha.Value.Year, DTFecha.Value.Month, r.Cells("DIA_H").Value)
                        Dim hs As Decimal
                        If Not IsDBNull(r.Cells(4).Value) Then
                            If med.monto_diferencial = 0 Then
                                ut.mensaje("Este prestador no tiene cargado un monto diferencial", utils.mensajes.err)
                                hs = 0
                                r.Cells(e.ColumnIndex).Value = Nothing
                            Else
                                monto += med.monto_diferencial * r.Cells(4).Value
                                hs = r.Cells(4).Value
                            End If
                        ElseIf Not IsDBNull(r.Cells(3).Value) Then
                            hs = r.Cells(3).Value
                            'If ut.esFindeOFeriado(fecha) Then
                            '    If med.monto_feriado = 0 Then
                            '        monto += med.monto_semana * r.Cells(3).Value
                            '    Else
                            '        monto += med.monto_feriado * r.Cells(3).Value
                            '    End If
                            'Else
                            '    monto += med.monto_semana * r.Cells(3).Value
                            'End If
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
            lblMonto.ForeColor = Color.Black
            lblHoras.ForeColor = Color.Black

            For Each r As DataGridViewRow In dgFechas.Rows
                r.Cells(4).Value = ""
            Next
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
        txtLocalidadPrest.Text = ""
        txtMat.Text = ""
        txtServicio.Text = ""
        txtObservacionPac.Text = ""
        txtObservacionPre.Text = ""
        lblHoras.Text = ""
        lblMonto.Text = ""
        txtLocalidadPac.Text = ""
        txtOS.Text = ""
        lblMed.Text = ""
        lblPaciente.Text = ""
        cargarGrilla()
        lblMes.Text = MonthName(DTFecha.Value.Month)
        edicion = False
        lblHoras.Text = 0
        lblMonto.Text = 0

        dgFechas.AutoResizeColumns()
        dgFechas.AutoResizeRows()

    End Sub

    Private Sub frmPracticas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub

    Private Sub cbMedico_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbMedico.SelectedIndexChanged
        If Not carga Then
            If cbMedico.SelectedIndex <> -1 Then

                med.id = cbMedico.SelectedValue.ToString
                Try
                    lblMed.Text = String.Format("{0} {1}", med.apellido, med.nombre)
                    txtMat.Text = med.CUIT
                    txtLocalidadPrest.Text = med.localidad
                    txtEspecialidad.Text = med.especialidad
                    txtServicio.Text = med.servicio
                    lblPrecioFeriado.Text = med.monto_feriado.ToString("F")
                    lblPrecioLaV.Text = med.monto_semana.ToString("F")
                    txtOS.Text = med.servicio
                    lblPrecioDif.Text = med.monto_diferencial.ToString("F")
                    PracticasPrestadorToolStripMenuItem.Enabled = True
                    txtObservacionPre.Text = med.comentario
                Catch ex As Exception
                    ut.mensaje(ex.Message, utils.mensajes.err)
                End Try
            Else
                PracticasPrestadorToolStripMenuItem.Enabled = False
            End If
        End If
    End Sub

    Private Sub PracticasPacienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PracticasPacienteToolStripMenuItem.Click
        Dim fecha = DTFecha.Value
        Dim frm As New frmPracticaPacienteDetalle(pac.afiliado, fecha)
        frm.ShowDialog()
    End Sub

    Private Sub PracticasPrestadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PracticasPrestadorToolStripMenuItem.Click
        Dim fecha = DTFecha.Value
        Dim frm As New frmLiquidacionDetalle(med.id, fecha)
        frm.ShowDialog()
    End Sub

    Private Sub cbModulo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbModulo.SelectedIndexChanged
        If Not carga Then
            If cbModulo.SelectedIndex <> -1 Then
                modu.codigo = cbModulo.SelectedValue
            End If
        End If
    End Sub

    Private Sub cbPaciente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbPaciente.KeyPress
        If Not carga Then
            Dim c = e.KeyChar
            If Char.IsLetterOrDigit(c) Then
                If cbPaciente.DroppedDown Then
                    cbPaciente.DroppedDown = False
                End If
            End If
        End If
    End Sub

    Private Sub cbMedico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbMedico.KeyPress
        If Not carga Then
            Dim c = e.KeyChar
            If Char.IsLetterOrDigit(c) Then
                If cbMedico.DroppedDown Then
                    cbMedico.DroppedDown = False
                End If
            End If
        End If
    End Sub
End Class
