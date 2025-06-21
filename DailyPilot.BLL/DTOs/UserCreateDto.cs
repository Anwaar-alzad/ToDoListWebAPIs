﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPilot.BLL.DTOs
{
    //this class will recieve user input and through auto mapping it will map to ApplicationUser
    public class UserCreateDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public int PhoneNumber { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }
        //[Required]
        //[Compare("Password", ErrorMessage = "Passwords do not match")]
        //public string ConfirmPassword { get; set; }

    }
}
