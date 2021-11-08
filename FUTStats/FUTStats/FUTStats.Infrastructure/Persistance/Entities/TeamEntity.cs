using System;
using System.Collections.Generic;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Entities
{
    public class TeamEntity
    {
        public Guid Id { get; set; }
        public PlayerEntity? Player1Entity { get; set; }
        public PlayerEntity? Player2Entity { get; set; }
        public PlayerEntity? Player3Entity { get; set; }
        public PlayerEntity? Player4Entity { get; set; }
        public PlayerEntity? Player5Entity { get; set; }
        public PlayerEntity? Player6Entity { get; set; }
        public PlayerEntity? Player7Entity { get; set; }
        public PlayerEntity? Player8Entity { get; set; }
        public PlayerEntity? Player9Entity { get; set; }
        public PlayerEntity? Player10Entity { get; set; }
        public PlayerEntity? Player11Entity { get; set; }
        public CoachEntity? CoachEntity { get; set; }
    }
}
