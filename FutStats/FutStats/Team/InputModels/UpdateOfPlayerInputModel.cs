using System;
using System.ComponentModel.DataAnnotations;

namespace FutStats.Api.Team.InputModels
{
    public class UpdateOfPlayerInputModel
    {
        [Required] public Guid TeamId { get; set; }
        [Required] public Guid PlayerId { get; set; }
        [Required] public string PlayerName { get; set; }
        [Required] public string PlayerSurname { get; set; }
    }
}
