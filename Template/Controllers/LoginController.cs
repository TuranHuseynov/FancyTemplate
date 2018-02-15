using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Template.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]

        public ActionResult LogIn()
        {

            return View();
        }



      

        [HttpPost]
        public ActionResult LogIn(FormCollection frm)
        {
            Session["User_Name"] = frm["User_name"];
            Session["User_Password"] = frm["User_password"];
            if (Session["User_Name"].ToString() == "admin")
            {
                if (Session["User_Password"].ToString() == "admin")
                {
                    return RedirectToAction("Index","Adminka");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");

            }
        }

        public ActionResult LogOut()
        {
         
            
                Session.Abandon();
                return RedirectToAction("LogIn");

          

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