using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BellinatiCorreio.Views.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using SicWEB.Data;
using SicWEB.Models;

namespace SicWEB.Controllers
{
  [Authorize]
  public class JuntadaTermoCessaoController : Controller
  {
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();
    private readonly ApplicationDbContext _context;

    public JuntadaTermoCessaoController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: JuntadaTermoCessao
    public async Task<IActionResult> Index()
    {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.JuntadaTermoCessao.ToListAsync());
    }

    // GET: JuntadaTermoCessao/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var juntadaTermoCessao = await _context.JuntadaTermoCessao
          .FirstOrDefaultAsync(m => m.Id == id);
      if (juntadaTermoCessao == null)
      {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(juntadaTermoCessao);
    }

    // GET: JuntadaTermoCessao/Create
    public IActionResult Create()
    {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View();
    }

    // POST: JuntadaTermoCessao/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,BancoCedente,Reu,Oab,Data,NomeUser")] JuntadaTermoCessao juntadaTermoCessao)
    {
      if (_context.JuntadaTermoCessao.Any(x => x.Contrato == juntadaTermoCessao.Contrato))
      {
        ModelState.AddModelError("Contrato", "Contrato ja foi cadastrado");
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      }
      if (ModelState.IsValid)
      {
        _context.Add(juntadaTermoCessao);
        await _context.SaveChangesAsync();
        TempData["mensagemCreate"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      return View(juntadaTermoCessao);
    }

    // GET: JuntadaTermoCessao/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var juntadaTermoCessao = await _context.JuntadaTermoCessao.FindAsync(id);
      if (juntadaTermoCessao == null)
      {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(juntadaTermoCessao);
    }

    // POST: JuntadaTermoCessao/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,BancoCedente,Reu,Oab,Data,NomeUser")] JuntadaTermoCessao juntadaTermoCessao)
    {
      if (id != juntadaTermoCessao.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(juntadaTermoCessao);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!JuntadaTermoCessaoExists(juntadaTermoCessao.Id))
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
      return View(juntadaTermoCessao);
    }

    // GET: JuntadaTermoCessao/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var juntadaTermoCessao = await _context.JuntadaTermoCessao
          .FirstOrDefaultAsync(m => m.Id == id);
      if (juntadaTermoCessao == null)
      {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(juntadaTermoCessao);
    }

    // POST: JuntadaTermoCessao/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var juntadaTermoCessao = await _context.JuntadaTermoCessao.FindAsync(id);
      _context.JuntadaTermoCessao.Remove(juntadaTermoCessao);
      await _context.SaveChangesAsync();
      TempData["mensagemDelete"] = "Ok";
      return RedirectToAction(nameof(Index));
    }

    private bool JuntadaTermoCessaoExists(int id)
    {
      return _context.JuntadaTermoCessao.Any(e => e.Id == id);
    }

    public FileResult GerarRelatorio(int? id)
    {
      using (var doc = new PdfSharpCore.Pdf.PdfDocument())
      {
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

        List<JuntadaTermoCessao> dados = new List<JuntadaTermoCessao>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = c.ConexaoDados();
        con.Open();
        string data = DateTime.Now.ToShortDateString();
        MySqlCommand command = new MySqlCommand("SELECT * FROM juntadatermocessao  WHERE  Id = '" + id + "'", con);
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
          while (reader.Read())
          {
            dados.Add(new JuntadaTermoCessao()
            {
              Autos = reader.GetString("Autos"),
              Contrato = reader.GetInt64("Contrato"),
              Vara = reader.GetString("Vara"),
              Comarca = reader.GetString("Comarca"),
              Estado = reader.GetString("Estado"),
              Banco = reader.GetString("Banco"),
              Reu = reader.GetString("Reu"),
              BancoCedente = reader.GetString("BancoCedente"),
              Oab = reader.GetString("Oab"),
              Data = reader.GetString("Data")
            }); ;
          }
          Console.WriteLine(data);
        }

        for (int i = 0; i < dados.Count; i++)
        {

          //Imagem todo da pagina
          XImage imagem = XImage.FromFile(logo);
          grafics.DrawImage(imagem, 200, 40, 200, 80);

          var topo =
            "EXCELENTÍSSIMO SENHOR DOUTOR JUIZ DE DIREITO DA " + dados[i].Vara + " DA " + dados[i].Comarca + " – ESTADO DO " + dados[i].Estado;

          var dadosAutos =
            "Autos nº: " + dados[i].Autos + "\n" +
            "Contrato nº: " + dados[i].Contrato;


          var texto =
            "                                 " + dados[i].Banco + ", já qualificado, conforme procuração anexa, vem, nos " +
            "autos em epígrafe, que " + dados[i].BancoCedente + " litiga contra " + dados[i].Reu + ", já também devidamente " +
            "qualificada, vem, por seu procurador signatário, respeitosamente, à Douta presença de Vossa Excelência, " +
            "em atendimento ao despacho retro, REQUERER a juntada do comprovante da cessão do crédito, decorrente do " +
            "contrato objeto da lide.\n \n \n" +

            "                                 Diante deste fato, pugna a parte autora a admissão no polo ativo destes autos, " +
            "como cessionária o " + dados[i].Banco + ", nos termos do artigo 567 II, " +
            "do Código de Processo Civil, bem como sejam procedidas todas as anotações de estilo o cartório distribuidor e " +
            "na autuação do feito, nos termos de termo de cessão específico acostado ao final.\n \n \n" +

            "                                 Caso não seja o entendimento deste D. Juízo, requer de forma subsidiaria, " +
            "que " + dados[i].Banco + ", figure como assistente litisconsorcial, com base no artigo 109, § 2ª, do CPC.\n \n \n" +

            "                                 In fine, requer que todas as intimações se deem na forma prevista nos " +
            "artigos 272 e 273 do NCPC, para que sejam publicadas apenas em nome da Dra. " +
            "CRISTIANE BELLINATI GARCIA LOPES, " + dados[i].Oab + ", sob pena de nulidade da intimação, conforme previsto no " +
            "artigo 280 do CPC.\n \n \n" +

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
          XRect rectTopo = new XRect(48, 155, 490, page.Height);
          textJustify.DrawString(topo, fonteTitulo, corFonte, rectTopo, XStringFormats.TopLeft);

          //Dados do Contrato
          textJustify.Alignment = XParagraphAlignment.Left;
          XRect rectDados = new XRect(48, 230, 490, page.Height);
          textJustify.DrawString(dadosAutos, fonteNegrito, corFonte, rectDados, XStringFormats.TopLeft);

          //Dados do Texto
          textJustify.Alignment = XParagraphAlignment.Justify;
          XRect rectTexto = new XRect(48, 290, 490, page.Height);
          textJustify.DrawString(texto, fonteOrganizacao, corFonte, rectTexto, XStringFormats.TopLeft);

          //Texto OAB
          textJustify.Alignment = XParagraphAlignment.Center;
          XRect rectOab = new XRect(48, 680, 490, page.Height);
          textJustify.DrawString(oab, fonteTitulo, corFonte, rectOab, XStringFormats.TopLeft);

          textJustify.Alignment = XParagraphAlignment.Center;
          XRect rectenderecoRodape = new XRect(48, 790, 490, page.Height);
          textJustify.DrawString(enderecoRodape, fonteDetalhes, corFonte, rectenderecoRodape, XStringFormats.TopLeft);
        }

        using (MemoryStream stream = new MemoryStream())
        {
          var contentType = "application/pdf";
          doc.Save(stream, false);
          var nomeArquivo = "Juntada Termo de Cessão.pdf";
          return File(stream.ToArray(), contentType, nomeArquivo);
        }
      }
    }


  }
}
