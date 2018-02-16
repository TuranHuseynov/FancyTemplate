using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class AdminkaController : Controller
    {
        TemplateFevralEntities db = new TemplateFevralEntities();
        // GET: Adminka
        public ActionResult Index()
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        private bool Check_Admin()
        {

            if (Session["User_Name"] != null)
            {

                return true;
            }
            else
            {

                return false;
            }
        }
    }
}