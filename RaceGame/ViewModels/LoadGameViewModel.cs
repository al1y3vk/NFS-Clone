using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using HomeWork5.RaceModel;

namespace RaceGame
{
    public class LoadGameViewModel : INotifyPropertyChanged
    {
        #region Fields

        IPageView View;
        public RaceGameRepository Repository;
        private Player selectedPlayer;
        public List<Player> PlayersList { get; set; }
        public string CoinImagePath { get; set; }
        public string LevelImagePath { get; set; }

        private RelayCommand toPlyayerInterfaceCommand;
        private RelayCommand backMenuCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        public LoadGameViewModel(IPageView view, RaceGameRepository repository)
        {
            this.View = view;
            this.Repository = repository;
            PlayersList = Repository.GetAllPlayers().ToList();
            CoinImagePath = System.IO.Path.GetFullPath("..\\..\\..\\images\\icons\\coin.png");
            LevelImagePath = System.IO.Path.GetFullPath("..\\..\\..\\images\\icons\\level.png");
        }

        #region Properties / Commands

        public Player SelectedPlayer
        {
            get
            {
                return selectedPlayer;
            }
            set
            {
                selectedPlayer = value;
                OnPropertyChanged("SelectedPlayer");
            }
        }

        public RelayCommand ToPlayerInterfaceCommand
        {
            get
            {
                if (toPlyayerInterfaceCommand is null)
                {
                    return toPlyayerInterfaceCommand = new RelayCommand
                    (
                        (param) =>
                        {
                            Repository.CurrentPlayer = SelectedPlayer;
                            Repository.CurrentCar = Repository.CurrentPlayer.PlayerCars.First();
                            View.Navigate(Repository, "PlayerInterface");
                        },
                        (param) =>
                        {
                            return SelectedPlayer != null;
                        }
                        );
                }
                return toPlyayerInterfaceCommand;
            }
        }

        public RelayCommand BackMenuCommand
        {
            get
            {
                if (backMenuCommand is null)
                {
                    return backMenuCommand = new RelayCommand
                    (
                        (param) =>
                        {
                            View.Navigate(Repository, "Menu");
                        }
                        );
                }
                return backMenuCommand;
            }
        }

        #endregion


        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
