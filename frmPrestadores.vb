Public Class frmPrestadores
    Dim prest As Prestador
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If cbEspecialidad.SelectedIndex = -1 Then
                Throw New Exception("SELECCIONE UNA ESPECIALIDAD")
            End If
            If IsNothing(prest) Then
                ut.validarTxtBoxLleno(txtBoxes)
                ' ut.validarLargo(txtCuit, 11)
                ut.validarMail(txtEmail.Text.Trim)
                Dim cuit = txtCuit.Text.ToString
                If cuit.Length > 1 Then
                    cuit = cuit.Insert(2, "-")
                    cuit = cuit.Insert(cuit.Length - 1, "-")
                End If
                prest = New Prestador(cuit, txtNombre.Text, txtApellido.Text.Trim, txtEmail.Text.Trim, cbEspecialidad.SelectedValue, txtLocalidad.Text.Trim, numLunVie.Text.Trim, numFeriados.Text.Trim, numFijo.Text.Trim, numPorcentaje.Text.Trim, dtCese.Text, txtServicio.Text)
                prest.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
                prest = Nothing
            Else
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarMail(txtEmail.Text.Trim)
                'ut.validarLargo(txtCuit, 11)
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
                If numLunVie.Text.Trim <> prest.montoNormal Then
                    prest.montoNormal = numLunVie.Text.Trim
                End If
                If numFeriados.Text.Trim <> prest.montoFeriado Then
                    prest.montoFeriado = numFeriados.Text.Trim
                End If
                If numPorcentaje.Text.Trim <> prest.porcentaje Then
                    prest.porcentaje = numPorcentaje.Text.Trim
                End If
                If numFijo.Text.Trim <> prest.montoFijo Then
                    prest.montoFijo = numFijo.Text.Trim
                End If

                If chbCese.Checked Then
                    If dtCese.Value.ToShortDateString <> prest.fechaCese Then
                        prest.fechaCese = dtCese.Text
                    End If
                End If

                prest.actualizar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
                prest = Nothing
            End If
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un Prestador con el mismo cuit/especialidad/localidad/servicio", utils.mensajes.err)
            Else
                ut.mensaje(ex.Message, utils.mensajes.err)
            End If

            If ex.Message.Contains("No se realizaron modificaciones") Then
                iniciarControles()
            End If
        End Try
    End Sub

    Private Sub iniciarControles()
        txtCuit.ReadOnly = False
        cbEspecialidad.SelectedIndex = -1
        ut.iniciarTxtBoxes(txtBoxes)
        numPorcentaje.Text = "0"
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
        Dim esp As New especialidad
        esp.llenarcombo(cbEspecialidad)
        dtCese.Enabled = False
        txtBoxes = {txtCuit, txtNombre, txtApellido, txtEmail, txtLocalidad, txtServicio, numLunVie, numFeriados, numFijo}
        iniciarControles()
        numPorcentaje.Text = 0
        numPorcentaje.ReadOnly = True
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
        cbEspecialidad.SelectedValue = _prestador.especialidad
        txtLocalidad.Text = _prestador.localidad
        numLunVie.Text = _prestador.montoNormal
        numFeriados.Text = _prestador.montoFeriado
        numPorcentaje.Text = _prestador.porcentaje
        numFijo.Text = _prestador.montoFijo
        txtServicio.Text = _prestador.obraSocial
        dtCese.Text = _prestador.fechaCese
        prest = _prestador
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        prest = Nothing
        txtCuit.ReadOnly = False
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmPrestadores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class