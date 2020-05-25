Imports System.DateTime
Imports System.Configuration
Imports System.Collections.Specialized

Public Class frmPracticas
    Dim pac As Paciente
    Dim med As Prestador
    Dim modu As Modulo
    Dim subModu As subModulo
    Dim index As Integer
    Dim edicion As Boolean = False
    Dim sel As Boolean = False
    Dim cellVal
    Dim selectedRows As DataGridViewSelectedRowCollection
    Dim ut As utils
    Dim carga As Boolean
    Dim cpac As ControllerPaciente
    Dim cprest As ControllerPrestador
    Dim cp As ControllerPractica
    Dim cSubMod As ControllerSubModulo
    Dim cmod As ControllerModulo

    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ut = New utils
            cpac = New ControllerPaciente
            cprest = New ControllerPrestador
            cp = New ControllerPractica(DTFecha.Value.Year)
            cSubMod = New ControllerSubModulo()
            cmod = New ControllerModulo()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try

        Me.WindowState = FormWindowState.Maximized
        carga = True
        Try
            dgFechas.Columns.Clear()
            DTFecha.Value = DateTime.Today.AddMonths(-1)
            DTFecha.CustomFormat = "MMMM - yyyy"
            lblMes.Text = MonthName(DTFecha.Value.Month).ToUpper

            cpac.llenarcombo(cbPaciente)
            cprest.llenarcombo(cbMedico)
            cmod.llenarcombo(cbModulo)
            cSubMod.llenarcombo(cbSubModulo)

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
                    pac = cpac.paciente(cbPaciente.SelectedValue)
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
        Dim oldCI As Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
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

                    For Each r As DataGridViewRow In dgFechas.Rows

                        Dim horas As Integer
                        Dim horasDif As Integer
                        Dim dia As Integer

                        If (IsDBNull(r.Cells("PRACTICAS-HS").Value) OrElse r.Cells("PRACTICAS-HS").Value = 0 OrElse r.Cells("PRACTICAS-HS").Value = "") And
                           (IsDBNull(r.Cells("DIFERENCIAL-HS").Value) OrElse r.Cells("DIFERENCIAL-HS").Value = 0 OrElse r.Cells("DIFERENCIAL-HS").Value = "") Then
                            r.DefaultCellStyle.BackColor = Color.LightGray
                            Continue For
                        Else
                            carga = True
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

                            cp.addPractica(med, pac, modu, subModu, horas, horasDif, fec, obs, obsPac, obsPre)
                            r.DefaultCellStyle.BackColor = Color.LightGreen
                            r.DefaultCellStyle.ForeColor = Color.Black
                            r.Cells("RESULTADO").Value = "Cargado"
                        End If
                    Next

                    Dim re = cp.InsertarPracticas()

                    If re.Rows.Count > 0 Then
                        err = True
                        Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
                        For Each r As DataGridViewRow In dgFechas.Rows
                            Dim reRow As DataRow()
                            Dim dia = r.Cells("DIA_H").Value
                            Dim fecha As New Date(DTFecha.Value.Year, DTFecha.Value.Month, r.Cells("DIA_H").Value)
                            reRow = re.Select(String.Format("date = #{0}#", fecha))
                            If reRow.Count > 0 Then
                                r.DefaultCellStyle.BackColor = Color.Red
                                r.DefaultCellStyle.ForeColor = Color.Black
                                r.Cells("RESULTADO").Value = reRow(0)("err")
                            End If
                        Next
                    End If

                    cpac.refrescar()
                    cprest.refrescar()
                    cprest.llenarcombo(cbMedico)
                    cpac.llenarcombo(cbPaciente)

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
            Cursor.Current = Cursors.Default
            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI

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
            If cp.findeFeriado(fecha) Then
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
                            If cp.findeFeriado(fecha) Then

                                If med.monto_feriado = 0 Then
                                    monto += med.monto_semana * r.Cells(3).Value
                                Else
                                    monto += med.monto_feriado * r.Cells(3).Value
                                End If
                            Else
                                monto += med.monto_semana * r.Cells(3).Value
                            End If
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


                med = cprest.prestador(cbMedico.SelectedValue.ToString)
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
        Dim frm As New frmPracticaPacienteDetalle(pac.id, fecha)
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
                modu = cmod.modulo(cbModulo.SelectedValue)
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

    Private Sub cbSubModulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubModulo.SelectedIndexChanged
        If Not carga Then
            If cbSubModulo.SelectedIndex <> -1 Then
                subModu = cSubMod.subModulo(cbSubModulo.SelectedValue)
            End If
        End If
    End Sub
End Class
