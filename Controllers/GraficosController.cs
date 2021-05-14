using Microsoft.AspNetCore.Mvc;

namespace SicWEB.Controllers {
  public class GraficosController : Controller {
    public IActionResult Index() {
      return View();
    }

    public IActionResult Malote() {
      return View();
    }
  }
}
