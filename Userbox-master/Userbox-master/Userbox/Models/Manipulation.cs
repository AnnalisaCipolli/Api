namespace Userbox.Models
{

    public class JsonAnagraficaIDM
    {
        public string id_ab { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string ds_ruolo { get; set; }
        public string ruolo { get; set; }

        public string ds_inquadr { get; set; }
        public string inquadr { get; set; }

        public string cod_fis { get; set; }
        public string cd_istat_nasc { get; set; }
        public string cd_catasto_nasc { get; set; }
        public Nullable<System.DateTime> dt_nascita { get; set; }
        public string matricola { get; set; }
        public Nullable<System.DateTime> data_inserimento { get; set; }
        public string ds_comune_nasc { get; set; }
        public string EmailPr { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> dt_rap_ini { get; set; }

        public string Cd_ssd { get; set; }
        public string Ds_ssd { get; set; }
        public string Ds_ssd_breve { get; set; }
        public string Area_ssd { get; set; }
        public string Ds_area_ssd { get; set; }

    }


    public class Manipulation
    {



    }
}
