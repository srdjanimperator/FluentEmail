using System;
using System.Collections.Generic;
using System.Text;

namespace FluentEmail.Core
{
    public interface IEmailStyler
    {
        string GetStylesForDivWrapper();
        string GetStylesForParagraph();
        string GetStylesForHeading1();
        string GetStylesForHeading2();
        string GetStylesForLink();
        string GetStyleAttribute(string css);
    }
}
