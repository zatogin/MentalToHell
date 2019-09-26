using System;
using System.Collections.Generic;
using System.Text;
using MentalToHell_3.Models;
using MentalToHell_3.Models.Users;
using MentalToHell_3.Models.Users.Misc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MentalToHell_3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //ToUser
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Temperament> Temperaments { get; set; }
        public DbSet<UserState> UserStates { get; set; }
        public DbSet<JobSatisfaction> JobSatisfactions { get; set; }
        public DbSet<LifeJoy> LifeJoys { get; set; }
        public DbSet<MentalToHell_3.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}