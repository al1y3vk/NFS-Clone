using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using HomeWork5.RaceModel;

namespace RaceGame
{
    public class PlayerCreationViewModel
    {
        #region Fields

        IPageView View;
        public RaceGameRepository Repository;
        private string playerName;

        private RelayCommand backToMenuCommand;
        private RelayCommand startGameCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public PlayerCreationViewModel(IPageView view, RaceGameRepository repository)
        {
            this.View = view;
            this.Repository = repository;
        }

        #region Properties / Commands

        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
                OnPropertyChanged("PlayerName");
            }
        }

        public RelayCommand BackToMenuCommand
        {
            get
            {
                if (backToMenuCommand is null)
                {
                    return backToMenuCommand = new RelayCommand(
                        (param) =>
                        {
                            View.Navigate(Repository, "Menu");
                        }

                        );
                }
                return backToMenuCommand;
            }
        }

        public RelayCommand StartGameCommand
        {
            get
            {
                if (startGameCommand is null)
                {
                    return startGameCommand = new RelayCommand(
                        StartGameExecute,
                        (param) =>
                        {
                            return !String.IsNullOrWhiteSpace(PlayerName) && PlayerName.Length > 3;
                        }

                        );
                }
                return startGameCommand;
            }
        }

        #endregion

        #region Methods

        private void StartGameExecute(object param)
        {
            if (Repository.GetAllPlayers().Any(p => p.Name == PlayerName))
            {
                View.ShowMessage("Current name is busy.Choose another name");
                return;
            }
            Player newPlayer = Repository.AddNewPlayer(PlayerName);
            PlayerCar newCar = newPlayer.PlayerCars.First();
            Repository.SaveChanges();
            Repository.CurrentPlayer = newPlayer;
            Repository.CurrentCar = newCar;

            View.Navigate(Repository, "PlayerInterface");
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

    }
}
