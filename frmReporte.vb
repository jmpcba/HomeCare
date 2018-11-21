Public Class frmReporte
    Private Sub frmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim fec As Date
        fec = dtFiltro.Value
        Dim db = New DB
        DataGridView1.DataBindings.Clear()
        DataGridView1.DataSource = db.getVisitas(fec)

    End Sub
End Class