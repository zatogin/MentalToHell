using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models.Reports
{
    public class Hobby
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        [Required]
        [Display(Name = "Хобби:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string HobbyName { get; set; }

        public virtual List<ReportsPage> ReportsPages { get; set; }
    }
}
