using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data;
using MyWebApp.Entities;
using MyWebApp.Extensions;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class GameController : Controller
    {

        ApplicationDbContext _context;
        int _pageSize;

        public GameController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo=1)
        {
            var gamesFiltered = _context.Games.Where(d => !group.HasValue || d.GameGroupId == group.Value);
            ViewData["Groups"] = _context.GameGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            var model = ListViewModel<Game>.GetModel(gamesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_listpartial", model);
            }
            else
                return View(model);
        }
    }
}
