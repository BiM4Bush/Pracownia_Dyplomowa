using FutStats.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutStats.Api.Player.InputModels
{
    public class CreatePlayerInputModel
    {
        [Required] public string Name { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public int KitNumber { get; set; }
        [Required] public Positions Position { get; set; }
    }
}
