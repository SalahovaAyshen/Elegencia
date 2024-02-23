using Elegencia.Application.Abstractions.Services.MailService;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.MailService
{
    public class MailService : IMailService
    {
     
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string ToEmail, string subject, string body, bool ishtml)
        {
            SmtpClient smtpClient = new SmtpClient(_configuration["MailSettings:Host"], Convert.ToInt32(_configuration["MailSettings:Port"]));
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_configuration["MailSettings:Mail"], _configuration["MailSettings:Password"]);
            MailAddress from = new MailAddress(_configuration["MailSettings:Mail"], "Elegencia");
            MailAddress to = new MailAddress(ToEmail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = ishtml;

                await smtpClient.SendMailAsync(message);

        }


    }
}
