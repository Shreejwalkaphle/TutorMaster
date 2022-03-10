using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models.DatabaseTest
{
    public class MySubject
    {
        [Key]
        public int subjectid { get; set; }
        public string subjectname { get; set; }
        public List<string> userid { get; set; }
        public string roleid { get; set; }
    }   
}
