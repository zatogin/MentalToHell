using MentalToHell.Models.Reports;
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
        private int id;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        [Required]
        [Display(Name = "Nicname:")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Nicname { get; set; }

        private string email;

        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string value)
        {
            email = value;
        }

        [Required]
        public int UserPersonalStateId { get; set; }

        public virtual UserPersonalState UserPersonalState { get; set; }

        public virtual List<Hobby> Hobbies { get; set; }
        public virtual List<Motivation> Motivations { get; set; }
        public virtual List<Report> Reports { get; set; }
    }
}
