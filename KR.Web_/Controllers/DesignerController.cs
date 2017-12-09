using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KR.Business.Repositories;
using KR.Business.Entities;
using PagedList;
using KR.DbEF.Repositories;

namespace KR.Web.Controllers
{
    public class DesignerController : Controller
    {
        private static IDesigner<Designer> _Repositories; 
        //public DesignerController(IDesigner<Designer> Repositories)
        //{
        //    _Repositories = Repositories;
        //}

        public DesignerController()
        {
            _Repositories = new DesignerRepositories();
        }

        // GET: Designer
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
        public ActionResult Add(Designer designer)
        {
            if (ModelState.IsValid)
            {
                _Repositories.Save(designer);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var designer = _Repositories.GetbyId(id);
            if (designer == null)
                return RedirectToAction("Index");
            return View(designer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Designer customer)
        {
            if (ModelState.IsValid)
            {
                _Repositories.Edit(customer);
                return RedirectToAction("Index");
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

        public ActionResult Info(int id)
        {
            var user = _Repositories.GetbyId(id);
            if (user == null)
                return RedirectToAction("Index");
            return View(user);
        }
    }
}