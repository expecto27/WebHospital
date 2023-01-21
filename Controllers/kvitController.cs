using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    public class kvitController : Controller
    {
        // GET: kvit
        public ActionResult Index()
        {
            return View();
        }
        private HospitalEntities db = new HospitalEntities();
        public ActionResult kvitancia_Result(int idP)
        {
            var query = "exec kvitancia " + idP;
            Console.WriteLine(query);
            var qq = db.Database.SqlQuery<kvitancia_Result>(query);
            return View(qq.ToList());
        }
    }
    
    

}