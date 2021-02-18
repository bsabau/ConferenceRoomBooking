using System;
using System.ComponentModel.DataAnnotations;

namespace ConferenceRoomBooking.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int RoomID { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }
    }
}
