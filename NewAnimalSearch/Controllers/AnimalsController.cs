using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcSiteMapProvider.Web.Mvc.Filters;
using NewAnimalSearch.Models;

namespace NewAnimalSearch.Controllers
{
    public class AnimalsController : Controller
    {
        private AnimalSearchDB db = new AnimalSearchDB();
        SharedMethods m = new SharedMethods();

        // GET: Animals
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.AgeSortParm = sortOrder == "Age" ? "age_desc" : "Age";
            ViewBag.TypeSortParm = sortOrder == "Type" ? "type_desc" : "Type";

            var animals = db.Animals.Include(a => a.Org);

            switch (sortOrder)
            {
                case "Name":
                    animals = animals.OrderBy(a => a.Name);
                    break;
                case "name_desc":
                    animals = animals.OrderByDescending(a => a.Name);
                    break;
                case "Age":
                    animals = animals.OrderBy(a => a.AgeYear).ThenBy(a => a.AgeMonth);
                    break;
                case "age_desc":
                    animals = animals.OrderByDescending(a => a.AgeYear).ThenBy(a => a.AgeMonth);
                    break;
                case "Type":
                    animals = animals.OrderBy(a => a.Type);
                    break;
                case "type_desc":
                    animals = animals.OrderByDescending(a => a.Type);
                    break;
            }                     
            
            ViewBag.Photos = m.GetPhotos();
            return View(animals.ToList());
        }

        // GET: Animals/Details/5        
        public ActionResult Details(Guid? animalId, string slug)
        {           
            if (animalId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(animalId);
            if (animal == null)
            {
                return HttpNotFound();
            }

            //add slug
            if (string.IsNullOrEmpty(slug))
            {
                slug = animal.Name + "-" + animal.Type;
                return RedirectToAction("Details", new { animalId, slug });
            }  
            
            //add photos
            ViewBag.Pics = ((from p in db.Photos
                         where p.AnimalID == animalId
                         select p as Photo).ToList());
            return View(animal);
        }

        // GET: Animals/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.OrgList = new SelectList(db.Organisations, "OrgId", "Name");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProtegeId,OrgId,Type,Name,RegisteredAtOrg,AgeMonth,AgeYear,URL,About")] Animal animal, HttpPostedFileBase[] files)
        {
            string path = String.Empty;
            List<Photo> pics = new List<Photo>();

            if (Request.Files.Count != 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    try
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        string name = file.FileName;
                        int size = file.ContentLength;
                        path = Path.Combine(HttpContext.Server.MapPath("~/Content/AnimalPics/"), name);
                        file.SaveAs(path);
                        Photo photo = new Photo()
                        {
                            PhotoId = Guid.NewGuid(),
                            Title = file.FileName,
                            URL = "/Content/AnimalPics/" + name,
                            ContentType = file.ContentType,                           
                        };
                        pics.Add(photo);
                        db.Photos.Add(photo);
                    }
                    catch
                    {
                        ModelState.AddModelError("MyPics", "Nem sikerült a képek feltöltése.");
                    }
                }
            }
            if (ModelState.IsValid)
            {
                animal.ProtegeId = Guid.NewGuid();               
                //animal.MyPics = pics;

                if (pics.Count != 0)
                    foreach (Photo item in pics)
                    {
                        item.AnimalID = animal.ProtegeId;
                    }
                try
                {
                    db.Animals.Add(animal);
                    db.SaveChanges();
                }
                catch
                {
                    ViewBag.Message = "Nem sikerült a mentés.";
                }
                return RedirectToAction("Index");
            }

            ViewBag.OrgList = new SelectList(db.Organisations, "OrgId", "Name", animal.OrgId);
            return View(animal);
        }

        // GET: Animals/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrgId = new SelectList(db.Organisations, "OrgId", "Name", animal.OrgId);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProtegeId,OrgId,Type,Name,RegisteredAtOrg,AgeMonth,AgeYear,URL,About")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrgId = new SelectList(db.Organisations, "OrgId", "Name", animal.OrgId);
            return View(animal);
        }

        // GET: Animals/Delete/5
        [Authorize]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
    }
}
