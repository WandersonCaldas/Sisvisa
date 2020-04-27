using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SISVISA.Core.Regra;
using SISVISA.Core.Models;

namespace SISVISA.UI.Web.Controllers
{
    
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }               

        [AllowAnonymous]
        public ActionResult About()
        {            
            return View();
        }
    }
}