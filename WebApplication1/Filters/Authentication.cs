using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using ActionFilterAttribute = System.Web.Mvc.ActionFilterAttribute;

namespace WebApplication1.Filters
{
    public class Authentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                
        }
        public void OnException(ExceptionContext filterContext)
        {
            string message = filterContext.RouteData.Values["controller"].ToString() + " -> " +
               filterContext.RouteData.Values["action"].ToString() + " -> " +
               filterContext.Exception.Message + " \t- " + DateTime.Now.ToString() + "\n";
        }

        public bool Authenticate(ActionExecutingContext filterContext)
        {
            return true;
            var headers = filterContext.HttpContext.Request.Headers;
            string[] keys = headers.AllKeys;

            //if (filterContext.HttpContext.Request.RequestType != "OPTIONS")
            //{
            //    //return true;
            //    if (keys.Contains("auth-key"))
            //    {

            //        //if (DBL.Authenticate(StaticClass.DecryptStringAES(headers.GetValues("auth-key").First())))
            //        //{
            //        //    return true;

            //        //}
            //        //else
            //        //{
            //        //    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            //        //    return false;
            //        //}

            //    }
            //    else
            //    {
            //        filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            //        return false;
            //    }
            //}
            //else
            //{
            //    JsonResult Res = new JsonResult
            //    {
            //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
            //    };
            //    filterContext.Result = Res;
            //    return false;
            //}


        }
    }
}