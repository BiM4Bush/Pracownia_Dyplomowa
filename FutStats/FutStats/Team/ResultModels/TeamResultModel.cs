using System.Collections.Generic;
using FutStats.Domain.Enums;

namespace FutStats.Api.Team.ResultModels
{
    public class TeamResultModel
    {
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }
        public string CoachName { get; set; }
        public string CoachSurname { get; set; }
        public int Week { get; set; }
        public class Player
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int KitNumber { get; set; }
            public Positions Position { get; set; }
        }
    }
}
