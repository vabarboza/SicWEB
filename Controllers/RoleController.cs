using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
  public class RoleController : Controller
  {
    RoleManager<IdentityRole> roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
      this.roleManager = roleManager;
    }

    [Authorize(Policy = "super")]
    public IActionResult Index()
    {
      var roles = roleManager.Roles.ToList();
      return View(roles);
    }

    [Authorize(Policy = "super")]
    public IActionResult Create()
    {
      return View(new IdentityRole());
    }

    [HttpPost]
    public async Task<IActionResult> Create(IdentityRole role)
    {
      await roleManager.CreateAsync(role);
      return RedirectToAction("Index");
    }
  }
}
