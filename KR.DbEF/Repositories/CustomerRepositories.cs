using AutoMapper;
using KR.Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace KR.DbEF.Repositories
{
    public class CustomerRepositories
    {
        public IEnumerable<Customer> GetList()
        {
            List<customer> customer;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                customer = db.customer.ToList<customer>();
            }
            return Mapper.Map<List<Customer>>(customer.OrderByDescending(x => x.id));
        }

        public void Save(Customer _customer)
        {
            if (_customer != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    db.customer.Add(Mapper.Map<customer>(_customer));
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Couldn't save null instance");
            }
        }

        public int Edit(Customer _customer)
        {
            if (_customer != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    db.Entry(Mapper.Map<customer>(_customer)).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Couldn't save null instance");
            }
        }

        public Customer GetbyId(int id)
        {
            using (LD_kursEntities db = new LD_kursEntities())
            {
                var user = db.customer.SingleOrDefault(c => c.id == id);
                return Mapper.Map<Customer>(user);
            }
        }

        public Customer Delete(int id)
        {
            var user = GetbyId(id);
            if (user != null)
            {
                using (LD_kursEntities db = new LD_kursEntities())
                {
                    //db.items.Remove(user);
                    db.Entry(Mapper.Map<customer>(user)).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            return user;
        }

    }
}