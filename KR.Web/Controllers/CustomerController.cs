using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KR.Business.Entities;
using KR.DbEF.Repositories;
using PagedList;

namespace KR.Web.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepositories _Repositories;
        LandRepositories LandRepositories;
        public CustomerController()
        {
            _Repositories = new CustomerRepositories();
            LandRepositories = new LandRepositories();
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var List = _Repositories.GetList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(List.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _Repositories.Save(customer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _Repositories.GetbyId(id);
            if (customer == null)
                return RedirectToAction("Customer");
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _Repositories.Edit(customer);
                return RedirectToAction("Customer");
            }
            
            return View();
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var customer = _Repositories.Delete(id);
            if (customer == null)
            {
                Json(-1);
            }
            return Json(id);
        }

        public string Del(int id)
        {
            var customer = _Repositories.Del(id);
            return(id.ToString());
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            var customer = _Repositories.GetbyId(id);
            var LandsList = LandRepositories.GetListForUser(id);
            if (customer == null || LandsList == null)
                return RedirectToAction("Index");

            CustomerInfo Info = new CustomerInfo() { Customer = customer, Lands = LandsList };

            return View(Info);
        }

        public string Adds()
        {
            var customer = new Customer() { name = "Ivan", surname = "Ivanov", age = 43};
            _Repositories.Save(customer);
            return "done";

        }

    }
}