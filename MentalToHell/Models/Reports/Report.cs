using MentalToHell.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.Reports
{
    public class Report
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Дата отчета")]
        [DataType(DataType.DateTime)]
        public DateTime Day { get; set; }

        [Required]
        [Display(Name = "Заголовок")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Настрой")]
        public int ReportMoodId { get; set; }
        public virtual ReportMood  ReportMood { get; set; }        

        [Required]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)]
        [StringLength(256)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Полное содержание")]
        [StringLength(1024)]
        public string Content { get; set; }

        [Display(Name = "Иллюстрация 1")]
        [DataType(DataType.ImageUrl)]
        [StringLength(256)]
        public string Image1 { get; set; }

        [Display(Name = "Иллюстрация 2")]
        [DataType(DataType.ImageUrl)]
        [StringLength(256)]
        public string Image2 { get; set; }

        [Display(Name = "Иллюстрация 3")]
        [DataType(DataType.ImageUrl)]
        [StringLength(256)]
        public string Image3 { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
