using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Assignment3Morgenmadbuffeten.Pages
{
    public class Restaurant : PageModel
    {
        private readonly ILogger<Restaurant> _logger;

        public Restaurant(ILogger<Restaurant> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}