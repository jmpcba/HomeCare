Public Class frmPrestadores
    Dim prest As Prestador
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(prest) Then
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarLargo(txtCuit, 11)
                prest = New Prestador(txtCuit.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtEspecialidad.Text, txtLocalidad.Text, numLunVie.Text, numFeriados.Text, numFijo.Text, numPorcentaje.Text, dtCese.Text)
                prest.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                ut.iniciarTxtBoxes(txtBoxes)
            Else
                ut.validarTxtBoxLleno(txtBoxes)
                'ut.validarLargo(txtCuit, 11)
                If txtNombre.Text <> prest.nombre Then
                    prest.nombre = txtNombre.Text
                End If
                If txtApellido.Text <> prest.apellido Then
                    prest.apellido = txtApellido.Text
                End If
                If txtEmail.Text <> prest.email Then
                    prest.email = txtEmail.Text
                End If
                If txtEspecialidad.Text <> prest.especialidad Then
                    prest.especialidad = txtEspecialidad.Text
                End If
                If txtLocalidad.Text <> prest.localidad Then
                    prest.localidad = txtLocalidad.Text
                End If
                If numLunVie.Text <> prest.montoNormal Then
                    prest.montoNormal = numLunVie.Text
                End If
                If numFeriados.Text <> prest.montoFeriado Then
                    prest.montoFeriado = numFeriados.Text
                End If
                If numPorcentaje.Text <> prest.porcentaje Then
                    prest.porcentaje = numPorcentaje.Text
                End If
                If numFijo.Text <> prest.montoFijo Then
                    prest.montoFijo = numFijo.Text
                End If

                If chbCese.Checked Then
                    If dtCese.Value.ToShortDateString <> prest.fechaCese Then
                        prest.fechaCese = dtCese.Text
                    End If
                End If


                prest.actualizar()
                iniciarControles()
                prest = Nothing
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
            End If
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un Prestador con el mismo cuit/especialidad/localidad", utils.mensajes.err)
            Else
                ut.mensaje(ex.Message, utils.mensajes.err)
            End If
        End Try
    End Sub

    Private Sub iniciarControles()
        txtCuit.ReadOnly = False
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Try
            Dim frmBuscar As New frmBuscar(Me)
            frmBuscar.ShowDialog()

        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            prest = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub txtCuit_TextChanged(sender As Object, e As EventArgs) Handles txtCuit.TextChanged
        Try

            'ut.validarNumerico(txtCuit)
            If Not IsNothing(prest) Then
                prest = Nothing
            End If

        Catch ex As Exception
            txtCuit.Text = ""
            btnBuscar.Enabled = False
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub chbCese_TextChanged(sender As Object, e As EventArgs) Handles chbCese.TextChanged
        Try
            If chbCese.Text <> "" Then
                dtCese.Enabled = True
            Else
                dtCese.Enabled = False
            End If

        Catch ex As Exception
            chbCese.Text = ""
            dtCese.Enabled = False
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmprestadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtCese.Enabled = False
        txtBoxes = {txtCuit, txtNombre, txtApellido, txtEmail, txtEspecialidad, txtLocalidad, numLunVie, numFeriados, numFijo, numPorcentaje}
        iniciarControles()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        prest = Nothing
        Me.Close()
    End Sub

    Private Sub chbCese_CheckedChanged(sender As Object, e As EventArgs) Handles chbCese.CheckedChanged
        If chbCese.Checked = True Then
            dtCese.Enabled = True
        Else
            dtCese.Enabled = False
        End If
    End Sub

    Public Sub resultadoBusqueda(ByRef _prestador As Prestador)
        txtCuit.ReadOnly = True
        txtCuit.Text = _prestador.cuit
        txtNombre.Text = _prestador.nombre
        txtApellido.Text = _prestador.apellido
        txtEmail.Text = _prestador.email
        txtEspecialidad.Text = _prestador.especialidad
        txtLocalidad.Text = _prestador.localidad
        numLunVie.Text = _prestador.montoNormal
        numFeriados.Text = _prestador.montoFeriado
        numPorcentaje.Text = _prestador.porcentaje
        numFijo.Text = _prestador.montoFijo
        dtCese.Text = _prestador.fechaCese
        prest = _prestador
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        prest = Nothing
        txtCuit.ReadOnly = False
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub
End Class