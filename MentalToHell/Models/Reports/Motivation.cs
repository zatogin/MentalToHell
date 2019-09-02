using MentalToHell.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.Reports
{
    public class Motivation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Дата:")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Мотивация:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string MotivationText { get; set; }

        [Required]
        public int? ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }
    }
}
