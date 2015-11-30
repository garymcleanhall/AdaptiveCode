using System.Web.Mvc;

using TestOverspecification.Services;

namespace TestOverspecification.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public ActionResult Login(string username, string password)
        {
            return Redirect("/");
        }

        private readonly ILoginService _loginService;
    }
}
