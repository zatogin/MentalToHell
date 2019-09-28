using MentalToHell_3.Models.Reports;
using MentalToHell_3.Models.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string NicName { get; set; }

        //to User
        public virtual List<UserState> UserStates { get; set; }
        public virtual List<JobSatisfaction> JobSatisfactions { get; set; }
        public virtual List<LifeJoy> LifeJoys { get; set; }
        //toReport
        public virtual List<Hobby> Hobbies { get; set; }
        public virtual List<Motivation> Motivations { get; set; }
        public virtual List<PartyTime> PartyTimes { get; set; }
        public virtual List<Report> Reports { get; set; }
        public virtual List<ReportsPage> ReportsPages { get; set; }
    }
}
