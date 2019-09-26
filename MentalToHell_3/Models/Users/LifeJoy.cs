using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models.Users
{
    public class LifeJoy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        [Required]
        [Display(Name = "Опишите, что вам нравится в вашей жизни:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string LifeJoyExpl { get; set; }

        [Required]
        [Display(Name = "Дата:")]
        [DataType(DataType.DateTime)]
        public string JobDate { get; set; }
    }
}
