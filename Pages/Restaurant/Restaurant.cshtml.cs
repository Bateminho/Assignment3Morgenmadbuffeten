using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Assignment3Morgenmadbuffeten.Data;

namespace Assignment3Morgenmadbuffeten.Pages.Restaurant
{
    public class Restaurant : PageModel
    {
        private readonly BreakfastBuffetDbContext _context;

        public Restaurant(BreakfastBuffetDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
    }
}