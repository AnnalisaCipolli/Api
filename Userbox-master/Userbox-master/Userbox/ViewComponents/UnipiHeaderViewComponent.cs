using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Userbox.Models;

namespace Userbox.ViewComponents
{
    public class UnipiHeaderViewComponent : ViewComponent
    {
        public UnipiHeaderViewComponent() { }
        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}