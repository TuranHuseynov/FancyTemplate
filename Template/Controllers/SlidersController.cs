﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Template.Models;

namespace Template.Controllers
{
    public class SlidersController : Controller
    {
        private TemplateFevralEntities db = new TemplateFevralEntities();

        // GET: Sliders
        public ActionResult Index()
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            return View(db.Sliders.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "slider_id,slider_title,slider_first_url,slider_second_url")] Slider slider, HttpPostedFileBase slider_img)
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                var file_name = Path.GetFileName(slider_img.FileName);
                if (slider_img.ContentLength > 0)
                {
                    var file_src = Path.Combine(Server.MapPath("/Upload"), file_name);
                    slider_img.SaveAs(file_src);
                }
                slider.slider_img = file_name;
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "slider_id,slider_title,slider_img,slider_first_url,slider_second_url")] Slider slider)
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                db.Entry(slider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!Check_Admin())
            {
                return RedirectToAction("Index", "Login");
            }
            Slider slider = db.Sliders.Find(id);
            db.Sliders.Remove(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
