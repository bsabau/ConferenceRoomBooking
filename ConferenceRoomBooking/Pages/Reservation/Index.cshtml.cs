using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Pages.Rezervations
{
    public class IndexModel : PageModel
    {
        private readonly ConferenceRoomBooking.Data.ConferenceRoomBookingContext _context;

        public IndexModel(ConferenceRoomBooking.Data.ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get;set; }

        public async Task OnGetAsync()
        {
            Reservation = await _context.Reservation
                .Include(r => r.Room)
                .Include(r => r.User).ToListAsync();
        }
    }
}
