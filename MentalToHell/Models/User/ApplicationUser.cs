﻿using MentalToHell.Models.RelationAndAchive;
using MentalToHell.Models.Reports;
using MentalToHell.Models.WhatTo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }

        [Required]
        public int UserPersonalStateId { get; set; }
        public virtual UserPersonalState UserPersonalState { get; set; }

        public virtual List<Hobby> Hobbies { get; set; }
        public virtual List<Motivation> Motivations { get; set; }
        public virtual List<Report> Reports { get; set; }
        public virtual List<PersonalRelationDay> PersonalRelationDays { get; set; }
        public virtual List<PersonalRelationWeek> PersonalRelationWeeks { get; set; }
        public virtual List<PersonalRelationMonth> PersonalRelationMonths { get; set; }
        public virtual List<PersonalRelationYear> PersonalRelationYears { get; set; }
        public virtual List<ToThinkAbout> ToThinkAbouts { get; set; }
        public virtual List<WhatToRead> WhatToReads { get; set; }
        public virtual List<WhatToTaste> WhatToTastes { get; set; }
        public virtual List<WhatToWatch> WhatToWatches { get; set; }
        public virtual List<WhereToBe> WhereToBes { get; set; }
    }
}