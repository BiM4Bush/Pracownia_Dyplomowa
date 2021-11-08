using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Entities
{
    public class CoachEntity
    {
        public Guid Id { get; set; }

        [MinLength(2, ErrorMessage = "Wrong name format")]
        [MaxLength(50, ErrorMessage = "Wrong name format")]
        [RegularExpression(@"^[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćąśęłóń]*$", ErrorMessage = "Wrong name format")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "Wrong surname format")]
        [MaxLength(50, ErrorMessage = "Wrong surname format")]
        [RegularExpression(@"^[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćąśęłóń]*$", ErrorMessage = "Wrong surname format")]
        public string Surname { get; set; }

        public enum EnumNationality {  Argentina, Brazil, Spain, France, Netherlands, Germany, England, Portugal, Croatia, Poland, Italy, Belgium, Urugway, Columbia, Denmark }

        public EnumNationality Nationality { get; set; }
        public Guid TeamId { get; set; }
        public TeamEntity Team { get; set; }


    }
}
