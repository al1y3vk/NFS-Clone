using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using HomeWork5.RaceModel;

namespace RaceGame
{
    public class PlayerInterfaceViewModel : INotifyPropertyChanged
    {
        #region Fields

        IPageView pageView;

        public RaceGameRepository Repository;
        public List<Road> Roads { get; set; }
        public Player Player { get; set; }
        private Road road { get; set; }
        public PlayerCar PlayerCar { get; set; }
        private string roadPrice;
        private float playerDistance;
        public string CoinImagePath { get; set; }
        public string LevelImagePath { get; set; }

        private RelayCommand returnMenuCommand;
        private RelayCommand toGarageCommand;
        private RelayCommand toLeaderboardCommand;
        private RelayCommand nextRoadCommand;
        private RelayCommand prevRoadCommand;
        private RelayCommand buyRoadCommand;
        private RelayCommand goRaceCommand;
        private RelayCommand goAdventureCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public PlayerInterfaceViewModel(IPageView view, RaceGameRepository repository)
        {
            this.pageView = view;
            this.Repository = repository;
            CoinImagePath = System.IO.Path.GetFullPath("..\\..\\..\\images\\icons\\coin.png");
            LevelImagePath = System.IO.Path.GetFullPath("..\\..\\..\\images\\icons\\level.png");
            Player = Repository.CurrentPlayer;
            Roads = Repository.GetAllRoads().ToList();
            road = Player.Roads.First();
            PlayerCar = Repository.CurrentCar;
            RoadPrice = "Bought";

            if (Player.Adventures.Where(a => a.Adventure.Road == road).Count() > 0)
            {
                float Distance = Player.Adventures.Where(a => a.Adventure.Road == road).Max(a => a.Distance);
                PlayerDistance = Distance;
            }
        }

        #region Properties / Commands

        public string RoadPrice
        {
            get
            {
                return roadPrice;
            }
            set
            {
                roadPrice = value;
                OnPropertyChanged("RoadPrice");
            }
        }

        public float PlayerDistance
        {
            get
            {
                return playerDistance;
            }
            set
            {
                playerDistance = value;
                OnPropertyChanged("PlayerDistance");
            }
        }

        public Road Road
        {
            get
            {
                return road;
            }
            set
            {
                road = value;
                OnPropertyChanged("Road");
            }
        }

        public RelayCommand ReturnMenuCommand
        {
            get
            {
                if (returnMenuCommand is null)
                {
                    return returnMenuCommand = new RelayCommand(

                        (param) =>
                        {
                            pageView.Navigate(Repository, "Menu");
                        }
                        );
                }
                return returnMenuCommand;
            }
        }


        public RelayCommand ToGarageCommand
        {
            get
            {
                if (toGarageCommand is null)
                {
                    return toGarageCommand = new RelayCommand(

                        (param) =>
                        {
                            pageView.Navigate(Repository, "Garage");
                        }
                        );
                }
                return toGarageCommand;
            }
        }


        public RelayCommand ToLeaderboardCommand
        {
            get
            {
                if (toLeaderboardCommand is null)
                {
                    return toLeaderboardCommand = new RelayCommand(

                        (param) =>
                        {
                            pageView.Navigate(Repository, "Leaderboard");
                        }
                        );
                }
                return toLeaderboardCommand;
            }
        }

        public RelayCommand NextRoadCommand
        {
            get
            {
                if (nextRoadCommand is null)
                {
                    return nextRoadCommand = new RelayCommand(
                        ChangeNextRoad,
                        (param) =>
                        {
                            return Roads.IndexOf(road) + 1 < Roads.Count;
                        }
                        );
                }
                return nextRoadCommand;
            }
        }

        public RelayCommand PrevRoadCommand
        {
            get
            {
                if (prevRoadCommand is null)
                {
                    return prevRoadCommand = new RelayCommand(
                        ChangePrevRoad,
                        (param) =>
                        {
                            return Roads.IndexOf(road) - 1 >= 0;
                        }
                        );
                }
                return prevRoadCommand;
            }
        }

