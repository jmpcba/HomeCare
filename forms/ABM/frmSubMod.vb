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
                subMod = Nothing
            Else
                ut.validarLargo(txtCodigo, 6)
                ut.validarTxtBoxLleno(txtBoxes)

                If txtDescripcion.Text.Trim <> subMod.descripcion Then
                    subMod.descripcion = txtDescripcion.Text.Trim
                End If

                subMod.actualizar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
                ut.iniciarTxtBoxes(txtBoxes)
                subMod = Nothing
            End If
        Catch ex As apiException
            ut.mensaje(ex.Message, utils.mensajes.err)
            If ex.Message.Contains("No se realizaron modificaciones") Then
                iniciarControles()
            End If
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim frmBuscar As New frmBuscar(Me)
            frmBuscar.ShowDialog()
        Catch ex As apiException
            ut.mensaje(ex.Message, utils.mensajes.err)
            subMod = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub iniciarControles()
        txtCodigo.ReadOnly = False
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        Try
            ut.validarNumerico(txtCodigo)

            If Not IsNothing(subMod) Then
                subMod = Nothing
            End If

        Catch ex As Exception
            txtCodigo.Text = ""
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmSubMod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        iniciarControles()
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
        iniciarControles()
        subMod = Nothing
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmSubMod_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class