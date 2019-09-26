using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models.Users
{
    public class JobSatisfaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        [Required]
        [Display(Name = "Опишите удовлетворенность своей работой:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string JobSatisfactionText { get; set; }

        [Required]
        [Display(Name ="Дата:")]
        [DataType(DataType.DateTime)]
        public string JobDate { get; set; }
    }
}
