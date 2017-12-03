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
    public class ZakazInfoRepositories //: IZakazInfo<ZakazInfo>
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

        public ZakazInfo GetbyId(int id)
        {
            ZakazInfo ZkazInfo;
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


    }
}