using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Filters;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManagement ep = new EmployeeManagement();

        [System.Web.Http.HttpGet]
        public ActionResult getAllEmployees()
        {
            return Json(ep.getAllEmployees(), JsonRequestBehavior.AllowGet);
        }

        [Authentication]
        [System.Web.Http.HttpGet]
        public ActionResult getEmployeeByID(int EmpID)
        {
            return Json(ep.getEmployeeByID(EmpID), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult insertEmployee(EmployeeModel EmpModel)
        {
            return Json(ep.insertEmployee(EmpModel), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult updateEmployee(EmployeeModel EmpModel)
        {
            return Json(ep.updateEmployee(EmpModel), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public ActionResult deleteEmployee(int EmpID)
        {
            return Json(ep.deleteEmployee(EmpID), JsonRequestBehavior.AllowGet);
        }

    }
}