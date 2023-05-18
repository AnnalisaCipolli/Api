using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Userbox.Models
{
    public class Select2UsersItems
    {
        public string id { get; set; }
        public string text { get; set; }

        public bool disabled { get; set; }
        public bool selected { get; set; }
    }

    public class Select2Users : Select2Dati
    {
        public List<Select2UsersItems> items { get; set; }
    }

    public class Select2Dati
    {
        public int total_count { get; set; }
        public bool incomplete_result { get; set; }
    }

    public class ViewUtente
    {
        public string Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }
        [Display(Name = "Cod. Fiscale")]
        public string Cod_fiscale { get; set; }

        public bool Personale { get; set; }
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        public bool Studente { get; set; }

        public bool Ospite { get; set; }

        public string Tipo { get; set; } // variabile di supporto
        public int Conteggio { get; set; } // variabile di supporto

    }

}