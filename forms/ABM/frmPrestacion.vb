Public Class frmPrestacion
    Dim prestacion As Prestacion
    Dim ut As New utils
    Dim txtBoxes As TextBox()

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If IsNothing(prestacion) Then
                ut.validarLargo(numPresCod, 6)
                ut.validarTxtBoxLleno(txtBoxes)
                prestacion = New Prestacion(numPresCod.Text, txtDescri.Text)
                prestacion.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            Else
                ut.validarLargo(numPresCod, 6)
                ut.validarTxtBoxLleno(txtBoxes)

                If txtDescri.Text <> prestacion.descripcion Then
                    prestacion.descripcion = txtDescri.Text
                End If

                prestacion.actualizar()
                ut.iniciarTxtBoxes(txtBoxes)
                prestacion = Nothing
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
            prestacion = New Prestacion
            prestacion.codigo = numPresCod.Text
            txtDescri.Text = prestacion.descripcion
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            prestacion = Nothing
            iniciarControles()
        End Try
    End Sub

    Private Sub iniciarControles()
        numPresCod.Text = ""
        txtDescri.Text = ""
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles numPresCod.TextChanged
        Try
            If numPresCod.Text <> "" Then
                btnBuscar.Enabled = True
            Else
                btnBuscar.Enabled = False
            End If
            ut.validarNumerico(numPresCod)

            If Not IsNothing(prestacion) Then
                prestacion = Nothing
            End If

        Catch ex As Exception
            numPresCod.Text = ""
            btnBuscar.Enabled = False
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub

    Private Sub frmprestacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBuscar.Enabled = False
        txtBoxes = {numPresCod, txtDescri}
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtDescri.TextChanged

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmPrestacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub
End Class