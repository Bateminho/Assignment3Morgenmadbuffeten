using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Assignment3Morgenmadbuffeten.Pages
{
    public class Kitchen : PageModel
    {
        private readonly ILogger<Kitchen> _logger;

        public Kitchen(ILogger<Kitchen> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}