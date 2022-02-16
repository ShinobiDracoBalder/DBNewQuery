using DBNewQuery.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartialViewCrudDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult MyCreatePartial(Customer stud)
        {
            var stuName = stud.Name;

            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(stuName))
                {
                    //_context.Especialidad.Add(stud);
                    //_context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return PartialView("CreatePartial");
        }
        //[HttpGet]
        //public ActionResult GetByID(int? ID)
        //{

        //    if (ID == null)
        //    {
        //        return NotFound();
        //    }
        //    Especialidad stuTable = _context.Especialidad.Find(ID);
        //    if (stuTable == null)
        //    {
        //        return NotFound();
        //    }
        //    return PartialView("EditPartial", stuTable);
        //}
        //[HttpPost]
        //public ActionResult MyEditPartial(Especialidad stuTable)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (!string.IsNullOrEmpty(stuTable.EspecialidadNombre))
        //        {
        //            _context.Entry(stuTable).State = EntityState.Modified;
        //            _context.SaveChanges();
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }

        //    return PartialView("EditPartial");
        //}
    }
}
