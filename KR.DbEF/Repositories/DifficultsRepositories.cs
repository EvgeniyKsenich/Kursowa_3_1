using AutoMapper;
using KR.Business.Entities;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.DbEF.Repositories
{
    public class DifficultsRepositories //: IWork<Work>
    {
        public int Save(int orderId, int DifficultsId)
        {
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var order = db.zakaz.SingleOrDefault(c => c.id == orderId);
                var diff = db.difficulties.SingleOrDefault(c => c.id == DifficultsId);
                if(order == null || diff == null)
                {
                    return -1;
                }
                order.difficulties.Add(diff);
                db.SaveChanges();
            }
            return DifficultsId;
        }

        public Difficulties Remove(int orderId, int DifficultsId)
        {
            Difficulties difficults = new Difficulties();
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var order = db.zakaz.SingleOrDefault(c => c.id == orderId);
                var diff = db.difficulties.SingleOrDefault(c => c.id == DifficultsId);
                if (order == null || diff == null)
                {
                    return null;
                }
                order.difficulties.Remove(diff);
                db.SaveChanges();
                difficults = Mapper.Map<Difficulties>(diff);
            }
            return difficults;
        }
    }
}