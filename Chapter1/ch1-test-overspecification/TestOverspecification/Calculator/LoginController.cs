using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using TestOverspecification.Services;

namespace TestOverspecification.Core
{
    public class LoginController : Controller
    {
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public ActionResult Login(string username, string password)
        {
            return View();   
        }

        private readonly ILoginService loginService;
    }
}
