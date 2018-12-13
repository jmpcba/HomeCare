Public Class frmModulo
    Dim modu As Modulo
    Dim ut As New utils
    Dim txtboxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If IsNothing(modu) Then
                ut.validarLargo(txtCodigo, 6)
                ut.validarTxtBoxLleno(txtboxes)

                modu = New Modulo(txtCodigo.Text, txtMedico.Text, txtEnfermeria.Text, txtKinesio.Text, txtFono.Text, txtCuidador.Text, txtNutricion.Text)
                modu.insertar()
                MessageBox.Show("Guardado Exitoso")
                ut.iniciarTxtBoxes(txtboxes)
                txtCodigo.ReadOnly = False
            Else
                ut.validarLargo(txtCodigo, 6)
                ut.validarTxtBoxLleno(txtboxes)

                If txtMedico.Text <> modu.topeMedico Then
                    modu.topeMedico = txtMedico.Text
                End If

                If txtEnfermeria.Text <> modu.topeEnfermeria Then
                    modu.topeEnfermeria = txtEnfermeria.Text
                End If

                If txtKinesio.Text <> modu.topeKinesio Then
                    modu.topeKinesio = txtKinesio.Text
                End If

                If txtFono.Text <> modu.topeFono Then
                    modu.topeFono = txtFono.Text
                End If

                If txtNutricion.Text <> modu.topeNutricionista Then
                    modu.topeNutricionista = txtNutricion.Text
                End If

                modu.actualizar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                ut.iniciarTxtBoxes(txtboxes)
                modu = Nothing
                txtCodigo.ReadOnly = False
            End If

        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un Modulo con el mismo codigo", utils.mensajes.err)
            Else
                ut.mensaje(ex.Message, utils.mensajes.err)
            End If
            If ex.Message.Contains("No se realizaron modificaciones") Then
                iniciarControles()
            End If
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim frmBuscar As New frmBuscar(Me)
            frmBuscar.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            modu = Nothing
            iniciarControles()
        End Try
    End Sub

    Public Sub iniciarControles()
        txtCodigo.Text = ""
        txtCuidador.Text = ""
        '   txtDescripcion.Text = ""
        txtEnfermeria.Text = ""
        txtFono.Text = ""
        txtKinesio.Text = ""
        txtMedico.Text = ""
        txtNutricion.Text = ""
    End Sub

    Private Sub txtCodigo_Click(sender As Object, e As EventArgs)
        txtCodigo.Select(0, 0)
    End Sub

    Private Sub validarCampos()
        '   If (txtCodigo.Text = "" Or txtDescripcion.Text = "") Then
        '   Throw New Exception("Complete los campos necesarios")
        '   End If
        If (txtMedico.Text = "" And txtEnfermeria.Text = "" And txtKinesio.Text = "" And txtFono.Text = "" And txtCuidador.Text = "" And txtNutricion.Text = "") Then
            Throw New Exception("Debe cargar algún tope")
        End If
        If txtCodigo.Text.Length <> 6 Then
            Throw New Exception("El codigo debe tener 6 digitos")
        End If
    End Sub

    Private Sub txtMedico_TextChanged(sender As Object, e As EventArgs)
        Try
            ut.validarNumerico(txtMedico)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtEnfermeria_TextChanged(sender As Object, e As EventArgs) Handles txtEnfermeria.TextChanged
        Try
            ut.validarNumerico(txtEnfermeria)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub txtKinesio_TextChanged(sender As Object, e As EventArgs) Handles txtKinesio.TextChanged
        Try
            ut.validarNumerico(txtKinesio)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub txtFono_TextChanged(sender As Object, e As EventArgs) Handles txtFono.TextChanged
        Try
            ut.validarNumerico(txtFono)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub txtCuidador_TextChanged(sender As Object, e As EventArgs) Handles txtCuidador.TextChanged
        Try
            ut.validarNumerico(txtCuidador)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub txtNutricion_TextChanged(sender As Object, e As EventArgs) Handles txtNutricion.TextChanged
        Try
            ut.validarNumerico(txtNutricion)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmModulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'btnBuscar.Enabled = False
        txtboxes = {txtCodigo, txtMedico, txtEnfermeria, txtKinesio, txtFono, txtCuidador, txtNutricion}
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        Try
            '  If txtCodigo.Text <> "" Then
            '  btnBuscar.Enabled = True
            '  Else
            '  btnBuscar.Enabled = False
            '  End If

            If Not IsNothing(modu) Then
                modu = Nothing
            End If

            ut.validarNumerico(txtCodigo)

        Catch ex As Exception
            txtCodigo.Text = ""
            btnBuscar.Enabled = False
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub resultadoBusqueda(ByRef _modulo As Modulo)
        txtCodigo.ReadOnly = True
        txtCodigo.Text = _modulo.codigo
        txtCuidador.Text = _modulo.topeCuidador
        ' txtDescripcion.Text = _modulo.descripcion
        txtEnfermeria.Text = _modulo.topeEnfermeria
        txtFono.Text = _modulo.topeFono
        txtKinesio.Text = _modulo.topeKinesio
        txtMedico.Text = _modulo.topeMedico
        txtNutricion.Text = _modulo.topeNutricionista
        modu = _modulo

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtCodigo.ReadOnly = False
        iniciarControles()
        modu = Nothing
    End Sub

    Private Sub frmModulo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class