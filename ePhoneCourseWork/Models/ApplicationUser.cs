using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ePhoneCourseWork.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
