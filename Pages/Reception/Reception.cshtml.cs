using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment3Morgenmadbuffeten.Data;
using Microsoft.Extensions.Logging;

namespace Assignment3Morgenmadbuffeten.Pages.Reception
{
    public class Reception : PageModel
    {
        private readonly BreakfastBuffetDbContext _context;

        public Reception (BreakfastBuffetDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}