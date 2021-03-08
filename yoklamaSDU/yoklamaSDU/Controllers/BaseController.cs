
using Net.SourceForge.Koogra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yoklamaSDU.AppCode;
using yoklamaSDU.Models.EntityFramework;

namespace yoklamaSDU.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            // session timeout olduğunda login sayfasına yönlendirme

            if (GetLoginUser() == null)
            {
                filterContext.Result = RedirectToAction("Index", "Giris");
            }
            else
            {
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
               
            }
        }

        public LoginUser GetLoginUser()
        {
            return (LoginUser)Session["LoginUser"];
        }
        public string GetCellValue(IRow cells, uint column)
        {
            if (cells != null && cells.GetCell(column) != null)
            {
                object value = cells.GetCell(column).Value;
                if (value != null)
                {
                    return value.ToString().Trim();
                }
            }
            return string.Empty;
        }
    }
}