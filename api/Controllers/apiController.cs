using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class apiController : ApiController
    {
        private readonly ConfigurationManager _config;
        WebServiceCall wsc;


        public apiController( ConfigurationManager config)
        {
            _config = config;
            wsc = new WebServiceCall(_config);


        }


       
        #region utenti in generale


        /* ANAGRAFICA*/




        [System.Web.Http.HttpGet]

        [System.Web.Http.Route("api/GetMUD/{id}")]
        public async Task<ActionResult<RootExport>> GetMUD(string id)
        {
            try
            {
                Root p = wsc.GetMUD(id);

                if (p != null)
                    return utility.GetMUD(p);
                else
                    return null;

                 //   return NotFound();
                
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