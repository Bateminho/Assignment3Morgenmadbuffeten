using Assignment3Morgenmadsbuffeten.Hub;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using Assignment3Morgenmadbuffeten.Data;
using Assignment3Morgenmadsbuffeten.Models;

namespace Assignment3Morgenmadsbuffeten.Pages.Restaurant
{
    [Authorize("Waiter")]
    public class GuestCheckInModel : PageModel
    {
        private readonly BreakfastBuffetDbContext _context;
        private readonly IHubContext<KitchenHub, IKitchenHub> _kitchenHub;

        [BindProperty] public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [DataType(DataType.Date)]
            public DateTime Date { get; set; } = DateTime.Today;

            public int RoomNumber { get; set; }
            public int Adults { get; set; } = 0;
            public int Children { get; set; } = 0;
        }

        public GuestCheckInModel(BreakfastBuffetDbContext context, IHubContext<KitchenHub, IKitchenHub> kitchenHub)
        {
            _context = context;
            Input = new InputModel();
            _kitchenHub = kitchenHub;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var breakfastCheckin = new CheckInBreakfastBuffetGuest
            {
                Adults = Input.Adults,
                Children = Input.Children,
                Date = Input.Date,
                RoomNumber = Input.RoomNumber
            };

            _context.CheckInBreakfastBuffetGuests.Add(breakfastCheckin);
            await _context.SaveChangesAsync();
            _kitchenHub.Clients.All.KitchenUpdate();
            return Page();
        }

        public void OnGet() { }
    }
}
