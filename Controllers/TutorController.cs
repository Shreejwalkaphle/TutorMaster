using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorMaster.Models;

namespace TutorMaster.Controllers
{
    public class TutorController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly My_DBContext _my_DBContext;

        public TutorController(RoleManager<IdentityRole> rolemanager, UserManager<ApplicationUser> userManager, My_DBContext my_DBContext)
        {
            this._rolemanager = rolemanager;
            this._userManager = userManager;
            this._my_DBContext = my_DBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Tutors()
        {
            var roles = _rolemanager.Roles;
            ViewBag.RoleId = from role in roles
                                where role.Name.Equals("teacher")
                                select role.Id;

            ViewBag.RoleName = from role in roles
                             where role.Name.Equals("teacher")
                             select role.Name;

            /*var user = _userManager.Users.ToList();

            var teachernames = from teacher in user
                               where _userManager.IsInRoleAsync(teacher, ViewBag.Rolename)
                               select teacher;*/

            
            
            var subjects = _my_DBContext.Subject.ToList(); 
            return View(subjects);
        }

        [HttpGet]
        public IActionResult Teachers(string id)
        {
            return View();
        }
    }
}
