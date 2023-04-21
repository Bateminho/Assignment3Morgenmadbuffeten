using Assignment3Morgenmadbuffeten.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Assignment3Morgenmadsbuffeten.Pages.Kitchen
{
    [Authorize("Kitchen")]
    public class BreakfastReportModel : PageModel
    {

        private readonly BreakfastBuffetDbContext _context;

        public int ExpectedAdults;
        public int ExpectedChildren;
        public int ExpectedTotal;
        public int CheckedInAdults;
        public int CheckedInChildren;

        [BindProperty] public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [DataType(DataType.Date)]
            public DateTime Date { get; set; } = DateTime.Now;
        }

        public BreakfastReportModel(BreakfastBuffetDbContext context)
        {
            _context = context;
            Input = new InputModel();
        }

        public async Task OnGet()
        {
            var dbExpected = await _context.ExpectedBreakfastGuests!
                .Where(b => b.Date.Day == Input.Date.Day && b.Date.Month == Input.Date.Month)
                .ToListAsync();

            if (dbExpected == null)
            {
                ModelState.AddModelError("Input.Date", "No guest on this date");
                return;
            }

            foreach (var item in dbExpected)
            {
                ExpectedAdults = item.Adults;
                ExpectedChildren = item.Children;
                ExpectedTotal = ExpectedAdults + ExpectedChildren;
            }

            var dbCheckedIn = await _context.CheckInBreakfastBuffetGuests
               .Where(b => b.Date.Day == Input.Date.Day && b.Date.Month == Input.Date.Month)
               .ToListAsync();

            if (dbCheckedIn == null)
            {
                ModelState.AddModelError("Input.Date", "No guest on this date");
                return;
            }

            foreach (var item in dbCheckedIn)
            {
                CheckedInAdults += item.Adults;
                CheckedInChildren += item.Children;
            }
        }

        public async Task OnPost()
        {
            var dbExpected = await _context.ExpectedBreakfastGuests
                .Where(b => b.Date.Day == Input.Date.Day && b.Date.Month == Input.Date.Month)
                .ToListAsync();

            if (dbExpected == null)
            {
                ModelState.AddModelError("Input.Date", "No guest on this date");
                return;
            }

            foreach (var item in dbExpected)
            {
                ExpectedAdults = item.Adults;
                ExpectedChildren = item.Children;
                ExpectedTotal = ExpectedAdults + ExpectedChildren;
            }

            var dbCheckedIn = await _context.CheckInBreakfastBuffetGuests
               .Where(b => b.Date.Day == Input.Date.Day && b.Date.Month == Input.Date.Month)
               .ToListAsync();

            if (dbCheckedIn == null)
            {
                ModelState.AddModelError("Input.Date", "No guest on this date");
                return;
            }

            foreach (var item in dbCheckedIn)
            {
                CheckedInAdults += item.Adults;
                CheckedInChildren += item.Children;
            }
        }
    }
}