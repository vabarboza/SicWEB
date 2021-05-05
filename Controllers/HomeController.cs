using BellinatiCorreio.Views.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SicWEB.Models;
using System.Diagnostics;

namespace SicWEB.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    static Conexao c = new Conexao();
    public static string sql = c.ConexaoDados();

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);

      ViewBag.TotalMalote = c.ContarMalote();
      ViewBag.TotalMaringa = c.ContarMaringa();
      ViewBag.TotalCuritiba = c.ContarCuritiba();
      ViewBag.TotalSP = c.ContarSP();

      ViewBag.ContarNotificacao = c.ContarNotificacao();
      ViewBag.ContarCitacaocarta = c.ContarNotificacaoCitacao();
      ViewBag.ContarExpedicaoMandado = c.ContarNotificacaoExpedicao();
      ViewBag.ContarFielDepositario = c.ContarNotificacaoFiel();
      ViewBag.ContarInformarEndereco = c.ContarNotificacaoInformarEndereco();
      ViewBag.ContarInformarOrgao = c.ContarNotificacaoInformarOrgao();
      ViewBag.ContarNotificacaoJuntadaTermoCessao = c.ContarNotificacaoJuntadaTermoCessao();
      ViewBag.ContarNotificacaoConversaoExecucao = c.ContarNotificacaoConversaoExecucao();
      ViewBag.ContarNotificacaoConversaoExecucaoItau = c.ContarNotificacaoConversaoExecucaoItau();

      return View();
    }

    public IActionResult Privacy()
    {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      ViewBag.NomeUser = c.NomeUser(User.Identity.Name);
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
