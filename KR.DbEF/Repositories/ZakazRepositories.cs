using AutoMapper;
using KR.Business.Entities;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.DbEF.Repositories
{
    public class ZakazRepositories //: IZakaz<Zakaz>
    {
        public IEnumerable<Zakaz> GetList()
        {
            List<zakaz> zakaz;
            List<Zakaz> Zakaz;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                zakaz = db.zakaz.ToList<zakaz>();
                Zakaz = Mapper.Map<List<Zakaz>>(zakaz.OrderByDescending(x => x.id));
            }
            return Zakaz;
        }
    }
}