using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult GetAdmin()
        {
         
            var entity = new CL.CRUD.AdminMenuCRUD(DapperMsg.DbContext);
            var AdminMenus = entity.GetList("AdminMenus");
            return Json(AdminMenus);
        }
    }
}