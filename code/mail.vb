Imports System.Net.Mail
Imports System.Net
Imports System.IO
Public Class Mail

    Dim liqui As Liquidacion
    Dim client As SmtpClient = New SmtpClient()
    Dim NetworkCred As NetworkCredential

    Public Sub New()
        Dim db As New DB

        With client
            .EnableSsl = True
            .Port = 587
            .UseDefaultCredentials = True
        End With
    End Sub

    Public Sub send(_liq As Liquidacion)

        Try
            Dim zona As New Zona
            Dim mail As String = My.Resources.mailTemplate
            Dim mm As MailMessage = New MailMessage()
            Dim totalFinal As Decimal
            Dim attachment As Attachment

            mail = mail.Replace("[MES]", MonthName(_liq.mes.Month))
            mail = mail.Replace("[YEAR]", _liq.mes.Year)
            totalFinal = _liq.montoFijo + _liq.importeFeriado + _liq.importeNormal + _liq.importeDiferencial
            mail = mail.Replace("[MONTO_TOTAL]", totalFinal.ToString("F"))
            mail = mail.Replace("[OBS]", _liq.observaciones)
            mail = mail.Replace("[APELLIDO]", _liq.prestador.apellido.ToUpper)
            mail = mail.Replace("[NOMBRE]", _liq.prestador.nombre.ToUpper)
            mail = mail.Replace("[SERVICIO]", _liq.prestador.servicio)

            zona.idzona = _liq.prestador.zona
            Dim mailFrom = zona.email.ToLower

            mm.From = New MailAddress(mailFrom)
            mm.Subject = "Liquidacion HomeCare " & MonthName(_liq.mes.Month)
            mm.IsBodyHtml = True
            mm.Body = mail
            mm.To.Add(New MailAddress(_liq.prestador.mail))
            attachment = New Attachment(Path.Combine(My.Application.Info.DirectoryPath, "Resources\logo.jpg"))
            attachment.ContentId = "logo.jpg"
            mm.Attachments.Add(attachment)

            If mailFrom.EndsWith("gmail.com") Then
                client.Host = "smtp.gmail.com"
            ElseIf mailFrom.EndsWith("hotmail.com") Or mailFrom.EndsWith("outlook.com") Then
                client.Host = "smtp.live.com"
            End If

            client.Credentials = New NetworkCredential(zona.email, zona.pass)
            client.Send(mm)

        Catch ex As Exception
            Throw New Exception("Error enviando mail: " & ex.Message)
        End Try
    End Sub

End Class
