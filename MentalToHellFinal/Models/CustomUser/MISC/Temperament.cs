using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHellFinal.Models.CustomUser.MISC
{
    public class Temperament
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Темперамент:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string TemperamentName { get; set; }

        public virtual List<UserCurrentState> UserCurrentStates { get; set; }
    }
}
