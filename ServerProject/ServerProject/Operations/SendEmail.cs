using ClientProject.Models;
using System;
using System.Net.Mail;
using System.Text;

namespace ServerProject.Operations
{
    public static class SendEmail
    {

        public static void send(DataTransfer data)
        {
            try
            {
                SmtpClient mySmtpClient = new SmtpClient("smtp.live.com");

                mySmtpClient.Port = 587;
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential("vitor_gamer22@hotmail.com", "Saopaulo2014");
                mySmtpClient.Credentials = basicAuthenticationInfo;
                mySmtpClient.EnableSsl = true;

                MailAddress from = new MailAddress("vitor_gamer22@hotmail.com", "Vitor Gamer");
                MailAddress to = new MailAddress("vitor_hugonascimento@hotmail.com", "Vitor Hugo do Nascimento");
                MailMessage myMail = new MailMessage(from, to);

                myMail.Subject = "Send Squids";
                myMail.SubjectEncoding = Encoding.UTF8;

                myMail.Body = @$"<b>Dados:</b>
                                <br>
                                <b>tempo de leitura do client:</b>{data.Client}
                                <br>
                                <b>tempo de 'parse' do arquivo em objeto:</b>{data.Parse}
                                <br>
                                <b>tempo de transferencia:</b>{data.Transfer}
                                <br>
                                <b>tempo do processo do server:</b>{data.Server}
                                <br> 
                                <b>tempo total do processo:</b>{data.Full}
                                <br>
                                <b>total de registros:</b>{data.Registros}";
                myMail.BodyEncoding = Encoding.UTF8;
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
            }
            catch (SmtpException ex)
            {
                throw new ApplicationException
                  ("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
