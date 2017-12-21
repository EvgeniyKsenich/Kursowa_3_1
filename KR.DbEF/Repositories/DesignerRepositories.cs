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
            List<Designer> List;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                user = db.designer.ToList<designer>();
                List = Mapper.Map<List<Designer>>(user.OrderByDescending(x => x.id));
            }
            return List;
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

        private designer GetbyIduser(int id)
        {
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var user = db.designer.SingleOrDefault(c => c.id == id);
                return (user);
            }
        }

        public Designer Delete(int id)
        {
            var user = GetbyIduser(id);
            if (user != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var orders = db.zakaz.Where(x => x.designer_id == id).ToList();
                            foreach (var zakaz in orders)
                            {
                                var wk = db.work.Where(x => x.zakazId == zakaz.id).ToList();
                                foreach (var it in wk)
                                {
                                    db.Entry(it).State = EntityState.Deleted;
                                }
                                db.Entry(zakaz).State = EntityState.Deleted;
                            }
                            db.Entry(user).State = EntityState.Deleted;
                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            return Mapper.Map<Designer>(user);
        }


    }
}