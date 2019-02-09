Public Class frmZonas

    Dim zonas As Zona
    Dim ut As New utils
    Dim txtBoxes As TextBox()
    Dim db As New DB

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            If IsNothing(zonas) Then
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarNumerico(numZona)
                ut.validarMail(txtEmail.Text.Trim)
                zonas = New Zona(numZona.Text, txtNombre.Text.Trim, txtEmail.Text.Trim, txtPassw.Text.Trim, TxtPropietario.Text.Trim)
                zonas.insertar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
            Else
                Dim enc As New Encriptador()
                ut.validarTxtBoxLleno(txtBoxes)
                ut.validarNumerico(numZona)
                ut.validarMail(txtEmail.Text.Trim)
                If txtNombre.Text.Trim <> zonas.nombre Then
                    zonas.nombre = txtNombre.Text.Trim
                End If

                If txtEmail.Text.Trim <> zonas.email Then
                    zonas.email = txtEmail.Text.Trim
                End If
                If txtPassw.Text.Trim <> zonas.pass Then
                    zonas.pass = txtPassw.Text.Trim
                End If
                If TxtPropietario.Text.Trim <> zonas.propietario Then
                    zonas.propietario = TxtPropietario.Text.Trim
                End If

                zonas.actualizar()
                ut.mensaje("Guardado Exitoso", utils.mensajes.info)
                iniciarControles()
                ut.iniciarTxtBoxes(txtBoxes)
                zonas = Nothing
            End If



        Catch ex As Exception
            If ex.Message.Contains("duplicate values in the index") Or ex.Message.Contains("valores duplicados en el índice") Then
                ut.mensaje("Ya existe un paciente con el mismo numero", utils.mensajes.err)
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
            zonas = Nothing
            iniciarControles()
        End Try
    End Sub

    Public Sub resultadoBusqueda(ByRef _zonas As Zona)
        numZona.ReadOnly = True
        numZona.Text = _zonas.idzona
        txtNombre.Text = _zonas.nombre
        TxtPropietario.Text = _zonas.propietario
        txtPassw.Text = _zonas.pass
        zonas = _zonas
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        zonas = Nothing
        iniciarControles()
    End Sub

    Private Sub iniciarControles()
        numZona.ReadOnly = False
        ut.iniciarTxtBoxes(txtBoxes)
    End Sub

    Private Sub frmusuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBoxes = {numZona, txtNombre, txtEmail, txtPassw, TxtPropietario}
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmPrincipal.Show()
    End Sub

End Class