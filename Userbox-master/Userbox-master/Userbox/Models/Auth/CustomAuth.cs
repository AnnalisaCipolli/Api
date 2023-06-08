//using Microsoft.AspNetCore.Authorization;

//namespace Userbox.Models.Auth
//{
//    public class CustomAuth : AuthorizeAttribute
//    {
//        public bool condizioni_or { get; set; }
//        public string role { get; set; } // qui trovo i possibili ruoli ammessi
//        public string capabilities { get; set; } // qui trovo le possibili capabilities ammesse

//        #region Categorie privilegi Utenti
//        // Amministratore Portale con accesso illimitato
//        public bool Amministratore { get; set; }

//        #endregion

//        public Object[] hasAuthorizeAttribute { get; set; }


//        public override void OnAuthorization(AuthorizationContext filterContext)
//        {
//            //var parametriController = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(inherit: true);

//            // Se in sessione non esiste lo UserName
//            if (HttpContext.Current.Session[System.Configuration.ConfigurationManager.AppSettings["ChiaveUtenteInSessione"]] == null)
//            {
//                // Ma l'utente è autenticato
//                if (filterContext.HttpContext.User.Identity.IsAuthenticated == true)
//                {
//                    // inserisco in sessione lo Username
//                    HttpContext.Current.Session[System.Configuration.ConfigurationManager.AppSettings["ChiaveUtenteInSessione"]] = filterContext.HttpContext.User.Identity.Name;

//                    // Creo l'elenco dei permessi
//                    hasAuthorizeAttribute = filterContext.ActionDescriptor.GetCustomAttributes(typeof(IDMWebApp.Auth.CustomAuth), false);
//                    // e lo inserisco in sessione
//                    HttpContext.Current.Session["Ruoli"] = filterContext.ActionDescriptor.GetCustomAttributes(typeof(CustomAuth), false);
//                }
//            }


//            hasAuthorizeAttribute = filterContext.ActionDescriptor.GetCustomAttributes(typeof(CustomAuth), false);

//            if (hasAuthorizeAttribute.Count() == 0)
//                hasAuthorizeAttribute = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(CustomAuth), false);


//            base.OnAuthorization(filterContext);
//        }


//        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
//        {
//            MyCapabilities my = CapMgmt.get();
//            if (my == null)
//            {
//                string returnUrl = filterContext.HttpContext.Request.RawUrl;
//                if (returnUrl.Contains("LogOff"))
//                    returnUrl = "";
//                filterContext.Result = new RedirectToRouteResult(
//                        new RouteValueDictionary(new { controller = "Account", action = "Login", returnUrl = returnUrl })
//                );
//            }
//            //User is logged in but has no access
//            else
//            {
//                filterContext.Result = new RedirectToRouteResult(
//                        new RouteValueDictionary(new { controller = "Account", action = "NotAuthorized" })
//                );
//            }

//        }


//        protected override bool AuthorizeCore(HttpContextBase httpContext)
//        {
//            bool bool_ruolo = false;
//            bool bool_cap = false;


//            MyCapabilities my = CapMgmt.get();
//            if (my == null)
//            {
//                return false;
//            }

//            if (role != null && role != "")
//            {

//                foreach (string myr in my.role)
//                {
//                    if (role.Split(',').Contains(myr.Trim()) || role == "*")
//                    {
//                        bool_ruolo = true;
//                        break;
//                    }
//                }
//            }
//            else
//                bool_ruolo = true;


//            if (capabilities != null && capabilities != "")
//            {
//                foreach (string myc in my.cap)
//                {
//                    if (capabilities.Split(',').Contains(myc) || myc == "*")
//                    {
//                        bool_cap = true;
//                        break;
//                    }
//                }
//            }
//            else
//                bool_cap = true;

//            if (condizioni_or == true)
//                return bool_ruolo || bool_cap;
//            else
//                return bool_ruolo && bool_cap;

//        }
//    }



//}





