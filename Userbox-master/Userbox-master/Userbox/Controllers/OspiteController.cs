using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Userbox.Models;
using Userbox.Models.Ldap;

namespace Userbox.Controllers
{


    public class OspiteController : Controller
    {

        private readonly ConfigurationManager _config;
        WebServiceCall wsc;


        public OspiteController(ConfigurationManager config)
        {
            _config = config;
            wsc = new WebServiceCall(_config);


        }

        // GET: OspiteController
        public ActionResult Index()
        {
            List<JsonOspite> lista = new List<JsonOspite>();
            try
            {
                lista = wsc.GetListaOspite();
            }
            catch (Exception ex)
            {

            }
            return View(lista);
        }

        // GET: OspiteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //[CustomAuth(role = "Amministratore", capabilities = "CreazioneAccountOspite", condizioni_or = true)]
        public ActionResult Create()
        {
          
            /* nuovo metodo*/
            ViewOspite model = new ViewOspite();
            model.Data_fine = null;
            model.Data_nascita = null;
            ConfigureViewModel(model);

            return View(model);
        }

        // POST: OspiteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewOspite model)
        { 
            try
            {
                string messaggio = "";
                APIAnagraficaCarriera psupporto = wsc.GetAnagraficaIDMByCF(model.Cod_fiscale);


                if (psupporto.Cod_fiscale != null)
                {
                    ConfigureViewModel(model);
                    ModelState.AddModelError("Cod_fiscale", "L'utente con codice fiscale " + psupporto.Cod_fiscale + " è già presente");
                    return View(model);
                }
                else
                {
                    if (model.SelectedNazione_nascita == "ITALIA" && model.SelectedComune_nascita == "")
                    {
                        ConfigureViewModel(model);
                        ModelState.AddModelError("SelectedNazione_nascita", "Se la Nazione di Nascita è ITALIA, specificare il comune di nascita");
                        return View(model);
                    }
                    if (model.Data_fine< DateTime.Now)
                    {
                        ConfigureViewModel(model);
                        ModelState.AddModelError("Data_fine", "La data di fine validità deve essere successiva ad oggi ");
                        return View(model);
                    }

                    if (!ModelState.IsValid)
                    {
                        ConfigureViewModel(model);
                        return View(model);
                    }
                    else 
                    {


                        string nazione = wsc.GetListaNazioniIDM().Where(x => x.Nazione_catasto == model.SelectedNazione_nascita).First().Nazione_nome;
                        string comune = (model.SelectedComune_nascita==null || model.SelectedComune_nascita=="")? "":  wsc.GetComuneByIstatIDM(model.SelectedComune_nascita).Comune_nome;

                        /* creo il json per inserire su mongo l'utente ospite*/
                        JsonOspite jo = new JsonOspite
                        {
                            nome = model.Nome.Trim().ToUpper(),
                            cognome = model.Cognome.Trim().ToUpper(),
                            codice_fiscale = model.Cod_fiscale.Trim().ToUpper(),
                            mail = model.Mail.Trim().ToUpper(),
                            mail_esterna = model.Mail_esterna.Trim().ToUpper(),
                            data_nascita = model.Data_nascita.Value,
                            nazione_nascita = nazione,
                            nazione_nascita_cod = model.SelectedNazione_nascita.Trim().ToUpper(),
                            comune_nascita_cod = model.SelectedComune_nascita.Trim().ToUpper(),
                            comune_nascita = comune.Trim().ToUpper(),
                            data_fine = model.Data_fine.Value
                        };
                        string ris = wsc.PostAnagraficaOspite(new JsonOspite { nome = "mario", cognome = "rossi", codice_fiscale = "abc" });
                        if (ris == "OK")
                        {
                            /* procedo con la chiamata a LDAP*/
                             ris = wsc.PostAnagraficaOspiteLDAP(
                                 new UnipiADEntry {  
                                     givenName="ANNA",
                                     displayName="CIPO",
                                    
                                     sn="A",
                                     uid="a.test123"
                                 });

                            if (ris == "OK")
                                ViewBag.messaggio = "Utente creato con successo";
                            else
                            {
                                ModelState.AddModelError("CustomError", "Errore durante la creazione su LDAP");
                                ConfigureViewModel(model);
                            }

                        }
                        else
                        {
                            /* mostro messaggio di errore*/
                            ModelState.AddModelError("CustomError", ris);
                            ConfigureViewModel(model);



                        }


                        return View("index");
                    }
                       
                }





                
            }
            catch
            {
                return View();
            }
        }

        
        #region funzioni creazione/modifica utente

