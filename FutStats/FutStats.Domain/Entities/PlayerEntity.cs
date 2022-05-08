using FutStats.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Domain.Entities
{
    public class PlayerEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
 
        public int KitNumber { get; set; }
 
        public Positions Position { get; set; }

        public Guid? StatisticEntityId { get; set; }
        public StatisticEntity? StatisticEntity { get; set; }
        
        public Guid? TeamId { get; set; }
        
        public TeamEntity? Team { get; set; }
    }
}
