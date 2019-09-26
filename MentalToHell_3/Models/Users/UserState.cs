using MentalToHell_3.Models.Users.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models.Users
{
    public class UserState
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        [Required]
        [Display(Name = "Пол:")]
        public int? SexId { get; set; }
        public virtual Sex Sex { get; set; }

        [Required]
        [Display(Name = "Гендер:")]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        [Required]
        [Display(Name = "Ваш темперамент:")]
        public int? TemperamentId { get; set; }
        public virtual Temperament Temperament { get; set; }

        [Required]
        [Display(Name = "Кредо:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string Credo { get; set; }

        [Required]
        [Display(Name = "Какой вы человек:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string Character { get; set; }

        [Required]
        [Display(Name = "Ваша религия:")]
        public int? ReligionId { get; set; }
        public virtual Religion Religion { get; set; }

        [Required]
        [Display(Name = "День рожденья:")]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }
    }
}
