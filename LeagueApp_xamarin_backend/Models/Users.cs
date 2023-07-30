using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueApp_xamarin_backend.Models
{
    public class User
    {
        [Key] // This attribute marks the UserID property as the primary key
        public int UserID { get; set; }
        [MaxLength(50)] // Set the maximum length to 50 characters
        public string Username { get; set; }
        [MaxLength(254)] // Set the maximum length for email address (you can adjust it as needed)
        public string Email { get; set; }
        public string Password { get; set; } // For the password, make sure to hash/encrypt it when storing
        [MaxLength(100)] // Set the maximum length to 50 characters
        public string FirstName { get; set; }
        [MaxLength(100)] // Set the maximum length to 50 characters
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(15)] // Set the maximum length for phone number (you can adjust it as needed)
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}