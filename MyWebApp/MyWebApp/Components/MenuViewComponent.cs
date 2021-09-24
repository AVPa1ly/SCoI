using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Components
{
    public class MenuViewComponent: ViewComponent
    {
        // Инициализация списка элементов меню 
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{Controller="Home", Action="Index", Text="Лб 3"},
            new MenuItem{Controller="Product", Action="Index", Text="Каталог"},
            new MenuItem{Controller="Admin", Action="Index", Text="Администрирование"},
        };

        public IViewComponentResult Invoke()
        {
            //Получение значений сегментов маршрута
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];

            foreach (var item in _menuItems)
            {
                var _matchController = controller?.Equals(item.Controller) ?? false;
                var _matchArea = area?.Equals(item.Area) ?? false;
                if (_matchArea || _matchController)
                {
                    item.Active = "active";
                }
            }
            return View(_menuItems);
        }
    }
}
