using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models
{
    public class UsersUnderRoleViewModel
    {
        public UsersUnderRoleViewModel()
        {
            UsersUnderRoleList = new List<string>();
        }
        public List<string> UsersUnderRoleList { get; set; }
    }
}
