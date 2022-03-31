using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork5;
using HomeWork5.RaceModel;

namespace RaceGame
{
    public class RaceGameRepository
    {
        public RaceGameContext context {get;set;}
        public Player CurrentPlayer { get; set; }
        public PlayerCar CurrentCar { get; set; }

        public RaceGameRepository()
        {
            context = new RaceGameContext();
            if (context.ShopCars.Count() == 0)
            {
                ShopCar car1 = new ShopCar()
                {
                    Name = "Volkswagen Golf",
                    Price = 0,
                    ImagePath = "..\\..\\..\\images\\cars\\1.Volkswagen_Golf.jpg"
                };
                ShopCar car2 = new ShopCar()
                {
                    Name = "Vauxhall Monaro",
                    Price = 2000,
                    ImagePath = "..\\..\\..\\images\\cars\\2.VauxhallMonaro.jpg"
                };
                ShopCar car3 = new ShopCar()
                {
                    Name = "Toyota Supra Vic",
                    Price = 4000,
                    ImagePath = "..\\..\\..\\images\\cars\\3.ToyotaSupraVic.jpg"
                };
                ShopCar car4 = new ShopCar()
                {
                    Name = "Porsche Cayman",
                    Price = 8000,
                    ImagePath = "..\\..\\..\\images\\cars\\4.PorscheCayman.jpg"
                };
                ShopCar car5 = new ShopCar()
                {
                    Name = "Porsche Cayman v2",
                    Price = 16000,
                    ImagePath = "..\\..\\..\\images\\cars\\5.PorscheCayman2.jpg"
                };
                ShopCar car6 = new ShopCar()
                {
                    Name = "Mitsubishi Eclipse GT",
                    Price = 32000,
                    ImagePath = "..\\..\\..\\images\\cars\\6.MitsubishiEclipseGT.jpg"
                };
                ShopCar car7 = new ShopCar()
                {
                    Name = "Lamborghini Gallardo",
                    Price = 64000,
                    ImagePath = "..\\..\\..\\images\\cars\\7.LamborghiniGallardo.jpg"
                };
                ShopCar car8 = new ShopCar()
                {
                    Name = "AstonMartin DB9",
                    Price = 120000,
                    ImagePath = "..\\..\\..\\images\\cars\\8.AstonMartinDB9.jpg"
                };
                ShopCar car9 = new ShopCar()
                {
                    Name = "Mercedes Benz SLR McLaren Bull",
                    Price = 240000,
                    ImagePath = "..\\..\\..\\images\\cars\\9.MercedesBenzSLRMcLarenBull.jpg"
                };
                ShopCar car10 = new ShopCar()
                {
                    Name = "BMWM 3 GTR Razor",
                    Price = 480000,
                    ImagePath = "..\\..\\..\\images\\cars\\10.BMWM3GTRRazor.jpg"
                };

                Road road1 = new Road()
                {
                    Name = "Waterfront & Century",
                    Distance = 4.6,
                    Price = 10,
                    ImagePath = "..\\..\\..\\images\\roads\\1.WaterfrontCentury.jpg"
                };
                Road road2 = new Road()
                {
                    Name = "Chase & Bristol",
                    Distance = 6.1,
                    Price = 100,
                    ImagePath = "..\\..\\..\\images\\roads\\2.ChaseandBristol.jpg"
                };
                Road road3 = new Road()
                {
                    Name = "North Bay & Harbor",
                    Distance = 7.5,
                    Price = 250,
                    ImagePath = "..\\..\\..\\images\\roads\\3.NorthBayandHarborCourse.jpg"
                };
                Road road4 = new Road()
                {
                    Name = "Camden & Fisher",
                    Distance = 8.0,
                    Price = 500,
                    ImagePath = "..\\..\\..\\images\\roads\\4.CamdenandFisher.jpg"
                };
                Road road5 = new Road()
                {
                    Name = "Union & Hollis",
                    Distance = 9.0,
                    Price = 1000,
                    ImagePath = "..\\..\\..\\images\\roads\\5.UnionandHollis.jpg"
                };
                Road road6 = new Road()
                {
                    Name = "Heritage & Diamond",
                    Distance = 10.1,
                    Price = 2000,
                    ImagePath = "..\\..\\..\\images\\roads\\6.HeritageandDiamond.jpg"
                };
                Road road7 = new Road()
                {
                    Name = "Union Row & Ocean",
                    Distance = 12.4,
                    Price = 4000,
                    ImagePath = "..\\..\\..\\images\\roads\\7.UnionRowandOcean.jpg"
                };
                Road road8 = new Road()
                {
                    Name = "Interchange & Bond",
                    Distance = 8,
                    Price = 8000,
                    ImagePath = "..\\..\\..\\images\\roads\\8.WInterchangeandBond.jpg"
                };
                Road road9 = new Road()
                {
                    Name = "Lyons & State",
                    Distance = 14.2,
                    Price = 16000,
                    ImagePath = "..\\..\\..\\images\\roads\\9.LyonsandState.jpg"
                };
                Road road10 = new Road()
                {
                    Name = "Clubhouse & Lennox",
                    Distance = 16.0,
                    Price = 32000,
                    ImagePath = "..\\..\\..\\images\\roads\\10.ClubhouseandLennox.jpg"
                };
                Road road11 = new Road()
                {
                    Name = "Burger King Challenge",
                    Distance = 17.2,
                    Price = 64000,
                    ImagePath = "..\\..\\..\\images\\roads\\11.BurgerKingChallenge.jpg"
                };
                Road road12 = new Road()
                {
                    Name = "World Loop",
                    Distance = 27.2,
                    Price = 120000,
                    ImagePath = "..\\..\\..\\images\\roads\\12.WorldLoop.jpg"
                };

                context.ShopCars.AddRange(new List<ShopCar>() { car1, car2, car3, car4, car5, car6, car7, car8, car9, car10 });
                context.Roads.AddRange(new List<Road>() { road1, road2, road3, road4, road5, road6, road7, road8, road9, road10, road11, road12 });
                context.SaveChanges();
            }
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return context.Players;
        }

