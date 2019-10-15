using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHellFinal.Models.CustomUser.MISC
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Гендер")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string GenderName { get; set; }

        public virtual List<UserCurrentState> UserCurrentStates { get; set; }
    }
}
