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
    public class OrderDateReportBilders : ReportBilders
    {
        public static Byte[] GetReport(OrderCommonDate report)
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
                    "<h1 class=\"id\">Period:", report.Period, "<h1/>",
                    "Land Size:", "<br />",
                    "AVG:", report.AvgLandSize, "<br />",
                    "Max:", report.MaxLandSize, "<br />",
                    "Min:", report.MinLandSize, "<br />",
                    "<br />",
                    "<br />",
                    "Work Count in sigle work:", "<br />",
                    "AVG:", report.AvgWorkCount, "<br />",
                    "Max:", report.MaxWorkCount, "<br />",
                    "Min:", report.MinWorkCount, "<br />",
                "</body>",
                "</html>"
                );

            return PdfSharpConvert(Html);
        }
    }
}