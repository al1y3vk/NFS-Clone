using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.RaceModel
{
    public class PlayerCar:INotifyPropertyChanged
    {
        public int Id { get; set; }

        private int engineLevel;
        public int EngineLevel
        {
            get
            {
                return engineLevel;
            }
            set
            {
                engineLevel = value;
                OnPropertyChanged("EngineLevel");
            }
        }

        private int clutchLevel;
        public int ClutchLevel
        {
            get
            {
                return clutchLevel;
            }
            set
            {
                clutchLevel = value;
                OnPropertyChanged("ClutchLevel");
            }
        }

        private int transmissionLevel;
        public int TransmissionLevel
        {
            get
            {
                return transmissionLevel;
            }
            set
            {
                transmissionLevel = value;
                OnPropertyChanged("TransmissionLevel");
            }
        }

        private int fuelCapacityLevel;
        public int FuelCapacityLevel
        {
            get
            {
                return fuelCapacityLevel;
            }
            set
            {
                fuelCapacityLevel = value;
                OnPropertyChanged("FuelCapacityLevel");
            }
        }

        private string color;
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }


        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int ShopCarId { get; set; }
        public virtual ShopCar ShopCar { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
