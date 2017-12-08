using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TheArtOfDev.HtmlRenderer.Core;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace KR.Business.ReportBilders
{
    public class ReportBilders
    {
        public static Byte[] PdfSharpConvert(String html )
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }
            return res;
        }
    }
}