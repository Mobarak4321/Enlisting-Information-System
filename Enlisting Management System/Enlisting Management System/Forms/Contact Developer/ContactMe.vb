Imports System.Net.Mail

Public Class ContactMe

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(fromtxt.Text, passwordtxt.Text)
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"
            e_mail = New MailMessage
            e_mail.From = New MailAddress(fromtxt.Text)
            e_mail.To.Add("Mobarakguro@Gmail.com")
            e_mail.Subject = subjecttxt.Text
            e_mail.Body = messagetxt.Text
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sended, Thank you")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class