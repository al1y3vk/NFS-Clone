using System.Collections.Generic;
using System.Linq;
using HomeWork5.RaceModel;

namespace RaceGame
{
    public class LeaderboardViewModel
    {
        public RaceGameRepository Repository;
        public List<Player> PlayersList { get; set; }
        public string CoinImagePath { get; set; }
        public string LevelImagePath { get; set; }
        IPageView View;

        public LeaderboardViewModel(IPageView view, RaceGameRepository repository)
        {
            this.View = view;
            this.Repository = repository;
            PlayersList = Repository.GetAllPlayers().OrderByDescending(p => p.Level).ToList();
            CoinImagePath = System.IO.Path.GetFullPath("..\\..\\..\\images\\icons\\coin.png");
            LevelImagePath = System.IO.Path.GetFullPath("..\\..\\..\\images\\icons\\level.png");
            
        }

        private RelayCommand backPlyayerInterfaceCommand;
        public RelayCommand BackPlayerInterfaceCommand
        {
            get
            {
                if (backPlyayerInterfaceCommand is null)
                {
                    return backPlyayerInterfaceCommand = new RelayCommand
                    (
                        (param) =>
                        {
                            View.Navigate(Repository, "PlayerInterface");
                        }
                        );
                }
                return backPlyayerInterfaceCommand;
            }
        }
    }
}
