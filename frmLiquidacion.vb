Public Class frmLiquidacion
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
        dtFecha.CustomFormat = " MMMM - yyyy"
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
            dgDetalle.DataSource = DB.liquidacion(_fecha)
            dgDetalle.AutoResizeColumns()
            dgDetalle.AutoResizeRows()
        Catch ex As Exception
            Throw
        End Try

    End Sub
End Class