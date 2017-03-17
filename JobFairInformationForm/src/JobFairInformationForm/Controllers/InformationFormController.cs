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
        protected ApplicationDbContextFactory DbFactory { get; set; }

        public InformationFormController(ApplicationDbContextFactory factory)
        {
            DbFactory = factory;
        }
        // GET: InformationForm
        public ActionResult Index()
        {
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
                        Location = collection.Location,
                        Name = collection.Name,
                        Surname = collection.Surname,
                        PhoneNumber = collection.PhoneNumber,
                        Email = collection.Email,
                        Education = collection.Education,
                        Allocation = collection.Allocation,
                        GraduationDate = collection.GraduationDate,
                        PreferredJob = collection.PreferredJob
                    });

                    db.SaveChanges();
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
                    Location = collection.Location,
                    Name = collection.Name,
                    Surname = collection.Surname,
                    PhoneNumber = collection.PhoneNumber,
                    Email = collection.Email,
                    Education = collection.Education,
                    Allocation = collection.Allocation,
                    GraduationDate = collection.GraduationDate,
                    PreferredJob = collection.PreferredJob

                }).ToList();

                return View(data);
            }

        }

        // GET: InformationForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InformationForm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: InformationForm/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}