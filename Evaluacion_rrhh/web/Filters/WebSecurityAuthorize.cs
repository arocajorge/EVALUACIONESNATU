using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Filters
{
    public class WebSecurityAuthorize : AuthorizeAttribute
    {
        protected bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.Request.IsAuthenticated)
            {
                return false;
            }
            if (HttpContext.Current.Session["SessionHelper"] == null)
            {
                return false;
            }

            return true;
        }

        protected void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/");
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}