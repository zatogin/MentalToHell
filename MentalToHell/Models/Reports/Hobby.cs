using MentalToHell.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.Reports
{
    public class Hobby
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hobby specialization:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string HobbySpec { get; set; }

        [Required]
        [Display(Name = "Hobby name:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string HobbyName { get; set; }

        [Required]
        public int? ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }
    }
}