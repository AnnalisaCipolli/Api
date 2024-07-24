using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class apiController : Controller
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/index")]
        public async Task<IActionResult> Index()
        {


            return Json("Connessione avvenuta con successo");
        }

        #region utenti in generale


        /* ANAGRAFICA*/




        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/anagrafica/id/{id}")]
        public async Task<IActionResult> AnagraficaID(string id)
        {
            try
            {
                //Persona p = PersonaModel.find(id.ToUpper());


                //if (p != null)
                //{

                //    return Json(utility.GetAPIAnagrafica(p));

                //}
                //else
                //{
                    return NotFound();
                //}

            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(ex.Message) };
                throw new HttpResponseException(resp);
            }

        }

    }
}
#endregion