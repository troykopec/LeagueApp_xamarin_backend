using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LeagueApp_xamarin_backend.Models
{
    public class League
    {
        [Key]
        public int Id { get; set; }
        public string LeagueName { get; set; }
        public string Description { get; set; }
        public string SportType { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegistrationStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegistrationEndDate { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal RegistrationFee { get; set; }
        public int MaxTeamCapacity { get; set; }
        public int MaxTeams{ get; set; }
        //public User Organizer { get; set; }
        public int OrganizerId { get; set; }
        
        public List<Team> Teams { get; set; }
        public string UniqueCode { get; set; }

        // Base constructor
        public League()
        {
            Teams = new List<Team>();
        }

        // Other properties and methods as needed
    }

    // Sport-specific League classes 

    public class SoccerLeague : League
    {
        // public int FieldSize { get; set; }
        // Other soccer-specific properties
        public string SportType { get; } = "Soccer";
        public int Goals { get; set; } // Scoring property for soccer
        /*
        public List<SoccerGame> SoccerGames { get; set; }

        public SoccerLeague()
        {
            SoccerGames = new List<SoccerGame>();
        }
        */
    }

    public class BasketballLeague : League
    {
        // public int CourtSize { get; set; }
        // Other basketball-specific properties
        public string SportType { get; } = "Basketball";
        public int Points { get; set; } // Scoring property for soccer

        /*
        public List<BasketballGame> BasketballGames { get; set; }

        public BasketballLeague()
        {
            BasketballGames = new List<BasketballGame>();
        }
        */
    }

    public class NicheLeague : League
    {
        // Other  Niche-specific properties
        public int NichePoints { get; set; } // Scoring property for soccer
        
        /*public List<NicheGame> NicheGames { get; set; }

        public NicheLeague()
        {
            NicheGames = new List<NicheGame>();
        }
        */
    }
/*

    public class Game
    {
        [Column(TypeName = "datetime")]
        public DateTime GameDate { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        // Common game properties and methods
    }

    // Sport-specific game classes 

    public class SoccerGame : Game
    {
        public int RedCards { get; set; }
        public int YellowCards { get; set; }
        // Other soccer-specific game properties and methods
    }

    public class BasketballGame : Game
    {
        public int Fouls { get; set; }
        // Other basketball-specific game properties and methods
    }

    public class NicheGame : Game
    {
        // Other basketball-specific game properties and methods
    }
*/
}
