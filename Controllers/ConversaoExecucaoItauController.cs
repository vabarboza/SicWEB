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

namespace SicWEB.Controllers
{
  [Authorize]
  public class ConversaoExecucaoItauController : Controller
  {
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();

    private readonly ApplicationDbContext _context;

    public ConversaoExecucaoItauController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: ConversaoExecucaoItau
    public async Task<IActionResult> Index()
    {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.ConversaoExecucaoItau.ToListAsync());
    }

    // GET: ConversaoExecucaoItau/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var conversaoExecucaoItau = await _context.ConversaoExecucaoItau
          .FirstOrDefaultAsync(m => m.Id == id);
      if (conversaoExecucaoItau == null)
      {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucaoItau);
    }

    // GET: ConversaoExecucaoItau/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: ConversaoExecucaoItau/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Processo,Vara,Comarca,Estado,Banco,Reu,ValorReal,Oab,Data,NomeUser")] ConversaoExecucaoItau conversaoExecucaoItau)
    {
      if (_context.ConversaoExecucaoItau.Any(x => x.Processo == conversaoExecucaoItau.Processo))
      {
        ModelState.AddModelError("Contrato", "Contrato ja foi cadastrado");
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      }
      if (ModelState.IsValid)
      {
        _context.Add(conversaoExecucaoItau);
        await _context.SaveChangesAsync();
        TempData["mensagemCreate"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucaoItau);
    }

    // GET: ConversaoExecucaoItau/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var conversaoExecucaoItau = await _context.ConversaoExecucaoItau.FindAsync(id);
      if (conversaoExecucaoItau == null)
      {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucaoItau);
    }

    // POST: ConversaoExecucaoItau/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Processo,Vara,Comarca,Estado,Banco,Reu,ValorReal,Oab,Data,NomeUser")] ConversaoExecucaoItau conversaoExecucaoItau)
    {
      if (id != conversaoExecucaoItau.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(conversaoExecucaoItau);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ConversaoExecucaoItauExists(conversaoExecucaoItau.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        TempData["mensagemEdit"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucaoItau);
    }

    // GET: ConversaoExecucaoItau/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var conversaoExecucaoItau = await _context.ConversaoExecucaoItau
          .FirstOrDefaultAsync(m => m.Id == id);
      if (conversaoExecucaoItau == null)
      {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucaoItau);
    }

    // POST: ConversaoExecucaoItau/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var conversaoExecucaoItau = await _context.ConversaoExecucaoItau.FindAsync(id);
      _context.ConversaoExecucaoItau.Remove(conversaoExecucaoItau);
      await _context.SaveChangesAsync();
      TempData["mensagemDelete"] = "Ok";
      return RedirectToAction(nameof(Index));
    }

    private bool ConversaoExecucaoItauExists(int id)
    {
      return _context.ConversaoExecucaoItau.Any(e => e.Id == id);
    }
  }
}
