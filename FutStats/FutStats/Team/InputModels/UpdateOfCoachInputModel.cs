using System;
using System.ComponentModel.DataAnnotations;

namespace FutStats.Api.Team.InputModels
{
    public class UpdateOfCoachInputModel
    {
        [Required] public Guid TeamId { get; set; }
        [Required] public Guid CoachId { get; set; }
        [Required] public string CoachName { get; set; }
        [Required] public string CoachSurname { get; set; }
    }
}
