using FutStats.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutStats.Api.Player.ResultModels
{
    public class PlayersResultModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int KitNumber { get; set; }
        public Positions Position { get; set; }
    }
}
