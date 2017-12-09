using KR.Business.Entities;
using KR.Business.Repositories;
using KR.DbEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KR.Web.Controllers
{
    public class LandController : Controller
    {
        private static ICustomer<Customer> CustomerRepositories;
        private static ILand<Land> LandRepositories;
        public LandController(ICustomer<Customer> _Repositories, ILand<Land> _LandRepositories)
        {
            CustomerRepositories = _Repositories;
            LandRepositories = _LandRepositories;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Index","Home",null);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Add(int id)
        {
            Land land = new Land();
            land.customer_id = id;
            return View(land);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Add(Land land)
        {
            if (ModelState.IsValid)
            {
                LandRepositories.Save(land);
                return RedirectToAction("Info", "Customer", new { id = land.customer_id });
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var land = LandRepositories.GetbyId(id);
            if (land == null)
                return RedirectToAction("Index", "Home", null);
            return View(land);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Land land)
        {
            if (ModelState.IsValid)
            {
                LandRepositories.Edit(land);
                return RedirectToAction("Info", "Customer", new { id= land.customer_id});
            }
            return View();
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            var land = LandRepositories.GetbyId(id);
            if(land ==null)
                return RedirectToAction("Index", "Home", null);
            return View(land);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public JsonResult Delete(int id)
        {
            var customer = LandRepositories.Delete(id);
            if (customer == null)
            {
                Json(-1);
            }
            return Json(id);
        }
    }
}