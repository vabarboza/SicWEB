using BellinatiCorreio.Views.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PdfSharpCore.Drawing;
using SicWEB.Data;
using SicWEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SicWEB.Controllers {
  [Authorize]
  public class MalotesController : Controller {
    static Conexao c = new Conexao();
    static Mail mail = new Mail();

    public static string sql = c.ConexaoDados();

    private readonly ApplicationDbContext _context;

    public MalotesController(ApplicationDbContext context) {
      _context = context;
    }

    // GET: Malotes
    public async Task<IActionResult> Index() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.Malote.ToListAsync());
    }

    // GET: Malotes/Details/5
    public async Task<IActionResult> Details(int? id) {
      if (id == null) {
        return NotFound();
      }

      var malote = await _context.Malote
          .FirstOrDefaultAsync(m => m.Id == id);
      if (malote == null) {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(malote);
    }


    // GET: Malotes/Create
    [Authorize(Policy = "usuario")]
    public IActionResult Create() {
      ViewBag.CidadeUser = c.CidadeUser(User.Identity.Name);
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View();
    }

    // POST: Malotes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "usuario")]
    public async Task<IActionResult> Create([Bind("Id,Numero,Percurso,Lacre,Cidade,Remetente,Status,Atualizacao,DataEnvio,DataRecebido,CidadeSaida,NomeUser")] Malote malote) {
      if (ModelState.IsValid) {
        _context.Add(malote);
        await _context.SaveChangesAsync();
        TempData["mensagemCreate"] = "MSG";
        var remetente = c.EmailUser(User.Identity.Name);
        mail.enviaMalote(malote.Status, malote.DataEnvio, malote.Cidade, malote.Numero, malote.Percurso, malote.Lacre, malote.Remetente, remetente);
        return RedirectToAction(nameof(Index));
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(malote);
    }

    // GET: Malotes/Edit/5
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Edit(int? id) {
      if (id == null) {
        return NotFound();
      }

      var malote = await _context.Malote.FindAsync(id);
      if (malote == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(malote);
    }

    // POST: Malotes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Policy = "admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Numero,Percurso,Lacre,Cidade,Remetente,Status,Atualizacao,DataEnvio,DataRecebido,CidadeSaida,NomeUser")] Malote malote) {
      if (id != malote.Id) {
        return NotFound();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update(malote);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!MaloteExists(malote.Id)) {
            return NotFound();
          } else {
            throw;
          }
        }
        TempData["mensagemEdit"] = "MSG";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(malote);
    }

    // GET: Malotes/Delete/5
    [Authorize(Policy = "super")]
    public async Task<IActionResult> Delete(int? id) {
      if (id == null) {
        return NotFound();
      }

      var malote = await _context.Malote
          .FirstOrDefaultAsync(m => m.Id == id);
      if (malote == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(malote);
    }

    // POST: Malotes/Delete/5
    [Authorize(Policy = "super")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
      var malote = await _context.Malote.FindAsync(id);
      _context.Malote.Remove(malote);
      await _context.SaveChangesAsync();
      TempData["mensagemDelete"] = "MSG";
      return RedirectToAction(nameof(Index));
    }

    private bool MaloteExists(int id) {
      return _context.Malote.Any(e => e.Id == id);
    }

    public FileResult GerarRelatorio() {
      using (var doc = new PdfSharpCore.Pdf.PdfDocument()) {
        var page = doc.AddPage();
        page.Size = PdfSharpCore.PageSize.A4;
        page.Orientation = PdfSharpCore.PageOrientation.Portrait;

        List<Malote> lst = new List<Malote>();
        lst.Add(new Malote() { Remetente = "Teste", Cidade = "Teste" });

        var grafics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
        var corFonte = PdfSharpCore.Drawing.XBrushes.Black;
        var textFormatter = new PdfSharpCore.Drawing.Layout.XTextFormatter(grafics);
        var fonteOrganizacao = new PdfSharpCore.Drawing.XFont("Arial", 10);
        var fonteTitulo = new PdfSharpCore.Drawing.XFont("Arial", 10, PdfSharpCore.Drawing.XFontStyle.Bold);
        var fonteDesc = new PdfSharpCore.Drawing.XFont("Arial", 8, PdfSharpCore.Drawing.XFontStyle.Bold);
        var titulo = new PdfSharpCore.Drawing.XFont("Arial", 14, PdfSharpCore.Drawing.XFontStyle.Bold);
        var fonteDetalhes = new PdfSharpCore.Drawing.XFont("Arial", 7);
        var logo = @"C:\Logo.png";

        var qtdpaginas = doc.PageCount;

        textFormatter.DrawString(qtdpaginas.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 7), corFonte,
          new PdfSharpCore.Drawing.XRect(575, 825, page.Width, page.Height));

        XImage imagem = XImage.FromFile(logo);
        grafics.DrawImage(imagem, 160, 15, 280, 150);

        textFormatter.DrawString("Protocolo de Envio de Malote", titulo, corFonte, new PdfSharpCore.Drawing.XRect(200, 160, page.Width, page.Height));

        textFormatter.DrawString("REMETENTE", fonteTitulo, corFonte, new PdfSharpCore.Drawing.XRect(70, 210, page.Width, page.Height));
        textFormatter.DrawString("DESTINO", fonteTitulo, corFonte, new PdfSharpCore.Drawing.XRect(170, 210, page.Width, page.Height));
        textFormatter.DrawString("N. LACRE ", fonteTitulo, corFonte, new PdfSharpCore.Drawing.XRect(270, 210, page.Width, page.Height));
        textFormatter.DrawString("PERCURSO", fonteTitulo, corFonte, new PdfSharpCore.Drawing.XRect(370, 210, page.Width, page.Height));
        textFormatter.DrawString("N. MALOTE", fonteTitulo, corFonte, new PdfSharpCore.Drawing.XRect(470, 210, page.Width, page.Height));


        List<Malote> alunos = new List<Malote>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = c.ConexaoDados();
        con.Open();
        string data = DateTime.Now.ToShortDateString();
        //Npgsql.NpgsqlCommand command = new Npgsql.NpgsqlCommand("SELECT" + '"' + "Remetente" + '"' + " , " + '"' + "Cidade" + "FROM" + '"' + "MaloteModel" + '"', con);
        MySqlCommand command = new MySqlCommand("SELECT * FROM Malote  WHERE  DataEnvio = '" + DateTime.Today.ToString("yyyy/MM/dd") + "'", con);
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows) {
          while (reader.Read()) {
            alunos.Add(new Malote() {
              CidadeSaida = reader.GetString("CidadeSaida"),
              Cidade = reader.GetString("Cidade"),
              Lacre = reader.GetInt32("Lacre"),
              Percurso = reader.GetInt32("Percurso"),
              Numero = reader.GetInt32("Numero")

            });
          }
          Console.WriteLine(data);
        }

        var alturaItens = 230;
        for (int i = 0; i < alunos.Count; i++) {
          textFormatter.DrawString(alunos[i].CidadeSaida, fonteOrganizacao, corFonte, new PdfSharpCore.Drawing.XRect(70, alturaItens, page.Width, page.Height));
          textFormatter.DrawString(alunos[i].Cidade, fonteOrganizacao, corFonte, new PdfSharpCore.Drawing.XRect(170, alturaItens, page.Width, page.Height));
          textFormatter.DrawString(alunos[i].Lacre.ToString(), fonteOrganizacao, corFonte, new PdfSharpCore.Drawing.XRect(270, alturaItens, page.Width, page.Height));
          textFormatter.DrawString(alunos[i].Percurso.ToString(), fonteOrganizacao, corFonte, new PdfSharpCore.Drawing.XRect(370, alturaItens, page.Width, page.Height));
          textFormatter.DrawString(alunos[i].Numero.ToString(), fonteOrganizacao, corFonte, new PdfSharpCore.Drawing.XRect(470, alturaItens, page.Width, page.Height));

          alturaItens += 20;
        }

        textFormatter.DrawString("________________________________", fonteOrganizacao, corFonte,
          new PdfSharpCore.Drawing.XRect(50, 750, page.Width, page.Height));

        textFormatter.DrawString("________________________________", fonteOrganizacao, corFonte,
          new PdfSharpCore.Drawing.XRect(360, 750, page.Width, page.Height));

        textFormatter.DrawString("Correios", fonteOrganizacao, corFonte,
          new PdfSharpCore.Drawing.XRect(50, 770, page.Width, page.Height));

        textFormatter.DrawString("Grupo Bellinati", fonteOrganizacao, corFonte,
          new PdfSharpCore.Drawing.XRect(360, 770, page.Width, page.Height));


        using (MemoryStream stream = new MemoryStream()) {
          var contentType = "application/pdf";
          doc.Save(stream, false);
          var nomeArquivo = "Protocolo do Malote: " + DateTime.Today.ToString("dd/MM/yyyy") + ".pdf";

          return File(stream.ToArray(), contentType, nomeArquivo);

        }

      }
    }


  }
}
