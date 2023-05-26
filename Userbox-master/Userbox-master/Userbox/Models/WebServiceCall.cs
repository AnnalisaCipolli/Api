using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace Userbox.Models
{
    public class WebServiceCall
    {
        protected ConfigurationManager _config;
        public WebServiceCall(ConfigurationManager conf)
        {
            
            _config = conf;
        }
        
        

        public APIAnagraficaCarriera GetAnagraficaIDMByCF(string cod_fiscale)
        {
            string ris = "";
            APIAnagraficaCarriera r = new APIAnagraficaCarriera();

            ris = WebServiceConnector.getRequester(_config["WebService:url_ws02_API_IDM"], _config["WebService:token_ws02_API_IDM"], _config["WebService:method_ws02_API_IDM_Anagrafica_cf"] + cod_fiscale,null);

            if (ris != "")
            {
                r = JsonConvert.DeserializeObject<APIAnagraficaCarriera>(ris);
             }

            return r;
        }

        public List<string> GetCapabilityIDMByCF(string cod_fiscale)
        {
            string ris = "";
            List<string> lista = new List<string>();

            ris = WebServiceConnector.getRequester(_config["WebService:url_API_IDM_USER"], _config["WebService:token_API_IDM_USER"], _config["WebService:method_API_IDM_USER_Capability_cf"] + cod_fiscale, null);

            if (ris != "")
            {
                lista = JsonConvert.DeserializeObject<List<string>>(ris);
            }

            return lista;
        }



    }
}
