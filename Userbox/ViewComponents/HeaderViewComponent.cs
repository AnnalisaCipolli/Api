﻿using Microsoft.AspNetCore.Mvc;

namespace Userbox.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public HeaderViewComponent() { }

        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}