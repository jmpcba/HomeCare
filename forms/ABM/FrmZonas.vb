Public Class frmZonas

    Dim zona As Zona
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim db As New DB
    Dim cz As ControllerZona

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click


        If IsNothing(zona) Then
            Try
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarNumerico(numZona)
                ut.validarMail(txtEmail.Text.Trim)
                cz.insertar(txtNombre.Text.Trim.ToUpper, txtEmail.Text.Trim, txtPassw.Text.Trim, TxtPropietario.Text.Trim)
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()

            Catch ex As ExcepcionDeSistema
                iniciarControles()
                ut.mensaje(ex.Message, utils.mensajes.err)
            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            Finally
                zona = Nothing
            End Try

        Else
            Try
                Dim modificado As Boolean = False
                Dim enc As New Encriptador()
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarNumerico(numZona)
                ut.validarMail(txtEmail.Text.Trim)

                If txtNombre.Text.Trim <> zona.nombre Then
                    zona.nombre = txtNombre.Text.Trim
                    modificado = True
                End If

                If txtEmail.Text.Trim <> zona.mail Then
                    zona.mail = txtEmail.Text.Trim
                    modificado = True
                End If
                If txtPassw.Text.Trim <> zona.pwd Then
                    zona.pwd = txtPassw.Text.Trim
                    modificado = True
                End If
                If TxtPropietario.Text.Trim <> zona.propietario Then
                    zona.propietario = TxtPropietario.Text.Trim
                    modificado = True
                End If

                If modificado Then
                    cz.actualizar(zona)
                    ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                    iniciarControles()
                    ut.iniciarTxtBoxes(txtBoxes)
                    zona = Nothing
                Else
                    ut.mensaje("No se realizaron cambios", utils.mensajes.err)
                End If

            Catch ex As ExcepcionDeSistema
                iniciarControles()
                ut.mensaje(ex.Message, utils.mensajes.err)
            Catch ex As Exception
                ut.mensaje(ex.Message, utils.mensajes.err)
            End Try
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim frmBuscar As New frmBuscar(Me)
            frmBuscar.ShowDialog()
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
            zona = Nothing
            iniciarControles()
        End Try
    End Sub

    Public Sub resultadoBusqueda(ByRef _zonas As Zona)
        numZona.ReadOnly = True
        numZona.Text = _zonas.id
        txtNombre.Text = _zonas.nombre
        TxtPropietario.Text = _zonas.propietario
        txtPassw.Text = _zonas.pwd
        txtEmail.Text = _zonas.mail
        zona = _zonas
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        zona = Nothing
        iniciarControles()
    End Sub

    Private Sub iniciarControles()
        numZona.Text = ""
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmusuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtBoxes = {txtNombre, txtEmail, txtPassw, TxtPropietario}
            cz = New ControllerZona(False)
        Catch ex As Exception
            ut.mensaje(ex.Message, utils.mensajes.err)
        End Try
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub

End Class