using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.ViewComponents
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