using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Userbox.Models
{
    public class UtenteAuth
    {
        public string? AuthType { get; set; }
        public string? Sub { get; set; }
        public string? Principal { get; set; }
        public string Credential { get; set; }
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public string? CodFiscale { get; set; }
        public string? Email { get; set; }
        public string? UnipiUserID { get; set; }

        public List<string> Capability { get; set; }


        public UtenteAuth Valorizza(List<System.Security.Claims.Claim> lista, ConfigurationManager _config)
        {
            WebServiceCall wsc = new WebServiceCall(_config);
            
            this.Sub = lista.Where(x => x.Type == "sub").First().Value;
            this.Principal = lista.Where(x => x.Type == "principal").First().Value;
            this.Nome = lista.Where(x => x.Type == "given_name").First().Value;
            this.Cognome = lista.Where(x => x.Type == "family_name").First().Value;
            this.CodFiscale = lista.Where(x => x.Type == "fiscalNumber").First().Value;
            this.Email = lista.Where(x => x.Type == "email").First().Value;
            this.UnipiUserID = lista.Where(x => x.Type == "UnipiUserID").First().Value;
            this.AuthType = lista.Where(x => x.Type == "tenant").First().Value;
            /* vediamo le capability da IDM*/
            this.Capability = new List<string>();
            this.Capability = wsc.GetCapabilityIDMByCF(this.CodFiscale);
            /*TEST */
            /* se sono personale tecnico amministrativo ho questo ruolo*/
            APIAnagraficaCarriera ac = wsc.GetAnagraficaIDMByCF(this.CodFiscale);
            if (ac.Personale!=null && ac.Personale.RuoliPersonale.Any(x=> x.InquadramentoCod=="ND"))
                this.Capability.Add("AmministratoreUserbox");


           
            return this;
        }

    }


    //public class UserFromWSo2
    //{
    //    public string principal { get; set; }
    //    public string sub { get; set; }
    //    public string given_name { get; set; }
    //    public string family_name { get; set; }
    //    public string fiscalNumber { get; set; }
    //    public string email { get; set; }
    //    public string tenant { get; set; }

        
    //}


}
