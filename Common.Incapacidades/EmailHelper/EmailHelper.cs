using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Common.EmailHelper
{
    public class EmailHelper : IEmailHelper
    {
        private readonly string notificationServer;
        private readonly int notificationPort;
        private readonly string notificationMail;
        private readonly string notificationPassword;
        private readonly bool enableSsl;
        private readonly IConfiguration _configuration;

        public EmailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            notificationServer = _configuration["EmailSettings:NotificationServer"];
            notificationPort = Convert.ToInt32(_configuration["EmailSettings:NotificationPort"]);
            notificationMail = _configuration["EmailSettings:NotificationMail"];
            notificationPassword = _configuration["EmailSettings:NotificationPassword"];
            enableSsl = Convert.ToBoolean(_configuration["EmailSettings:EnableSsl"]);
        }

        public Task<MailResponse> SendEmail(EmailModel mail)
        {
            // Crear Mail
            MailMessage netMail = new MailMessage();
            var email = notificationMail;
            var passwd = notificationPassword;
            var server = notificationServer;
            var port = notificationPort;

            netMail.From = new MailAddress(email, mail.FromDisplayName);

            mail.Addressee.To.ForEach(fe => netMail.To.Add(new MailAddress(fe)));

            // Agregar CC
            if (mail.Addressee.CC.Any())
                foreach (string CC in mail.Addressee.CC)
                    if (!string.IsNullOrEmpty(CC))
                        netMail.CC.Add(new MailAddress(CC));

            // Agregar CCO
            if (mail.Addressee.CCO.Any())
                foreach (string CCO in mail.Addressee.CCO)
                    if (!string.IsNullOrEmpty(CCO))
                        netMail.Bcc.Add(new MailAddress(CCO));

            if (!string.IsNullOrEmpty(Environment.MachineName) && !Environment.MachineName.ToLower().StartsWith("pro"))
            {
                mail.Subject = $"{mail.Subject}";
            }
            netMail.Subject = mail.Subject;
            netMail.Body = mail.Body.HtmlContent;

            

            if (mail.Attachements.Any())
            {
                foreach (var att in mail.Attachements)
                {
                    netMail.Attachments.Add(att);
                }
            }

            netMail.IsBodyHtml = true;

            try
            {
                // Crear el cliente y enviar el correo
                using (SmtpClient client = new SmtpClient(server, port))
                {
                    
                    client.Credentials = new System.Net.NetworkCredential(email, passwd);
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = enableSsl;

                    client.Send(netMail);
                    return Task.FromResult<MailResponse>(new MailResponse()
                    {
                        Type = "Success",
                        Message = "SendSuccess"
                    });
                }
            }
            catch (Exception e)
            {
                return Task.FromResult<MailResponse>(new MailResponse()
                {
                    Type = "Error",
                    Message = $"{e.Message}"
                });
            }
        }
    }

    public class MailResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}