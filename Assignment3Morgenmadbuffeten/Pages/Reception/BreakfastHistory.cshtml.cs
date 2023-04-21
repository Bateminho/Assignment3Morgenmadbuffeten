using Assignment3Morgenmadbuffeten.Data;
using Assignment3Morgenmadbuffeten.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace Assignment3Morgenmadbuffeten.Pages.Reception
{
    [Authorize("Reception")]
    public class BreakfastHistoryModel : PageModel
    {
        private readonly BreakfastBuffetDbContext _context;
        public string DateNow { get; set; }
        public List<CheckInBreakfastBuffetGuest> CheckedIn { get; set; } = new List<CheckInBreakfastBuffetGuest>();
        public DisplayModel Display { get; set; }
        public class DisplayModel
        {
            public int RoomNumber { get; set; } = 0;
            public int Adults { get; set; } = 0;
            public int Children { get; set; } = 0;
        }

        public BreakfastHistoryModel(BreakfastBuffetDbContext context)
        {
            _context = context;
            Display = new DisplayModel();
            DateNow = DateTime.Now.Day + "/" + DateTime.Now.Month;
        }
        public async Task OnGetAsync()
        {
            // Load all checkins for today from database
            var dbBreakfastCheckIns = await _context.CheckInBreakfastBuffetGuests
                .Where(b => b.Date.Day == DateTime.Now.Day && b.Date.Month == DateTime.Now.Month)
                .ToListAsync();

            if (false) { RedirectToPage("Error"); return; }

            CheckedIn = dbBreakfastCheckIns;
        }
    }
}

