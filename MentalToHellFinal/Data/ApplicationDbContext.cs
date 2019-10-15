using System;
using System.Collections.Generic;
using System.Text;
using MentalToHellFinal.Models.CustomUser;
using MentalToHellFinal.Models.CustomUser.MISC;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MentalToHellFinal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //User
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Temperament> Temperaments { get; set; }
        public DbSet<UserCurrentState> UserCurrentStates { get; set; }
        public DbSet<LifeConclusion> LifeConclusions { get; set; }
        public DbSet<JobConclusion> JobConclusions { get; set; }
    }
}
