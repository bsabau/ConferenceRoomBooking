using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ConferenceRoomBooking.Models
{
    public class User
    {
        public int ID { get; set; }

        [Column(TypeName = "VARCHAR(128)")]
        [StringLength(128, MinimumLength = 6)]
        [Required]
        public string Email { get; set;}
        
        [Display(Name = "First Name")]
        [Column(TypeName = "varchar(64)")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Column(TypeName = "VARCHAR(64)")]
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
