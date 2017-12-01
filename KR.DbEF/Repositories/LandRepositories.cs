using AutoMapper;
using KR.Business.Entities;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace KR.DbEF.Repositories
{
    public class LandRepositories : ILand<Land>
    {
        public IEnumerable<Land> GetList()
        {
            List<land> Lands;
            List<Land> List;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                Lands = db.land.ToList<land>();
                List = Mapper.Map<List<Land>>(Lands.OrderByDescending(x => x.id));
            }
            return List;
        }

        public IEnumerable<Land> GetListForUser(int customerId)
        {
            List<land> Lands;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                Lands = db.land
                    .Where(f => f.customer_id == customerId)
                    .ToList<land>();
            }
            return Mapper.Map<List<Land>>(Lands.OrderByDescending(x => x.id));
        }

        public void Save(Land _land)
        {
            if (_land != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    db.land.Add(Mapper.Map<land>(_land));
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Couldn't save null instance");
            }
        }

        public int Edit(Land _land)
        {
            if (_land != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    db.Entry(Mapper.Map<land>(_land)).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Couldn't save null instance");
            }
        }

        public Land GetbyId(int id)
        {
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var user = db.land.SingleOrDefault(c => c.id == id);
                return Mapper.Map<Land>(user);
            }
        }

        public Land Delete(int id)
        {
            var land = GetbyId(id);
            if (land != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    db.Entry(Mapper.Map<land>(land)).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            return land;
        }

    }
}