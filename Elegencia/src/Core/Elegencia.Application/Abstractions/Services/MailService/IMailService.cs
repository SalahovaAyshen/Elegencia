using Elegencia.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services.MailService
{
    public interface IMailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml=true);
    }
}
