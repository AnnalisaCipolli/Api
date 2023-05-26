using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Userbox.Models;

namespace Userbox.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IStringLocalizer _localizer;
        private readonly UtenteAuth _utenteauth;

        public SidebarViewComponent(IStringLocalizer Localizer,  UtenteAuth utenteauth)
        {
            _localizer = Localizer;
            _utenteauth = utenteauth;
        }
        public IViewComponentResult Invoke(string filter)
        {
            var sidebars = new List<SidebarMenu>();
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Home, _localizer["Home"], Url.Action("Index", "Home", null), "fa fa-home"));



            if (_utenteauth.Capability.Contains("AmministratoreUserbox"))
            {
                sidebars.Add(ModuleHelper.AddTree(_localizer["MenuMain_Utenti"], "fa fa-users"));



                sidebars.Last().TreeChild = new List<SidebarMenu>()
                {
                    ModuleHelper.AddModule(ModuleHelper.Module.Utenti, _localizer["MenuMain_Users"], Url.Action("Users", "Home", null),"fa fa-users")
                };
            }
            return View(sidebars);
        }
    }
}