using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueApp_xamarin_backend.Models
{
    public class Item
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(50)] // Set the maximum length to 50 characters
        public string Text { get; set; }

        // Set a unique constraint on the Description property (protected override in mydbContext)
        public string Description { get; set; }
    }
}