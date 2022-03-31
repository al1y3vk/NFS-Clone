using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.RaceModel
{
    public class Race
    {
        public int Id { get; set; }
        public DateTime Date {get;set;}

        public int RoadId { get; set; }
        public virtual Road Road { get; set; }

        public virtual ICollection<RacePlayer> RacesPlayers { get; set; }
        public Race()
        {
            RacesPlayers = new List<RacePlayer>();
        }
    }
}
