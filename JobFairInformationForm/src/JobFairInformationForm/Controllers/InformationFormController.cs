using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobFairInformationForm.Models.InformationForm;
using JobFairInformationForm.Database;
using JobFairInformationForm.Database.Entities;
using Microsoft.EntityFrameworkCore;

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
            using (var db = DbFactory.Create())
            {
                var model = new InformationFormViewModel
                {
                    GraduationDate = DateTime.Today,
                    LocationCheckboxes = db.Location.Select(l => new Checkbox
                    {
                        Id = l.Id,
                        Name = l.Name
                    }).ToList()
                };
                return View(model);
            }
        }

        // GET: InformationForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: InformationForm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InformationFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                using (var db = DbFactory.Create())
                {
                    model.LocationCheckboxes = db.Location.Select(l => new Checkbox
                    {
                        Id = l.Id,
                        Name = l.Name
                    }).ToList();
                    foreach (var pair in model.CheckedLocations)
                    {
                        var oneLocation = model.LocationCheckboxes.FirstOrDefault(c => c.Id == pair.Key);
                        oneLocation.Checked = true;
                    }
                }
                ViewData[MessageKey] = "Invalid data!";
                return View("Index", model);
            }
            try
            {
                // TODO: Add insert logic here
                using (var db = DbFactory.Create())
                {
                    var isUpdateAction = model.Id > 0;
                    InformationForm entity = null;
                    if (isUpdateAction)
                    {
                        entity = db.InformationForm
                            .Include(i => i.InformationForm2Locations)
                            .FirstOrDefault(i => i.Id == model.Id);
                        if (entity == null)
                        {
                            TempData[MessageKey] = "User not found!";
                            return RedirectToAction("Index");
                        }
                        db.RemoveRange(entity.InformationForm2Locations);
                        db.SaveChanges();
                    }
                    else
                    {
                        entity = new InformationForm();
                        db.Add(entity);
                    }
                    entity.Location = model.Location;
                    entity.Name = model.Name;
                    entity.Surname = model.Surname;
                    entity.PhoneNumber = model.PhoneNumber;
                    entity.Email = model.Email;
                    entity.Education = model.Education;
                    entity.Allocation = model.Allocation;
                    entity.GraduationDate = model.GraduationDate;
                    entity.PreferredJob = (model.PreferredJob == "Other" && !string.IsNullOrWhiteSpace(model.PreferredJobOther)) ? model.PreferredJobOther : model.PreferredJob;
                    entity.NoteString = model.NoteString;
                    var addLocations = new List<InformationForm2Location>();
                    var delLocations = new List<InformationForm2Location>();
                    foreach (var pair in model.CheckedLocations)
                    {
                        var location = db.Location.First(l => l.Id == pair.Key);
                        var relation = new InformationForm2Location
                        {
                            InformationForm = entity,
                            Location = location
                        };
                        entity.InformationForm2Locations.Add(relation);
                    }
                    db.SaveChanges();
                    if (isUpdateAction)
                    {
                        return RedirectToAction( "Overview");
                    }
                    else
                    {
                        TempData[MessageKey] = "Saved!";
                        return RedirectToAction( "Index");
                    }
                }
            }
            catch (Exception e)
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
                    Location = string.Join(", ", collection.InformationForm2Locations.Select(r => r.Location.Name).ToList()),
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
                var allCheckboxes = db.Location.Select(l => new Checkbox { Id = l.Id, Name = l.Name }).ToList();
                var entity = db.InformationForm
                    .Include(i => i.InformationForm2Locations)
                    .First(a => a.Id == id);
                var checkedLocationIds = entity.InformationForm2Locations.Select(l => l.LocationId).ToList();
                foreach (var locId in checkedLocationIds)
                {
                    var oneLocation = allCheckboxes.FirstOrDefault(c => c.Id == locId);
                    oneLocation.Checked = true;
                }
                var data = new InformationFormViewModel
                {
                    Id = entity.Id,
                    LocationCheckboxes = allCheckboxes,
                    PreferredJob = entity.PreferredJob,
                    Name = entity.Name,
                    Surname = entity.Surname,
                    PhoneNumber = entity.PhoneNumber,
                    Email = entity.Email,
                    Allocation = entity.Allocation,
                    GraduationDate = entity.GraduationDate,
                    Education = entity.Education,
                    NoteString = entity.NoteString
                };

                return View("Index", data);
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