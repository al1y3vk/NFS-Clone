namespace HomeWork5
{
    using HomeWork5.RaceModel;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RaceGameContext : DbContext
    {
        // Your context has been configured to use a 'RaceContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HomeWork5.RaceContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RaceContext' 
        // connection string in the application configuration file.
        public RaceGameContext()
            : base("name=RaceGameContext")
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<ShopCar> ShopCars { get; set; }
        public virtual DbSet<Road> Roads { get; set; }
        public virtual DbSet<Adventure> Adventures { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RacePlayer> RacesPlayers { get; set; }
        public virtual DbSet<AdventurePlayer> AdventuresPlayers { get; set; }
        public virtual DbSet<PlayerCar> PlayerCars { get; set; }

    }

}