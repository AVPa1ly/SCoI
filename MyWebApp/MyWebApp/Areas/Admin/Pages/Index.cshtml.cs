using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Entities;

namespace MyWebApp.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyWebApp.Data.ApplicationDbContext _context;

        public IndexModel(MyWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }

        public async Task OnGetAsync()
        {
            Game = await _context.Games
                .Include(g => g.Group).ToListAsync();
        }
    }
}
