using KR.Business.Entities;
using KR.Business.ReportBilders;
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
        SingleOrderRepositories SingleOrderRepo;
        DifficultsRepositories DiffiicultsRepo;
        WorkRepositories WorkRepositories;

        public HomeController()
        {
            ZakazInfoRepositories = new ZakazInfoRepositories();
            ZakazRepositories = new ZakazRepositories();
            SingleOrderRepo = new SingleOrderRepositories();
            DiffiicultsRepo = new DifficultsRepositories();
            WorkRepositories = new WorkRepositories();
        }

        public ActionResult Index(int? page, 
            string nameDesigner, string surnameDesigner,
            string nameCustomer, string surnameCustomer,
            string price, 
            string startDate, string endDate)
        {
            if (String.IsNullOrEmpty(nameDesigner))
                nameDesigner = String.Empty;
            if (String.IsNullOrEmpty(surnameDesigner))
                surnameDesigner = String.Empty;

            if (String.IsNullOrEmpty(nameCustomer))
                nameCustomer = String.Empty;
            if (String.IsNullOrEmpty(surnameCustomer))
                surnameCustomer = String.Empty;

            if (String.IsNullOrEmpty(price))
                price = String.Empty;

            if (String.IsNullOrEmpty(startDate))
                startDate = String.Empty;
            if (String.IsNullOrEmpty(endDate))
                endDate = String.Empty;

            var List = ZakazInfoRepositories.GetList(nameDesigner, surnameDesigner,
                                                     nameCustomer,  surnameCustomer, price,startDate,  endDate);

            if (List == null)
                List = new List<ZakazInfo>();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(List.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            var zakaz = SingleOrderRepo.GetbyId(id);
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

        [HttpPost]
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


        [HttpPost]
        public JsonResult AddDifficults(int orderId, int difficultsId)
        {
            var add = DiffiicultsRepo.Save(orderId, difficultsId);
            return Json(add);
        }

        [HttpPost]
        public JsonResult DeleteDifficults(int orderId, int difficultsId)
        {
            var add = DiffiicultsRepo.Remove(orderId, difficultsId);
            if (add == null)
                return Json(-1);
            return Json(add.id);
        }

        [HttpPost]
        public JsonResult AddWork(int orderId, Work work)
        {
            var add = WorkRepositories.Save(orderId, work);
            return Json(add);
        }


        [HttpPost]
        public JsonResult DeleteWork(int orderId, int workId)
        {
            var add = WorkRepositories.Remove(orderId, workId);
            if (add == null)
                return Json(-1);
            return Json(add.id);
        }





        //========================

        public FileResult GetReport(int id)
        {
            var report = ZakazInfoRepositories.GetReport(id);
            var file = OrderReportBilders.GetReport(report);
            return File(file, "application/pdf", "report.pdf");
        }

    }
}