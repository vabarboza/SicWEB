using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BellinatiCorreio.Views.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SicWEB.Data;
using SicWEB.Models;

namespace SicWEB.Controllers {
  [Authorize]
  public class CitacaoEditalController : Controller {
    private readonly ApplicationDbContext _context;
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();

    public CitacaoEditalController(ApplicationDbContext context) {
      _context = context;
    }

    // GET: CitacaoEdital
    public async Task<IActionResult> Index() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.CitacaoEdital.ToListAsync());
    }

    // GET: CitacaoEdital/Details/5
    public async Task<IActionResult> Details(int? id) {
      if (id == null) {
        return NotFound();
      }

      var citacaoEdital = await _context.CitacaoEdital
          .FirstOrDefaultAsync(m => m.Id == id);
      if (citacaoEdital == null) {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(citacaoEdital);
    }

    // GET: CitacaoEdital/Create
    [Authorize(Policy = "usuario")]
    public IActionResult Create() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View();
    }

    // POST: CitacaoEdital/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "usuario")]
    public async Task<IActionResult> Create([Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,Oab,Data,NomeUser")] CitacaoEdital citacaoEdital) {
      if (_context.CitacaoEdital.Any(x => x.Contrato == citacaoEdital.Contrato)) {
        ModelState.AddModelError("Contrato", "Contrato ja foi cadastrado");
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      }
      if (ModelState.IsValid) {
        _context.Add(citacaoEdital);
        await _context.SaveChangesAsync();
        TempData["mensagemCreate"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(citacaoEdital);
    }

    // GET: CitacaoEdital/Edit/5
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Edit(int? id) {
      if (id == null) {
        return NotFound();
      }

      var citacaoEdital = await _context.CitacaoEdital.FindAsync(id);
      if (citacaoEdital == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(citacaoEdital);
    }

    // POST: CitacaoEdital/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,Oab,Data,NomeUser")] CitacaoEdital citacaoEdital) {
      if (id != citacaoEdital.Id) {
        return NotFound();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update(citacaoEdital);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!CitacaoEditalExists(citacaoEdital.Id)) {
            return NotFound();
          } else {
            throw;
          }
        }
        TempData["mensagemEdit"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(citacaoEdital);
    }

    // GET: CitacaoEdital/Delete/5
    [Authorize(Policy = "super")]
    public async Task<IActionResult> Delete(int? id) {
      if (id == null) {
        return NotFound();
      }

      var citacaoEdital = await _context.CitacaoEdital
          .FirstOrDefaultAsync(m => m.Id == id);
      if (citacaoEdital == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(citacaoEdital);
    }

    // POST: CitacaoEdital/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "super")]
    public async Task<IActionResult> DeleteConfirmed(int id) {
      var citacaoEdital = await _context.CitacaoEdital.FindAsync(id);
      _context.CitacaoEdital.Remove(citacaoEdital);
      await _context.SaveChangesAsync();
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      TempData["mensagemDelete"] = "Ok";
      return RedirectToAction(nameof(Index));
    }

    private bool CitacaoEditalExists(int id) {
      return _context.CitacaoEdital.Any(e => e.Id == id);
    }
  }
}
