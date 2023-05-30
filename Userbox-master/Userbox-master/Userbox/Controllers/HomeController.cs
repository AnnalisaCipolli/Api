using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Userbox.Models;

namespace Userbox.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UtenteAuth _utenteauth;
        private readonly ConfigurationManager _config;
      
        public HomeController(ILogger<HomeController> logger,  UtenteAuth utenteauth, ConfigurationManager config)
        {
            _logger = logger;
            _utenteauth = utenteauth;
           _config= config;
          
        }
        [Authorize]
        public IActionResult Index()
        {
           List<System.Security.Claims.Claim> cc=  HttpContext.User.Claims.ToList();
           

          WebServiceCall  wsc = new WebServiceCall(_config);
            APIAnagraficaCarriera ac = wsc.GetAnagraficaIDMByCF(_utenteauth.CodFiscale);
           // ViewBag.nome = User.Identity.Name + "- " + System.Text.Json.JsonSerializer.Serialize(_utenteauth);
            return View(ac);
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
           
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            ViewBag.stato = User.Identity.IsAuthenticated + " " + User.Identity.Name + "- ";
                 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult Logout()
        {
            var cookies = Request.Cookies.Keys;
            foreach (var cookie in cookies)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.User = null;

            SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Logout");
        }
    }
}