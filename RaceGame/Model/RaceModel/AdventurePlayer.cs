using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.RaceModel
{
    public class AdventurePlayer
    {
        public int Id { get; set; }

        public float Distance { get; set; }
        public int GainedCoins { get; set; }

        public int AdventureId { get; set; }
        public virtual Adventure Adventure { get; set; }

        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}
