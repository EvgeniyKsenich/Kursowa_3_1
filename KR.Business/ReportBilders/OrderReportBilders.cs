using KR.Business.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TheArtOfDev.HtmlRenderer.Core;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace KR.Business.ReportBilders
{
    public class OrderReportBilders : ReportBilders
    {
        public static Byte[] GetReport(OrderReport report)
        {
            string workList = GetWorkList(report);
            string difficultiesList = GetDifficulties(report);

            String Html = String.Concat(
                "<html>",
                "<head>",
                    "<style>",
                    "body {font-size:16}",
                    ".id {text-align:center}",
                    "</style>",
                "</head>",
                "<body>",
                    "<h1 class=\"id\">Order:", report.OrderId, "<h1/>",
                    "<span>Price:", report.price, "<span/><br/>",
                    "Start Date: ", report.start_time, "<br/>",
                    "End Date: ", report.end_time, "<br/>",
                    "<br/>",
                    "Customer: ", report.CustomerName, " ", report.CustomerSurname, "<br/>",
                    "<br/>",
                    "Land: ", "<br/>",
                    "Name: ", report.LandAddress, "<br/>",
                    "Address:", report.LandAddress, "<br/>",
                    "Size:", report.LandSize, "<br/>",
                    "<br/>",
                    "<br/>",
                    "Designer: ", report.DesignerName, " ", report.DesignerSurname, "<br/>",
                    workList, "</br>",
                    "<br/>",
                    difficultiesList, "</br>",
                    "<br/>",
                "</body>",
                "</html>"
                );

            return PdfSharpConvert(Html);
        }

        public static string GetWorkList(OrderReport report)
        {
            String Html = String.Concat(
                "Work List :" , "</br>"
                );
            foreach(var item in report.WorkList)
            {
                Html += String.Concat(
                     "Type:  ",item.typee, "  Count:", item.countt, "  Price:", item.price, "</br>"
                    );
            }

            return Html;
        }

        public static string GetDifficulties(OrderReport report)
        {
            String Html = String.Concat(
                "Difficulties List :", "</br>"
                );
            foreach (var item in report.DifficultiesList)
            {
                Html += String.Concat(
                     "Subject:  ", item.subj, "  Price:", item.price, "</br>"
                    );
            }

            return Html;
        }
    }
}