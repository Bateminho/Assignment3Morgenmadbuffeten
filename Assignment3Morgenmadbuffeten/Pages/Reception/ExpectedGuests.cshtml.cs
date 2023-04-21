using Assignment3Morgenmadsbuffeten.Hub;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Assignment3Morgenmadbuffeten.Data;
using Assignment3Morgenmadbuffeten.Models;

namespace Assignment3Morgenmadbuffeten.Pages.Reception
{
        [Authorize("Reception")]
        public class ExpectedGuestsModel : PageModel
        {
            private readonly BreakfastBuffetDbContext _context;
            private readonly IHubContext<KitchenHub, IKitchenHub> _kitchenHub;

            [BindProperty] public InputModel Input { get; set; }
            public class InputModel
            {
                [Required]
                [DataType(DataType.Date)]
                public DateTime Date { get; set; } = DateTime.Today;

                public int Adults { get; set; } = 0;
                public int Children { get; set; } = 0;
            }

            public ExpectedGuestsModel(BreakfastBuffetDbContext context, IHubContext<KitchenHub, IKitchenHub> kitchenHub)
            {
                _context = context;
                _kitchenHub = kitchenHub;
                Input = new InputModel();
            }
            public IActionResult OnPostRedirect()
            {
                return RedirectToPage("BreakfastHistory");
            }

            public async Task<IActionResult> OnPostAsync()
            {
                var expectedBreakfastGuests = new ExpectedBreakfastGuests
                {
                    Adults = Input.Adults,
                    Children = Input.Children,
                    Date = Input.Date
                };

                Debug.Assert(_context.ExpectedBreakfastGuests != null, "_context.ExpectedBreakfastGuests != null");
                _context.ExpectedBreakfastGuests.Add(expectedBreakfastGuests);
                await _context.SaveChangesAsync();
            await _kitchenHub.Clients.All.KitchenUpdate();
                return Page();
            }

            public void OnGet() { }
        }
    }
