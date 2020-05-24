using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentEmail.ViewModels
{
    public class SendEmailRequest
    {
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
