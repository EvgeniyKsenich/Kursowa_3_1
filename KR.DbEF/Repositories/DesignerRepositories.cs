using AutoMapper;
using KR.Business.Entities;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace KR.DbEF.Repositories
{
    public class DesignerRepositories : IDesigner<Designer>
    {
        public IEnumerable<Designer> GetList()
        {
            List<designer> user;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                user = db.designer.ToList<designer>();
            }
            return Mapper.Map<List<Designer>>(user.OrderByDescending(x => x.id));
        }

        public void Save(Designer user)
        {
            if (user != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    db.designer.Add(Mapper.Map<designer>(user));
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Couldn't save null instance");
            }
        }

        public int Edit(Designer user)
        {
            if (user != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    db.Entry(Mapper.Map<designer>(user)).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Couldn't save null instance");
            }
        }

        public Designer GetbyId(int id)
        {
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var user = db.designer.SingleOrDefault(c => c.id == id);
                return Mapper.Map<Designer>(user);
            }
        }

        public Designer Delete(int id)
        {
            var user = GetbyId(id);
            if (user != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    //db.items.Remove(user);
                    db.Entry(Mapper.Map<designer>(user)).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            return user;
        }

    }
}