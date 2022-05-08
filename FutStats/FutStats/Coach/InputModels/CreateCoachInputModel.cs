using FutStats.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutStats.Api.Coach.InputModels
{
    public class CreateCoachInputModel
    {
        [Required] public string Name { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public Nationalities Nationality { get; set; }

    }
}
