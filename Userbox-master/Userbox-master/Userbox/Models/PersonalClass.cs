using Microsoft.AspNetCore.Mvc.Rendering;
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

    public class ViewOspite
    {


        public string Id { get; set; }
        public string Tipo { get; set; }


        [Required(ErrorMessage = "Nome obbligatorio")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }



        [Required(ErrorMessage = "Cognome obbligatorio")]
        [Display(Name = "Cognome")]
        public string Cognome { get; set; }



        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale è di 16 caratteri")]
        [Required]
        [Display(Name = "Codice Fiscale")]
        public string Cod_fiscale { get; set; }


        [Required(ErrorMessage = "Nazione obbligatoria")]
        [Display(Name = "Nazione di Nascita")]
        public string SelectedNazione_nascita { get; set; }

        [Display(Name = "Regione di Nascita")]
        public string SelectedRegione_nascita { get; set; }

        [Display(Name = "Provincia di Nascita")]
        public string SelectedProvincia_nascita { get; set; }

        [Display(Name = "Comune di Nascita")]
        public string SelectedComune_nascita { get; set; }



        [Display(Name = "Nazione di Nascita")]
        public SelectList Nazione_nascita { get; set; }


        [Display(Name = "Regione di Nascita")]
        public SelectList Regione_nascita { get; set; }


        [Display(Name = "Provincia di Nascita")]

        public SelectList Provincia_nascita { get; set; }

        [Display(Name = "Comune di Nascita")]

        public SelectList Comune_nascita { get; set; }



        [Required(ErrorMessage = "Data di nascita obbligatoria")]
        [Display(Name = "Data di nascita")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Data_nascita { get; set; }

        [Required(ErrorMessage = "Telefono cellulare obbligatoria")]
        [Display(Name = "Telefono cellulare")]
        [DataType(DataType.PhoneNumber)]

        public string Telefono { get; set; }


        [Required(ErrorMessage = "Mail obbligatoria")]
        [Display(Name = "Mail")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Mail esterna obbligatoria")]
        [Display(Name = "Mail Esterna")]
        [DataType(DataType.EmailAddress)]
        public string Mail_esterna { get; set; }


        

        [Required(ErrorMessage = "Data di fine validità obbligatoria")]
        [Display(Name = "Data di fine validità")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Data_fine { get; set; }




    }

    public class JsonOspite
    {

        public string nome;
        public string cognome;
        public string codice_fiscale;
        public DateTime data_nascita;
        public string nazione_nascita;
        public string nazione_nascita_cod;
        public string comune_nascita;
        public string comune_nascita_cod;
        public string mail;
        public string mail_esterna;
        public DateTime data_inizio;
        public DateTime data_fine;

    }




}