﻿Public Class frmPrestadores
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
                'ut.validarLargo(txtCuit, 11)
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
                'ut.validarLargo(txtCuit, 11)
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
                If txtEmail.Text.Trim <> prest.email Then
                    prest.email = txtEmail.Text.Trim
                End If
                If cbEspecialidad.SelectedValue <> prest.especialidad Then
                    prest.especialidad = cbEspecialidad.SelectedValue
                End If
                If txtLocalidad.Text.Trim <> prest.localidad Then
                    prest.localidad = txtLocalidad.Text.Trim
                End If
                If txtServicio.Text.Trim <> prest.obraSocial Then
                    prest.obraSocial = txtServicio.Text.Trim
                End If
                If montoLaV <> prest.montoNormal Then
                    prest.montoNormal = montoLaV
                End If
                If montoFeriado <> prest.montoFeriado Then
                    prest.montoFeriado = montoFeriado
                End If
                If numDiferencial.Text.Trim <> prest.montoDiferencial Then
                    prest.montoDiferencial = numDiferencial.Text.Trim
                End If
                If montoFijo <> prest.montoFijo Then
                    prest.montoFijo = montoFijo
                End If

                If chbCese.Checked Then

                    If dtCese.Value.ToShortDateString <> prest.fechaCese Then
                        prest.fechaCese = dtCese.Text
                    End If
                Else
                    If prest.fechaCese <> Date.MinValue Then
                        prest.fechaCese = Date.MinValue
                        prest.reactivar()
                    End If
                End If

                If txtComentario.Text.Trim <> prest.observaciones Then
                    prest.observaciones = txtComentario.Text.Trim
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
        txtCuit.Text = _prestador.cuit
        txtNombre.Text = _prestador.nombre
        txtApellido.Text = _prestador.apellido
        txtEmail.Text = _prestador.email
        cbEspecialidad.SelectedValue = _prestador.especialidad
        txtLocalidad.Text = _prestador.localidad
        numLunVie.Text = _prestador.montoNormal
        numFeriados.Text = _prestador.montoFeriado
        numDiferencial.Text = _prestador.montoDiferencial
        numFijo.Text = _prestador.montoFijo
        txtServicio.Text = _prestador.obraSocial
        dtCese.Text = _prestador.fechaCese
        chbCese.Checked = False
        cbZona.SelectedValue = _prestador.zona

        If _prestador.fechaCese <> Date.MinValue Then
            chbCese.Checked = True
            ut.desactivarTxtBoxes(txtBoxes)
        End If

        txtComentario.Text = _prestador.observaciones
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