﻿using MentalToHell.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.Reports
{
    public class PartyTime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Дата:")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name = "Событие:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string Name { get; set; }

        [Required]
        public int? ApplicationUserId { get; set; }
        public virtual List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
