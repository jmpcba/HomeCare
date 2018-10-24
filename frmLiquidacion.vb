Public Class frmLiquidacion
    Dim dt As New DataTable

    Private Sub tbReporte_TabIndexChanged(sender As Object, e As EventArgs) Handles tbReporte.TabIndexChanged
        Dim fecha = dtFecha.Value
        Try
            If tbReporte.TabIndex = 0 Then
                cargarGrilla(fecha)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmLiquidacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PRESTADORES' Puede moverla o quitarla según sea necesario.
        Me.PRESTADORESTableAdapter.Fill(Me.HomeCareDataSet.PRESTADORES)
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PACIENTES' Puede moverla o quitarla según sea necesario.
        Me.PACIENTESTableAdapter.Fill(Me.HomeCareDataSet.PACIENTES)
        dtFecha.CustomFormat = " MMMM - yyyy"

        cbPaciente.SelectedIndex = -1
        cbPrestadores.SelectedIndex = -1
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        Dim db As New DB()
        Dim fecha = dtFecha.Value

        Try
            cargarGrilla(fecha)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cargarGrilla(_fecha As Date)
        Dim db As New DB()
        Try
            dgDetalle.DataSource = Nothing
            dt = db.liquidacion(_fecha)
            dgDetalle.DataSource = dt
            dgDetalle.AutoResizeColumns()
            dgDetalle.AutoResizeRows()

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaciente.SelectedIndexChanged

        If cbPaciente.SelectedIndex <> -1 Then
            Dim bs = New BindingSource
            bs.DataSource = dt
            bs.Filter = String.Format("AFILIADO='{0}'", cbPaciente.SelectedValue)
            dgDetalle.DataSource = bs
            cbPrestadores.SelectedIndex = -1
        End If

    End Sub

    Private Sub cbPrestadores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPrestadores.SelectedIndexChanged

        If cbPrestadores.SelectedIndex <> -1 Then
            Dim bs = New BindingSource
            bs.DataSource = dt
            bs.Filter = String.Format("CUIT_PRESTADOR='{0}'", cbPrestadores.SelectedValue)
            dgDetalle.DataSource = bs
            cbPaciente.SelectedIndex = -1
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        cbPaciente.SelectedIndex = -1
        cbPrestadores.SelectedIndex = -1


        Dim bs = New BindingSource
        bs.DataSource = dt
        bs.Filter = Nothing
        dgDetalle.DataSource = bs
    End Sub
End Class