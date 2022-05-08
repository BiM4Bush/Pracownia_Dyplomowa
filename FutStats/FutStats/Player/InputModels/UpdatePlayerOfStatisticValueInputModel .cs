using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutStats.Api.Player.InputModels
{
    public class UpdatePlayerOfStatisticValueInputModel
    {
        [Required] public Guid StatisticId { get; set; }
        [Required] public Guid PlayerId { get; set; }
    }
}
