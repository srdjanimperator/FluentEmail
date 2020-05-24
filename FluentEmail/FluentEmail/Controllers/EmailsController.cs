using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly Sender _sender;

        public EmailsController(Sender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Send(SendEmailRequest request)
        {
            var recipient = request.Recipient;
            var subject = request.Subject;

            var dict = new Dictionary<string, string>();
            dict.Add("ime", "srdjan");
            dict.Add("posiljalac", "Test@test.com");

            var message = new EmailTemplateBuilder(new DefaultEmailStyler())
                                .AddHeading1(subject)
                                .AddParagraph("Zdravo [ime],")
                                .AddParagraph("primili ste posiljku od [posiljalac]")
                                .AddParagraph("Ovo je jos jedan testni paragraf")
                                .AddLink("www.verto.rs", "Otvori Verto")
                                //.AddImage("https://th.bing.com/th/id/OIP.c0doCNZwZcn2uK6YR3e1jAHaD4?pid=Api&rs=1")
                                .Bind(dict)
                                .Build();

            _sender.Dispatch(recipient, subject, message);

            return NoContent();
        }
    }
}
