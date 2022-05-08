using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Domain.Entities
{
    public class TeamEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlayerEntity>? Players { get; set; }

        public CoachEntity? Coach { get; set; }

        public int Week { get; set; }
    }
}
