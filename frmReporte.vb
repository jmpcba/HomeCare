Public Class frmReporte
    Dim dt As New DataTable
    Dim db As New DB
    Private Sub frmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DTFinal As New DataTable
        dt = db.getLiquidacion(Today, DB.tiposLiquidacion.anual)

        Dim datos = {"ID_PREST", "CUIT", "NOMBRE", "APELLIDO"}

        'AGREGAR COLUMNAS
        For Each d In datos
            DTFinal.Columns.Add(d)
        Next

        'AGREGAR MESES
        For i = 1 To Today.Month
            DTFinal.Columns.Add(MonthName(i).ToUpper)
        Next

        For Each r As DataRow In dt.Rows
            Dim idPrestador = r("ID_PREST")
            Dim fecha = DateTime.Parse(r("MES"))

            If DTFinal.Select("ID_PREST=" & idPrestador).Count = 0 Then
                Dim newRow = DTFinal.NewRow

                For Each d In datos
                    newRow(d) = r(d)
                Next

                DTFinal.Rows.Add(newRow)
            End If

            Dim row = DTFinal.Select("ID_PREST=" & idPrestador)
            row(0)(MonthName(fecha.Month.ToString).ToUpper) = r("$ TOTAL")
        Next

        dgAnual.DataSource = DTFinal
    End Sub

    Private Sub frmReporte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class