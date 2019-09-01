using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.User
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

        public virtual List<UserPersonalState> UserPersonalStates { get; set; }
    }
}
