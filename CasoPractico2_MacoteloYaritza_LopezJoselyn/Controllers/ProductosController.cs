using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CasoPractico2_MacoteloYaritza_LopezJoselyn.Models;

namespace CasoPractico2_MacoteloYaritza_LopezJoselyn.Controllers
{
    public class ProductosController : Controller
    {
        private readonly TechstoreSaContext _context;

        public ProductosController(TechstoreSaContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var techstoreSaContext = _context.Productos.Include(p => p.NombreCategoriaNavigation).Include(p => p.NombreMarcaNavigation);
            return View(await techstoreSaContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.NombreCategoriaNavigation)
                .Include(p => p.NombreMarcaNavigation)
                .FirstOrDefaultAsync(m => m.NombreProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["NombreCategoria"] = new SelectList(_context.CategoriasProductos, "NombreCategoria", "NombreCategoria");
            ViewData["NombreMarca"] = new SelectList(_context.Marcas, "NombreMarca", "NombreMarca");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NombreProducto,NombreCategoria,NombreMarca,Precio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NombreCategoria"] = new SelectList(_context.CategoriasProductos, "NombreCategoria", "NombreCategoria", producto.NombreCategoria);
            ViewData["NombreMarca"] = new SelectList(_context.Marcas, "NombreMarca", "NombreMarca", producto.NombreMarca);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["NombreCategoria"] = new SelectList(_context.CategoriasProductos, "NombreCategoria", "NombreCategoria", producto.NombreCategoria);
            ViewData["NombreMarca"] = new SelectList(_context.Marcas, "NombreMarca", "NombreMarca", producto.NombreMarca);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NombreProducto,NombreCategoria,NombreMarca,Precio")] Producto producto)
        {
            if (id != producto.NombreProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.NombreProducto))
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
            ViewData["NombreCategoria"] = new SelectList(_context.CategoriasProductos, "NombreCategoria", "NombreCategoria", producto.NombreCategoria);
            ViewData["NombreMarca"] = new SelectList(_context.Marcas, "NombreMarca", "NombreMarca", producto.NombreMarca);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.NombreCategoriaNavigation)
                .Include(p => p.NombreMarcaNavigation)
                .FirstOrDefaultAsync(m => m.NombreProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(string id)
        {
            return _context.Productos.Any(e => e.NombreProducto == id);
        }
    }
}
