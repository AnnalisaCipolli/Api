using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Userbox.Models
{
    public class WebServiceConnector
    {
        protected ConfigurationManager _config;
        public WebServiceConnector(ConfigurationManager conf)
        {
            
            _config = conf;
        }
        
        public static string getRequester(string url, string token, string method, string urlParam)
        {
            string content = "", endpoint;

            endpoint = url + method;
            if (urlParam != null)
            {
                endpoint += "?" + urlParam;
            }
            var client = new WebClient();
            client.Headers.Set("Authorization", "Bearer " + token);
            client.Headers.Set("Accept", "application/json");
            client.Encoding = Encoding.UTF8;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            try
            {
                content = client.DownloadString(endpoint);
            }
            catch (Exception e)
            {
                string errore = e.Message;
            }
            return content;
        }


        public static string postRequesterOLD(string url, string method, string token, string urlParam, bool usePut = false)
        {
            string content = "", endpoint;

            endpoint = url + method;

            endpoint = "http://localhost:61106/apiuserbox/utenteospite/";
            
            //if (urlParam != null)
            //    endpoint += "/" + urlParam;
            var client = new WebClient();
            client.Headers.Set("Authorization", "Bearer " + token);
            client.Headers.Set("Accept", "application/json");
            client.Headers.Set("Content-Type", "application/json");
            client.Encoding = Encoding.UTF8;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            try
            {
                if (usePut)
                {
                    content = client.UploadString(endpoint, "PUT", "");
                }
                else
                {

                    content = client.UploadString(endpoint, "POST", urlParam);
                }

            }
            catch(Exception ex)
            {
            }
            return content;
        }

        public static string postRequester(string url, string method, string token, string urlParam, bool usePut = false)
        {
            string content = "", endpoint;

            endpoint = url + method;

            endpoint = "http://localhost:61106/apiuserbox/utenteospite/";


            StringContent sc = new StringContent(urlParam,
                Encoding.UTF8,
                "application/json");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            

            var res = client.PostAsync(endpoint,sc);
            try
            {
                res.Result.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                return "Errore";
            }

            return res.Result.Content.ReadAsStringAsync().Result.ToString();
        }



    }
}
