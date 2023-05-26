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

    }


}
