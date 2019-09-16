using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.WhatTo
{
    public class InfoTable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Link:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string IfoItem { get; set; }

        [Required]
        [Display(Name = "Name:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string IfoName { get; set; }
    }
}
