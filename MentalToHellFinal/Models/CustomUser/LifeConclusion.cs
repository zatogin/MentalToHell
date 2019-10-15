using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHellFinal.Models.CustomUser
{
    public class LifeConclusion
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
        public string LifeConclusionHead { get; set; }

        [Required]
        [Display(Name = "Опишите, что вам нравится в вашей жизни:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string LifeConExpl { get; set; }

        [Required]
        [Display(Name = "Дата:")]
        [DataType(DataType.DateTime)]
        public string LifeConDate { get; set; }
    }
}
