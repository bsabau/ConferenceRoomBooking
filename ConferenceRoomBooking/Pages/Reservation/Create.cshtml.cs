using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Pages.Rezervations
{
    public class CreateModel : PageModel
    {
        private readonly ConferenceRoomBooking.Data.ConferenceRoomBookingContext _context;

        public CreateModel(ConferenceRoomBooking.Data.ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
        ViewData["UserID"] = new SelectList(_context.User, "ID", "Email");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (OverlapExists(Reservation.RoomID, Reservation.StartTime, Reservation.EndTime))
            {
                ModelState.AddModelError("NewReservation", "Dates overlaping!");
                return OnGet();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool OverlapExists(int id, DateTime start, DateTime end)
        {
            return _context.Reservation.Any(e =>
                e.StartTime <= end &&
                e.EndTime >= start &&
                e.RoomID == id);
        }
    }
}





