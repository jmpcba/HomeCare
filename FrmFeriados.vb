Public Class FrmFeriados






    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DtCalendario.ValueChanged
        txtDescripciion.Text = DtCalendario.Value.ToShortDateString
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

End Class