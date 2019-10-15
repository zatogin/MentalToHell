using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHellFinal.Models.CustomUser
{
    public class JobConclusion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        [Required]
        [Display(Name = "Заголовок:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string JobConclusionHead { get; set; }

        [Required]
        [Display(Name = "Опишите удовлетворенность своей работой:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string JobSatisfactionText { get; set; }

        [Required]
        [Display(Name = "Дата:")]
        [DataType(DataType.DateTime)]
        public string JobDate { get; set; }
    }
}
