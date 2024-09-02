using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Code_FirstApproach.Models;
using System.Data;

namespace Code_FirstApproach.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db=new StudentContext();
        // GET: Home
        public ActionResult Index()
        {
            var data=db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s) {
            db.Students.Add(s);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var StudentIdRow = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(StudentIdRow);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.DeleteMessage ="<script>alert('Deleted')</script>";
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id) 
        {
            var rowDel =db.Students.Where (model=>model.Id==id).FirstOrDefault();
            return View(rowDel);
        }

        [HttpPost]
        public ActionResult Edit(Student s, int id)
        {
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
    }
}