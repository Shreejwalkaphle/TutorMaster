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
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly My_DBContext _dbContext;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> rolemanager,My_DBContext dbcontext)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._rolemanager = rolemanager;
            _dbContext = dbcontext;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
         {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    UserName = model.email,
                    Email = model.email,
                    Address = model.Address,
                    PhoneNumber = model.phoneNumber,
                    gender = model.gender,
                    
                };
                var result = await _userManager.CreateAsync(user, model.password);

                if (result.Succeeded)
                {
                   await _signInManager.SignInAsync(user, isPersistent : false);
                    return RedirectToAction("StudentloginSuccess", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public  IActionResult Login(string ReturnUrl)
        {
            if(!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
            {
                ViewBag.Returnurl = ReturnUrl;
            }
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Login(LoginViewModel logindetails,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(logindetails.Email, logindetails.Password, logindetails.RememberMe, false);
                if (result.Succeeded)
                {
                    //preventing open redirect attack by checking if the entered url is local url or not
                    /*if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))*/
                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {   
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("StudentLoginSuccess", "Home");
                    }
                }
                
                ModelState.AddModelError(string.Empty, "invalid login attempts");
            }

            return View(logindetails);
        }
        [HttpGet]
        public IActionResult Tutors()
        {
            var roles = _rolemanager.Roles;
            ViewBag.TeacherId = from role in roles
                                where role.Name.Equals("teacher")
                                select role.Id;

            List<TeacherAndSubject> teacherAndSubjects = _dbContext.TeacherAndSubject.ToList();

            return View(teacherAndSubjects);
        }

        

        

        /*[HttpPost]
        public IActionResult Tutors()
        {
            return View();
        }*/

        [HttpGet]
        [Authorize]
        public IActionResult Book()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Book(Teacher teacher)
        {
            return View();
        }
    }
}