        public RelayCommand BuyRoadCommand
        {
            get
            {
                if (buyRoadCommand is null)
                {
                    return buyRoadCommand = new RelayCommand(
                        BuyRoadExecute,
                        (param) =>
                        {
                            return Player.Coins >= road.Price && !Player.Roads.Any(r => r == road);
                        }
                        );
                }
                return buyRoadCommand;
            }
        }

        public RelayCommand GoRaceCommand
        {
            get
            {
                if (goRaceCommand is null)
                {
                    return goRaceCommand = new RelayCommand(
                        GoRaceExecute,
                        (param) =>
                        {
                            return Player.Roads.Any(r => r == road);
                        }
                        );
                }
                return goRaceCommand;
            }
        }

        public RelayCommand GoAdventureCommand
        {
            get
            {
                if (goAdventureCommand is null)
                {
                    return goAdventureCommand = new RelayCommand(
                        GoAdventureExecute,
                        (param) =>
                        {
                            return Player.Roads.Any(r => r == road);
                        }
                        );
                }
                return goAdventureCommand;
            }
        }

        #endregion

        #region Methods

        private void ChangeNextRoad(object param)
        {
            Road = Roads[Roads.IndexOf(Road) + 1];
            if (Player.Adventures.Where(a => a.Adventure.Road == road).Count() > 0)
            {
                float Distance = Player.Adventures.Where(a => a.Adventure.Road == road).Max(a => a.Distance);
                PlayerDistance = Distance;
            }
            else
            {
                PlayerDistance = 0;
            }
            if (Player.Roads.Any(r => r == road))
            {
                RoadPrice = "Bought";
            }
            else
            {
                RoadPrice = road.Price.ToString();
            }
        }

        private void ChangePrevRoad(object param)
        {
            Road = Roads[Roads.IndexOf(road) - 1];
            if (Player.Adventures.Where(a => a.Adventure.Road == road).Count() > 0)
            {
                float Distance = Player.Adventures.Where(a => a.Adventure.Road == road).Max(a => a.Distance);
                PlayerDistance = Distance;
            }
            else
            {
                PlayerDistance = 0;
            }
            if (Player.Roads.Any(r => r == road))
            {
                RoadPrice = $"Bought";
            }
            else
            {
                RoadPrice = road.Price.ToString();
            }
        }

        private void BuyRoadExecute(object param)
        {
            Player.Coins -= road.Price;
            Player.Roads.Add(road);
            Repository.SaveChanges();
            RoadPrice = $"Bought";
        }

        private void GoRaceExecute(object param)
        {
            Random random = new Random();
            int Position = random.Next(1, 4);
            int Reward = ((road.Price / 5) / Position) * 5;
            if (Reward == 0)
            {
                Reward = 5;
            }
            MessageBox.Show($"You take {Position} position \n You gained {Reward} coins");
            Player.Coins += Reward;
            Repository.AddNewRace(Player, road, Position);
            Repository.IncreasePlayerLevel(Player);
            Repository.SaveChanges();
        }

        private void GoAdventureExecute(object param)
        {
            Random random = new Random();
            int RandomDistance = random.Next(100, (int)(road.Distance * 100));
            int DistancePercent = (int)((float)RandomDistance / road.Distance);
            int Reward = road.Price * DistancePercent / 100;
            float DistanceReached = (float)RandomDistance / (float)100;
            MessageBox.Show($"You have made {DistanceReached} km \n That is {DistancePercent} % of all Distance \n You gained {Reward} coins");
            Player.Coins += Reward;

            float Distance = 0;
            if (Player.Adventures.Where(a => a.Adventure.Road == road).Count() > 0)
            {
                Distance = Player.Adventures.Where(a => a.Adventure.Road == road).Max(a => a.Distance);
            }
            Repository.AddNewAdventure(Player, road, DistanceReached, Reward);
            if (Player.Adventures.Where(a => a.Adventure.Road == road).Count() > 0)
            {

                if (Distance < DistanceReached)
                {
                    PlayerDistance = DistanceReached;
                }
            }
            else
            {
                PlayerDistance = DistanceReached;
            }
            Repository.IncreasePlayerLevel(Player);
            Repository.SaveChanges();

        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

    }
}
