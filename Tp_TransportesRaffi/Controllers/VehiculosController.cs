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
    public class VehiculosController : Controller
    {
        private readonly TransportesRaffiContext _context;

        public VehiculosController(TransportesRaffiContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("ListarVehiculos");
        }
        public async Task<IActionResult> ListarVehiculos()
        {
            var transportesRaffiContext = _context.Vehiculos.Include(v => v.IdchoferNavigation);
            //ViewBag.choferes = _context.Choferes.ToList();
            //ViewBag.vehiculos = _context.Vehiculos.ToList();
            return View(await transportesRaffiContext.ToListAsync());
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.IdchoferNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            ViewData["Idchofer"] = new SelectList(_context.Choferes, "Id", "Nombre");
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idchofer,Patente,Marca,Modelo,Anio,Seguro,Tipo")] Vehiculo vehiculo)
        {
         
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idchofer"] = new SelectList(_context.Choferes, "Id", "Nombre", vehiculo.Idchofer);
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["Idchofer"] = new SelectList(_context.Choferes, "Id", "Nombre", vehiculo.Idchofer);
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idchofer,Patente,Marca,Modelo,Anio,Seguro,Tipo")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
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
            ViewData["Idchofer"] = new SelectList(_context.Choferes, "Id", "Nombre", vehiculo.Idchofer);
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.IdchoferNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.Id == id);
        }
    }
}
