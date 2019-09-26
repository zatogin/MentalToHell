using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models.Users.Misc
{
    public class Sex
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пол")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string SexName { get; set; }

        public virtual List<UserState> UserStates { get; set; }
    }
}
