using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ConferenceRoomBooking.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Display(Name = "Room Name")]
        [Column(TypeName = "VARCHAR(128)")]
        [StringLength(128, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Maximum Capacity")]
        [Required]
        [Range(1, 40)]
        public int Capacity { get; set; }

        [Display(Name = "Short Description")]
        [Column(TypeName = "varchar(512)")]
        public string Description { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
