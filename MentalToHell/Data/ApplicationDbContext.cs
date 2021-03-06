﻿using System;
using System.Collections.Generic;
using System.Text;
using MentalToHell.Models.misc;
using MentalToHell.Models.RelationAndAchive;
using MentalToHell.Models.Reports;
using MentalToHell.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MentalToHell.Models.WhatTo;

namespace MentalToHell.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CurrentStatus> CurrentStatuses { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<PersonalLyfeJoy> PersonalLyfeJoys { get; set; }
        public DbSet<JobSatisfaction> JobSatisfactions { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Temperament> Temperaments { get; set; }
        public DbSet<UserPersonalState> UserPersonalStates { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Motivation> Motivations { get; set; }
        public DbSet<PartyTime> PartyTimes { get; set; }
        public DbSet<ReportMood> ReportMoods { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PersonalRelationDay> PersonalRelationDays { get; set; }
        public DbSet<PersonalRelationWeek> PersonalRelationWeeks { get; set; }
        public DbSet<PersonalRelationMonth> PersonalRelationMonths { get; set; }
        public DbSet<PersonalRelationYear> PersonalRelationYears { get; set; }
        public DbSet<MentalToHell.Models.WhatTo.ToThinkAbout> ToThinkAbout { get; set; }
        public DbSet<MentalToHell.Models.WhatTo.WhatToRead> WhatToRead { get; set; }
        public DbSet<MentalToHell.Models.WhatTo.WhatToStatus> WhatToStatus { get; set; }
        public DbSet<MentalToHell.Models.WhatTo.WhatToTaste> WhatToTaste { get; set; }
        public DbSet<MentalToHell.Models.WhatTo.WhatToWatch> WhatToWatch { get; set; }
        public DbSet<MentalToHell.Models.WhatTo.WhereToBe> WhereToBe { get; set; }
        public DbSet<InfoTable> InfoTables { get; set; }
    }
}