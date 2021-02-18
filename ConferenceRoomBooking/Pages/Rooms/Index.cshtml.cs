using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly ConferenceRoomBooking.Data.ConferenceRoomBookingContext _context;

        public IndexModel(ConferenceRoomBooking.Data.ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public IList<Room> Room { get;set; }

        public async Task OnGetAsync()
        {
            Room = await _context.Room.ToListAsync();
        }
    }
}
