using MentalToHell.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.WhatTo
{
    public class WhatToRead
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Пользователь:")]
        public int UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Что почитать:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string ToRead { get; set; }

        [Required]
        public int StatusId { get; set; }
        public virtual WhatToStatus WhatToStatus { get; set; }
    }
}
