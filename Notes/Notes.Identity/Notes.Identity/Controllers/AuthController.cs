using Microsoft.AspNetCore.Mvc;


namespace Notes.Identity.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login(string returnUrl)
        {
            return View();
        }
    }
}
