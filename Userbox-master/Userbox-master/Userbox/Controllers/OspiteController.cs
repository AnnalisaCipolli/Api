using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Userbox.Models;

namespace Userbox.Controllers
{


    public class OspiteController : Controller
    {

        private readonly ConfigurationManager _config;


        public OspiteController(ConfigurationManager config)
        {
            _config = config;

        }

        // GET: OspiteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OspiteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OspiteController/Create
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        #region funzioni creazione/modifica utente

        private void ConfigureViewModel(ViewOspite model)
        {
            WebServiceCall wsc = new WebServiceCall(_config);


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


        #endregion 

    }
}
