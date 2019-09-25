using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHell_3.Models
{
    public class ApplicationRole : IdentityRole<int>
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
