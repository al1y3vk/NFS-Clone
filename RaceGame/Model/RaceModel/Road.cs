using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.RaceModel
{
    public class Road : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name { get; set; }
        private double distance { get; set; }
        public int Price { get; set; }
        private string imagePath { get; set; }
        public virtual ICollection<Adventure> Adventures { get; set; }
        public virtual ICollection<Race> Races { get; set; }
        public virtual ICollection<Player> Players { get; set; }


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

        public double Distance
        {
            get
            {
                return distance;
            }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

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


        public Road()
        {
            Adventures = new List<Adventure>();
            Races = new List<Race>();
            Players = new List<Player>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
