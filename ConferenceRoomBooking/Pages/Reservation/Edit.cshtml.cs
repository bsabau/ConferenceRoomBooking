using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConferenceRoomBooking.Data;
using ConferenceRoomBooking.Models;

namespace ConferenceRoomBooking.Pages.Rezervations
{
    public class EditModel : PageModel
    {
        private readonly ConferenceRoomBooking.Data.ConferenceRoomBookingContext _context;

        public EditModel(ConferenceRoomBooking.Data.ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservation
                .Include(r => r.Room)
                .Include(r => r.User).FirstOrDefaultAsync(m => m.ReservationID == id);

            if (Reservation == null)
            {
                return NotFound();
            }
           ViewData["RoomID"] = new SelectList(_context.Room, "ID", "Name");
           ViewData["UserID"] = new SelectList(_context.User, "ID", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(Reservation.ReservationID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ReservationID == id);
        }
    }
}
