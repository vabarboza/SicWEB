using BellinatiCorreio.Views.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using SicWEB.Data;
using SicWEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SicWEB.Controllers {
  [Authorize]
  public class ExpedicaoNovoMandadoController : Controller {
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();
    private readonly ApplicationDbContext _context;

    public ExpedicaoNovoMandadoController(ApplicationDbContext context) {
      _context = context;
    }

    // GET: ExpedicaoNovoMandado
    public async Task<IActionResult> Index() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.ExpedicaoNovoMandado.ToListAsync());
    }

    // GET: ExpedicaoNovoMandado/Details/5
    public async Task<IActionResult> Details(int? id) {
      if (id == null) {
        return NotFound();
      }

      var expedicaoNovoMandado = await _context.ExpedicaoNovoMandado
          .FirstOrDefaultAsync(m => m.Id == id);
      if (expedicaoNovoMandado == null) {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoNovoMandado);
    }

    // GET: ExpedicaoNovoMandado/Create
    [Authorize(Policy = "usuario")]
    public IActionResult Create() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View();
    }

    // POST: ExpedicaoNovoMandado/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "usuario")]
    public async Task<IActionResult> Create([Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,Endereco,Oab,Data,NomeUser")] ExpedicaoNovoMandado expedicaoNovoMandado) {
      if (_context.ExpedicaoNovoMandado.Any(x => x.Contrato == expedicaoNovoMandado.Contrato)) {
        ModelState.AddModelError("Contrato", "Contrato ja foi cadastrado");
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      }
      if (ModelState.IsValid) {
        _context.Add(expedicaoNovoMandado);
        await _context.SaveChangesAsync();
        TempData["mensagemCreate"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoNovoMandado);
    }



    // GET: ExpedicaoNovoMandado/Edit/5
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Edit(int? id) {
      if (id == null) {
        return NotFound();
      }

      var expedicaoNovoMandado = await _context.ExpedicaoNovoMandado.FindAsync(id);
      if (expedicaoNovoMandado == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoNovoMandado);
    }

    // POST: ExpedicaoNovoMandado/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Policy = "admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,Endereco,Oab,Data,NomeUser")] ExpedicaoNovoMandado expedicaoNovoMandado) {
      if (id != expedicaoNovoMandado.Id) {
        return NotFound();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update(expedicaoNovoMandado);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!ExpedicaoNovoMandadoExists(expedicaoNovoMandado.Id)) {
            return NotFound();
          } else {
            throw;
          }
        }
        TempData["mensagemEdit"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoNovoMandado);
    }



    // GET: ExpedicaoNovoMandado/Delete/5
    [Authorize(Policy = "super")]
    public async Task<IActionResult> Delete(int? id) {
      if (id == null) {
        return NotFound();
      }

      var expedicaoNovoMandado = await _context.ExpedicaoNovoMandado
          .FirstOrDefaultAsync(m => m.Id == id);
      if (expedicaoNovoMandado == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(expedicaoNovoMandado);
    }

    // POST: ExpedicaoNovoMandado/Delete/5
    [Authorize(Policy = "super")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
      var expedicaoNovoMandado = await _context.ExpedicaoNovoMandado.FindAsync(id);
      _context.ExpedicaoNovoMandado.Remove(expedicaoNovoMandado);
      await _context.SaveChangesAsync();
      TempData["mensagemDelete"] = "Ok";
      return RedirectToAction(nameof(Index));
    }

    private bool ExpedicaoNovoMandadoExists(int id) {
      return _context.ExpedicaoNovoMandado.Any(e => e.Id == id);
    }

    public FileResult GerarRelatorio(int? id) {
      using (var doc = new PdfSharpCore.Pdf.PdfDocument()) {
        var page = doc.AddPage();
        page.Size = PdfSharpCore.PageSize.A4;
        page.Orientation = PdfSharpCore.PageOrientation.Portrait;

        var grafics = XGraphics.FromPdfPage(page);
        var corFonte = XBrushes.Black;
        var textFormatter = new XTextFormatter(grafics);
        var textJustify = new XTextFormatter(grafics);
        var fonteOrganizacao = new XFont("Times New Roman", 12);
        var fonteTitulo = new XFont("Times New Roman", 12, XFontStyle.Bold);
        var fonteDesc = new XFont("Times New Roman", 8, XFontStyle.Bold);
        var titulo = new XFont("Times New Roman", 10, XFontStyle.Bold);
        var fonteDetalhes = new XFont("Times New Roman", 7);
        var fonteNegrito = new XFont("Times New Roman", 12, XFontStyle.Bold);
        var logo = @"C:\Logo.png";
        var qtdpaginas = doc.PageCount;


        textFormatter.DrawString(qtdpaginas.ToString(), new XFont("Arial", 7), corFonte,
        new XRect(575, 825, page.Width, page.Height));

        List<ExpedicaoNovoMandado> dados = new List<ExpedicaoNovoMandado>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = c.ConexaoDados();
        con.Open();
        string data = DateTime.Now.ToShortDateString();
        MySqlCommand command = new MySqlCommand("SELECT * FROM expedicaonovomandado  WHERE  Id = '" + id + "'", con);
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows) {
          while (reader.Read()) {
            dados.Add(new ExpedicaoNovoMandado() {
              Autos = reader.GetString("Autos"),
              Contrato = reader.GetInt64("Contrato"),
              Vara = reader.GetString("Vara"),
              Comarca = reader.GetString("Comarca"),
              Estado = reader.GetString("Estado"),
              Banco = reader.GetString("Banco"),
              Reu = reader.GetString("Reu"),
              Endereco = reader.GetString("Endereco"),
              Oab = reader.GetString("Oab"),
              Data = reader.GetString("Data")
            }); ;
          }
          Console.WriteLine(data);
        }

        for (int i = 0; i < dados.Count; i++) {

          //Imagem todo da pagina
          XImage imagem = XImage.FromFile(logo);
          grafics.DrawImage(imagem, 230, 40, 150, 80);

          var topo =
            "EXCELENTÍSSIMO SENHOR DOUTOR JUIZ DE DIREITO DA " + dados[i].Vara + " DA " + dados[i].Comarca + " – ESTADO DO " + dados[i].Estado;

          var dadosAutos =
            "Autos nº: " + dados[i].Autos + "\n" +
            "Contrato nº: " + dados[i].Contrato;


          var texto =
            "                                 " + dados[i].Banco + ", já qualificada(o) nos autos em epígrafe, " +
            "que move em face de " + dados[i].Reu + ", também já qualificada(o), por seus advogados que esta subscrevem, vem, " +
            "respeitosamente perante Vossa Excelência, REQUERER a expedição de novo mandado para o seguinte endereço: " +
            "" + dados[i].Endereco + ", com o intuito de citar o requerido e apreender o bem, objeto da presente ação. \n \n \n" +
            "                              Outrossim, requer que todas as intimações dos atos processuais destes autos sejam efetivadas " +
            "na forma prevista nos artigos 270 e 272 do CPC (Lei 13.105/2015), " +
            "na pessoa de Cristiane Belinati Garcia Lopes, " + dados[i].Oab + ", independentemente dos demais procuradores constantes nas procurações " +
            "e substabelecimentos juntados a estes autos, sob pena de nulidade da intimação, conforme previsto no artigo 280 do CPC.\n \n \n" +
            "                                 Termos em que,\n" +
            "                                 Pede deferimento.\n" +
            "                                 Maringá / PR, " + dados[i].Data;


          var oab =
            "CRISTIANE BELINATI GARCIA LOPES\n" +
            dados[i].Oab;

          var enderecoRodape =
            "Endereço: Rua João Paulino Vieira Filho, 625, 12º andar – Sala 1201\n" +
            "Bairro: Zona 01 CEP: 87020-015 - Fone: (44) 3033-9291 / (44) 2103-9291\n" +
            "Maringa/PR";

          //Texto do Topo
          textJustify.Alignment = XParagraphAlignment.Left;
          XRect rectTopo = new XRect(50, 155, 490, page.Height);
          textJustify.DrawString(topo, fonteTitulo, corFonte, rectTopo, XStringFormats.TopLeft);

          //Dados do Contrato
          textJustify.Alignment = XParagraphAlignment.Left;
          XRect rectDados = new XRect(50, 230, 490, page.Height);
          textJustify.DrawString(dadosAutos, fonteNegrito, corFonte, rectDados, XStringFormats.TopLeft);

          //Dados do Texto
          textJustify.Alignment = XParagraphAlignment.Justify;
          XRect rectTexto = new XRect(50, 290, 490, page.Height);
          textJustify.DrawString(texto, fonteOrganizacao, corFonte, rectTexto, XStringFormats.TopLeft);

          //Texto OAB
          textJustify.Alignment = XParagraphAlignment.Center;
          XRect rectOab = new XRect(50, 625, 490, page.Height);
          textJustify.DrawString(oab, fonteTitulo, corFonte, rectOab, XStringFormats.TopLeft);

          textJustify.Alignment = XParagraphAlignment.Center;
          XRect rectenderecoRodape = new XRect(50, 790, 490, page.Height);
          textJustify.DrawString(enderecoRodape, fonteDetalhes, corFonte, rectenderecoRodape, XStringFormats.TopLeft);
        }

        using (MemoryStream stream = new MemoryStream()) {
          var contentType = "application/pdf";
          doc.Save(stream, false);
          var nomeArquivo = "Expedicao de Mandado.pdf";
          return File(stream.ToArray(), contentType, nomeArquivo);
        }
      }
    }

  }
}
