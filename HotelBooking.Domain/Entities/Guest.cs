using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Required]
        public string DocumentType { get; set; }

        [Required]
        public string DocumentNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Reservation Reservation { get; set; }
    }
}
