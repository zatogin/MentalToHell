using MentalToHell.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.RelationAndAchive
{
    public class RelationPeriod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Начальная Дата:")]
        [DataType(DataType.DateTime)]
        public DateTime Year { get; set; }

        [Required]
        [Display(Name = "Конечная Дата:")]
        [DataType(DataType.DateTime)]
        public DateTime YearA { get; set; }

        [Required]
        [Display(Name = "Настроение:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string RelationLink { get; set; }

        [Required]
        [Display(Name = "Фраза года:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string YearPhraze { get; set; }

        [Required]
        [Display(Name = "Ваше отношению к этому гду:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string PersonalRelationY { get; set; }
        
    }
}
