using acikveriportal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace acikveriportal.Controllers
{
    public class OrganizationController : Controller
    {
        
        db_AcikVeriPortalEntities db = new db_AcikVeriPortalEntities();
        // GET: Home
        [HttpGet]
        public ActionResult belbim()
        {
            return View();

        }

        [HttpGet]
        public ActionResult igdas()
        {
            return View();

        }

        [HttpGet]

        public ActionResult iski()
        {
            return View();

        }





    }




}




