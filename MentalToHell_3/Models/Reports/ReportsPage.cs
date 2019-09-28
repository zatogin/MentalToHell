using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models.Reports
{
    public class ReportsPage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public int? ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        [Required]
        [Display(Name = "Хобби:")]
        public int? HobbyId { get; set; }
        public virtual Hobby Hobby { get; set; }

        [Required]
        [Display(Name = "Мотивация:")]
        public int? MotivationId { get; set; }
        public virtual Motivation Motivation { get; set; }

        [Required]
        [Display(Name = "Время веселья:")]
        public int? PartyId { get; set; }
        public virtual PartyTime PartyTime { get; set; }

        [Required]
        [Display(Name = "Отчет:")]
        public int? ReportId { get; set; }
        public virtual Report Report { get; set; }
    }
}
