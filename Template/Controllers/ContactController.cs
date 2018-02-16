using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;
using Template.ViewModel;

namespace Template.Controllers
{
    public class ContactController : Controller
    {
        TemplateFevralEntities db = new TemplateFevralEntities();
        // GET: Contact
        public ActionResult Index()
        {
            MyModel vm = new MyModel();
            vm._contatc = db.Contacts.ToList();
            vm._menu = db.Menus.ToList();
            vm._category = db.Categories.ToList();

            return View(vm);
        }

        [HttpPost]


        public ActionResult Index(FormCollection frm)
        {
            Message msg = new Message();
            msg.message_email = frm["email"];
            msg.message_name = frm["name"];
            msg.message_website_url = frm["subject"];
            msg.message_content = frm["message"];
            db.Messages.Add(msg);
            db.SaveChanges();



            return RedirectToAction("Index");


        }

    }
}