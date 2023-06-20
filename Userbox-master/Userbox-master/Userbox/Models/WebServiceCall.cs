using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using Userbox.Models.Ldap;

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

        public List<JsonOspite> GetListaOspite()
        {
            string ris = "";
            List<APIAnagraficaCarriera> lista = new List<APIAnagraficaCarriera>();
            List<JsonOspite> lista_end = new List<JsonOspite>();

            ris = WebServiceConnector.getRequester(_config["WebService:url_ws02_API_IDM"], _config["WebService:token_ws02_API_IDM"], _config["WebService:method_ws02_API_IDM_ListaOspite"] , null);

            if (ris != "")
            {
                lista = JsonConvert.DeserializeObject<List<APIAnagraficaCarriera>>(ris);
            }


            foreach (APIAnagraficaCarriera a in lista)
            {
                lista_end.Add(new JsonOspite { 
                nome= a.Nome,
                cognome= a.Cognome,
                codice_fiscale = a.Cod_fiscale,
                data_nascita = a.Data_nascita.Value,
                data_inizio = a.Ospite.Data_inizio.Value,
                data_fine = a.Ospite.Data_fine.Value,
                mail= a.Ospite.Mail,
                mail_esterna = a.Ospite.Mail_esterna
                });
            }

            return lista_end;
        }


        public string PostAnagraficaOspite(JsonOspite jo)
        {
            string ris = "";
            string json = JsonConvert.SerializeObject(jo);
    
            ris = WebServiceConnector.postRequester(_config["WebService:url_API_IDM"], _config["WebService:method_API_IDM_PostOspite"], _config["WebService:token_API_IDM"] ,json, false);

            
            return ris;
        }


        public string GetAnagraficaLdap(string cod_fiscale)
        {
            string ris = "";
           
            ris = WebServiceConnector.getRequester(_config["WebService:url_LDAP"], _config["WebService:token_LDAP"], _config["WebService:method_LDAP_searchcf"]+"/"+ cod_fiscale, null);


            return ris;
        }

        public string PostAnagraficaOspiteLDAP(UnipiEntry jo)
        {
            string ris = "";
            string json = JsonConvert.SerializeObject(jo);

            ris = WebServiceConnector.postRequester(_config["WebService:url_LDAP"], _config["WebService:method_LDAP_add"], _config["WebService:token_LDAP"], json, false);


            return ris;
        }

        public string PostAnagraficaOspiteAD(UnipiADEntry jo)
        {
            string ris = "";
            string json = JsonConvert.SerializeObject(jo);

            ris = WebServiceConnector.postRequester(_config["WebService:url_LDAP"], _config["WebService:method_AD_add"], _config["WebService:token_LDAP"], json, false);


            return ris;
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
