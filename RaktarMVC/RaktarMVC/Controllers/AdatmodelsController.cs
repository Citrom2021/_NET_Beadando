#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RaktarMVC.Data;
using RaktarMVC.Models;

namespace RaktarMVC.Controllers
{
    public class AdatmodelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdatmodelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adatmodels
        public async Task<IActionResult> Index(string elnevezeskereses, string kategoriaKereses)
        {
            Arukereso keresoAru = new Arukereso();
            var Aru = _context.Adatmodel.Select(x => x);
            if (!string.IsNullOrEmpty(elnevezeskereses))
            {
                keresoAru.megnevezesKereses = elnevezeskereses;
                Aru = Aru.Where(x => x.Megnevezes.Contains(elnevezeskereses));
            }

            if (!string.IsNullOrEmpty(kategoriaKereses))
            {
                keresoAru.tipusKereses = kategoriaKereses;
                Aru = Aru.Where(x => x.Tipus.Equals(kategoriaKereses));
            }

            keresoAru.tipusLista = new SelectList(await _context.Adatmodel.Select(x => x.Tipus).Distinct().ToListAsync());
            keresoAru.Aru = await Aru.ToListAsync();

            return View(keresoAru);
        }

        // GET: Adatmodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adatmodel = await _context.Adatmodel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adatmodel == null)
            {
                return NotFound();
            }

            return View(adatmodel);
        }

        // GET: Adatmodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adatmodels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Megnevezes,Gyarto,Tipus,BeszerzesiAr")] Adatmodel adatmodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adatmodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adatmodel);
        }

        // GET: Adatmodels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adatmodel = await _context.Adatmodel.FindAsync(id);
            if (adatmodel == null)
            {
                return NotFound();
            }
            return View(adatmodel);
        }

        // POST: Adatmodels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Megnevezes,Gyarto,Tipus,BeszerzesiAr")] Adatmodel adatmodel)
        {
            if (id != adatmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adatmodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdatmodelExists(adatmodel.Id))
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
            return View(adatmodel);
        }

        // GET: Adatmodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adatmodel = await _context.Adatmodel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adatmodel == null)
            {
                return NotFound();
            }

            return View(adatmodel);
        }

        // POST: Adatmodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adatmodel = await _context.Adatmodel.FindAsync(id);
            _context.Adatmodel.Remove(adatmodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdatmodelExists(int id)
        {
            return _context.Adatmodel.Any(e => e.Id == id);
        }
    }
}
