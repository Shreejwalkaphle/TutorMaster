using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Role Name must be Specified")]
        public string RoleName { get; set; }
    }
}
