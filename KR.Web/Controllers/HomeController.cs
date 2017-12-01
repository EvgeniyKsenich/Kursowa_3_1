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
        ZakazInfoRepositories ZakazRepositories;
        public HomeController()
        {
            ZakazRepositories = new ZakazInfoRepositories();
        }

        public ActionResult Index(int? page)
        {
            var List = ZakazRepositories.GetList();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(List.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Info(int id)
        {
            var zakaz = ZakazRepositories.GetbyId(id);
            if(zakaz == null)
                return RedirectToAction("Index");
            
            return View(zakaz);
        }

    }
}