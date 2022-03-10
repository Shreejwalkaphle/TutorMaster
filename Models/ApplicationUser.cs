using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Address { get; set; }
        public string gender{ get; set; }
    }
}
