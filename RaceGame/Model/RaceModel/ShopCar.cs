using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.RaceModel
{
    public class ShopCar: INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        private string imagePath { get; set; }

        public virtual ICollection<PlayerCar> PlayerCars { get; set; }


        public string ImagePath
        {
            get
            {
                return System.IO.Path.GetFullPath(imagePath);
            }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public ShopCar()
        {
            PlayerCars = new List<PlayerCar>();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
