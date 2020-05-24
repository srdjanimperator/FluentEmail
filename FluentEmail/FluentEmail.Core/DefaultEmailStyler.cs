using System;
using System.Collections.Generic;
using System.Text;

namespace FluentEmail.Core
{
    public class DefaultEmailStyler : IEmailStyler
    {
        public string GetStylesForDivWrapper()
        {
            return "style=\"max-width: 700px; background-color: #fafafa;\"";
        }

        public string GetStylesForHeading1()
        {
            return "style=\"padding: 10px; background-color: #0a2251; color: #fafafa\"";
        }

        public string GetStylesForHeading2()
        {
            return "style=\"padding: 5px; background-color: #ddd; color: #333\"";
        }

        public string GetStylesForLink()
        {
            return "style=\"padding: 8px 15px; margin: 8px; font-size: 110%; background-color: #0a2251; display: inline-block; color: #fff\"";
        }

        public string GetStylesForParagraph()
        {
            return "style=\"padding-left: 10px;\"";
        }

        public string GetStyleAttribute(string css)
        {
            return "style=\"" + css + "\"";
        }
    }
}
