using ServiceImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            loginService = new LoginService();
        }

        public ActionResult Login(string username, string password)
        {
            ActionResult result;
            if(loginService.CheckCredentials(username, password))
            {
                result = RedirectToAction("MainPage");
            }
            else
            {
                var errorModel = new ErrorViewModel(string.Format("The user {0} was not recognized, or the password entered was incorrect", username));
                result = View(errorModel);
            }
            return result;
        }

        private readonly LoginService loginService;
    }
}
