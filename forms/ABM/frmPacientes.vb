﻿Public Class frmPacientes
    Dim pac As Paciente
    Dim modu As New Modulo
    Dim subModu As New subModulo
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim txtBoxesDA As TextBox()
    Dim carga As Boolean

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If IsNothing(pac) Then
            Try
                ut.validarTxtBoxLleno(txtBoxes)
                'ut.validarLargo(numDni, 8)
                If txtObSocial.Text = "PAMI" Then
                    ut.validarLargo(numAfiliado, 12)
                Else
                    ut.validarLargo(numAfiliado, 8)
                End If
                Dim combos = {cbModulo, cbSubModulo}
                ut.validarCombos(combos)
                '  ut.validarLargo(numAfiliado, 12)
                pac = New Paciente(numAfiliado.Text.Trim, numDni.Text.Trim, txtNombre.Text.Trim, txtApellido.Text.Trim, txtObSocial.Text.Trim, txtLocalidad.Text.Trim, txtObservacionPac.Text.Trim, cbModulo.SelectedValue, cbSubModulo.SelectedValue, dtBaja.Text.Trim)
                pac.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            Catch ex As Exception
                If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                    ut.mensaje("Ya existe un paciente con el mismo numero", utils.mensajes.err)
                Else
                    ut.mensaje(ex.Message, utils.mensajes.err)
                End If
            Finally
                pac = Nothing
            End Try

        Else
            Try
                ut.validarTxtBoxLleno(txtBoxes)
                'ut.validarLargo(numDni, 8)
                'If txtObSocial.Text.Trim.ToUpper = "PAMI" Then
                '    ut.validarLargo(numAfiliado, 12)
                'Else
                '    ut.validarLargo(numAfiliado, 8)
                'End If
                Dim combos = {cbModulo, cbSubModulo}
                ut.validarCombos(combos)

                If txtObSocial.Text.Trim <> pac.obrasocial Then
                    pac.obrasocial = txtObSocial.Text.Trim
                End If

                If txtApellido.Text.Trim <> pac.apellido Then
                    pac.apellido = txtApellido.Text.Trim
                End If

                If txtNombre.Text.Trim <> pac.nombre Then
                    pac.nombre = txtNombre.Text.Trim
                End If

                If txtObSocial.Text.Trim <> pac.obrasocial Then
                    pac.obrasocial = txtObSocial.Text.Trim
                End If

                If txtLocalidad.Text.Trim <> pac.localidad Then
                    pac.localidad = txtLocalidad.Text.Trim
                End If

                If txtObservacionPac.Text.Trim <> pac.observaciones Then
                    pac.observaciones = txtObservacionPac.Text.Trim
                End If

                If numDni.Text.Trim <> pac.dni Then
                    pac.dni = numDni.Text.Trim
                End If

                If cbModulo.SelectedValue <> pac.modulo Then
                    pac.modulo = cbModulo.SelectedValue
                End If

                If cbSubModulo.SelectedValue <> pac.subModulo Then
                    pac.subModulo = cbSubModulo.SelectedValue
                End If

                If chbBaja.Checked Then
                    If dtBaja.Value.ToShortDateString <> pac.fechaBaja Then
                        pac.fechaBaja = dtBaja.Text
                    End If
                Else
                    If pac.fechaBaja <> Date.MinValue Then
                        pac.fechaBaja = Date.MinValue
                        pac.reactivar()
                    End If
                End If

                pac.actualizar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            Catch ex As Exception
                If ex.Message.Contains("No se realizaron modificaciones") Then
                    iniciarControles()
                End If
                ut.mensaje(ex.Message, utils.mensajes.err)
            End Try
        End If
    End Sub

    Private Sub iniciarControles()
        ut.iniciarTxtBoxes(txtBoxes)
        txtObSocial.Text = "PAMI"
        txtLocalidad.Text = "CORDOBA"
        cbModulo.SelectedIndex = -1
        cbSubModulo.SelectedIndex = -1
        txtObservacionPac.Text = " "
        numAfiliado.ReadOnly = False
        chbBaja.Enabled = False
        chbBaja.Checked = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim frmBuscar As New frmBuscar(Me)
            frmBuscar.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            pac = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub txtAfiliado_TextChanged(sender As Object, e As EventArgs) Handles numAfiliado.TextChanged
        Try
            ut.validarNumerico(numAfiliado)
            If Not IsNothing(pac) Then
                pac = Nothing
            End If

        Catch ex As Exception
            numAfiliado.Text = ""
            btnBuscar.Enabled = False
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmPacientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga = True
        txtBoxes = {numAfiliado, numDni, txtApellido, txtNombre, txtObSocial, txtLocalidad}
        iniciarControles()
        modu.llenarcombo(cbModulo)
        subModu.llenarcombo(cbSubModulo)
        dtBaja.Enabled = False
    End Sub

    Private Sub cbModulo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbModulo.SelectedIndexChanged
        If Not carga Then
            If cbModulo.SelectedIndex <> -1 Then
                pac.afiliado = cbModulo.SelectedValue
            End If
        End If
    End Sub

    Private Sub cbSubModulo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cbSubModulo.SelectedIndexChanged
        If Not carga Then
            If cbSubModulo.SelectedIndex <> -1 Then
                subModu.codigo = cbSubModulo.SelectedValue
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub resultadoBusqueda(ByRef _paciente As Paciente)
        numAfiliado.ReadOnly = True
        numAfiliado.Text = _paciente.afiliado
        numDni.Text = _paciente.dni
        txtApellido.Text = _paciente.apellido
        txtNombre.Text = _paciente.nombre
        txtObSocial.Text = _paciente.obrasocial
        txtLocalidad.Text = _paciente.localidad
        dtBaja.Text = _paciente.fechaBaja
        txtObservacionPac.Text = _paciente.observaciones
        cbModulo.SelectedValue = _paciente.modulo
        cbSubModulo.SelectedValue = _paciente.subModulo

        If _paciente.fechaBaja <> Date.MinValue Then
            chbBaja.Checked = True
            ut.desactivarTxtBoxes(txtBoxes)
        Else
            chbBaja.Checked = False
        End If

        chbBaja.Enabled = True
        pac = _paciente
        btnGuardar.Enabled = True
    End Sub

    Private Sub chbBaja_TextChanged(sender As Object, e As EventArgs) Handles chbBaja.TextChanged
        Try
            If chbBaja.Text <> "" Then
                dtBaja.Enabled = True
            Else
                dtBaja.Enabled = False
            End If

        Catch ex As Exception
            chbBaja.Text = ""
            dtBaja.Enabled = False
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub chbBaja_CheckedChanged(sender As Object, e As EventArgs) Handles chbBaja.CheckedChanged
        If chbBaja.Checked = True Then
            dtBaja.Enabled = True
            ut.desactivarTxtBoxes(txtBoxes)
        Else
            dtBaja.Enabled = False
            ut.activarTxtBoxes(txtBoxes)
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        pac = Nothing
        iniciarControles()
    End Sub

    Private Sub frmPacientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class