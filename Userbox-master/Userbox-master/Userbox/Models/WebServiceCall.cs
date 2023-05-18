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
        
        

        public  JsonAnagraficaIDM GetAnagraficaIDMByCF(string cod_fiscale)
        {
            string ris = "";
            string msg = "";
            JsonAnagraficaIDM r = new JsonAnagraficaIDM();

            ris = WebServiceConnector.getRequester(_config["WebService:url_ws02_API_IDM"], _config["WebService:token_ws02_API_IDM"], _config["WebService:method_ws02_API_IDM_Anagrafica_cf"] + cod_fiscale,null);

            if (ris != "")
            {
                r = JsonConvert.DeserializeObject<JsonAnagraficaIDM>(ris);
             }

            return r;
        }




    }
}
