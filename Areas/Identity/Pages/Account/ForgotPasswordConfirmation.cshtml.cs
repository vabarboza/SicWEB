using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SicWEB.Areas.Identity.Pages.Account
{
  [AllowAnonymous]
  public class ForgotPasswordConfirmation : PageModel
  {
    public void OnGet()
    {
    }
  }
}
