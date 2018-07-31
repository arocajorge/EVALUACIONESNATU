using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Filters;

namespace web.Controllers
{
    [WebSecurityAuthorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {   
            return View();
        }
    }
}

public enum HeaderViewRenderMode { Full, Title }