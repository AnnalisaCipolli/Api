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

        public List<JsonNazione> GetListaNazioniIDM()
        {
            string ris = "";
            List<JsonNazione> r = new List<JsonNazione>();

            ris = WebServiceConnector.getRequester(_config["WebService:url_API_IDM"], _config["WebService:token_API_IDM"], _config["WebService:method_API_IDM_Nazioni"], null);

            if (ris != "")
            {
                r = JsonConvert.DeserializeObject<List<JsonNazione>>(ris);
            }

            return r;
        }

        public List<JsonRegione> GetListaRegioniIDM()
        {
            string ris = "";
            List<JsonRegione> r = new List<JsonRegione>();

            ris = WebServiceConnector.getRequester(_config["WebService:url_API_IDM"], _config["WebService:token_API_IDM"], _config["WebService:method_API_IDM_Regioni"], null);

            if (ris != "")
            {
                r = JsonConvert.DeserializeObject<List<JsonRegione>>(ris);
            }

            return r;
        }
        public List<JsonProvincia> GetListaProvinceIDM(string regione)
        {
            string ris = "";
            List<JsonProvincia> r = new List<JsonProvincia>();

            ris = WebServiceConnector.getRequester(_config["WebService:url_API_IDM"], _config["WebService:token_API_IDM"], _config["WebService:method_API_IDM_Province"] + regione, null);

            if (ris != "")
            {
                r = JsonConvert.DeserializeObject<List<JsonProvincia>>(ris);
            }

            return r;
        }

        public List<JsonComune> GetListaComuniIDM(string provincia)
        {
            string ris = "";
            List<JsonComune> r = new List<JsonComune>();

            ris = WebServiceConnector.getRequester(_config["WebService:url_API_IDM"], _config["WebService:token_API_IDM"], _config["WebService:method_API_IDM_Comuni"] + provincia, null);

            if (ris != "")
            {
                r = JsonConvert.DeserializeObject<List<JsonComune>>(ris);
            }

            return r;
        }

        public JsonComune GetComuneByIstatIDM(string comune)
        {
            string ris = "";
            JsonComune r = new JsonComune();

            ris = WebServiceConnector.getRequester(_config["WebService:url_API_IDM"], _config["WebService:token_API_IDM"], _config["WebService:method_API_IDM_Comune"] + comune, null);

            if (ris != "")
            {
                r = JsonConvert.DeserializeObject<JsonComune>(ris);
            }

            return r;
        }



        public List<string> GetCapabilityIDMByCF(string cod_fiscale)
        {
            string ris = "";
            List<string> lista = new List<string>();

            ris = WebServiceConnector.getRequester(_config["WebService:url_API_IDM"], _config["WebService:token_API_IDM"], _config["WebService:method_API_IDM_USER_Capability_cf"] + cod_fiscale, null);

            if (ris != "")
            {
                lista = JsonConvert.DeserializeObject<List<string>>(ris);
            }

            return lista;
        }



    }
}
