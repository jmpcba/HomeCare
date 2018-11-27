Public Class frmSubMod
    Dim subMod As subModulo
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(subMod) Then
                ut.validarLargo(txtCodigo, 6)
                ut.validarTxtBoxLleno(txtBoxes)
                subMod = New subModulo(txtCodigo.Text, txtDescripcion.Text)
                subMod.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            Else
                ut.validarLargo(txtCodigo, 6)
                ut.validarTxtBoxLleno(txtBoxes)

                If txtDescripcion.Text <> subMod.descripcion Then
                    subMod.descripcion = txtDescripcion.Text
                End If

                '  If txtTope.Text <> subMod.tope Then
                '  subMod.tope = txtTope.Text
                '  End If
                subMod.actualizar()
                ut.iniciarTxtBoxes(txtBoxes)
                subMod = Nothing
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            End If
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un Sub Modulo con el mismo codigo", utils.mensajes.err)
            Else
                ut.mensaje(ex.Message, utils.mensajes.err)
            End If
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim frmBuscar As New frmBuscar(Me)
            frmBuscar.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            subMod = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub iniciarControles()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        '  txtTope.Text = ""
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        Try
            If txtCodigo.Text <> "" Then
                btnBuscar.Enabled = True
            Else
                btnBuscar.Enabled = False
            End If
            ut.validarNumerico(txtCodigo)

            If Not IsNothing(subMod) Then
                subMod = Nothing
            End If

        Catch ex As Exception
            txtCodigo.Text = ""
            btnBuscar.Enabled = False
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    ' Private Sub txtTope_TextChanged(sender As Object, e As EventArgs)
    ' Try
    '         ut.validarNumerico(txtTope)
    ' Catch ex As Exception
    '         ut.mensaje(ex.Message, utils.mensajes.err)
    ' End Try
    ' End Sub

    Private Sub frmSubMod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  btnBuscar.Enabled = False
        txtBoxes = {txtCodigo, txtDescripcion}
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Public Sub resultadoBusqueda(ByRef _submod As subModulo)
        txtCodigo.ReadOnly = True
        txtCodigo.Text = _submod.codigo
        txtDescripcion.Text = _submod.descripcion
        subMod = _submod
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtCodigo.ReadOnly = False
        iniciarControles()
        subMod = Nothing
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class