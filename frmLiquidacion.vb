Public Class frmLiquidacion
    Dim dataTableDetalle As New DataTable
    Dim dataTablePaciente As New DataTable
    Dim dataTablePrestador As New DataTable




    Private Sub frmLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fecha = dtFecha.Value

        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PRESTADORES' Puede moverla o quitarla según sea necesario.
        Me.PRESTADORESTableAdapter.Fill(Me.HomeCareDataSet.PRESTADORES)
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PACIENTES' Puede moverla o quitarla según sea necesario.
        Me.PACIENTESTableAdapter.Fill(Me.HomeCareDataSet.PACIENTES)

        dtFecha.CustomFormat = " MMMM - yyyy"
        dtPrestador.CustomFormat = " MMMM - yyyy"
        dtPaciente.CustomFormat = " MMMM - yyyy"

        Me.WindowState = FormWindowState.Maximized

        restaurarCombos()

        Try
            cargarGrillaDetalle(fecha)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub restaurarCombos()
        cbPaciente.SelectedIndex = -1
        cbPrestadores.SelectedIndex = -1
        cbPacientePaciente.SelectedIndex = -1
        cbPacientePrestador.SelectedIndex = -1
        cbPrestadorPrestador.SelectedIndex = -1
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        Dim fecha = dtFecha.Value

        Try
            cargarGrillaDetalle(fecha)
            restaurarCombos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarGrillaDetalle(_fecha As Date)
        Dim db As New DB()
        Try
            dgDetalle.DataSource = Nothing
            dataTableDetalle = db.liquidacion(_fecha, DB.liquidaciones.detalle)
            dgDetalle.DataSource = dataTableDetalle
            dgDetalle.AutoResizeColumns()
            dgDetalle.AutoResizeRows()

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaciente.SelectedIndexChanged

        If cbPaciente.SelectedIndex <> -1 Then
            Dim bs = New BindingSource
            bs.DataSource = dataTableDetalle
            bs.Filter = String.Format("AFILIADO='{0}'", cbPaciente.SelectedValue)
            dgDetalle.DataSource = bs
            cbPrestadores.SelectedIndex = -1
        End If

    End Sub

    Private Sub cbPrestadores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPrestadores.SelectedIndexChanged

        If cbPrestadores.SelectedIndex <> -1 Then
            Dim bs = New BindingSource
            bs.DataSource = dataTableDetalle
            bs.Filter = String.Format("CUIT='{0}'", cbPrestadores.SelectedValue)
            dgDetalle.DataSource = bs
            cbPaciente.SelectedIndex = -1
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cbPaciente.SelectedIndex = -1
        cbPrestadores.SelectedIndex = -1

        Dim bs = New BindingSource
        bs.DataSource = dataTableDetalle
        bs.Filter = Nothing
        dgDetalle.DataSource = bs
    End Sub

    Private Sub tbReporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbReporte.SelectedIndexChanged

        Try
            If tbReporte.SelectedIndex = 0 Then
                If IsNothing(dgDetalle.DataSource) Then
                    Dim fecha = dtFecha.Value
                    cargarGrillaDetalle(fecha)
                End If
            ElseIf tbReporte.SelectedIndex = 1 Then
                Dim fecha = dtPrestador.Value
                If IsNothing(dgPrestador.DataSource) Then
                    cargarGrillaPrestador(fecha)
                End If
            ElseIf tbReporte.SelectedIndex = 2 Then
                Dim fecha = dtPaciente.Value
                If IsNothing(dgPaciente.DataSource) Then
                    cargarGrillaPaciente(fecha)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarGrillaPaciente(_fecha As Date)
        Dim db As New DB()
        Try
            dgPaciente.DataSource = Nothing
            dataTablePaciente = db.liquidacion(_fecha, DB.liquidaciones.paciente)
            dgPaciente.DataSource = dataTablePaciente
            dgPaciente.AutoResizeColumns()
            dgPaciente.AutoResizeRows()

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cargarGrillaPrestador(_fecha As Date)
        Dim db As New DB()
        Try
            dgPrestador.DataSource = Nothing
            dataTablePrestador = db.liquidacion(_fecha, DB.liquidaciones.medico)
            dgPrestador.DataSource = dataTablePrestador
            dgPrestador.AutoResizeColumns()
            dgPrestador.AutoResizeRows()

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub dtPrestador_ValueChanged(sender As Object, e As EventArgs) Handles dtPrestador.ValueChanged
        Dim fecha = dtPrestador.Value
        Try
            cargarGrillaPrestador(fecha)
            restaurarCombos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtPaciente_ValueChanged(sender As Object, e As EventArgs) Handles dtPaciente.ValueChanged
        Dim fecha = dtPaciente.Value
        Try
            cargarGrillaPaciente(fecha)
            restaurarCombos()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cbPrestadorPrestador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPrestadorPrestador.SelectedIndexChanged
        If cbPrestadorPrestador.SelectedIndex <> -1 Then
            Dim bs = New BindingSource
            bs.DataSource = dataTablePrestador
            bs.Filter = String.Format("CUIT='{0}'", cbPrestadorPrestador.SelectedValue)
            dgPrestador.DataSource = bs
        End If
    End Sub

    Private Sub cbPacientePrestador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPacientePrestador.SelectedIndexChanged
        If cbPacientePrestador.SelectedIndex <> -1 Then
            Dim bs = New BindingSource
            bs.DataSource = dataTablePaciente
            bs.Filter = String.Format("CUIT='{0}'", cbPacientePrestador.SelectedValue)
            dgPaciente.DataSource = bs
            cbPacientePaciente.SelectedIndex = -1
        End If
    End Sub

    Private Sub cbPacientePaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPacientePaciente.SelectedIndexChanged
        If cbPacientePaciente.SelectedIndex <> -1 Then
            Dim bs = New BindingSource
            bs.DataSource = dataTablePaciente
            bs.Filter = String.Format("AFILIADO='{0}'", cbPacientePaciente.SelectedValue)
            dgPaciente.DataSource = bs
            cbPacientePrestador.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnLimpiarPrestador_Click(sender As Object, e As EventArgs) Handles btnLimpiarPrestador.Click
        cbPrestadorPrestador.SelectedIndex = -1

        Dim bs = New BindingSource
        bs.DataSource = dataTablePrestador
        bs.Filter = Nothing
        dgPrestador.DataSource = bs
    End Sub

    Private Sub btnPacienteLimpiar_Click(sender As Object, e As EventArgs) Handles btnPacienteLimpiar.Click
        cbPacientePaciente.SelectedIndex = -1
        cbPacientePrestador.SelectedIndex = -1

        Dim bs = New BindingSource
        bs.DataSource = dataTablePaciente
        bs.Filter = Nothing
        dgPaciente.DataSource = bs
    End Sub
End Class