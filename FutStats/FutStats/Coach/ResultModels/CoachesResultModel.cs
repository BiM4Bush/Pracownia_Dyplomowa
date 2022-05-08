using FutStats.Domain.Entities;
using FutStats.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutStats.Api.Coach.ResultModels
{
    public class CoachesResultModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Nationalities Nationality { get; set; }
    }
}
