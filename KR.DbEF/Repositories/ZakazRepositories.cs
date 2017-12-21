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
    public class ZakazRepositories : IZakaz<Zakaz>
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

        public Zakaz Save(Zakaz _zakaz)
        {
            Zakaz returnZakaz;
            if (_zakaz != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    var zakaz = Mapper.Map<zakaz>(_zakaz);
                    db.zakaz.Add(zakaz);
                    db.SaveChanges();
                    returnZakaz = Mapper.Map<Zakaz>(zakaz);
                }
            }
            else
            {
                throw new Exception("Couldn't save null instance");
            }
            return returnZakaz;
        }

        public Zakaz Edit(Zakaz _zakaz)
        {
            Zakaz returnZakaz;
            if (_zakaz != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    var zakaz = Mapper.Map<zakaz>(_zakaz);
                    db.Entry(zakaz).State = EntityState.Modified;
                    db.SaveChanges();
                    returnZakaz = Mapper.Map<Zakaz>(zakaz);
                }
            }
            else
            {
                throw new Exception("Couldn't edit null instance");
            }
            return returnZakaz;
        }

        public Zakaz Get(int id)
        {
            Zakaz returnZakaz;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var zakaz = db.zakaz.SingleOrDefault(c => c.id == id);
                returnZakaz = Mapper.Map<Zakaz>(zakaz);
            }
            return returnZakaz;
        }

    }
}