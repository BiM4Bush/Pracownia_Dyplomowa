using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Entities
{
    public class StatisticEntity
    {
        public Guid Id { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
#nullable enable
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public Guid PlayerId { get; set; }
        public PlayerEntity Player { get; set; }
    }
}
