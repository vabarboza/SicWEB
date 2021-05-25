using BellinatiCorreio.Views.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SicWEB.Data;
using SicWEB.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicWEB.Controllers {
  [Authorize]
  public class ExpedicaoMandadoCitacaoController : Controller {
    private readonly ApplicationDbContext _context;
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();

    public ExpedicaoMandadoCitacaoController(ApplicationDbContext context) {
      _context = context;
    }

    // GET: ExpedicaoMandadoCitacao
    public async Task<IActionResult> Index() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.ExpedicaoMandadoCitacao.ToListAsync());
    }

    // GET: ExpedicaoMandadoCitacao/Details/5
    public async Task<IActionResult> Details(int? id) {
      if (id == null) {
        return NotFound();
      }

      var expedicaoMandadoCitacao = await _context.ExpedicaoMandadoCitacao
          .FirstOrDefaultAsync(m => m.Id == id);
      if (expedicaoMandadoCitacao == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoMandadoCitacao);
    }

    // GET: ExpedicaoMandadoCitacao/Create
    [Authorize(Policy = "usuario")]
    public IActionResult Create() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View();
    }

    // POST: ExpedicaoMandadoCitacao/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "usuario")]
    public async Task<IActionResult> Create([Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,Endereco,Oab,Data,NomeUser")] ExpedicaoMandadoCitacao expedicaoMandadoCitacao) {
      if (_context.ExpedicaoMandadoCitacao.Any(x => x.Contrato == expedicaoMandadoCitacao.Contrato)) {
        ModelState.AddModelError("Contrato", "Contrato ja foi cadastrado");
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      }
      if (ModelState.IsValid) {
        _context.Add(expedicaoMandadoCitacao);
        await _context.SaveChangesAsync();
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
        TempData["mensagemCreate"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoMandadoCitacao);
    }

    // GET: ExpedicaoMandadoCitacao/Edit/5
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Edit(int? id) {
      if (id == null) {
        return NotFound();
      }

      var expedicaoMandadoCitacao = await _context.ExpedicaoMandadoCitacao.FindAsync(id);
      if (expedicaoMandadoCitacao == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoMandadoCitacao);
    }

    // POST: ExpedicaoMandadoCitacao/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,Endereco,Oab,Data,NomeUser")] ExpedicaoMandadoCitacao expedicaoMandadoCitacao) {
      if (id != expedicaoMandadoCitacao.Id) {
        return NotFound();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update(expedicaoMandadoCitacao);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!ExpedicaoMandadoCitacaoExists(expedicaoMandadoCitacao.Id)) {
            return NotFound();
          } else {
            throw;
          }
        }
        TempData["mensagemEdit"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoMandadoCitacao);
    }

    // GET: ExpedicaoMandadoCitacao/Delete/5
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Delete(int? id) {
      if (id == null) {
        return NotFound();
      }

      var expedicaoMandadoCitacao = await _context.ExpedicaoMandadoCitacao
          .FirstOrDefaultAsync(m => m.Id == id);
      if (expedicaoMandadoCitacao == null) {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoMandadoCitacao);
    }

    // POST: ExpedicaoMandadoCitacao/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> DeleteConfirmed(int id) {
      var expedicaoMandadoCitacao = await _context.ExpedicaoMandadoCitacao.FindAsync(id);
      _context.ExpedicaoMandadoCitacao.Remove(expedicaoMandadoCitacao);
      await _context.SaveChangesAsync();
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      TempData["mensagemDelete"] = "Ok";
      return RedirectToAction(nameof(Index));
    }

    private bool ExpedicaoMandadoCitacaoExists(int id) {
      return _context.ExpedicaoMandadoCitacao.Any(e => e.Id == id);
    }
  }
}
