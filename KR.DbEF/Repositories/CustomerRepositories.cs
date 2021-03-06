﻿using AutoMapper;
using KR.Business.Entities;
using KR.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace KR.DbEF.Repositories
{
    public class CustomerRepositories : ICustomer<Customer>
    {
        public IEnumerable<Customer> GetList()
        {
            List<customer> customer;
            List<Customer> Customer;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                customer = db.customer.ToList<customer>();
                Customer = Mapper.Map<List<Customer>>(customer.OrderByDescending(x => x.id));
            }
            return Customer;
        }

        public IEnumerable<Customer> GetList(string name, string surname, string dateOfB)
        {
            List<customer> customer;
            List<Customer> Customer;

            using (LD_kursEntities db = new LD_kursEntities())
            {
                DateTime result = new DateTime();
                if (DateTime.TryParse(dateOfB, out result))
                {
                    customer = db.customer
                    .Where(item => item.name.Contains(name))
                    .Where(item => item.surname.Contains(surname))
                    .Where(item => item.dateOfBirth == result)
                    .ToList();
                }
                else
                {
                    customer = db.customer
                    .Where(item => item.name.Contains(name))
                    .Where(item => item.surname.Contains(surname))
                    .ToList();
                }
                Customer = Mapper.Map<List<Customer>>(customer.OrderByDescending(x => x.id));
            }
            return Customer;
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

        public customer GetcustomerById(int id)
        {
            customer user;
            using (LD_kursEntities db = new LD_kursEntities())
            {
                user = db.customer.SingleOrDefault(c => c.id == id);
                user.land = user.land.ToList();
            }
            return user;
        }

        public Customer Delete(int id)
        {
            var user = GetcustomerById(id);
            using (LD_kursEntities db = new LD_kursEntities())
            {
                if (user != null)
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach (var item in user.land.ToList())
                            {
                                var orders = db.zakaz.Where(x => x.land.id == item.id).ToList();
                                foreach (var zk in orders)
                                {
                                    var wk = db.work.Where(x => x.zakazId == zk.id).ToList();
                                    foreach (var it in wk)
                                    {
                                        db.Entry(it).State = EntityState.Deleted;
                                    }
                                    db.Entry(zk).State = EntityState.Deleted;
                                }
                                db.Entry(item).State = EntityState.Deleted;
                            }
                            db.Entry(Mapper.Map<customer>(user)).State = EntityState.Deleted;
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
            return Mapper.Map<Customer>(user);
        }

        //test
        public Customer Del(int id)
        {
            var user = GetcustomerById(id);
            using (LD_kursEntities db = new LD_kursEntities())
            {
                if (user != null)
                {
                    foreach (var land in user.land.ToList())
                    {
                        db.Entry(land).State = EntityState.Deleted;
                    }
                    db.Entry(user).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            return Mapper.Map<Customer>(user);
        }

    }
}