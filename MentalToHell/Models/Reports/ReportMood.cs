using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.Reports
{
    public class ReportMood
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Настроение:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string MoodName { get; set; }

        public virtual List<Report> Reports { get; set; }
    }
}
