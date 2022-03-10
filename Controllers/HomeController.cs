using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TutorMaster.Models;
using static TutorMaster.Models.My_DBContext;

namespace TutorMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly My_DBContext _dbcontext;

        public HomeController(ILogger<HomeController> logger,My_DBContext dbcontext )
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TeacherRegistration()
        {
            return View();
        }
        /* [HttpPost]
         public IActionResult TeacheRegistration(Teacher_tbl teacher_ko_register_details)
         {
             if (teacher_ko_register_details.password.Equals(teacher_ko_register_details.confirmpassword))
             {
                 My_DBContext table = new My_DBContext();
                 table.Teacher_tbl.Add(teacher_ko_register_details);
                 table.SaveChanges();
                 var elist = table.Teacher_tbl.ToList();
                 return RedirectToAction("Login");
             }
             else return RedirectToAction("ErrorInStudentRegistration");
             return View();
         }*/


        

        [HttpGet]
        public IActionResult StudentRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentRegistration(Student_tbl table_ma_halnuparni_data)
        {
             if (table_ma_halnuparni_data.passwords.Equals(table_ma_halnuparni_data.confirmpasswords))
            {
                My_DBContext table = _dbcontext;
                table.Student_tbl.Add(table_ma_halnuparni_data);
                table.SaveChanges();
                var elist = table.Student_tbl.ToList();
                return RedirectToAction("Login");
            }                
            else return RedirectToAction("ErrorInStudentRegistration");
        }
        [HttpGet]
        public IActionResult ErrorInStudentRegistration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /*[HttpPost]
        public IActionResult Login()
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentLogin(Student studentlogincredianttials)
        {
            My_DBContext d1 = _dbcontext;
            var data = d1.Student_tbl.ToList();
            foreach (var item in data)
            {
                if (item.email.Equals(studentlogincredianttials.email) && item.passwords.Equals(studentlogincredianttials.passwords))
                {
                    return RedirectToAction("StudentLoginSuccess");
                }
                
            }
                return RedirectToAction("StudentLoginFailed");
            
        }

        [HttpGet]
        public IActionResult StudentLoginSuccess()
        {
            My_DBContext table = _dbcontext;
            List<RatingViewModel> databasebataakodata = table.RatingViewModels.ToList();

            RatingViewModel ratings = new RatingViewModel();
            foreach (var item in databasebataakodata)
            {
                ratings.Communication = item.Communication;
                ratings.Personality = item.Personality;
                ratings.Punctuality = item.Punctuality;
                ratings.UserWhoRated = item.UserWhoRated;
                ratings.AverageRating = item.AverageRating;
            }
            return View(ratings);
        }
        [HttpGet]
        public IActionResult StudentLoginFailed()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TeacherLogin()
        {
            return View();
        }
        /*[HttpPost]
        public IActionResult TeacherLogin()
        {
            return View();
        }*/

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
