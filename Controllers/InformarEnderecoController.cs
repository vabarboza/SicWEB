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
  public class InformarEnderecoController : Controller {
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();

    private readonly ApplicationDbContext _context;

    public InformarEnderecoController(ApplicationDbContext context) {
      _context = context;
    }

    // GET: InformarEndereco
    public async Task<IActionResult> Index() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.InformarEndereco.ToListAsync());
    }

    // GET: InformarEndereco/Details/5
    public async Task<IActionResult> Details(int? id) {
      if (id == null) {
        return NotFound();
      }

      var informarEndereco = await _context.InformarEndereco
          .FirstOrDefaultAsync(m => m.Id == id);
      if (informarEndereco == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(informarEndereco);
    }

    // GET: InformarEndereco/Create
    [Authorize(Policy = "usuario")]
    public IActionResult Create() {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View();
    }

    // POST: InformarEndereco/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "usuario")]
    public async Task<IActionResult> Create([Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,Endereco,Oab,Data,NomeUser")] InformarEndereco informarEndereco) {
      if (_context.InformarEndereco.Any(x => x.Contrato == informarEndereco.Contrato)) {
        ModelState.AddModelError("Contrato", "Contrato ja foi cadastrado");
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      }
      if (ModelState.IsValid) {
        _context.Add(informarEndereco);
        await _context.SaveChangesAsync();
        TempData["mensagemCreate"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(informarEndereco);
    }

    // GET: InformarEndereco/Edit/5
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Edit(int? id) {
      if (id == null) {
        return NotFound();
      }

      var informarEndereco = await _context.InformarEndereco.FindAsync(id);
      if (informarEndereco == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(informarEndereco);
    }

    // POST: InformarEndereco/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [Authorize(Policy = "admin")]
    [HttpPost]
    [ValidateAntiForgeryToken]
  
    public async Task<IActionResult> Edit(int id, [Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,Endereco,Oab,Data,NomeUser")] InformarEndereco informarEndereco) {
      if (id != informarEndereco.Id) {
        return NotFound();
      }

      if (ModelState.IsValid) {
        try {
          _context.Update(informarEndereco);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) {
          if (!InformarEnderecoExists(informarEndereco.Id)) {
            return NotFound();
          } else {
            throw;
          }
        }
        TempData["mensagemEdit"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(informarEndereco);
    }

    // GET: InformarEndereco/Delete/5
    [Authorize(Policy = "super")]
    public async Task<IActionResult> Delete(int? id) {
      if (id == null) {
        return NotFound();
      }

      var informarEndereco = await _context.InformarEndereco
          .FirstOrDefaultAsync(m => m.Id == id);
      if (informarEndereco == null) {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(informarEndereco);
    }

    // POST: InformarEndereco/Delete/5
    [Authorize(Policy = "super")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
      var informarEndereco = await _context.InformarEndereco.FindAsync(id);
      _context.InformarEndereco.Remove(informarEndereco);
      await _context.SaveChangesAsync();
      TempData["mensagemDelete"] = "Ok";
      return RedirectToAction(nameof(Index));
    }

    private bool InformarEnderecoExists(int id) {
      return _context.InformarEndereco.Any(e => e.Id == id);
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

        List<InformarEndereco> dados = new List<InformarEndereco>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = c.ConexaoDados();
        con.Open();
        string data = DateTime.Now.ToShortDateString();
        MySqlCommand command = new MySqlCommand("SELECT * FROM informarendereco  WHERE  Id = '" + id + "'", con);
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows) {
          while (reader.Read()) {
            dados.Add(new InformarEndereco() {
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
            "                                 " + dados[i].Banco + ", já qualificada nos autos em epígrafe, que litiga " +
            "contra " + dados[i].Reu + ", também já qualificada, por seus advogados que esta subscrevem, vem, " +
            "respeitosamente perante Vossa Excelência, INFORMAR o endereço da parte ré, para que proceda com a " +
            "expedição do respectivo mandado, o qual segue: " + dados[i].Endereco + "\n \n \n" +

            "Outrossim, requer que todas as intimações dos atos processuais destes autos sejam efetivadas na " +
            "forma prevista nos artigos 270 e 272 do Novo C.P.C.(Lei 13.105/2015), na pessoa de " +
            "Cristiane Belinati Garcia Lopes, " + dados[i].Oab + ", independentemente dos demais procuradores " +
            "constantes nas procurações e substabelecimentos juntados a estes autos, sob pena de nulidade da intimação, " +
            "conforme previsto no artigo 280 do Novo C.P.C.\n \n \n" +

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
          var nomeArquivo = "Informar Endereço.pdf";
          return File(stream.ToArray(), contentType, nomeArquivo);
        }
      }
    }


  }
}
