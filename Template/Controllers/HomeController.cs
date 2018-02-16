using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Template.Models;
using Template.ViewModel;
namespace Template.Controllers
{
    public class HomeController : Controller
    {
        TemplateFevralEntities db = new TemplateFevralEntities();
        MyModel vm = new MyModel();
        public ActionResult Index()
        {
            vm._blog = db.Blogs.Take(3).ToList();
            vm._feature = db.Feature_Boxes.Take(3).ToList();
            vm._slider = db.Sliders.ToList();
            vm._industry = db.Industries.ToList();
            vm._contatc = db.Contacts.ToList();
            vm._category = db.Categories.ToList();
            vm._service_area = db.Service_Area.ToList();
            vm._testimonial = db.Testimonials_Slider.ToList();
            vm._service_area_content = db.Service_Area_Contents.ToList();
            vm._menu = db.Menus.ToList();
            return View(vm);
        }



        public ActionResult Blog(int id)
        {
            vm._blog = db.Blogs.Where(b => b.blog_id == id).ToList();
            vm._menu = db.Menus.ToList();
            vm._contatc = db.Contacts.ToList();
            vm._category = db.Categories.ToList();



            return View(vm);
        }
       

    }
}