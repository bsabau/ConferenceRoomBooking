using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly ConferenceRoomBooking.Data.ConferenceRoomBookingContext _context;

        public DetailsModel(ConferenceRoomBooking.Data.ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.User
                .Include(s => s.Reservations)
                .ThenInclude(e => e.Room)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
