using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class vedController : Controller
    {
        // GET: ved
        public ActionResult Index()
        {
            return View();
        }
        private HospitalEntities db = new HospitalEntities();
        public ActionResult salary_Result(DateTime firsDate, DateTime lastDate)
        {
            var query = "exec salary '" + firsDate.ToString("yyyyMMdd HH:mm: ss") + "', '" + lastDate.ToString("yyyyMMdd HH: mm:ss") + "'";
            Console.WriteLine(query);
            var qq = db.Database.SqlQuery<salary_Result>(query);
            return View(qq.ToList());
        }
    }
}