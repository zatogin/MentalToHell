using MentalToHell.Models.Reports;
using MentalToHell.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.RelationAndAchive
{
    public class PersonalRelationDay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Дата:")]
        [DataType(DataType.DateTime)]
        public DateTime Day { get; set; }

        [Required]
        [Display(Name ="Настроение:")]
        public int Mood { get; set; }
        public virtual ReportMood ReportMood { get; set; }

        [Required]
        [Display(Name = "Ключевая фраза:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string RelationLink { get; set; }

        [Required]
        [Display(Name = "Ваше отношению к этому дню:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string PersonalRelation { get; set; }
    }
}
