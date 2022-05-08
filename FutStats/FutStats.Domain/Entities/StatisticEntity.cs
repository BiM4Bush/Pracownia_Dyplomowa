using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Domain.Entities
{
    public class StatisticEntity
    {
        public Guid Id { get; set; }

        public int Goals { get; set; }
        
        public int Assists { get; set; }

        public int YellowCards { get; set; }
        
        public int RedCards { get; set; }
        
        public Guid? PlayerId { get; set; }
        
        public PlayerEntity? Player { get; set; }
    }
}
