Public Class frmLiquidacionDetalle

    Public Sub New(_cuit As String, _fecha As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TextBox1.Text = _cuit
        TextBox2.Text = _fecha
    End Sub

End Class