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
    Dim carga As Boolean

    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ut = New utils
        Me.WindowState = FormWindowState.Maximized
        carga = True
        Try
            dgFechas.Columns.Clear()
            DTFecha.Value = DateTime.Today.AddMonths(-1)
            DTFecha.CustomFormat = "MMMM - yyyy"
            lblMes.Text = MonthName(DTFecha.Value.Month).ToUpper

            pac = New Paciente()
            med = New Prestador()
            subModu = New subModulo
            modu = New Modulo()

            pac.llenarcombo(cbPaciente)
            med.llenarcombo(cbMedico)
            modu.llenarcombo(cbModulo)
            subModu.llenarcombo(cbSubModulo)

            txtAfiliado.Text = ""
            txtBeneficio.Text = ""
            txtEspecialidad.Text = ""
            txtLocalidadPrest.Text = ""
            txtMat.Text = ""
            txtObservaciones.Text = ""
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
                    pac.afiliado = cbPaciente.SelectedValue
                    lblPaciente.Text = String.Format("{0} {1}", pac.apellido, pac.nombre)
                    txtAfiliado.Text = pac.afiliado
                    txtBeneficio.Text = pac.obrasocial
                    txtLocalidadPac.Text = pac.localidad
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
                        Dim horasLaV As Integer
                        Dim horasFer As Integer
                        Dim horasDif As Integer
                        Dim dia As Integer

                        If IsDBNull(r.Cells("PRACTICAS-HS").Value) OrElse r.Cells("PRACTICAS-HS").Value = 0 OrElse r.Cells("PRACTICAS-HS").Value = "" Then
                            r.DefaultCellStyle.BackColor = Color.LightGray
                            Continue For
                        Else
                            horas = r.Cells("PRACTICAS-HS").Value
                            dia = r.Cells("DIA_H").Value

                            Dim fec = New Date(DTFecha.Value.Year.ToString, DTFecha.Value.Month.ToString, dia)

                            If r.Cells(4).Value = "SI" Then
                                horasDif = horas
                                horasLaV = 0
                                horasFer = 0
                            ElseIf ut.esFindeOFeriado(fec) Then
                                horasDif = 0
                                horasLaV = 0
                                horasFer = horas
                            Else
                                horasDif = 0
                                horasLaV = horas
                                horasFer = 0
                            End If

                            Dim practica = New Practica(med, pac, cbModulo.SelectedValue, cbSubModulo.SelectedValue, fec, horasLaV, horasFer, horasDif, obs, r.Index)

                            practicas.Add(practica)
                            r.DefaultCellStyle.BackColor = Color.LightGreen
                            r.Cells("RESULTADO").Value = "Cargado"
                            carga = True
                        End If
                    Next

                    Dim db As New DB
                    Dim re As New List(Of ResultadoCargaPracticas)

                    If carga Then
                        re = db.insertar(practicas)
                    End If

                    If re.Count > 0 Then
                        err = True
                        For Each r As ResultadoCargaPracticas In re
                            dgFechas.Rows(r.filaError).DefaultCellStyle.BackColor = Color.Red
                            dgFechas.Rows(r.filaError).DefaultCellStyle.ForeColor = Color.Black
                            dgFechas.Rows(r.filaError).Cells("RESULTADO").Value = r.mensajeError
                        Next
                    End If

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
        dt.Columns.Add("RESULTADO")

        For i = 0 To days - 1
            Dim r = dt.NewRow
            Dim fecha = New Date(year, month, i + 1)
            r("DIA") = fecha.ToString("dddd - dd")
            r("DIA_H") = i + 1
            dt.Rows.Add(r)
        Next

        Dim chkclm As New DataGridViewCheckBoxColumn
        Dim drpDiferencial As New DataGridViewComboBoxColumn

        With chkclm
            .HeaderText = ""
            .Name = ""
        End With

        With drpDiferencial
            .HeaderText = "DIFERENCIAL"
            .Name = ""
            .DataSource = {"SI", "NO"}
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

            .Columns("DIA").ReadOnly = True
            .Columns("RESULTADO").ReadOnly = True

            .Columns.Insert(0, chkclm)
            .Columns.Insert(.ColumnCount - 1, drpDiferencial)

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
        calcularTotales(e)

    End Sub

    Private Sub calcularTotales(e As DataGridViewCellEventArgs)
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
            If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
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
                        If r.Cells(4).Value = "SI" Then
                            If med.montoDiferencial = 0 Then
                                ut.mensaje("Este prestador no tiene cargado un monto diferencial", utils.mensajes.err)
                                hs = 0
                                r.Cells("PRACTICAS-HS").Value = Nothing
                                r.Cells(4).Value = "NO"
                            Else
                                monto += med.montoDiferencial * r.Cells("PRACTICAS-HS").Value
                            End If
                        Else
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
                        End If

                        ' If r.Cells(4).Value = "SI" Then
                        ' monto += med.montoDiferencial * r.Cells("PRACTICAS-HS").Value
                        'End If
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
        txtObservaciones.Text = ""
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
                    txtMat.Text = med.cuit
                    txtLocalidadPrest.Text = med.localidad
                    txtEspecialidad.Text = med.especialidad
                    txtServicio.Text = med.obraSocial
                    lblPrecioFeriado.Text = med.montoFeriado.ToString("F")
                    lblPrecioLaV.Text = med.montoNormal.ToString("F")
                    txtOS.Text = med.obraSocial
                    lblPrecioDif.Text = med.montoDiferencial.ToString("F")
                    PracticasPrestadorToolStripMenuItem.Enabled = True
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
End Class
