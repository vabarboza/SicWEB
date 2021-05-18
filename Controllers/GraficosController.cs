using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SicWEB.Controllers {
  public class GraficosController : Controller {

    [Authorize(Policy = "admin")]
    public IActionResult Index() {
      return View();
    }

    [Authorize(Policy = "admin")]
    public IActionResult Malote() {
      return View();
    }
  }
}
