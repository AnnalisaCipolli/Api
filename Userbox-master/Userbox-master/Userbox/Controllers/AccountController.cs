using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Userbox.Models;

namespace Userbox.Controllers
{
    public class AccountController : Controller
    {
        private readonly UtenteAuth _utenteAuth;
        private readonly ConfigurationManager _config;



        public AccountController(UtenteAuth utenteauth, ConfigurationManager config)
        {
            _utenteAuth = utenteauth;
            _config = config;

        }

        // GET: AccountController
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

       [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [Authorize]
        public ActionResult LoginUnipi()
        {

            var lista = User.Claims.ToList();

            if (lista.Count() > 0)
            {
                _utenteAuth.Valorizza(lista, _config);
              
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Msg = " Utente non trovato";
                ViewBag.MsgType = "WARNING";
                return View("Login");
            }
        }
        
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View();

            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    case SignInStatus.LockedOut:
            //        return View("Lockout");
            //    case SignInStatus.RequiresVerification:
            //        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            //    case SignInStatus.Failure:
            //    default:
            //        Utility.getMsg(ViewBag, "Tentativo di accesso non valido", Risorsa.ERROR);
            //        //ModelState.AddModelError("", "Tentativo di accesso non valido.");
            //        return View(model);
            //}
        }


        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
