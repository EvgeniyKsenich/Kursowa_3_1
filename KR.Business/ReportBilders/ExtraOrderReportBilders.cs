using KR.Business.Entities;
using KR.Business.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TheArtOfDev.HtmlRenderer.Core;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace KR.Business.ReportBilders
{
    public class ExtraOrderReportBilders : ReportBilders
    {
        public static Byte[] GetReport(OrderExtraReport report)
        {
            String Html = String.Concat(
                "<html>",
                "<head>",
                    "<style>",
                    "body {font-size:16}",
                    ".id {text-align:center}",
                    "</style>",
                "</head>",
                "<body>",
                    "<span>", "Period:" ,report.Period, "</span>", "<br/>",
                    "<span>", "Land Linq min:", report.LandVariable, "</span>", "<br/>",
                    "Land:", "<br/>",
                    "Avg size:", report.AvgLandSize, "<br/>",
                    "Min size:", report.MinLandSize, "<br/>",
                    "Max size:", report.MaxLandSize, "<br/>",
                    "First date in period:", report.MinStartTime, "<br/>",
                    "Last date in period:", report.MaxStartTime, "<br/>",
                "</body>",
                "</html>"
                );

            return PdfSharpConvert(Html);
        }
    }
}