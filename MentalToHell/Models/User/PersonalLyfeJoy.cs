using MentalToHell.Models.misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.User
{
    public class PersonalLyfeJoy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Опишите, что вам нравится в вашей жизни:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string LifeJoyExpl { get; set; }

        [Required]
        public int CurrentStatusId { get; set; }
        public virtual CurrentStatus CurrentStatus { get; set; }

        public virtual List<UserPersonalState> UserPersonalStates { get; set; }
    }
}
