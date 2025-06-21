using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPilot.BLL.DTOs
{
    //this class Used to do mapping with ApplicationUser entity when logging in 
    public class UserLoginDto
    {
    
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
