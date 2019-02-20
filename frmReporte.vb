Public Class frmReporte
    Dim dt As New DataTable
    Dim db As New DB
    Dim ut As New utils

    Private Sub frmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrilla()
        ToolStripProgressBar1.Visible = False
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub llenarGrilla()
        Dim DTFinal As New DataTable
        Try
            dt = db.getLiquidacion(Today, DB.tiposLiquidacion.anual)

            Dim datos = {"ID_PREST", "CUIT", "NOMBRE", "APELLIDO"}

            'AGREGAR COLUMNAS
            For Each d In datos
                DTFinal.Columns.Add(d)
            Next

            'AGREGAR MESES
            For i = 1 To 12
                DTFinal.Columns.Add(MonthName(i).ToUpper)
            Next

            With ToolStripProgressBar1
                .Visible = True
                .Maximum = 0
                .Maximum = dt.Rows.Count
            End With



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
                ToolStripProgressBar1.Increment(1)
            Next

            With dgAnual
                .DataSource = DTFinal
                .Columns("ID_PREST").Visible = False
                .AutoResizeColumns()
                .AutoResizeRows()
            End With

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        Finally
            ToolStripProgressBar1.Visible = False
        End Try
    End Sub

    Private Sub frmReporte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class