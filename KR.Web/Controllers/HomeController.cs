using KR.Business.Entities;
using KR.DbEF.Repositories;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KR.Web.Controllers
{
    public class HomeController : Controller
    {
        CustomerRepositories repo;
        public HomeController()
        {
            repo = new CustomerRepositories();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Customer(int? page)
        {
            var List = repo.GetList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(List.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.Save(customer);
                return RedirectToAction("Customer");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var customer = repo.GetbyId(id);
            if (customer == null)
                return RedirectToAction("Customer");
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(customer);
                return RedirectToAction("Customer");
            }
            return View();
        }

        [HttpPost]
        public JsonResult DeleteCustomer(int id)
        {
            var customer = repo.Delete(id);
            if (customer == null)
            {
                Json(-1);
            }
            return Json(id);
        }

    }
}