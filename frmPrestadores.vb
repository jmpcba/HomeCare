Public Class frmPrestadores
    Dim prestadores As Prestador
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(prestadores) Then
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarLargo(txtCuit, 11)
                prestadores = New Prestador(txtCuit.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtEspecialidad.Text, txtLocalidad.Text, numLunVie.Text, numFeriados.Text, numFijo.Text, numPorcentaje.Text, dtCese.Text)
                prestadores.insertar()
                MessageBox.Show("Guardado Exitoso")
                iniciarControles()
            Else
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarLargo(txtCuit, 11)
                If txtNombre.Text <> prestadores.nombre Then
                    prestadores.nombre = txtNombre.Text
                End If
                If txtApellido.Text <> prestadores.apellido Then
                    prestadores.apellido = txtApellido.Text
                End If
                If txtEmail.Text <> prestadores.email Then
                    prestadores.email = txtEmail.Text
                End If
                If txtEspecialidad.Text <> prestadores.especialidad Then
                    prestadores.especialidad = txtEspecialidad.Text
                End If
                If txtLocalidad.Text <> prestadores.localidad Then
                    prestadores.localidad = txtLocalidad.Text
                End If
                If numLunVie.Text <> prestadores.montoNormal Then
                    prestadores.montoNormal = numLunVie.Text
                End If
                If numFeriados.Text <> prestadores.montoFeriado Then
                    prestadores.montoFeriado = numFeriados.Text
                End If
                If numPorcentaje.Text <> prestadores.porcentaje Then
                    prestadores.porcentaje = numPorcentaje.Text
                End If
                If numFijo.Text <> prestadores.montoFijo Then
                    prestadores.montoFijo = numFijo.Text
                End If
                If dtCese.Text <> prestadores.fechaCese Then
                    prestadores.fechaCese = dtCese.Text
                End If

                prestadores.actualizar()
                ut.iniciarTxtBoxes(txtBoxes)
                prestadores = Nothing
                MessageBox.Show("Guardado Exitoso")
            End If
        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                MessageBox.Show("Ya existe un Prestador con el mismo cuit/especialidad/localidad")
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            prestadores = New Prestador
            txtNombre.Text = prestadores.nombre
            txtApellido.Text = prestadores.apellido
            txtEmail.Text = prestadores.email
            txtEspecialidad.Text = prestadores.especialidad
            txtLocalidad.Text = prestadores.localidad
            numLunVie.Text = prestadores.montoFijo
            numFeriados.Text = prestadores.montoFeriado
            numPorcentaje.Text = prestadores.porcentaje
            numFijo.Text = prestadores.montoFijo
            dtCese.Text = prestadores.fechaCese
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            prestadores = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub iniciarControles()
        txtCuit.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtEmail.Text = ""
        txtEspecialidad.Text = ""
        txtLocalidad.Text = ""
        numLunVie.Text = ""
        numFeriados.Text = ""
        numPorcentaje.Text = ""
        numFijo.Text = ""
        dtCese.Text = ""
    End Sub

    Private Sub txtCuit_TextChanged(sender As Object, e As EventArgs) Handles txtCuit.TextChanged
        Try
            If txtCuit.Text <> "" Then
                btnBuscar.Enabled = True
            Else
                btnBuscar.Enabled = False
            End If
            ut.validarNumerico(txtCuit)
            If Not IsNothing(prestadores) Then
                prestadores = Nothing
            End If

        Catch ex As Exception
            txtCuit.Text = ""
            btnBuscar.Enabled = False
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmprestadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        txtBoxes = {txtCuit, txtNombre, txtApellido, txtEmail, txtEspecialidad, txtLocalidad, numLunVie, numFeriados, numFijo, numPorcentaje, dtCese}
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

End Class