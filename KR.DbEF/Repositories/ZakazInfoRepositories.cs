using AutoMapper;
using KR.Business.Entities;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.DbEF.Repositories
{
    public class ZakazInfoRepositories //: IZakaz<Zakaz>
    {
        public IEnumerable<ZakazInfo> GetList()
        {
            List<zakaz> zakaz;
            List<ZakazInfo> InfoList = new List<ZakazInfo>();
            using (LD_kursEntities db = new LD_kursEntities())
            {
                zakaz = db.zakaz.ToList<zakaz>();
                foreach(var item in zakaz)
                {
                    InfoList.Add(new ZakazInfo()
                    {
                        zakaz = Mapper.Map<Zakaz>(item),
                        land = Mapper.Map<Land>(item.land),
                        customer = Mapper.Map<Customer>(item.land.customer),
                        designer = Mapper.Map<Designer>(item.designer),
                        difficults = Mapper.Map<Difficulties>(item.difficulties),
                        work = Mapper.Map<Work>(null)
                    });
                }  
            }
            return InfoList;
        }
    }
}