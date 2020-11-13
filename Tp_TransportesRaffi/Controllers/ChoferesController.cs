using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp_TransportesRaffi.Models;

namespace Tp_TransportesRaffi.Controllers
{
    public class ChoferesController : Controller
    {
        private readonly TransportesRaffiContext _context;

        public ChoferesController(TransportesRaffiContext context)
        {
            _context = context;
        }

        // GET: Choferes
        public IActionResult Index()
        {
            return RedirectToAction("ListarChoferes");
        }

        public async Task<IActionResult> ListarChoferes()
        {
            ViewBag.choferes = _context.Choferes.ToList();
            return View(await _context.Choferes.ToListAsync());
        }
        // GET: Choferes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chofer = await _context.Choferes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chofer == null)
            {
                return NotFound();
            }

            return View(chofer);
        }

        // GET: Choferes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Choferes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cuit,Nombre,FechaNacimiento,Comision")] Chofer chofer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chofer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chofer);
        }

        // GET: Choferes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chofer = await _context.Choferes.FindAsync(id);
            if (chofer == null)
            {
                return NotFound();
            }
            return View(chofer);
        }

        // POST: Choferes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cuit,Nombre,FechaNacimiento,Comision")] Chofer chofer)
        {
            if (id != chofer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chofer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoferExists(chofer.Id))
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
            return View(chofer);
        }

        // GET: Choferes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chofer = await _context.Choferes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chofer == null)
            {
                return NotFound();
            }

            return View(chofer);
        }

        // POST: Choferes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chofer = await _context.Choferes.FindAsync(id);
            _context.Choferes.Remove(chofer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoferExists(int id)
        {
            return _context.Choferes.Any(e => e.Id == id);
        }
    }
}
