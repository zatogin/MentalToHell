using MentalToHell.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.misc
{
    public class CurrentStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "CurrentStatus")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string StatusName { get; set; }

        public virtual List<JobSatisfaction> JobSatisfactions { get; set; }
        public virtual List<PersonalLyfeJoy> PersonalLyfeJoys { get; set; }
    }
}
