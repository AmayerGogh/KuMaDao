using Amayer.Info.CL.Models;
using Amayer.Info.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amayer.Info.Areas.Admin.Filters
{
    public sealed class Authorization : AuthorizeAttribute
    {
        //private CurrentUser User { get; set; }
        private string ActionName { get; set; }
        private string ControllerName { get; set; }
        private string AreaName { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //User = httpContext.Session["CurrentUser"] as CurrentUser;
            //if (User == null)
            //{
            //    var cookie = httpContext.Request.Cookies["CurrentUser"];
            //    if (cookie == null)
            //    {
            //        httpContext.Response.StatusCode = 401;
            //        return false;
            //    }
            //    User = new CurrentUser();
            //    int id = 0, rid = 0;
            //    if (int.TryParse(cookie["Id"], out id))
            //        User.Id = id;
            //    User.UserName = cookie["UserName"];
            //    User.RealName = HttpUtility.UrlDecode(cookie["RealName"]);
            //    User.Password = cookie["Password"];
            //    if (int.TryParse(cookie["RoleId"], out rid))
            //        User.RoleId = rid;
            //    User.RoleName = cookie["RoleName"];
            //    User.Email = cookie["Email"];
            //    User.Avatar = cookie["Avatar"];
            //    User.LoginTime = HttpUtility.UrlDecode(cookie["LoginTime"]);
            //    httpContext.Session["CurrentUser"] = User;
            //}
            //else
            //{
            //    User.RealName = HttpUtility.UrlDecode(User.RealName);
            //    User.LoginTime = HttpUtility.UrlDecode(User.LoginTime);
            //    User.RoleName = HttpUtility.UrlDecode(User.RoleName);
            //}

            //httpContext.Items.Add("CurrentUser", User);

            if (httpContext.Request.IsAjaxRequest())
                return true;

            var menuModels = new MenuModel();
            //menuModels.User = User;

            var list = new List<AdminMenu>();
            if (httpContext.Session["AdminMenu"] != null)
            {
                list = httpContext.Session["AdminMenu"] as List<AdminMenu>;
            }
            else
            {
                //todo
               // var db = new RunToDbContext();
                //list = db.AdminMenu.Where(m => m.Status > 0).ToList();
                //db.Dispose();
                //httpContext.Session.Add("AdminMenu", list);
            }

            menuModels.Menus = list.Where(model => model.ParentId == 0 && model.Status == 1).Select(model => new Menu
            {
                Id = model.Id,
                Icon = model.Icon,
                Name = model.Name,
                Description = model.Description,
                Action = model.Action,
                Controller = model.Controller,
                Area = model.Area,
                IsFinal = model.IsFinal,
                Children = model.IsFinal ? null : list.Where(item => item.ParentId == model.Id && item.Status == 1).ToList()
            }).ToList();

            //if (ControllerName == "error")
            //{
            //    menuModels.ActiveMenu = list.Where(model => model.Controller == ControllerName && model.Action == ActionName).FirstOrDefault();
            //    menuModels.TopMenu = menuModels.ActiveMenu;
            //    httpContext.Items.Add("Menus", menuModels);
            //    return true;
            //}

            //var authorityList = list.Where(model => model.Controller == ControllerName).ToList();
            //if (authorityList.Count == 0)
            //{
            //    menuModels.ActiveMenu = new AdminMenu();
            //    menuModels.TopMenu = new AdminMenu();
            //    httpContext.Response.StatusCode = 403;
            //    httpContext.Items.Add("Menus", menuModels);
            //    return true;
            //}

            //menuModels.ActiveMenu = authorityList.Where(model => model.Controller == ControllerName && model.Action == ActionName && model.IsFinal).FirstOrDefault();
            //if (menuModels.ActiveMenu == null)
            //{
            //    menuModels.ActiveMenu = new AdminMenu();
            //    menuModels.ActiveMenu.ParentId = 1;
            //    httpContext.Response.StatusCode = 403;
            //    httpContext.Items.Add("Menus", menuModels);
            //    return true;
            //}

            //if (menuModels.ActiveMenu.Status == 2)
            //{
            //    menuModels.ActiveMenu = authorityList.Where(model => model.Controller == ControllerName && model.Sort < menuModels.ActiveMenu.Sort && model.Status == 1)
            //        .OrderByDescending(model => model.Sort).FirstOrDefault();
            //}
            //menuModels.TopMenu = menuModels.ActiveMenu.ParentId == 0 ?
            //        menuModels.ActiveMenu : list.Where(model => model.Id == menuModels.ActiveMenu.ParentId).FirstOrDefault();

            httpContext.Items.Add("Menus", menuModels);
            return true;
        }

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{

        //    if (filterContext.HttpContext.Response.StatusCode == 401)
        //    {
        //        filterContext.Result = new RedirectToRouteResult("Admin_default", new System.Web.Routing.RouteValueDictionary(new { controller = "account", action = "login", returnurl = string.Format("/{0}/{1}/{2}", AreaName, ControllerName, ActionName) }), true);
        //    }
        //    else if (filterContext.HttpContext.Response.StatusCode == 403)
        //    {
        //        filterContext.Result = new RedirectToRouteResult("Admin_default", new System.Web.Routing.RouteValueDictionary(new { controller = "error", action = "denied" }), true);
        //    }
        //    else
        //    {
        //        base.HandleUnauthorizedRequest(filterContext);
        //    }
        //}

        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    ActionName = filterContext.ActionDescriptor.ActionName.ToLowerInvariant();
        //    ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLowerInvariant();
        //    if (filterContext.RouteData.DataTokens["area"] != null)
        //    {
        //        AreaName = filterContext.RouteData.DataTokens["area"].ToString().ToLowerInvariant();
        //    }
        //    base.OnAuthorization(filterContext);
        //}

        //protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        //{
        //    return base.OnCacheAuthorization(httpContext);
        //}
    }
}