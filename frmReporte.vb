Public Class frmReporte
    Private Sub frmReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.PRACTICAS' Puede moverla o quitarla según sea necesario.
        Me.PRACTICASTableAdapter.Fill(Me.HomeCareDataSet.PRACTICAS)
        'TODO: esta línea de código carga datos en la tabla 'HomeCareDataSet.VISITAS' Puede moverla o quitarla según sea necesario.
        'Me.VISITASTableAdapter.Fill(Me.HomeCareDataSet.VISITAS)

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim fec As Date
        fec = dtFiltro.Value
        Dim db = New DB
        DataGridView1.DataBindings.Clear()
        DataGridView1.DataSource = db.getVisitas(fec)

    End Sub
End Class