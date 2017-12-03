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
    public class WorkController : Controller
    {
        IWork<Work> WorkRepositories;
        public WorkController()
        {
            WorkRepositories = new WorkRepositories();
        }

        // GET: Work
        public ActionResult Index()
        {
            return RedirectToAction("Inde", "Home", null);
        }

        //[HttpGet]
        //public ActionResult Add(int id)
        //{
        //    var work = new Work();
        //    //work.
        //}
    }
}