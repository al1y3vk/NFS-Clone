using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.RaceModel
{
    public class Player : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name;
        private int coins;
        private int level { get; set; }

        public virtual ICollection<RacePlayer> RacesPlayers { get; set; }
        public virtual ICollection<AdventurePlayer> Adventures { get; set; }
        public virtual ICollection<PlayerCar> PlayerCars { get; set; }
        public virtual ICollection<Road> Roads { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Coins
        {
            get
            {
                return coins;
            }
            set
            {
                coins = value;
                OnPropertyChanged("Coins");
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                OnPropertyChanged("Level");
            }
        }



        public Player()
        {
            RacesPlayers = new List<RacePlayer>();
            Adventures = new List<AdventurePlayer>();
            PlayerCars = new List<PlayerCar>();
            Roads = new List<Road>();
        }

        public override string ToString()
        {
            return $"{Id}.{Name} Coins:{Coins} Level:{Level}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
