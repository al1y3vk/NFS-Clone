using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using HomeWork5.RaceModel;

namespace RaceGame
{
    public class GarageViewModel: INotifyPropertyChanged
    {

        #region Fields

        IPageView View;
        public RaceGameRepository Repository;
        public Player Player { get; set; }
        public ShopCar shopCar;
        public PlayerCar playerCar;
        private string shopCarPrice;
        private int engineUpgradePrice;
        private int clutchUpgradePrice;
        private int transmissionUpgradePrice;
        private int fuelCapacityUpgradePrice;
        public string CoinImagePath { get; set; }
        public List<string> CarColor { get; set; }
        public List<PlayerCar> playerCars { get; set; }
        public List<ShopCar> shopCars { get; set; }

        private RelayCommand nextPlayerCarCommand;
        private RelayCommand prevPlayerCarCommand;
        private RelayCommand nextShopCarCommand;
        private RelayCommand prevShopCarCommand;
        private RelayCommand backPlayerInterfaceCommand;
        private RelayCommand buyShopCarCommand;
        private RelayCommand engineUpgradeLevelCommand;
        private RelayCommand clutchUpgradeLevelCommand;
        private RelayCommand transmissionUpgradeLevelCommand;
        private RelayCommand fuelCapacityUpgradeLevelCommand;
        private RelayCommand prevCarColorCommand;
        private RelayCommand nextCarColorCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public GarageViewModel(IPageView view, RaceGameRepository repository)
        {
            this.View = view;
            this.Repository = repository;
            Player = Repository.CurrentPlayer;
            CoinImagePath = System.IO.Path.GetFullPath("..\\..\\..\\images\\icons\\coin.png");
            CarColor = new List<string>() { "Black", "White", "Grey", "Yellow", "Red", "Blue", "Purple" };
            shopCars = Repository.GetAllShopCars().ToList();
            playerCars = Player.PlayerCars.ToList();
            ShopCarPrice = "Bought";
            ShopCar = shopCars[0];
            PlayerCar = Repository.CurrentCar;
            EngineUpgradePrice = PlayerCar.EngineLevel * 1000 * 2;
            ClutchUpgradePrice = PlayerCar.ClutchLevel * 1000 * 2;
            TransmissionUpgradePrice = PlayerCar.TransmissionLevel * 1000 * 2;
            FuelCapacityUpgradePrice = PlayerCar.FuelCapacityLevel * 1000 * 2;

        }

        #region Properties / Commands

        public ShopCar ShopCar
        {
            get
            {
                return shopCar;
            }
            set
            {
                shopCar = value;
                OnPropertyChanged("ShopCar");
            }
        }

        public PlayerCar PlayerCar
        {
            get
            {
                return playerCar;
            }
            set
            {
                playerCar = value;
                OnPropertyChanged("PlayerCar");
            }
        }

        public string ShopCarPrice
        {
            get
            {
                return shopCarPrice;
            }
            set
            {
                shopCarPrice = value;
                OnPropertyChanged("ShopCarPrice");
            }
        }

        public int EngineUpgradePrice
        {
            get
            {
                return engineUpgradePrice;
            }
            set
            {
                engineUpgradePrice = value;
                OnPropertyChanged("EngineUpgradePrice");
            }
        }

        public int ClutchUpgradePrice
        {
            get
            {
                return clutchUpgradePrice;
            }
            set
            {
                clutchUpgradePrice = value;
                OnPropertyChanged("ClutchUpgradePrice");
            }
        }

        public int TransmissionUpgradePrice
        {
            get
            {
                return transmissionUpgradePrice;
            }
            set
            {
                transmissionUpgradePrice = value;
                OnPropertyChanged("TransmissionUpgradePrice");
            }
        }

        public int FuelCapacityUpgradePrice
        {
            get
            {
                return fuelCapacityUpgradePrice;
            }
            set
            {
                fuelCapacityUpgradePrice = value;
                OnPropertyChanged("FuelCapacityUpgradePrice");
            }
        }

