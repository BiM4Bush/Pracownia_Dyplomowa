using FutStats.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutStats.Domain.Entities
{
    public class CoachEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Nationalities Nationality { get; set; }

        public Guid? TeamId { get; set; }

        public TeamEntity? Team { get; set; }
    }
}
