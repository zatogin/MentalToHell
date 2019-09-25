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
    }
}
