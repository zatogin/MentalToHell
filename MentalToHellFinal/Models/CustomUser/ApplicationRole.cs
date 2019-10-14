using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHellFinal.Models.CustomUser
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }
        public ApplicationRole(string name)
         : this()
        {
            this.Name = name;
        }
        public string ShowingItsPossible { get; set; }
    }
}
