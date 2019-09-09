using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.WhatTo
{
    public class WhatToStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Status:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string WhatStatus { get; set; }

        public virtual List<ToThinkAbout> ToThinkAbouts { get; set; }
        public virtual List<WhatToRead> WhatToReads { get; set; }
        public virtual List<WhatToTaste> WhatToTastes { get; set; }
        public virtual List<WhatToWatch> WhatToWatches { get; set; }
        public virtual List<WhereToBe> WhereToBes { get; set; }
    }
}
