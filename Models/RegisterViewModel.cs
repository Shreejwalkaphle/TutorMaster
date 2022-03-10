using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models
{
    public class RegisterViewModel
    {
       /* [Required]
        public String fullname { get; set; }
        [Required]
        public String userName { get; set; }*/
        [Required]
        [EmailAddress]
        public String email { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public String password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("password",ErrorMessage =" password and confirm password does not match")]
        public String confirmpassword { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string gender { get; set; }
        /*  public String gender { get; set; }*/
    }
}
