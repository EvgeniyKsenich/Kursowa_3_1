using AutoMapper;
using KR.Business.Entities;
using KR.Business.ExelModels;
using System.Collections.Generic;
using System.Linq;

namespace KR.DbEF.Repositories
{
    public class ExportRepositories
    {
        public ZakazExelModel GetList()
        {
            ZakazExelModel Model = new ZakazExelModel();
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var orders = db.zakaz;
                Model.Customers = Mapper.Map<List<Customer>>(db.customer.ToList<customer>());
                Model.Designers = Mapper.Map<List<Designer>>(db.designer.ToList<designer>());
                Model.Lands = Mapper.Map<List<Land>>(db.land.ToList<land>());
                Model.Works = Mapper.Map<List<Work>>(db.work.ToList<work>());
                Model.Difficults = Mapper.Map<List<Difficulties>>(db.difficulties.ToList<difficulties>());
                Model.Orders = Mapper.Map<List<Zakaz>>(db.zakaz.ToList<zakaz>());

                var OrdersInfo = new List<OrderInfo>();
                foreach (var item in orders)
                {
                    foreach (var diff in item.difficulties)
                    {
                        OrdersInfo.Add(new OrderInfo()
                        {
                            DifficultiesId = diff.id,
                            OrderId = item.id
                        });
                    }
                }

                Model.OrdersInfo = OrdersInfo;
            }
            return Model;
        }
    }
}