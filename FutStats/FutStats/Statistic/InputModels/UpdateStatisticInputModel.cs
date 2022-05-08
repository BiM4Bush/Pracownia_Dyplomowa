using System;
using System.ComponentModel.DataAnnotations;

namespace FutStats.Api.Statistic.InputModels
{
    public class UpdateStatisticInputModel
    {
        [Required] public Guid StatisticId { get; set; }
        public int? Goals { get; set; }

        public int? Assists { get; set; }

        public int? YellowCards { get; set; }

        public int? RedCards { get; set; }

    }
}
