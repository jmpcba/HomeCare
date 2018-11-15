Imports System.DateTime
Imports System.Configuration
Imports System.Collections.Specialized

Public Class frmPracticas
    Dim pac As Paciente
    Dim med As Prestador
    Dim prest As Prestacion
    Dim modu As Modulo
    Dim subModu As subModulo
    Dim index As Integer
    Dim edicion As Boolean = False
    Dim cellVal
    Dim selectedRows As DataGridViewSelectedRowCollection
    Dim ut As utils
    Private Sub visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

        Try


            'cbMedico.SelectedIndex = -1
            CBPrestacion.SelectedIndex = -1
            cbPaciente.SelectedIndex = -1
            cbModulo.SelectedIndex = -1
            cbSubModulo.SelectedIndex = -1
            CBPrestacion.SelectedIndex = -1

            statusBar("CARGA INICIAL", False)

            DTFecha.CustomFormat = "MMMM - yyyy"
            lblMes.Text = MonthName(DTFecha.Value.Month).ToUpper

            ut = New utils
            pac = New Paciente()
            prest = New Prestacion()
            med = New Prestador()
            subModu = New subModulo
            modu = New Modulo()


            pac.llenarcombo(cbPaciente)
            med.llenarcombo(cbMedico)
            modu.llenarcombo(cbModulo)
            subModu.llenarcombo(cbSubModulo)
            prest.llenarcombo(CBPrestacion)

            cargarGrilla()

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try

    End Sub

    Private Sub CBPrestacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBPrestacion.SelectionChangeCommitted
        If CBPrestacion.SelectedIndex <> -1 Then
            Try
                prest.codigo = CBPrestacion.SelectedValue
                statusBar("PRESTACION CARGADA", False)
            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
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
                statusBar("PACIENTE CARGADO", False)

            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim err = False
        Dim carga = False
        ut = New utils
        Try
            dgFechas.Columns("RESULTADO").ReadOnly = False

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

                If ut.validarLiquidacion(cbMedico.SelectedValue, DTFecha.Value) Then
                    Throw New Exception("LIQUIDACION CERRADA PARA ESTE PRESTADOR - MES")
                Else
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
                        MessageBox.Show("Ocurrieron Errores durante la carga")
                    ElseIf carga Then
                        MessageBox.Show("Datos Cargados exitosamente")
                    Else
                        MessageBox.Show("No se cargaron horas para ningun dia")
                    End If
                    statusBar("TERMINADO", False)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        Finally
            With dgFechas
                .Columns("RESULTADO").ReadOnly = True
                .AutoResizeColumns()
                .AutoResizeRows()
            End With

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

            .Columns("HORAS").DefaultCellStyle.Font = New Font("arial", 8)

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

            'hay una columna oculta
            If e.ColumnIndex = 3 Then
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

    Private Sub cbModulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModulo.SelectionChangeCommitted
        If cbModulo.SelectedIndex <> -1 Then
            modu.codigo = cbModulo.SelectedValue
        End If

    End Sub

    Private Sub txtLocalidad_TextChanged(sender As Object, e As EventArgs) Handles txtLocalidad.TextChanged

    End Sub

    Private Sub cbMedico_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMedico.SelectionChangeCommitted
        If cbMedico.SelectedIndex <> -1 Then

            med.clave = cbMedico.SelectedValue.ToString
            Try
                txtMat.Text = med.cuit
                txtLocalidad.Text = med.localidad
                txtEspecialidad.Text = med.especialidad
                statusBar("MEDICO CARGADO", False)
            Catch ex As Exception
                MessageBox.Show("ERROR: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub cbSubModulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubModulo.SelectionChangeCommitted

    End Sub
End Class
