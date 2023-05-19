using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Userbox.Models
{


    public class APIAnagraficaCarriera
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        [Display(Name = "Codice Fiscale")] 
        public string Cod_fiscale { get; set; }
        public string Nazione_nascita { get; set; }
        [Display(Name = "Nazione nascita")] 
        public string Nazione_nascita_nome { get; set; }
        public string Comune_nascita { get; set; }
        [Display(Name = "Comune nascita")] 
        public string Comune_nascita_nome { get; set; }
        [Display(Name = "Data nascita")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_nascita { get; set; }
        public APIPersonale Personale { get; set; }
        public APIStudente Studente { get; set; }
        public APIOspite Ospite { get; set; }
        [Display(Name = "Data fine validità")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? DataFineValiditaUtente { get; set; }

        [Display(Name = "Data aggiornamento")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_aggiornamento { get; set; }

        public string Authority { get; set; }

    }

    public class APIPersonale
    {
        public string Matricola { get; set; }
        public string Uid { get; set; }
        public string Mail { get; set; }
        [Display(Name = "Mail esterna")] 
        public string Mail_esterna { get; set; }
        [Display(Name = "Data aggiornamento")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_aggiornamento { get; set; }
        [Display(Name = "Data inizio")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_inizio { get; set; }
        [Display(Name = "Data fine")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_fine { get; set; }
        public string Authority { get; set; }
        public List<APIRuoliPersonale> RuoliPersonale { get; set; }

    }


    public class APIRuoliPersonale
    {
        [Display(Name = "Ruolo")] 
        public string RuoloDescr { get; set; }
        [Display(Name = "Codice Ruolo")] 
        public string RuoloCod { get; set; }
        [Display(Name = "Inquadramento")] 
        public string InquadramentoDescr { get; set; }
        [Display(Name = "Docice Inquadramento")] 
        public string InquadramentoCod { get; set; }
        [Display(Name = "Codice SSD")]
        public string Cd_ssd { get; set; }
        [Display(Name = "Descrizione SSD")] 
        public string Ds_ssd { get; set; }
        [Display(Name = "Descrizione breve SSD")] 
        public string Ds_ssd_breve { get; set; }
        [Display(Name = "Codice Area SSD")] 
        public string Area_ssd { get; set; }
        [Display(Name = "Area SSD ")] 
        public string Ds_area_ssd { get; set; }
        [Display(Name = "Data inizio")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_inizio { get; set; }
        [Display(Name = "Data aggiornamento")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? DataAggiornamento { get; set; }
        public string Authority { get; set; }
        public List<APIAfferenze> Afferenze { get; set; }


    }

    public class APIAfferenze {
        [Display(Name = "Codice Afferenza")] 
        public string cod_afferenza { get; set; }
        [Display(Name = "Descrizione Afferenza")] 
        public string descr_afferenza { get; set; }
    }

    public class APIOspite
    {
        public string Mail { get; set; }
        [Display(Name = "Mail esterna")] 
        public string Mail_esterna { get; set; }
        [Display(Name = "Data inizio")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_inizio { get; set; }
        [Display(Name = "Data fine")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_fine { get; set; }
        [Display(Name = "Data aggiornamento")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_aggiornamento { get; set; }
        public string Authority { get; set; }


    }


    public class APIStudente
    {
        public string Esse3PersID { get; set; }
        public string Uid { get; set; }
        public string Mail { get; set; }
        [Display(Name = "Mail esterna")] 
        public string Mail_esterna { get; set; }
        public string Cellulare { get; set; }
        [Display(Name = "Data inizio")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_inizio { get; set; }
        [Display(Name = "Data fine")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_fine { get; set; }
        public string Authority { get; set; }
        [Display(Name = "Data aggiornamento")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_aggiornamento { get; set; }
        public List<APICorso> Corsi { get; set; }


    }

    public class APICorso
    {
        public string Matricola { get; set; }
        [Display(Name = "Corso studio")] 
        public string Corso_studio { get; set; }
        [Display(Name = "Codice Corso Studio")] 
        public string Cod_corso_studio { get; set; }
        [Display(Name = "Tipo Corso")] 
        public string Tipo_corso { get; set; }
        [Display(Name = "Codice Tipo Corso")] 
        public string Cod_tipo_corso { get; set; }
        [Display(Name = "Dipartimento")] 
        public string Dipartimento { get; set; }
        [Display(Name = "Codice Dipartimento")] 
        public string Cod_dipartimento { get; set; }
        [Display(Name = "Stato Carriera")] 
        public string Stato_carriera { get; set; }
        [Display(Name = "Data Inizio")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_inizio { get; set; }
        [Display(Name = "Data fine")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_fine { get; set; }
        [Display(Name = "Data Laurea")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_laurea { get; set; }
        [Display(Name = "Data aggiornamento")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime? Data_aggiornamento { get; set; }
        public string Authority { get; set; }

    }




}
