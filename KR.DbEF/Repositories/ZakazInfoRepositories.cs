using AutoMapper;
using KR.Business.Entities;
using KR.Business.Reports;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KR.DbEF.Repositories
{
    public class ZakazInfoRepositories : IZakazInfo<ZakazInfo, zakaz>
    {
        public IEnumerable<ZakazInfo> GetList()
        {
            List<zakaz> zakaz;
            List<ZakazInfo> InfoList = new List<ZakazInfo>();
            using (LD_kursEntities db = new LD_kursEntities())
            {
                zakaz = db.zakaz.ToList<zakaz>();

                foreach (var item in zakaz)
                {
                    InfoList.Add(new ZakazInfo()
                    {
                        zakaz = Mapper.Map<Zakaz>(item),
                        land = Mapper.Map<Land>(item.land),
                        customer = Mapper.Map<Customer>(item.land.customer),
                        designer = Mapper.Map<Designer>(item.designer),
                        difficults = Mapper.Map<List<Difficulties>>(item.difficulties),
                        work = Mapper.Map<List<Work>>(item.work)
                    });
                }
            }
            return InfoList;
        }

        public IEnumerable<ZakazInfo> GetList(List<zakaz> zakaz)
        {
            List<ZakazInfo> InfoList = new List<ZakazInfo>();
            using (LD_kursEntities db = new LD_kursEntities())
            {

                foreach (var item in zakaz)
                {
                    InfoList.Add(new ZakazInfo()
                    {
                        zakaz = Mapper.Map<Zakaz>(item),
                        land = Mapper.Map<Land>(item.land),
                        customer = Mapper.Map<Customer>(item.land.customer),
                        designer = Mapper.Map<Designer>(item.designer),
                        difficults = Mapper.Map<List<Difficulties>>(item.difficulties),
                        work = Mapper.Map<List<Work>>(item.work)
                    });
                }
            }
            return InfoList;
        }

        public IEnumerable<ZakazInfo> GetList(string nameDesigner, string surnameDesigner,
                              string nameCustomer, string surnameCustomer, string price,
                              string startDate, string endDate)
        {
            IEnumerable<ZakazInfo> Zakaz;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var zakaz = db.zakaz
                    .Where(item => item.designer.name.Contains(nameDesigner))
                    .Where(item => item.designer.surname.Contains(surnameDesigner))
                    .Where(item => item.land.customer.name.Contains(nameCustomer))
                    .Where(item => item.land.customer.surname.Contains(surnameCustomer))
                    .Where(item => item.price.ToString().Contains(price))
                    .Where(item => item.start_time.ToString().Contains(startDate))
                    .Where(item => item.end_time.ToString().Contains(endDate))
                    .ToList();
                Zakaz = GetList(zakaz);
            }
            return Zakaz;
        }

        public ZakazInfo GetbyId(int id)
        {
            ZakazInfo ZkazInfo = new ZakazInfo();
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var zakaz = db.zakaz.SingleOrDefault(c => c.id == id);
                ZkazInfo = new ZakazInfo()
                {
                    zakaz = Mapper.Map<Zakaz>(zakaz),
                    land = Mapper.Map<Land>(zakaz.land),
                    customer = Mapper.Map<Customer>(zakaz.land.customer),
                    designer = Mapper.Map<Designer>(zakaz.designer),
                    difficults = Mapper.Map<List<Difficulties>>(zakaz.difficulties),
                    work = Mapper.Map<List<Work>>(zakaz.work)
                };
            }
            return ZkazInfo;
        }

        public ZakazInfo Delete(int id)
        {
            ZakazInfo Info = GetbyId(id);
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var zakaz = db.zakaz.SingleOrDefault(c => c.id == id);
                if (zakaz == null)
                    return null;
                //using (var tran = db.Database.BeginTransaction())
                //{

                foreach (var item in zakaz.difficulties.ToList())
                {
                    //db.Entry(item).State = EntityState.Deleted;
                }
                foreach (var item in zakaz.work.ToList())
                {
                    //db.Entry(item).State = EntityState.Deleted;
                }
                db.Entry(zakaz).State = EntityState.Deleted;
                db.SaveChanges();
                //}

            }
            return Info;
        }


        public OrderReport GetReport(int id)
        {
            OrderReport Report = new OrderReport();
            List<ZakazInfo> InfoList = new List<ZakazInfo>();
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var zakaz = db.zakaz.SingleOrDefault(c => c.id == id);

                Report.OrderId = zakaz.id.ToString();
                Report.start_time = zakaz.start_time;
                Report.end_time = zakaz.end_time;

                Report.DesignerName = zakaz.designer.name;
                Report.DesignerSurname = zakaz.designer.surname;

                Report.LandName = zakaz.land.name;
                Report.LandAddress = zakaz.land.addres;
                Report.LandSize = zakaz.land.size.ToString();

                Report.CustomerName = zakaz.land.customer.name;
                Report.CustomerSurname = zakaz.land.customer.surname;

                Report.WorkList = Mapper.Map<List<Work>>(zakaz.work);
                Report.DifficultiesList = Mapper.Map<List<Difficulties>>(zakaz.difficulties);
            }
            return Report;
        }

        public OrderCommonDate GetOrderReport(string time)
        {
            var Order = new OrderCommonDate();

            using (LD_kursEntities db = new LD_kursEntities())
            {
                if (time == "3")
                {
                    Order = db.Database.SqlQuery<OrderCommonDate>("AvgOrderReportMonth").SingleOrDefault();
                    Order.Period = "Month";
                }
                else
                if (time == "2")
                {
                    Order = db.Database.SqlQuery<OrderCommonDate>("AvgOrderReportYear").SingleOrDefault();
                    Order.Period = "Year";
                }
                else
                {
                    Order = db.Database.SqlQuery<OrderCommonDate>("AvgOrderReport").SingleOrDefault();
                    Order.Period = "All period";
                }
            }

            return Order;
        }

    }
}