using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models.Reports
{
    public class PartyTime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUsers { get; set; }

        [Required]
        [Display(Name = "Событие:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string PartyName { get; set; }

        [Required]
        [Display(Name = "Дата:")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        public virtual List<ReportsPage> ReportsPages { get; set; }
    }
}
