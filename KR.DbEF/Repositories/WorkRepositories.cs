using AutoMapper;
using KR.Business.Entities;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KR.DbEF.Repositories
{
    public class WorkRepositories //: IWork<Work>
    {
        public int Save(int orderId, Work Work)
        {
            int result = -1;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var order = db.zakaz.SingleOrDefault(m => m.id == orderId);
                var work = Mapper.Map<work>(Work);
                if(order != null && work != null)
                {
                    order.work.Add(work);
                    db.SaveChanges();
                    result = work.id;
                }
                
            }
            return result;
        }

        public Work Remove(int orderId, int WorkId)
        {
            Work Work = new Work();
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var order = db.zakaz.SingleOrDefault(c => c.id == orderId);
                var work = db.work.SingleOrDefault(c => c.id == WorkId);
                if (order == null || work == null)
                {
                    return null;
                }
                order.work.Remove(work);
                db.SaveChanges();
                Work = Mapper.Map<Work>(work);
            }
            return Work;
        }
    }
}