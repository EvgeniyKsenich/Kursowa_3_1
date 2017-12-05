using KR.Business.Entities;
using KR.Business.Repositories;
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
        //IZakaz<Zakaz> ZakazRepositories;
        ZakazInfoRepositories ZakazInfoRepositories;
        ZakazRepositories ZakazRepositories;

        public HomeController()
        {
            ZakazInfoRepositories = new ZakazInfoRepositories();
            ZakazRepositories = new ZakazRepositories();
        }

        public ActionResult Index(int? page)
        {
            var List = ZakazInfoRepositories.GetList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(List.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            var zakaz = ZakazInfoRepositories.GetbyId(id);
            if (zakaz == null)
                return RedirectToAction("Index");

            return View(zakaz);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            var zakaz = new Zakaz();
            zakaz.land_id = id;
            return View(zakaz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Zakaz zakaz)
        {
            if (ModelState.IsValid)
            {
                var _zakaz = ZakazRepositories.Save(zakaz);
                if (_zakaz != null)
                {
                    return RedirectToAction("Info", new { id = zakaz.id });
                }
            }
            return View(zakaz);
        }

        //[HttpPost]
        public JsonResult Delete(int id)
        {
            var zakaz = ZakazInfoRepositories.Delete(id);
            if (zakaz == null)
                Json(-1);

            return Json(id);
        }

        public string Deletes(int id)
        {
            var zakaz = ZakazInfoRepositories.Delete(id);
            if (zakaz == null)
                return (-1).ToString();

            return (id).ToString();
        }

    }
}