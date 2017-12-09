using AutoMapper;
using KR.Business.Entities;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KR.DbEF.Repositories
{
    public class SingleOrderRepositories : ISingleOrder<SingleOrder>
    {
       
        public SingleOrder GetbyId(int id)
        {
            SingleOrder order = new SingleOrder();
            ZakazInfo ZkazInfo;
            List<Difficulties> difficults;
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
                difficults = Mapper.Map<List<Difficulties>>(db.difficulties.ToList<difficulties>());
            }
            order.ZakazInfo = ZkazInfo;
            order.AllPosibleDifficults = difficults;
            return order;
        }
    }
}