using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHellFinal.Models.CustomUser
{
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }
    }
}
