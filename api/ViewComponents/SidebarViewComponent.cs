using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using api.Models;

namespace api.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IStringLocalizer _localizer;
       
        public SidebarViewComponent(IStringLocalizer Localizer)
        {
            _localizer = Localizer;
       }
        public IViewComponentResult Invoke(string filter)
        {
            var sidebars = new List<SidebarMenu>();
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Home, _localizer["Home"], Url.Action("Index", "Home", null), "fa fa-home"));


    sidebars.Add(ModuleHelper.AddTree(_localizer["MenuMain_Ospiti"], "fa fa-users"));



                sidebars.Last().TreeChild = new List<SidebarMenu>()
                {
                    ModuleHelper.AddModule(ModuleHelper.Module.Utenti, _localizer["MenuMain_Ospiti_Crea"], Url.Action("Create", "Ospite", null),"fa fa-plus")
                    ,
                    ModuleHelper.AddModule(ModuleHelper.Module.Utenti, _localizer["MenuMain_Ospiti_Visualizza"], Url.Action("Index", "Ospite", null),"fa fa-users")
                };
            
            return View(sidebars);
        }
    }
}