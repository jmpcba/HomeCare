Public Class frmReporte
    Dim dt As DataTable
    Dim dtFinal As DataTable
    Dim db As DB
    Dim ut As New utils

    Private Sub frmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = New DataTable
        dtFinal = New DataTable("INFORME ANUAL")
        db = New DB

        llenarGrilla()
        ToolStripProgressBar1.Visible = False
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub llenarGrilla()
        Try
            dt = db.getLiquidacion(Today, DB.tiposLiquidacion.anual)

            Dim datos = {"ID_PREST", "CUIT", "NOMBRE", "APELLIDO"}

            'AGREGAR COLUMNAS
            For Each d In datos
                dtFinal.Columns.Add(d)
            Next

            'AGREGAR MESES
            For i = 1 To 12
                dtFinal.Columns.Add(MonthName(i).ToUpper)
            Next

            With ToolStripProgressBar1
                .Visible = True
                .Maximum = 0
                .Maximum = dt.Rows.Count
            End With



            For Each r As DataRow In dt.Rows
                Dim idPrestador = r("ID_PREST")
                Dim fecha = DateTime.Parse(r("MES"))

                Dim row = dtFinal.Select(String.Format("ID_PREST='{0}'", idPrestador.ToString))

                If row.Count = 0 Then
                    Dim newRow = dtFinal.NewRow

                    For Each d In datos
                        newRow(d) = r(d)
                    Next

                    dtFinal.Rows.Add(newRow)
                End If

                row = dtFinal.Select(String.Format("ID_PREST='{0}'", idPrestador.ToString))
                row(0)(MonthName(fecha.Month.ToString).ToUpper) = r("$ TOTAL")
                ToolStripProgressBar1.Increment(1)
            Next

            With dgAnual
                .DataSource = dtFinal
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

    Private Sub ExportarListadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarListadoToolStripMenuItem.Click
        Try
            ut.exportarExcel(dtFinal)
            Focus()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub
End Class