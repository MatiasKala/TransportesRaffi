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
    public class ViajesController : Controller
    {
        private readonly TransportesRaffiContext _context;

        public ViajesController(TransportesRaffiContext context)
        {
            _context = context;
        }

        // GET: Viajes
        public IActionResult Index()
        {
            return RedirectToAction("ListarViajes");
        }
        public async Task<IActionResult> ListarViajesAsync()
        {
            var transportesRaffiContext = _context.Viajes.Include(v => v.IdclienteNavigation).
                Include(v => v.IdvehiculoNavigation).
                Where(e => e.EstadoViaje == Viaje.Estado.LISTO);

            return View(await transportesRaffiContext.ToListAsync());
        }

        public async Task<IActionResult> ListarViajesHistoricosAsync()
        {
            var transportesRaffiContext = _context.Viajes.Include(v => v.IdclienteNavigation).
                Include(v => v.IdvehiculoNavigation).
                ThenInclude(c => c.IdchoferNavigation).
                Where(e => e.EstadoViaje == Viaje.Estado.FINALIZADO);

            return View(await transportesRaffiContext.ToListAsync());
        }

        public async Task<IActionResult> HojaDeRuta()
        {
            var viajesDeHoy = _context.Viajes.Include(v => v.IdclienteNavigation).
                                              Include(v => v.IdvehiculoNavigation).
                                              ThenInclude(c => c.IdchoferNavigation).
                                              Where(v => v.FechaHoraEntrega.Date == DateTime.Today && v.EstadoViaje!=Viaje.Estado.FINALIZADO);

            return View(await viajesDeHoy.ToListAsync());
        }

        // GET: Viajes/PasarAEnTransito/5
        public async Task<IActionResult> PasarAEnTransito(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Id", "Nombre", viaje.Idcliente);
            ViewData["Idvehiculo"] = new SelectList(_context.Vehiculos, "Id", "Patente", viaje.Idvehiculo);
            return View(viaje);
        }

        // GET: Viajes/PasarAEnTransito/5
        public async Task<IActionResult> PasarAFinalizado(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Id", "Nombre", viaje.Idcliente);
            ViewData["Idvehiculo"] = new SelectList(_context.Vehiculos, "Id", "Patente", viaje.Idvehiculo);
            return View(viaje);
        }

        // POST: Viajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CambiarEstado(int id, [Bind("Id,Idcliente,Idvehiculo,FechaHoraEntrega,DomicilioEntrega,DescripcionPaquete,ValorViaje,EstadoViaje")] Viaje viaje)
        {
            if (id != viaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViajeExists(viaje.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("HojaDeRuta");
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Id", "Nombre", viaje.Idcliente);
            ViewData["Idvehiculo"] = new SelectList(_context.Vehiculos, "Id", "Patente", viaje.Idvehiculo);
            return RedirectToAction("HojaDeRuta");
        }



        // GET: Viajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes
                .Include(v => v.IdclienteNavigation)
                .Include(v => v.IdvehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        
        // GET: Viajes/Create
        public IActionResult Create()
        {
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["Idvehiculo"] = new SelectList(_context.Vehiculos, "Id", "Patente");
            return View();
        }

        // POST: Viajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idcliente,Idvehiculo,FechaHoraEntrega,DomicilioEntrega,DescripcionPaquete,ValorViaje,EstadoViaje")] Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Id", "Nombre", viaje.Idcliente);
            ViewData["Idvehiculo"] = new SelectList(_context.Vehiculos, "Id", "Patente", viaje.Idvehiculo);
            return View(viaje);
        }

        // GET: Viajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes.FindAsync(id);
            if (viaje == null)
            {
                return NotFound();
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Id", "Nombre", viaje.Idcliente);
            ViewData["Idvehiculo"] = new SelectList(_context.Vehiculos, "Id", "Patente", viaje.Idvehiculo);
            return View(viaje);
        }

        // POST: Viajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idcliente,Idvehiculo,FechaHoraEntrega,DomicilioEntrega,DescripcionPaquete,ValorViaje,EstadoViaje")] Viaje viaje)
        {
            if (id != viaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViajeExists(viaje.Id))
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
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Id", "Nombre", viaje.Idcliente);
            ViewData["Idvehiculo"] = new SelectList(_context.Vehiculos, "Id", "Patente", viaje.Idvehiculo);
            return View(viaje);
        }

        // GET: Viajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viaje = await _context.Viajes
                .Include(v => v.IdclienteNavigation)
                .Include(v => v.IdvehiculoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (viaje == null)
            {
                return NotFound();
            }

            return View(viaje);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viaje = await _context.Viajes.FindAsync(id);
            _context.Viajes.Remove(viaje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViajeExists(int id)
        {
            return _context.Viajes.Any(e => e.Id == id);
        }
    }
}
