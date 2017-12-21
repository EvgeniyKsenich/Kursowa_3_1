using KR.Business.Entities;
using KR.Business.ReportBilders;
using KR.Business.Repositories;
using KR.DbEF.Repositories;
using KR.Web_.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KR.DbEF;
using KR.Business.ExelHelpers;

namespace KR.Web_.Controllers
{
    public class HomeController : Controller
    {
        private static IZakaz<Zakaz> ZakazRepositories;
        private static IWork<Work> WorkRepositories;
        private static IZakazInfo<ZakazInfo, zakaz> ZakazInfoRepositories;
        private static ISingleOrder<SingleOrder> SingleOrderRepo;
        private static IDifficulties<Difficulties> DiffiicultsRepo;

        private static ExportRepositories ExportRepositories;

        public HomeController(IZakaz<Zakaz> _ZakazRepositories,
                              IWork<Work> _WorkRepositories,
                              IZakazInfo<ZakazInfo, zakaz> _ZakazInfoRepositories,
                              ISingleOrder<SingleOrder> _SingleOrderRepo,
                              IDifficulties<Difficulties> _DiffiicultsRepo)
        {
            ZakazRepositories = _ZakazRepositories;
            WorkRepositories = _WorkRepositories;
            ZakazInfoRepositories = _ZakazInfoRepositories;
            SingleOrderRepo = _SingleOrderRepo;
            DiffiicultsRepo = _DiffiicultsRepo;

            ExportRepositories = new ExportRepositories();
        }

        [Authorize]
        public ActionResult Index(int? page,
            string nameDesigner, string surnameDesigner,
            string nameCustomer, string surnameCustomer,
            int? OrderPrice,
            string startDate, string endDate)
        {
            string prise = String.Empty;

            if (String.IsNullOrEmpty(nameDesigner))
                nameDesigner = String.Empty;
            if (String.IsNullOrEmpty(surnameDesigner))
                surnameDesigner = String.Empty;

            if (String.IsNullOrEmpty(nameCustomer))
                nameCustomer = String.Empty;
            if (String.IsNullOrEmpty(surnameCustomer))
                surnameCustomer = String.Empty;

            //throw new Exception("Price: " + OrderPrice);

            if (OrderPrice != null)
                prise = OrderPrice.Value.ToString();

            if (String.IsNullOrEmpty(startDate))
                startDate = String.Empty;
            if (String.IsNullOrEmpty(endDate))
                endDate = String.Empty;
           
            var List = ZakazInfoRepositories.GetList(nameDesigner, surnameDesigner,
                                                     nameCustomer, surnameCustomer, prise, startDate, endDate);

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
        [Authorize(Roles = "admin")]
        public ActionResult Add(int id)
        {
            var zakaz = new Zakaz();
            zakaz.land_id = id;
            return View(zakaz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public JsonResult Delete(int id)
        {
            var zakaz = ZakazInfoRepositories.Delete(id);
            if (zakaz == null)
                Json(-1);

            return Json(id);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public JsonResult AddDifficults(int orderId, int difficultsId)
        {
            var add = DiffiicultsRepo.Save(orderId, difficultsId);
            return Json(add);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public JsonResult DeleteDifficults(int orderId, int difficultsId)
        {
            var add = DiffiicultsRepo.Remove(orderId, difficultsId);
            if (add == null)
                return Json(-1);
            return Json(add.id);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public JsonResult AddWork(int orderId, Work work)
        {
            var add = WorkRepositories.Save(orderId, work);
            return Json(add);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public JsonResult DeleteWork(int orderId, int workId)
        {
            var add = WorkRepositories.Remove(orderId, workId);
            if (add == null)
                return Json(-1);
            return Json(add.id);
        }





        //========================

        [Authorize(Roles = "admin")]
        public ActionResult Reports()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public FileResult GetAvgOrderReport(string Time)
        {
            var report = ZakazInfoRepositories.GetOrderReport(Time);
            var file = OrderDateReportBilders.GetReport(report);
            return File(file, "application/pdf", "report.pdf");
        }

        [Authorize(Roles = "admin")]
        public FileResult GetOrderReport(int id)
        {
            var report = ZakazInfoRepositories.GetReport(id);
            var file = OrderReportBilders.GetReport(report);
            return File(file, "application/pdf", "report.pdf");
        }

        [Authorize(Roles = "admin")]
        public FileResult GetExtraOrderReport(int Time, int size)
        {
            var report = ZakazInfoRepositories.GetExtraReport(Time, size);
            var file = ExtraOrderReportBilders.GetReport(report);
            return File(file, "application/pdf", "report.pdf");
        }

        [Authorize(Roles = "admin")]
        public FileResult GetExelDb()
        {
            var List = ExportRepositories.GetList();
            var file = ExportToExel.Download(List);
            return File(file, "application/vnd.ms-excel", "export.xlsx");
        }

    }
}