using KR.Business.Entities;
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
        LandRepositories LandRepositories;
        CustomerRepositories CustomerRepositories;
        public LandController()
        {
            LandRepositories = new LandRepositories();
            CustomerRepositories = new CustomerRepositories();
        }

        // GET: Land
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home",null);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            Land land = new Land();
            land.customer_id = id;
            return View(land);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(int id)
        {
            var land = LandRepositories.GetbyId(id);
            if (land == null)
                return RedirectToAction("Info", "Customer", new { id = land.customer_id });
            return View(land);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Land land)
        {
            if (ModelState.IsValid)
            {
                LandRepositories.Edit(land);
                return RedirectToAction("Info", "Customer", new { id= land.customer_id});
            }
            return View();
        }

        [HttpPost]
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