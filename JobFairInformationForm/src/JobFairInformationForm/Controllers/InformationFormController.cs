using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobFairInformationForm.Models.InformationForm;
using JobFairInformationForm.Database;
using JobFairInformationForm.Database.Entities;

namespace JobFairInformationForm.Controllers
{
    public class InformationFormController : Controller
    {
        public const string MessageKey = "Message";
        protected ApplicationDbContextFactory DbFactory { get; set; }
        public object ScriptManager { get; private set; }

        public InformationFormController(ApplicationDbContextFactory factory)
        {
            DbFactory = factory;
        }
        // GET: InformationForm
        public ActionResult Index()
        {
            if (TempData.ContainsKey(MessageKey))
            {
                ViewData[MessageKey] = TempData[MessageKey];
            }
            return View();
        }

        // GET: InformationForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // POST: InformationForm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InformationFormViewModel collection)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",collection);
            }
            try
            {
                // TODO: Add insert logic here
                using (var db = DbFactory.Create())
                {
                    db.Add(new InformationForm()
                    {
                        Id= collection.Id,
                        Location = collection.Location,
                        Name = collection.Name,
                        Surname = collection.Surname,
                        PhoneNumber = collection.PhoneNumber,
                        Email = collection.Email,
                        Education = collection.Education,
                        Allocation = collection.Allocation,
                        GraduationDate = collection.GraduationDate,
                        PreferredJob = collection.PreferredJob,
                        NoteString = collection.NoteString
                    });

                    db.SaveChanges();
                    TempData[MessageKey] = "Saved";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        public IActionResult Overview()
        {
            using (var db = DbFactory.Create())
            {
                var data = db.InformationForm.Select(collection => new InformationFormViewModel()
                {
                    Id = collection.Id,
                    Location = collection.Location,
                    Name = collection.Name,
                    Surname = collection.Surname,
                    PhoneNumber = collection.PhoneNumber,
                    Email = collection.Email,
                    Education = collection.Education,
                    Allocation = collection.Allocation,
                    GraduationDate = collection.GraduationDate,
                    PreferredJob = collection.PreferredJob,
                    NoteString = collection.NoteString
                }).ToList();

                return View(data);
            }

        }

        // GET: InformationForm/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = DbFactory.Create())
            {
                var data = db.InformationForm.Select(a => new InformationFormViewModel()
                {
                    Id = a.Id,
                    Location = a.Location,
                    PreferredJob = a.PreferredJob,
                    Name = a.Name,
                    Surname = a.Surname,
                    PhoneNumber = a.PhoneNumber,
                    Email = a.Email,
                    Allocation = a.Allocation,
                    GraduationDate = a.GraduationDate,
                    Education = a.Education,
                    NoteString = a.NoteString
                }).First(a => a.Id == id);
                return View("Edit",  data);
            }
        }

        // POST: InformationForm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InformationFormViewModel collection)
        {
            try
            {
                using (var db = DbFactory.Create())
                {
                    var entity = db.InformationForm.First(a => a.Id == collection.Id);
                    entity.Location = collection.Location;
                    entity.PreferredJob = collection.PreferredJob;
                    entity.Name = collection.Name;
                    entity.Surname = collection.Surname;
                    entity.PhoneNumber = collection.PhoneNumber;
                    entity.Email = collection.Email;
                    entity.Allocation = collection.Allocation;
                    entity.GraduationDate = collection.GraduationDate;
                    entity.Education = collection.Education;
                    entity.NoteString = collection.NoteString;

                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InformationForm/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = DbFactory.Create())
            {
                var entity = db.InformationForm.First(a => a.Id == id);
                db.InformationForm.Remove(entity);
                db.SaveChanges();
            }
            //Store data across requests
            //TempData[MessageKey] = "You do not have permission for remove";
            return RedirectToAction("overview");
        }
    }
}