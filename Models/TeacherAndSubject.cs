using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models
{
    public class TeacherAndSubject
    {
        [Key]
        public int T_S_Id{ get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject subject { get; set; }

        [ForeignKey("Id")]
        public virtual IdentityRole role{ get; set; }
    }
}
