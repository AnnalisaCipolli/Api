using api.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using api.Models;
using api.Controllers;

namespace Userbox.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConfigurationManager _config;

        public HomeController(ILogger<HomeController> logger, ConfigurationManager config)
        {
            _logger = logger;
            _config = config;

        }
    //    [Authorize]
        public IActionResult Index()
        {
           
            return View();
        }

    }
}