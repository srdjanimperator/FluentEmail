using System;
using System.Collections.Generic;
using System.Text;

namespace FluentEmail.Core
{
    public class EmailTemplateBuilder
    {
        private readonly IEmailStyler _emailStyler;

        private string _message = String.Empty;

        public EmailTemplateBuilder(IEmailStyler emailStyler) 
        {
            _emailStyler = emailStyler;

            _message = "<div " + _emailStyler.GetStylesForDivWrapper() + ">";
        }


        public EmailTemplateBuilder AddHeading1(string content)
        {
            _message += String.Format("<h1 {0}>{1}</h1>", _emailStyler.GetStylesForHeading1(), content);
            return this;
        }

        public EmailTemplateBuilder AddHeading2(string content)
        {
            _message += String.Format("<h2 {0}>{1}</h2>", _emailStyler.GetStylesForHeading2(), content);
            return this;
        }

        public EmailTemplateBuilder AddHeading3(string content)
        {
            _message += String.Format("<h3 {0}>{1}</h3>", _emailStyler.GetStylesForHeading2(), content);
            return this;
        }

        public EmailTemplateBuilder AddParagraph(string content)
        {
            _message += String.Format("<p {0}>{1}</p>", _emailStyler.GetStylesForParagraph(), content);
            return this;
        }

        public EmailTemplateBuilder AddLink(string url, string label = null)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            label = label != null ? label : url;

            _message += String.Format("<a {0} href=\"{1}\">{2}</a>", _emailStyler.GetStylesForLink(), url, label);
            return this;
        }

        public EmailTemplateBuilder AddImage(string imageUrl, string alt = null)
        {
            if (imageUrl == null)
            {
                throw new ArgumentNullException("imageUrl");
            }

            alt = alt != null ? alt : "No image to display";

            _message += String.Format("<img src=\"{0}\" alt=\"{1}\" />", imageUrl, alt);
            return this;
        }

        public EmailTemplateBuilder Bind(Dictionary<string, string> bindingVariables)
        {
            var builder = new StringBuilder(_message);

            foreach(var item in bindingVariables)
            {
                builder.Replace("[" + item.Key + "]", item.Value);
            }

            _message = builder.ToString();

            return this;
        }

        public string Build()
        {
            return _message + "</div>";
        }
    }
}
