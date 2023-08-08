using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueApp_xamarin_backend.Models
{
    public class Team
    {
        [Key]
        public string Id { get; set; }
        public string TeamName { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public List<User> Players { get; set; }
        public User TeamLeader { get; set; }
        public int TeamLeaderId { get; set; }

        public Team()
        {
            Players = new List<User>();
        }
    }
}
