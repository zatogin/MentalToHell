﻿using MentalToHell.Models.misc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.User
{
    public class JobSatisfaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Опишите удовлетворенность своей работой:")]
        [DataType(DataType.Text)]
        [StringLength(1000)]
        public string JobSatisfactionText { get; set; }

        [Required]
        public int CurrentStatusId { get; set; }
        public virtual CurrentStatus CurrentStatus { get; set; }

        public virtual List<UserPersonalState> UserPersonalStates { get; set; }
    }
}
