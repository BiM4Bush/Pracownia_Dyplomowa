using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FUTStats.Infrastructure.Persistance.Entities
{
    public class PlayerEntity
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
        [Range(0, 99, ErrorMessage = "Kit number out of range")]
        public int KitNumber { get; set; }
        public enum EnumPosition { GK, RWB, RB, CB, LB, LWB, CDM, CM, CAM, LM, LW, LF, RM, RW, RF, CF, ST }
        public EnumPosition Position { get; set; }
        public StatisticEntity? StatisticEntity { get; set; }
        public Guid TeamId { get; set; }
        public TeamEntity Team { get; set; }


    }
}
