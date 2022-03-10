using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorMaster.Models;

namespace TutorMaster.Controllers
{
    
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _usermanager;
        public AdministrationController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> usermanager)
        {
            _usermanager = usermanager;
            _roleManager = roleManager;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult createRole()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> createRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole newrole = new IdentityRole();
                newrole.Name = model.RoleName;
                IdentityResult result = await _roleManager.CreateAsync(newrole);

                if (result.Succeeded)
                {
                    return RedirectToAction("StudentLoginSuccess", "Home");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(" ",error.Description);
                }
            }

            return View(model);

        }

        [HttpGet]
        public IActionResult ListRoles()
            {
            var AllRoleList = _roleManager.Roles;
            return View(AllRoleList); 
        }

        [HttpGet]
        public async Task<IActionResult> EditRoles(string editid)
        {
            var roleToBeEdited = await _roleManager.FindByIdAsync(editid);

            if(roleToBeEdited == null)
            {
                /*view bag ma error message halera view ma pathaidini*/
                ViewBag.ErrorMessage = $"no Role with {editid} was found";
                return View("NotFound");   
            }
            EditRoleViewModel RoleToBindInView = new EditRoleViewModel();
            RoleToBindInView.Id = roleToBeEdited.Id;
            RoleToBindInView.RoleName = roleToBeEdited.Name;
            return View(RoleToBindInView);
        }
        [HttpPost]
        public async Task<IActionResult> EditRoles(EditRoleViewModel model)
        {
            var roleToBeEdited = await _roleManager.FindByIdAsync(model.Id);

            if (roleToBeEdited == null)
            {
                /*view bag ma error message halera view ma pathaidini*/
                ViewBag.ErrorMessage = $"no Role with {model.Id} was found";
                return View("NotFound");
            }
            else
            {
                roleToBeEdited.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(roleToBeEdited);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach(var error in result.Errors)
                {
                        ModelState.AddModelError(" ", error.Description);
                }

            return View(roleToBeEdited);
            }  
        }

        //to see who are in the role 
        [HttpGet]
        public async Task<IActionResult> UsersInRole(string roleid)
        {
            var roleFromDatabase = await _roleManager.FindByIdAsync(roleid);

            ViewBag.RoleID = roleid;

            if(roleFromDatabase == null)
            {
                ViewBag.ErrorMessage($"role with roll id : {roleid} not found");
                return View("Notfound");
            }

            var usersUnderRole = new UsersUnderRoleViewModel();

            var userlist = _usermanager.Users.ToList();//yaha toList use nagarda runtime error ako thyo

            //usersUnderRole.UsersUnderRoleList = null;
            foreach(var user in userlist)
            {
                if (await _usermanager.IsInRoleAsync(user, roleFromDatabase.Name))
                {
                    //samplelist.Add(user.UserName.ToString());
                     usersUnderRole.UsersUnderRoleList.Add(user.UserName.ToString());
                }
            }
            return View(usersUnderRole);
        }

        //to add user in certain role
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleid)
        {
            ViewBag.RoleId = roleid;

            var role = await _roleManager.FindByIdAsync(roleid);

            ViewBag.RoleName = role.Name;
            if(role == null)
            {
                ViewBag.ErrorMessage($"no role for role id {roleid} found");
                return View("Notfound"); 
            }

            List<UserRoleViewModel> UserAndTheirRoleList = new List<UserRoleViewModel>();

           // UserRoleViewModel UserAndTheirRoleList = new UserRoleViewModel();

            foreach (var user in _usermanager.Users.ToList())
            {
                UserRoleViewModel userroleobject = new UserRoleViewModel();
                userroleobject.UserId = user.Id;
                userroleobject.UserName = user.UserName;
                if (await _usermanager.IsInRoleAsync(user, role.Name)){
                    userroleobject.IsSelected = true;
                }
                else
                {
                    userroleobject.IsSelected = false;
                }
                UserAndTheirRoleList.Add(userroleobject);
            }
            return View(UserAndTheirRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> UserAndTheirRoleList, string roleid)
        {
            var role = await _roleManager.FindByIdAsync(roleid);

            if(role == null)
            {
                return View("Notfound");
            }

            for(int i = 0; i < UserAndTheirRoleList.Count; i++)
            {
                var user = await _usermanager.FindByIdAsync(UserAndTheirRoleList[i].UserId);
                IdentityResult result = null;

                if(UserAndTheirRoleList[i].IsSelected && !(await _usermanager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _usermanager.AddToRoleAsync(user, role.Name);
                }

                if(!(UserAndTheirRoleList[i].IsSelected) && await _usermanager.IsInRoleAsync(user, role.Name))
                {
                    result = await _usermanager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < UserAndTheirRoleList.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("UsersInRole", new { roleid = roleid });
                    }
                }
            }
                
            return RedirectToAction("UsersInRole", new { roleid = roleid });
        }
    }
}
