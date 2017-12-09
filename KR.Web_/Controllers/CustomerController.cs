using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KR.Business.Entities;
using KR.DbEF.Repositories;
using PagedList;
using KR.Business.Repositories;

namespace KR.Web.Controllers
{
    public class CustomerController : Controller
    {
        private static ICustomer<Customer> CustomerRepositories;
        private static ILand<Land> LandRepositories;
        public CustomerController(ICustomer<Customer> _Repositories, ILand<Land> _LandRepositories)
        {
            CustomerRepositories = _Repositories;
            LandRepositories = _LandRepositories;
        }

        [Authorize]
        public ActionResult Index(int? page, string name, string surname, string age)
        {
            IEnumerable<Customer> List = new List<Customer>();
            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(surname) && String.IsNullOrEmpty(age))
            {
                List = CustomerRepositories.GetList();
            }
            else
            {
                if (String.IsNullOrEmpty(name))
                    name = String.Empty;
                if (String.IsNullOrEmpty(surname))
                    surname = String.Empty;
                if (String.IsNullOrEmpty(age))
                    age = String.Empty;
                List = CustomerRepositories.GetList(name , surname, age);
            }

            if (List == null)
                List = new List<Customer>();
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(List.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepositories.Save(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var customer = CustomerRepositories.GetbyId(id);
            if (customer == null)
                return RedirectToAction("Customer");
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepositories.Edit(customer);
                return RedirectToAction("Info", "Customer", new { id = customer.id });
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public JsonResult Delete(int id)
        {
            var customer = CustomerRepositories.Delete(id);
            if (customer == null)
            {
                return Json(-1);
            }
            return Json(id);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Info(int id)
        {
            var customer = CustomerRepositories.GetbyId(id);
            var LandsList = LandRepositories.GetListForUser(id);
            if (customer == null || LandsList == null)
                return RedirectToAction("Index");

            CustomerInfo Info = new CustomerInfo() { Customer = customer, Lands = LandsList };

            return View(Info);
        }
    }
}