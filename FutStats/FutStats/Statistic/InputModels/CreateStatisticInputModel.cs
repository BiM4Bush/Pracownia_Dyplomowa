using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FutStats.Api.Statistic.InputModels
{
    public class CreateStatisticInputModel
    {
        [Required] public int Goals { get; set; }
        [Required] public int Assists { get; set; }
        [Required] public int YellowCards { get; set; }
        [Required] public int RedCards { get; set; }
    }
}
