using BellinatiCorreio.Views.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using SicWEB.Data;
using SicWEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SicWEB.Controllers
{
  [Authorize]
  public class ConversaoExecucaoController : Controller
  {
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();

    private readonly ApplicationDbContext _context;

    public ConversaoExecucaoController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: ConversaoExecucao
    public async Task<IActionResult> Index()
    {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(await _context.ConversaoExecucao.ToListAsync());
    }

    // GET: ConversaoExecucao/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var conversaoExecucao = await _context.ConversaoExecucao
          .FirstOrDefaultAsync(m => m.Id == id);
      if (conversaoExecucao == null)
      {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucao);
    }

    // GET: ConversaoExecucao/Create
    public IActionResult Create()
    {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View();
    }

    // POST: ConversaoExecucao/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,ValorReal,ValorDescrito,Oab,Data,NomeUser")] ConversaoExecucao conversaoExecucao)
    {
      if (_context.ConversaoExecucao.Any(x => x.Contrato == conversaoExecucao.Contrato))
      {
        ModelState.AddModelError("Contrato", "Contrato ja foi cadastrado");
        ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      }
      if (ModelState.IsValid)
      {
        _context.Add(conversaoExecucao);
        await _context.SaveChangesAsync();
        TempData["mensagemCreate"] = "Ok";
        return RedirectToAction(nameof(Index));
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucao);
    }

    // GET: ConversaoExecucao/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var conversaoExecucao = await _context.ConversaoExecucao.FindAsync(id);
      if (conversaoExecucao == null)
      {
        return NotFound();
      }
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucao);
    }

    // POST: ConversaoExecucao/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Autos,Contrato,Vara,Comarca,Estado,Banco,Reu,ValorReal,ValorDescrito,Oab,Data,NomeUser")] ConversaoExecucao conversaoExecucao)
    {
      if (id != conversaoExecucao.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(conversaoExecucao);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ConversaoExecucaoExists(conversaoExecucao.Id))
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
      return View(conversaoExecucao);
    }

    // GET: ConversaoExecucao/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var conversaoExecucao = await _context.ConversaoExecucao
          .FirstOrDefaultAsync(m => m.Id == id);
      if (conversaoExecucao == null)
      {
        return NotFound();
      }

      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(conversaoExecucao);
    }

    // POST: ConversaoExecucao/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var conversaoExecucao = await _context.ConversaoExecucao.FindAsync(id);
      _context.ConversaoExecucao.Remove(conversaoExecucao);
      await _context.SaveChangesAsync();
      TempData["mensagemDelete"] = "Ok";
      return RedirectToAction(nameof(Index));
    }

    private bool ConversaoExecucaoExists(int id)
    {
      return _context.ConversaoExecucao.Any(e => e.Id == id);
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

        List<ConversaoExecucao> dados = new List<ConversaoExecucao>();

        MySqlConnection con = new MySqlConnection();
        con.ConnectionString = c.ConexaoDados();
        con.Open();
        string data = DateTime.Now.ToShortDateString();
        MySqlCommand command = new MySqlCommand("SELECT * FROM conversaoexecucao  WHERE  Id = '" + id + "'", con);
        MySqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
          while (reader.Read())
          {
            dados.Add(new ConversaoExecucao()
            {
              Autos = reader.GetString("Autos"),
              Contrato = reader.GetInt64("Contrato"),
              Vara = reader.GetString("Vara"),
              Comarca = reader.GetString("Comarca"),
              Estado = reader.GetString("Estado"),
              Banco = reader.GetString("Banco"),
              Reu = reader.GetString("Reu"),
              ValorReal = reader.GetString("ValorReal"),
              ValorDescrito = reader.GetString("ValorDescrito"),
              Oab = reader.GetString("Oab"),
              Data = reader.GetString("Data")
            }); ;
          }
          Console.WriteLine(data);
        }




        for (int i = 0; i < dados.Count; i++)
        {

          //Imagem todo da pagina
          textJustify.Alignment = XParagraphAlignment.Center;
          XImage imagem = XImage.FromFile(logo);
          grafics.DrawImage(imagem, 200, 40, 200, 80);

          var topo =
            "EXCELENTÍSSIMO SENHOR DOUTOR JUIZ DE DIREITO DA " + dados[i].Vara + " DA COMARCA DE " + dados[i].Comarca + " – ESTADO DO " + dados[i].Estado;

          var dadosAutos =
            "Autos nº: " + dados[i].Autos + "\n" +
            "Contrato nº: " + dados[i].Contrato;



          var textoTopo =

            "                                 " + dados[i].Banco + ", já qualificado nos autos em epígrafe, por intermédio de " +
            "seu procurador que a esta subscreve, com escritório profissional no endereço constante do rodapé desta, " +
            "proposta em face de " + dados[i].Reu + ", também já qualificado, vem, com o devido respeito e acatamento, " +
            "perante Vossa Excelência, requerer a:";

          var textoA =

            "pelos seguintes fundamentos de fato e de direito:" +
            "Compulsando os autos, verifica - se que o veículo é deslocalizado o que inviabilizou o cumprimento da liminar e do respectivo Mandado de Busca e Apreensão. " +
            "De acordo com a legislação, é facultado ao credor o direito de requerer a conversão da busca e apreensão em ação executiva, o que se extrai do art. 5º, caput, do Decreto - Lei 911 / 69:" +
            "“Se o credor preferir recorrer a ação executiva, (…), serão penhorados, a critério do autor da ação, bens do devedor quantos bastem para assegurar a execução.”" +
            "Com efeito, o crédito resultante de financiamento concedido com garantia contratual de alienação fiduciária é perfeitamente exequível." +
            "Nesse sentido, o entendimento do Poder Judiciário:" +
            "ALIENAÇÃO FIDUCIÁRIA. BUSCA E APREENSÃO.CONVERSÃO EM AÇÃO DE EXECUÇÃO DE TÍTULO EXTRAJUDICIAL." +
            "Possibilidade não citada a parte contrária e frustrada a localização do bem, é plenamente possível a conversão nos termos do art. 5º, do Decreto - Lei 911 / 69 inteligência dos arts. 264 e 294 do Código de Processo Civil decisão reformada.RECURSO DO AUTOR PROVIDO Agravo de Instrumento nº 0116045 - 10.2011.8.26.0000 - São José do Rio Preto" +
            "“AGRAVO DE INSTRUMENTO. Conversão de busca e apreensão fiduciária em execução por quantia certa.Possibilidade.Recurso do credor.Provimento.” (Agravo de Instrumento nº0537065 26.2010.8.26.0000.Des.Rel.Carlos Russo.DJ 11.05.2011.)" +
            "“ALIENAÇÃO FIDUCIÁRIA. Ação de busca e apreensão. (...) Veículo não localizado.Réu não citado.Alteração do pedido, para que o feito prossiga como execução de título extrajudicial Admissibilidade.Inteligência dos artigos 264, do Código de Processo Civil, e 5º, do Decreto - lei nº 911 / 69 Decisão reformada -Recurso provido.” (Agravo de Instrumento nº 0081771 20.2011.8.26.0000.Des.Rel.Carlos Nunes.DJ 16.05.2011.)" +
            "Por sua vez, até mesmo em observação do que diz o STJ acerca da purgação da mora com o surgimento da Lei 10.931 / 04, é perfeitamente possível converter a ação de busca e apreensão para ação de execução pelo valor integral da dívida(parcelas vencidas + parcelas vincendas).Vejamos:" +
            "AÇÃO DE BUSCA E APREENSÃO.PURGAÇÃO DE MORA.INCABÍVEL.PAGAMENTO DA INTEGRALIDADE DO DÉBITO.REDAÇÃO DA LEI N. 10.931 / 2004. 1.A nova redação do art. 3º do Decreto - Lei n. 911 / 69, introduzida pela Lei n.10.931 / 04, não mais admite purgação da mora na ação de busca e apreensão, podendo o credor, nos termos do respectivo § 2º, pagar a integralidade da dívida pendente segundo os valores apresentados pelo credor fiduciário na inicial, hipótese na qual o bem lhe será restituído livre de ônus.2.Recurso especial provido. { (Superior Tribunal de Justiça – RECURSO ESPECIAL Nº 1.057.022 - PR(2008 / 0103343 - 2)}" +
            "Outrossim, o vencimento antecipado da dívida, que autoriza a execução pelo valor integral da dívida, decorreria não apenas de cláusula contratual ou rito processual executivo, mas também pela norma abstraída do artigo 1.425 do Código Civil Brasileiro." +
            "Observa - se, ainda, o disposto no artigo 854, caput, do Novo Código de Processo Civil:" +
            "Art. 854.Para possibilitar a penhora de dinheiro em depósito ou em aplicação financeira, o juiz, a requerimento do exequente, sem dar ciência prévia do ato ao executado, determinará às instituições financeiras, por meio de sistema eletrônico gerido pela autoridade supervisora do sistema financeiro nacional, que torne indisponíveis ativos financeiros existentes em nome do executado, limitando - se a indisponibilidade ao valor indicado na execução. (grifamos)" +
            "Aufere - se, portanto, que a alteração voluntária da Busca e Apreensão em Ação de Execução, bem como a possibilidade de tornar indisponíveis ativos financeiros em nome do executado nos limites indicados na execução, traz efetividade aos princípios da celeridade e da economia processual." +
            "DOS PEDIDOS E REQUERIMENTOS" +
            "Ante o exposto, REQUER:" +
            "a.Seja convertida a ação de busca e apreensão em ação de execução de título extrajudicial, com fundamento nos artigos 778, caput e 784, II e XII  do Novo Código de Processo Civil;" +
            "        b.Seja determinado às instituições financeiras que tornem indisponíveis ativos financeiros em nome da executada, observando-se a desnecessidade de sua prévia ciência, limitando-se a indisponibilidade ao valor indicado na execução, por meio de sistema eletrônico, conforme dispõe o artigo 854 do mesmo diploma processual;" +
            "        c.Em havendo manifestação tempestiva do Executado(art. 854, § 3°, CPC), requer sejam aplicados os dispostos nos artigos 827 e seguintes do CPC, com a devida citação da parte executada, no endereço já diligenciado, através de carta com AR, para que no prazo de 03(três) dias, efetue o pagamento da importância devida, nos termos do artigo 829, § § 1° e 2°, devidamente corrigida, acrescida de juros de mora, custas processuais e honorários advocatórios, estes nos termos do artigo 827, ou, querendo, ofereça embargos no prazo legal;" +
            "        c.1.Requer, desde já, caso não haja o adimplemento do débito, e independentemente da oposição de embargos, sejam adotadas as medidas previstas no artigo 837, por intermédio do Sistema BacenJud, observada a ordem e a gradação do artigo 835, da mencionada Lei Adjetiva e os limites financeiros que norteiam esta execução;" +
            "        c.2.Na eventualidade de não serem encontrados ativos em nome do Executado, requer seja efetivada a penhora e avaliação - por mandado judicial, e por intermédio de Oficial de Justiça -incidindo em tantos bens quantos bastem ao pagamento do principal atualizado, acrescido de juros, custas processuais e honorários advocatícios;" +
            "        c.3.Em sendo necessária a penhora, e esta venha recair sobre bens imóveis, requer que a mesma seja realizada na forma concedida pelo artigo 844 do NCPC, com a consequente intimação do respectivo cônjuge(art. 842);" +
            "        c.4.Recaindo a penhora sobre bens móveis, requer sejam removidos para o Depositário Público;" +
            "        c.5.Caso não seja encontrado o Executado para citação, proceda o Sr.Oficial de Justiça o arresto de seus bens, facultando o mesmo procedimento requerido no item “c.4” acima;" +
            "        c.6.Requer sejam as diligências beneficiadas pelo disposto no artigo 212 e parágrafos do CPC." +
            "       d.Em não havendo manifestação do Executado ou não sendo encontrados ativos em seu nome, requer o ARQUIVAMENTO PROVISÓRIO do feito, tendo em vista o esgotamento de diligências a serem tomadas." +
            "Outrossim, requer que todas as intimações dos atos processuais destes autos sejam efetivadas na forma prevista nos artigos 270 e 272 do CPC(Lei 13.105 / 2015), na pessoa de Cristiane Belinati Garcia Lopes, OAB / BA 25.579, independentemente dos demais procuradores constantes nas procurações e substabelecimentos juntados a estes autos, sob pena de nulidade da intimação, conforme previsto no artigo 280 do CPC." +
            "   Dá - se à causa o valor de R$ 36.855,05(trinta e seis mil, oitocentos e cinquenta e cinco reais e cinco centavos)." +

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

          //Dados do Texto Topo
          textJustify.Alignment = XParagraphAlignment.Justify;
          XRect rectTextoTopo = new XRect(50, 290, 490, page.Height);
          textJustify.DrawString(textoTopo, fonteOrganizacao, corFonte, rectTextoTopo, XStringFormats.TopLeft);

          //Dados do Texto
          textJustify.Alignment = XParagraphAlignment.Justify;
          XRect rectTexto = new XRect(50, 290, 490, 400);
          textJustify.DrawString(textoA, fonteOrganizacao, corFonte, rectTexto, XStringFormats.TopLeft);

          //Texto OAB
          textJustify.Alignment = XParagraphAlignment.Center;
          XRect rectOab = new XRect(50, 625, 490, page.Height);
          textJustify.DrawString(oab, fonteTitulo, corFonte, rectOab, XStringFormats.TopLeft);

          textJustify.Alignment = XParagraphAlignment.Center;
          XRect rectenderecoRodape = new XRect(50, 900, 490, page.Height);
          textJustify.DrawString(enderecoRodape, fonteDetalhes, corFonte, rectenderecoRodape, XStringFormats.TopLeft);
        }

        doc.AddPage();

        for (int i = 0; i < dados.Count; i++)
        {
          //Imagem todo da pagina
          XImage imagem = XImage.FromFile(logo);
          grafics.DrawImage(imagem, 200, 40, 200, 80);
        }


        using (MemoryStream stream = new MemoryStream())
        {
          var contentType = "application/pdf";
          doc.Save(stream, false);
          var nomeArquivo = "Informar Órgãos para Expedição.pdf";
          return File(stream.ToArray(), contentType, nomeArquivo);
        }
      }
    }

    public class LayoutHelper
    {
      private readonly PdfDocument _document;
      private readonly XUnit _topPosition;
      private readonly XUnit _bottomMargin;
      private XUnit _currentPosition;

      public LayoutHelper(PdfDocument document, XUnit topPosition, XUnit bottomMargin)
      {
        _document = document;
        _topPosition = topPosition;
        _bottomMargin = bottomMargin;
        // Set a value outside the page - a new page will be created on the first request.
        _currentPosition = bottomMargin + 10000;
      }

      public XUnit GetLinePosition(XUnit requestedHeight)
      {
        return GetLinePosition(requestedHeight, -1f);
      }

      public XUnit GetLinePosition(XUnit requestedHeight, XUnit requiredHeight)
      {
        XUnit required = requiredHeight == -1f ? requestedHeight : requiredHeight;
        if (_currentPosition + required > _bottomMargin)
          CreatePage();
        XUnit result = _currentPosition;
        _currentPosition += requestedHeight;
        return result;
      }

      public XGraphics Gfx { get; private set; }
      public PdfPage Page { get; private set; }

      void CreatePage()
      {
        Page = _document.AddPage();
        Page.Size = PageSize.A4;
        Gfx = XGraphics.FromPdfPage(Page);
        _currentPosition = _topPosition;
      }
    }

    public FileResult Teste()
    {

      PdfDocument document = new PdfDocument();
      //var logo = @"C:\Logo.png";
      //var grafics = XGraphics.FromPdfPage(document);

      // Sample uses DIN A4, page height is 29.7 cm. We use margins of 2.5 cm.
      LayoutHelper helper = new LayoutHelper(document, XUnit.FromCentimeter(2.5), XUnit.FromCentimeter(29.7 - 2.5));
      XUnit left = XUnit.FromCentimeter(2.5);

      // Random generator with seed value, so created document will always be the same.
      Random rand = new Random(42);

      const int headerFontSize = 20;
      const int normalFontSize = 10;

      XFont fontHeader = new XFont("Verdana", headerFontSize, XFontStyle.BoldItalic);
      XFont fontNormal = new XFont("Verdana", normalFontSize, XFontStyle.Regular);

      const int totalLines = 666;
      bool washeader = false;
      for (int line = 0; line < totalLines; ++line)
      {
        bool isHeader = line == 0 || !washeader && line < totalLines - 1 && rand.Next(15) == 0;
        washeader = isHeader;
        // We do not want a single header at the bottom of the page, so if we have a header we require space for header and a normal text line.
        XUnit top = helper.GetLinePosition(isHeader ? headerFontSize + 5 : normalFontSize + 2, isHeader ? headerFontSize + 5 + normalFontSize : normalFontSize);
        
        //Imagem todo da pagina
       // XImage imagem = XImage.FromFile(logo);
       // grafics.DrawImage(imagem, 200, 40, 200, 80);

        helper.Gfx.DrawString(isHeader ? "Sed massa libero, semper a nisi nec" : "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            isHeader ? fontHeader : fontNormal, XBrushes.Black, left, top, XStringFormats.TopLeft);
      }

      using (MemoryStream stream = new MemoryStream())
      {
        var contentType = "application/pdf";
        document.Save(stream, false);
        var nomeArquivo = "Informar Órgãos para Expedição.pdf";
        return File(stream.ToArray(), contentType, nomeArquivo);
      }
    }
  }
}