        public RelayCommand NextPlayerCarCommand
        {
            get
            {
                if (nextPlayerCarCommand is null)
                {
                    return nextPlayerCarCommand = new RelayCommand
                    (
                        ChangeNextPlayerCar,
                        (param) =>
                        {
                            return playerCars.IndexOf(PlayerCar) + 1 != playerCars.Count;
                        }
                        );
                }
                return nextPlayerCarCommand;
            }
        }

        public RelayCommand PrevPlayerCarCommand
        {
            get
            {
                if (prevPlayerCarCommand is null)
                {
                    return prevPlayerCarCommand = new RelayCommand
                    (
                        ChangePrevPlayerCar,
                        (param) =>
                        {
                            return playerCars.IndexOf(PlayerCar) - 1 >= 0;
                        }
                        );
                }
                return prevPlayerCarCommand;
            }
        }

        public RelayCommand NextShopCarCommand
        {
            get
            {
                if (nextShopCarCommand is null)
                {
                    return nextShopCarCommand = new RelayCommand
                    (
                        ChangeNextShopCar,
                        (param) =>
                        {
                            return shopCars.IndexOf(ShopCar) + 1 != shopCars.Count;
                        }
                        );
                }
                return nextShopCarCommand;
            }
        }

        public RelayCommand PrevShopCarCommand
        {
            get
            {
                if (prevShopCarCommand is null)
                {
                    return prevShopCarCommand = new RelayCommand
                    (
                        ChangePrevShopCar,
                        (param) =>
                        {
                            return shopCars.IndexOf(ShopCar) - 1 >= 0;
                        }
                        );
                }
                return prevShopCarCommand;
            }
        }

        public RelayCommand BackPlayerInterfaceCommand
        {
            get
            {
                if (backPlayerInterfaceCommand is null)
                {
                    return backPlayerInterfaceCommand = new RelayCommand
                    (
                        (param) =>
                        {
                            View.Navigate(Repository, "PlayerInterface");
                        }
                        );
                }
                return backPlayerInterfaceCommand;
            }
        }

        public RelayCommand BuyShopCarCommand
        {
            get
            {
                if (buyShopCarCommand is null)
                {
                    return buyShopCarCommand = new RelayCommand
                    (
                        BuyShopCar,
                        (param) =>
                        {
                            return !Player.PlayerCars.Any(r => r.ShopCar == ShopCar) && Player.Coins >= ShopCar.Price;
                        }
                        );
                }
                return buyShopCarCommand;
            }
        }

        public RelayCommand EngineUpgradeLevelCommand
        {
            get
            {
                if (engineUpgradeLevelCommand is null)
                {
                    return engineUpgradeLevelCommand = new RelayCommand
                    (
                        UpgradeEngineLevel,
                        (param) =>
                        {
                            return Player.Coins >= EngineUpgradePrice;
                        }
                        );
                }
                return engineUpgradeLevelCommand;
            }
        }

        public RelayCommand ClutchUpgradeLevelCommand
        {
            get
            {
                if (clutchUpgradeLevelCommand is null)
                {
                    return clutchUpgradeLevelCommand = new RelayCommand
                    (
                        UpgradeClutchLevel,
                        (param) =>
                        {
                            return Player.Coins >= ClutchUpgradePrice;
                        }
                        );
                }
                return clutchUpgradeLevelCommand;
            }
        }

        public RelayCommand TransmissionUpgradeLevelCommand
        {
            get
            {
                if (transmissionUpgradeLevelCommand is null)
                {
                    return transmissionUpgradeLevelCommand = new RelayCommand
                    (
                        UpgradeTransmissionLevel,
                        (param) =>
                        {
                            return Player.Coins >= TransmissionUpgradePrice;
                        }
                        );
                }
                return transmissionUpgradeLevelCommand;
            }
        }

        public RelayCommand FuelCapacityUpgradeLevelCommand
        {
            get
            {
                if (fuelCapacityUpgradeLevelCommand is null)
                {
                    return fuelCapacityUpgradeLevelCommand = new RelayCommand
                    (
                        UpgradeFuelCapacityLevel,
                        (param) =>
                        {
                            return Player.Coins >= FuelCapacityUpgradePrice;
                        }
                        );
                }
                return fuelCapacityUpgradeLevelCommand;
            }
        }

