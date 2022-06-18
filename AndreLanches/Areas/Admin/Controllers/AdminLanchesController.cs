using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AndreLanches.Context;
using AndreLanches.Models;
using Microsoft.AspNetCore.Authorization;
using ReflectionIT.Mvc.Paging;

namespace AndreLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminLanchesController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLanchesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminLanches
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.Lanches.Include(l => l.Categoria);
        //    return View(await appDbContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var resultado = _context.Lanches.Include(l => l.Categoria).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }


        // GET: Admin/AdminLanches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancheModel = await _context.Lanches
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.LancheId == id);
            if (lancheModel == null)
            {
                return NotFound();
            }

            return View(lancheModel);
        }

        // GET: Admin/AdminLanches/Create
        public IActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Admin/AdminLanches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LancheId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,Emestoque,CategoriaId")] LancheModel lancheModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lancheModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoriaId = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", lancheModel.CategoriaId);
            return View(lancheModel);
        }

        // GET: Admin/AdminLanches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancheModel = await _context.Lanches.FindAsync(id);
            if (lancheModel == null)
            {
                return NotFound();
            }
            ViewBag.CategoriaId = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", lancheModel.CategoriaId);
            return View(lancheModel);
        }

        // POST: Admin/AdminLanches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LancheId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsLanchePreferido,Emestoque,CategoriaId")] LancheModel lancheModel)
        {
            if (id != lancheModel.LancheId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lancheModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancheModelExists(lancheModel.LancheId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", lancheModel.CategoriaId);
            return View(lancheModel);
        }

        // GET: Admin/AdminLanches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancheModel = await _context.Lanches
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.LancheId == id);
            if (lancheModel == null)
            {
                return NotFound();
            }

            return View(lancheModel);
        }

        // POST: Admin/AdminLanches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lancheModel = await _context.Lanches.FindAsync(id);
            _context.Lanches.Remove(lancheModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancheModelExists(int id)
        {
            return _context.Lanches.Any(e => e.LancheId == id);
        }
    }
}
