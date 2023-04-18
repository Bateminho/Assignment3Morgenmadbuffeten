using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Assignment3Morgenmadbuffeten.Pages
{
    public class Reception : PageModel
    {
        private readonly ILogger<Reception> _logger;

        public Reception(ILogger<Reception> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}