        public RelayCommand NextCarColorCommand
        {
            get
            {
                if (nextCarColorCommand is null)
                {
                    return nextCarColorCommand = new RelayCommand
                    (
                        ChangeNextCarColor,
                        (param) =>
                        {
                            return CarColor.IndexOf(PlayerCar.Color) + 1 != CarColor.Count;
                        }
                        );
                }
                return nextCarColorCommand;
            }
        }

        public RelayCommand PrevCarColorCommand
        {
            get
            {
                if (prevCarColorCommand is null)
                {
                    return prevCarColorCommand = new RelayCommand
                    (
                        ChangePrevCarColor,
                        (param) =>
                        {
                            return CarColor.IndexOf(PlayerCar.Color) - 1 >= 0;
                        }
                        );
                }
                return prevCarColorCommand;
            }
        }

        #endregion

        #region Methods

        private void ChangeNextPlayerCar(object param)
        {
            PlayerCar = playerCars[playerCars.IndexOf(PlayerCar) + 1];
            Repository.CurrentCar = PlayerCar;
        }

        private void ChangePrevPlayerCar(object param)
        {
            PlayerCar = playerCars[playerCars.IndexOf(PlayerCar) - 1];
            Repository.CurrentCar = PlayerCar;
        }

        private void ChangeNextShopCar(object param)
        {
            ShopCar = shopCars[shopCars.IndexOf(ShopCar) + 1];
            if (Player.PlayerCars.Any(r => r.ShopCar == ShopCar))
            {
                ShopCarPrice = "Bought";
            }
            else
            {
                ShopCarPrice = ShopCar.Price.ToString();
            }
        }

        private void ChangePrevShopCar(object param)
        {
            ShopCar = shopCars[shopCars.IndexOf(ShopCar) - 1];
            if (Player.PlayerCars.Any(r => r.ShopCar == ShopCar))
            {
                ShopCarPrice = "Bought";
            }
            else
            {
                ShopCarPrice = ShopCar.Price.ToString();
            }
        }

        private void BuyShopCar(object param)
        {
            Player.Coins -= ShopCar.Price;
            Repository.AddCarToPlayer(Player, ShopCar);
            Repository.SaveChanges();
            playerCars = Player.PlayerCars.ToList();
            ShopCarPrice = $"Bought";
        }

        private void UpgradeEngineLevel(object param)
        {
            Player.Coins -= EngineUpgradePrice;
            PlayerCar.EngineLevel += 1;
            Repository.SaveChanges();
            EngineUpgradePrice = PlayerCar.EngineLevel * 1000 * 2;
        }

        private void UpgradeClutchLevel(object param)
        {
            Player.Coins -= ClutchUpgradePrice;
            PlayerCar.ClutchLevel += 1;
            Repository.SaveChanges();
            ClutchUpgradePrice = PlayerCar.ClutchLevel * 1000 * 2;
        }

        private void UpgradeTransmissionLevel(object param)
        {
            Player.Coins -= TransmissionUpgradePrice;
            PlayerCar.TransmissionLevel += 1;
            Repository.SaveChanges();
            TransmissionUpgradePrice = PlayerCar.TransmissionLevel * 1000 * 2;
        }

        private void UpgradeFuelCapacityLevel(object param)
        {
            Player.Coins -= FuelCapacityUpgradePrice;
            PlayerCar.FuelCapacityLevel += 1;
            Repository.SaveChanges();
            FuelCapacityUpgradePrice = PlayerCar.FuelCapacityLevel * 1000 * 2;
        }

        private void ChangeNextCarColor(object param)
        {
            PlayerCar.Color = CarColor[CarColor.IndexOf(PlayerCar.Color) + 1];
            Repository.SaveChanges();
        }

        private void ChangePrevCarColor(object param)
        {
            PlayerCar.Color = CarColor[CarColor.IndexOf(PlayerCar.Color) - 1];
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
