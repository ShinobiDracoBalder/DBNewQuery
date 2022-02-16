using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBNewQuery.Common.Models;
using PartialViewCrudDemo.DataBase;

namespace PartialViewCrudDemo.Controllers
{
    public class EspecialidadsController : Controller
    {
        private readonly DataContext _context;

        public EspecialidadsController(DataContext context)
        {
            _context = context;
        }

        // GET: Especialidads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }

        // GET: Especialidads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad
                .FirstOrDefaultAsync(m => m.EspecialidadId == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // GET: Especialidads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EspecialidadId,EspecialidadNombre")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        [HttpPost]
        public ActionResult MyCreatePartial(Especialidad stud)
        {
            var stuName = stud.EspecialidadNombre;

            if (ModelState.IsValid)
            {

                if (!string.IsNullOrEmpty(stuName))
                {
                    _context.Especialidad.Add(stud);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return PartialView("CreatePartial");
        }
        [HttpGet]
        public ActionResult GetByID(int? ID)
        {

            if (ID==null)
            {
                return NotFound();
            }
            Especialidad stuTable = _context.Especialidad.Find(ID);
            if (stuTable == null)
            {
                return NotFound();
            }
            return PartialView("EditPartial", stuTable);
        }
        [HttpPost]
        public ActionResult MyEditPartial(Especialidad stuTable)
        {

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(stuTable.EspecialidadNombre))
                {
                    _context.Entry(stuTable).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            
            return PartialView("EditPartial");
        }

        // GET: Especialidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EspecialidadId,EspecialidadNombre")] Especialidad especialidad)
        {
            if (id != especialidad.EspecialidadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadExists(especialidad.EspecialidadId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        // GET: Especialidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad
                .FirstOrDefaultAsync(m => m.EspecialidadId == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // POST: Especialidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadExists(int id)
        {
            return _context.Especialidad.Any(e => e.EspecialidadId == id);
        }

        public async Task<IActionResult> GetByDeleteID(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            Especialidad stuTable = await _context.Especialidad.FindAsync(ID);
            if (stuTable == null)
            {
                return NotFound();
            }
            return PartialView("DeletePartial", stuTable);
        }

        [HttpPost]
        public async Task<IActionResult> MyDeletePartial(int? EspecialidadId)
        {
            if (EspecialidadId == null){
                return NotFound();
            }
            Especialidad tblStu = await _context.Especialidad.FindAsync(EspecialidadId);
            if (tblStu == null)
            {
                return NotFound();
            }
            _context.Especialidad.Remove(tblStu);
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Especialidads/Details/5
        public async Task<IActionResult> MyDetailPartials(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad
                .FirstOrDefaultAsync(m => m.EspecialidadId == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return PartialView("DetailPartials", especialidad);
        }
    }
}