        private void ConfigureViewModel(ViewOspite model)
        {

            List<JsonNazione> listan = wsc.GetListaNazioniIDM();
            List<SelectListItem> lista_nazioni = new List<SelectListItem>();
            foreach (JsonNazione n in listan)
            {
                lista_nazioni.Add(new SelectListItem { Value = n.Nazione_catasto, Text = n.Nazione_nome });

            }

            model.Nazione_nascita = new SelectList(lista_nazioni, "Value", "Text");


            if (model.SelectedNazione_nascita != null)
            {
                List<JsonRegione> listar = wsc.GetListaRegioniIDM();
                List<SelectListItem> lista_regioni = new List<SelectListItem>();
                foreach (JsonRegione r in listar)
                {
                    lista_regioni.Add(new SelectListItem { Value = r.Regione_codice, Text = r.Regione_nome });

                }

                model.Regione_nascita = new SelectList(lista_regioni, "Value", "Text");

                /* se ho il comune e la nazione è l'italia mi recupero regione, provincia*/
                if (model.SelectedNazione_nascita == "ITALIA" && model.SelectedComune_nascita != null && model.SelectedComune_nascita != "")
                {
                    JsonComune c = wsc.GetComuneByIstatIDM(model.SelectedComune_nascita);

                    model.SelectedRegione_nascita = c.Regione_codice;
                    model.SelectedProvincia_nascita = c.Provincia_codice;
                    model.SelectedComune_nascita = c.Comune_codice;

                }

            }
            else
            {
                model.Regione_nascita = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            if (model.SelectedRegione_nascita != null)
            {
                List<JsonProvincia> listap = wsc.GetListaProvinceIDM(model.SelectedRegione_nascita);
                List<SelectListItem> lista_province = new List<SelectListItem>();
                foreach (JsonProvincia r in listap)
                {
                    lista_province.Add(new SelectListItem { Value = r.Provincia_codice, Text = r.Provincia_nome });

                }

                model.Provincia_nascita = new SelectList(lista_province, "Value", "Text");
            }
            else
            {
                model.Provincia_nascita = new SelectList(Enumerable.Empty<SelectListItem>());
            }


            if (model.SelectedProvincia_nascita != null)
            {
                List<JsonComune> listac = wsc.GetListaComuniIDM(model.SelectedProvincia_nascita);
                List<SelectListItem> lista_comuni = new List<SelectListItem>();
                foreach (JsonComune c in listac)
                {
                    lista_comuni.Add(new SelectListItem { Value = c.Comune_codice, Text = c.Comune_nome });

                }
                model.Comune_nascita = new SelectList(lista_comuni, "Value", "Text");
            }
            else
            {
                model.Comune_nascita = new SelectList(Enumerable.Empty<SelectListItem>());
            }




        }


        [HttpPost]
        public JsonResult GetListaRegioni()
        {
            List<JsonRegione> listar = wsc.GetListaRegioniIDM();
            List<SelectListItem> lista_regioni = new List<SelectListItem>();
            foreach (JsonRegione r in listar)
            {
                lista_regioni.Add(new SelectListItem { Value = r.Regione_codice, Text = r.Regione_nome });

            }
            return Json(new SelectList(lista_regioni, "Value", "Text")  );

            
        }


        [HttpPost]
        public JsonResult GetListaProvince(string regione)
        {
            if (regione == null)
            {
                return Json(new { Success = "False", responseText = "Parametro in input non presente" });
            }
            List<JsonProvincia> listap = wsc.GetListaProvinceIDM(regione);
            List<SelectListItem> lista_province = new List<SelectListItem>();
            foreach (JsonProvincia r in listap)
            {
                lista_province.Add(new SelectListItem { Value = r.Provincia_codice, Text = r.Provincia_nome });

            }
            return Json(new SelectList(lista_province, "Value", "Text"));



        }

        [HttpPost]
        public JsonResult GetListaComuni(string provincia)
        {
            if (provincia == null)
            {
                return Json(new { Success = "False", responseText = "Parametro in input non presente" });
            }
            List<JsonComune> listac = wsc.GetListaComuniIDM(provincia);
            List<SelectListItem> lista_comuni = new List<SelectListItem>();
            foreach (JsonComune c in listac)
            {
                lista_comuni.Add(new SelectListItem { Value = c.Comune_codice, Text = c.Comune_nome });

            }
            return Json(new SelectList(lista_comuni, "Value", "Text"));

           
        }


        #endregion 

    }
}
