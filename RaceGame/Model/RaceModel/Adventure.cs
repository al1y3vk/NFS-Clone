using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5.RaceModel
{
    public class Adventure
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int RoadId { get; set; }
        public virtual Road Road { get; set; }

        public virtual ICollection<AdventurePlayer> Adventures { get; set; }

        public Adventure()
        {
            Adventures = new List<AdventurePlayer>();
        }
    }
}
