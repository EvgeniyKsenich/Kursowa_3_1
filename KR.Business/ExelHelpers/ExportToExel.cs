using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using OfficeOpenXml;
using KR.Business.Entities;
using KR.Business.Repositories;
using KR.Business.ExelModels;

namespace KR.Business.ExelHelpers
{
    public class ExportToExel
    {
        public static MemoryStream Download(ZakazExelModel List)
        {
            MemoryStream memStream;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("New Sheet");

                worksheet.Cells[1, 1].Value = "Orders";
                worksheet.Cells[2, 1].Value = "id";
                worksheet.Cells[2, 2].Value = "designer_id";
                worksheet.Cells[2, 3].Value = "land_id";
                worksheet.Cells[2, 4].Value = "price";
                worksheet.Cells[2, 5].Value = "start_time";
                worksheet.Cells[2, 6].Value = "end_time";

                int m = 3;
                foreach (var orders in List.Orders)
                {
                    worksheet.Cells[m, 1].Value = orders.id;
                    worksheet.Cells[m, 2].Value = orders.designer_id;
                    worksheet.Cells[m, 3].Value = orders.land_id;
                    worksheet.Cells[m, 4].Value = orders.price;
                    worksheet.Cells[m, 5].Value = orders.start_time.ToString();
                    worksheet.Cells[m, 6].Value = orders.end_time.ToString();
                    m++;
                }

                worksheet.Cells[1, 8].Value = "Designers";
                worksheet.Cells[2, 8].Value = "id";
                worksheet.Cells[2, 9].Value = "name";
                worksheet.Cells[2, 10].Value = "surname";
                worksheet.Cells[2, 11].Value = "dateOfBirth";

                m = 3;
                foreach (var orders in List.Designers)
                {
                    worksheet.Cells[m, 8].Value = orders.id;
                    worksheet.Cells[m, 9].Value = orders.name;
                    worksheet.Cells[m, 10].Value = orders.surname;
                    worksheet.Cells[m, 11].Value = orders.dateOfBirth.ToString();
                    m++;
                }

                worksheet.Cells[1, 13].Value = "Customers";
                worksheet.Cells[2, 13].Value = "id";
                worksheet.Cells[2, 14].Value = "name";
                worksheet.Cells[2, 15].Value = "surname";
                worksheet.Cells[2, 16].Value = "dateOfBirth";

                m = 3;
                foreach (var orders in List.Customers)
                {
                    worksheet.Cells[m, 13].Value = orders.id;
                    worksheet.Cells[m, 14].Value = orders.name;
                    worksheet.Cells[m, 15].Value = orders.surname;
                    worksheet.Cells[m, 16].Value = orders.dateOfBirth.ToString();
                    m++;
                }

                worksheet.Cells[1, 18].Value = "Lands";
                worksheet.Cells[2, 18].Value = "id";
                worksheet.Cells[2, 19].Value = "name";
                worksheet.Cells[2, 20].Value = "customer_id";
                worksheet.Cells[2, 21].Value = "size";
                worksheet.Cells[2, 22].Value = "address";

                m = 3;
                foreach (var items in List.Lands)
                {
                    worksheet.Cells[m, 18].Value = items.id;
                    worksheet.Cells[m, 19].Value = items.name;
                    worksheet.Cells[m, 20].Value = items.customer_id;
                    worksheet.Cells[m, 21].Value = items.size;
                    worksheet.Cells[m, 22].Value = items.addres;
                    m++;
                }

                worksheet.Cells[1, 24].Value = "Works";
                worksheet.Cells[2, 24].Value = "id";
                worksheet.Cells[2, 25].Value = "typee";
                worksheet.Cells[2, 26].Value = "count";
                worksheet.Cells[2, 27].Value = "price";
                worksheet.Cells[2, 28].Value = "zakazId";

                m = 3;
                foreach (var items in List.Works)
                {
                    worksheet.Cells[m, 24].Value = items.id;
                    worksheet.Cells[m, 25].Value = items.typee;
                    worksheet.Cells[m, 26].Value = items.countt;
                    worksheet.Cells[m, 27].Value = items.price;
                    worksheet.Cells[m, 28].Value = items.zakazId;
                    m++;
                }

                worksheet.Cells[1, 30].Value = "Difficulties";
                worksheet.Cells[2, 30].Value = "id";
                worksheet.Cells[2, 31].Value = "subject";
                worksheet.Cells[2, 32].Value = "price";

                m = 3;
                foreach (var items in List.Difficults)
                {
                    worksheet.Cells[m, 30].Value = items.id;
                    worksheet.Cells[m, 31].Value = items.price;
                    worksheet.Cells[m, 32].Value = items.price;
                    m++;
                }

                worksheet.Cells[1, 34].Value = "OrderDifficulties";
                worksheet.Cells[2, 34].Value = "difficultiesId";
                worksheet.Cells[2, 35].Value = "orderId";

                m = 3;
                foreach (var items in List.OrdersInfo)
                {
                    worksheet.Cells[m, 30].Value = items.DifficultiesId;
                    worksheet.Cells[m, 31].Value = items.OrderId;
                    m++;
                }

                memStream = new MemoryStream(package.GetAsByteArray());
            }

            return memStream;
        }


    }
}