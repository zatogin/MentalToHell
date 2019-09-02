using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.User
{
    public class UserPersonalState
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? SexId { get; set; }
        public virtual Sex Sex { get; set; }

        [Required]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        [Required]
        public int? PersonalLyfeJoyId { get; set; }
        public virtual PersonalLyfeJoy PersonalLyfeJoy { get; set; }

        [Required]
        [Display(Name = "Должность:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string JobPosition { get; set; }

        [Required]
        [Display(Name = "Место работы:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string JobPlace { get; set; }

        [Required]
        public int? JobSatisfactionId { get; set; }
        public virtual JobSatisfaction JobSatisfaction { get; set; }

        [Required]
        public int? ReligionId { get; set; }
        public virtual Religion Religion { get; set; }

        [Required]
        [Display(Name = "День рожденья:")]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        [Required]
        [Display(Name = "Отношение к жизни:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string AttitudeToLife { get; set; }

        [Required]
        [Display(Name = "Кредо:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string Credo { get; set; }

        [Required]
        [Display(Name = "Ваш характер:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string Character { get; set; }

        [Required]
        public int? TemperamentId { get; set; }
        public virtual Temperament Temperament { get; set; }

        [Required]
        public int? ApplicationUserId { get; set; }
        public virtual List<ApplicationUser> ApplicationUsers { get; set; }

    }
}
