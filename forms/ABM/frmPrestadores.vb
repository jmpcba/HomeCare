Public Class frmPrestadores
    Dim prest As Prestador
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim txtBoxesDA As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim montoLaV As Decimal
        Dim montoFeriado As Decimal
        Dim montoFijo As Decimal
        Dim montoDiferencial As Decimal

        If IsNothing(prest) Then
            Try
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarMail(txtEmail.Text.Trim)
                ut.validarNumerico({numFijo, numLunVie, numFeriados})

                If cbEspecialidad.SelectedIndex = -1 Then
                    Throw New Exception("SELECCIONE UNA ESPECIALIDAD")
                End If

                If cbZona.SelectedIndex = -1 Then
                    Throw New Exception("SELECCIONE UNA ZONA")
                End If

                montoLaV = numLunVie.Text.Trim
                montoFeriado = numFeriados.Text.Trim
                montoFijo = numFijo.Text.Trim
                montoDiferencial = numDiferencial.Text.Trim
                Dim cuit = txtCuit.Text.ToString
                If cuit.Length > 1 Then
                    cuit = cuit.Insert(2, "-")
                    cuit = cuit.Insert(cuit.Length - 1, "-")
                End If
                prest = New Prestador(cuit, txtNombre.Text, txtApellido.Text.Trim, txtEmail.Text.Trim, cbEspecialidad.SelectedValue, txtLocalidad.Text.Trim, montoLaV, montoFeriado, montoFijo, numDiferencial.Text.Trim, dtCese.Text.Trim, txtServicio.Text.Trim, txtComentario.Text.Trim, cbZona.SelectedValue)
                prest.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()

            Catch ex As Exception
                If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                    ut.mensaje("Ya existe un Prestador con el mismo cuit/especialidad/localidad/servicio", utils.mensajes.err)
                Else
                    ut.mensaje(ex.Message, utils.mensajes.err)
                End If
            Finally
                prest = Nothing
            End Try

        Else
            Try
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarMail(txtEmail.Text.Trim)
                ut.validarNumerico({numFijo, numLunVie, numFeriados})
                montoLaV = numLunVie.Text.Trim
                montoFeriado = numFeriados.Text.Trim
                montoFijo = numFijo.Text.Trim
                montoDiferencial = numDiferencial.Text.Trim
                If cbZona.SelectedIndex = -1 Then
                    Throw New Exception("SELECCIONE UNA ZONA")
                End If

                If txtNombre.Text.Trim <> prest.nombre Then
                    prest.nombre = txtNombre.Text.Trim
                End If
                If txtApellido.Text.Trim <> prest.apellido Then
                    prest.apellido = txtApellido.Text.Trim
                End If
                If txtEmail.Text.Trim <> prest.mail Then
                    prest.mail = txtEmail.Text.Trim
                End If
                If cbEspecialidad.SelectedValue <> prest.especialidad Then
                    prest.especialidad = cbEspecialidad.SelectedValue
                End If
                If txtLocalidad.Text.Trim <> prest.localidad Then
                    prest.localidad = txtLocalidad.Text.Trim
                End If
                If txtServicio.Text.Trim <> prest.servicio Then
                    prest.servicio = txtServicio.Text.Trim
                End If
                If montoLaV <> prest.monto_semana Then
                    prest.monto_semana = montoLaV
                End If
                If montoFeriado <> prest.monto_feriado Then
                    prest.monto_feriado = montoFeriado
                End If
                If numDiferencial.Text.Trim <> prest.monto_diferencial Then
                    prest.monto_diferencial = numDiferencial.Text.Trim
                End If
                If montoFijo <> prest.monto_fijo Then
                    prest.monto_fijo = montoFijo
                End If

                If chbCese.Checked Then

                    If dtCese.Value.ToShortDateString <> prest.baja Then
                        prest.baja = dtCese.Text
                    End If
                End If

                If txtComentario.Text.Trim <> prest.comentario Then
                    prest.comentario = txtComentario.Text.Trim
                End If

                If cbZona.SelectedValue <> prest.zona Then
                    prest.zona = cbZona.SelectedValue
                End If

                prest.actualizar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
                prest = Nothing
            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
                If ex.Message.Contains("No se realizaron modificaciones") Then
                    iniciarControles()
                End If
            End Try
        End If
    End Sub

    Private Sub iniciarControles()
        txtCuit.ReadOnly = False
        cbEspecialidad.SelectedIndex = -1
        ut.iniciarTxtBoxes(txtBoxes)
        ut.activarTxtBoxes(txtBoxes)
        numDiferencial.Text = "0"
        chbCese.Enabled = False
        chbCese.Checked = False
        txtComentario.Text = ""
        cbZona.SelectedValue = 1
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
        ut.habilitarBoton(txtBoxes, btnGuardar)
        Try

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
        Dim esp As New especialidad
        Dim zona As New Zona()

        zona.llenarcombo(cbZona)

        esp.llenarcombo(cbEspecialidad)
        dtCese.Enabled = False
        txtBoxes = {txtCuit, txtNombre, txtApellido, txtEmail, txtLocalidad, txtServicio, numLunVie, numFeriados, numFijo, numDiferencial}
        iniciarControles()

        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        prest = Nothing
        Me.Close()
    End Sub

    Private Sub chbCese_CheckedChanged(sender As Object, e As EventArgs) Handles chbCese.CheckedChanged
        If chbCese.Checked = True Then
            dtCese.Enabled = True
            txtBoxesDA = {txtCuit, txtNombre, txtApellido, txtEmail, txtLocalidad, txtServicio, numLunVie, numFeriados, numFijo, numDiferencial, txtComentario}
            ut.desactivarTxtBoxes(txtBoxesDA)
        Else
            dtCese.Enabled = False
            txtBoxesDA = {txtCuit, txtNombre, txtApellido, txtEmail, txtLocalidad, txtServicio, numLunVie, numFeriados, numFijo, numDiferencial, txtComentario}
            ut.activarTxtBoxes(txtBoxesDA)
        End If

    End Sub

    Public Sub resultadoBusqueda(ByRef _prestador As Prestador)
        txtCuit.ReadOnly = True
        txtCuit.Text = _prestador.CUIT
        txtNombre.Text = _prestador.nombre
        txtApellido.Text = _prestador.apellido
        txtEmail.Text = _prestador.mail
        cbEspecialidad.SelectedValue = _prestador.especialidad
        txtLocalidad.Text = _prestador.localidad
        numLunVie.Text = _prestador.monto_semana
        numFeriados.Text = _prestador.monto_feriado
        numDiferencial.Text = _prestador.monto_diferencial
        numFijo.Text = _prestador.monto_fijo
        txtServicio.Text = _prestador.servicio
        chbCese.Checked = False
        cbZona.SelectedValue = _prestador.zona

        If _prestador.baja Then
            chbCese.Checked = True
            ut.desactivarTxtBoxes(txtBoxes)
        End If

        txtComentario.Text = _prestador.comentario
        prest = _prestador
        chbCese.Enabled = True
        btnGuardar.Enabled = True

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        prest = Nothing
        txtCuit.ReadOnly = False
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmPrestadores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub

    Private Sub txtApellido_TextChanged(sender As Object, e As EventArgs) Handles txtApellido.TextChanged
        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub

    Private Sub txtLocalidad_TextChanged(sender As Object, e As EventArgs) Handles txtLocalidad.TextChanged
        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub

    Private Sub txtServicio_TextChanged(sender As Object, e As EventArgs) Handles txtServicio.TextChanged
        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub

    Private Sub numLunVie_TextChanged(sender As Object, e As EventArgs) Handles numLunVie.TextChanged
        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub

    Private Sub numFeriados_TextChanged(sender As Object, e As EventArgs) Handles numFeriados.TextChanged
        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub

    Private Sub numFijo_TextChanged(sender As Object, e As EventArgs) Handles numFijo.TextChanged
        ut.habilitarBoton(txtBoxes, btnGuardar)
    End Sub
End Class