        public IEnumerable<Road> GetAllRoads()
        {
            return context.Roads;
        }

        public IEnumerable<Race> GetAllRaces()
        {
            return context.Races;
        }

        public IEnumerable<Adventure> GetAllAdventures()
        {
            return context.Adventures;
        }

        public IEnumerable<ShopCar> GetAllShopCars()
        {
            return context.ShopCars;
        }

        public async void SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Player AddNewPlayer(string name)
        {
            Player newPlayer = new Player()
            {
                Name = name,
                Coins = 100,
                Level = 1,
            };
            context.Players.Add(newPlayer);
            ShopCar buyCar = context.ShopCars.Where(c => c.Id == 1).First();
            this.AddCarToPlayer(newPlayer, buyCar);
            Road firstRoad = context.Roads.Where(r => r.Id == 1).First();
            newPlayer.Roads.Add(firstRoad);
            return newPlayer;
        }

        public void AddCarToPlayer(Player player, ShopCar shopCar)
        {
            PlayerCar newCar = new PlayerCar()
            {
                Color = "Black",
                EngineLevel = 1,
                ClutchLevel = 1,
                TransmissionLevel = 1,
                FuelCapacityLevel = 1
            };
            shopCar.PlayerCars.Add(newCar);
            player.PlayerCars.Add(newCar);

        }

        public void AddNewRace(Player player,Road road,int position)
        {
            Race newRace = new Race()
            {
                Date = DateTime.Now,
                Road = road,
            };
            RacePlayer newRacePlayer = new RacePlayer()
            {
                Position = position,
            };
            context.Races.Add(newRace);
            newRace.RacesPlayers.Add(newRacePlayer);
            player.RacesPlayers.Add(newRacePlayer);
            context.SaveChanges();
        }

        public void AddNewAdventure(Player player, Road road, float distanceReached,int reward)
        {
            Adventure newAdventure = new Adventure()
            {
                Date = DateTime.Now,
                Road = road,

            };
            AdventurePlayer newAdventurePlayer = new AdventurePlayer()
            {
                Distance = distanceReached,
                GainedCoins = reward
            };
            context.Adventures.Add(newAdventure);
            newAdventure.Adventures.Add(newAdventurePlayer);
            player.Adventures.Add(newAdventurePlayer);
            context.SaveChanges();
        }

        public bool IncreasePlayerLevel(Player player)
        {
            int racesCount = player.Adventures.Count;
            int adventuresCount = player.RacesPlayers.Count;

            if (racesCount + adventuresCount > player.Level * 12)
            {
                player.Level += 1;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
