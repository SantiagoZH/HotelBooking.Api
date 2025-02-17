using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } 

        [Required]
        public string Role { get; set; } // "Agent" o "Traveler"

        public User() { }

        public User(string name, string email, string passwordHash, string role)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
        }
    }
}
