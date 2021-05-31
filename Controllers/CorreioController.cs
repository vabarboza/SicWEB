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
  public class CorreioController : Controller {
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();
    private readonly ApplicationDbContext _context;

    public CorreioController(ApplicationDbContext context) {
      _context = context;
    }

    // GET: Correio
    [Authorize(Policy = "usuario")]
    public async Task<IActionResult> Index() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.Correio.ToListAsync());
    }

    // GET: Correio/Details/5
    [Authorize(Policy = "usuario")]
    public async Task<IActionResult> Details(int? id) {
      if (id == null) {
        return NotFound();
      }

      var correio = await _context.Correio
          .FirstOrDefaultAsync(m => m.Id == id);
      if (correio == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(correio);
    }

    // GET: Correio/Create
    public IActionResult Create() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      ViewBag.SetorUser = c.SetorUser(User.Identity.Name);
      return View();
    }

    // POST: Correio/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Policy = "usuario")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Status,DataEnvio,Tipo,Destinatario,Cidade,Remetente,Setor,Atualizacao")] Correio correio) {
      if (ModelState.IsValid) {
        _context.Add(correio);
        await _context.SaveChangesAsync();
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
        TempData["mensagemCreate"] = "MSG";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(correio);
    }

    // GET: Correio/Edit/5
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Edit(int? id) {
      if (id == null) {
        return NotFound();
      }

      var correio = await _context.Correio.FindAsync(id);
      if (correio == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(correio);
    }

    // POST: Correio/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Policy = "admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Status,DataEnvio,Tipo,Destinatario,Cidade,Remetente,Setor,Atualizacao")] Correio correio) {
      if (id != correio.Id) {
        return NotFound();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update(correio);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!CorreioExists(correio.Id)) {
            return NotFound();
          } else {
            throw;
          }
        }
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
        TempData["mensagemEdit"] = "MSG";
        return RedirectToAction(nameof(Index));
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(correio);
    }

    // GET: Correio/Delete/5
    [Authorize(Policy = "super")]
    public async Task<IActionResult> Delete(int? id) {
      if (id == null) {
        return NotFound();
      }

      var correio = await _context.Correio
          .FirstOrDefaultAsync(m => m.Id == id);
      if (correio == null) {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(correio);
    }

    // POST: Correio/Delete/5
    [Authorize(Policy = "super")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
      var correio = await _context.Correio.FindAsync(id);
      _context.Correio.Remove(correio);
      await _context.SaveChangesAsync();
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      TempData["mensagemDelete"] = "MSG";
      return RedirectToAction(nameof(Index));
    }

    private bool CorreioExists(int id) {
      return _context.Correio.Any(e => e.Id == id);
    }
  }
}
