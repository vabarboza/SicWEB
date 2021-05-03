using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SicWEB.Controllers
{
  public class GraficosController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Malote()
    {
      return View();
    }
  }
}
