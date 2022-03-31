using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.RaceModel
{
    public class RacePlayer
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public int RaceId { get; set; }
        public Race Race { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
