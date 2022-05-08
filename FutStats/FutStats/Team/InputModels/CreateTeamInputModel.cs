using System.ComponentModel.DataAnnotations;

namespace FutStats.Api.Team.InputModels
{
    public class CreateTeamInputModel
    {
        [Required] public string Name { get; set; }
        [Required] public int Week { get; set; }
    }
}
