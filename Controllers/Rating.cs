using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorMaster.Models;

namespace TutorMaster.Controllers
{
    public class Rating : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private My_DBContext _my_DBContext;
        public Rating(UserManager<ApplicationUser> userManager, My_DBContext my_DBContext)
        {
            _userManager = userManager;
            _my_DBContext = my_DBContext;
        }
        [HttpGet]
        public IActionResult rating()
        {
            return View();
        }
        [HttpPost]
        public IActionResult rating(RatingViewModel ratings)
        {
            My_DBContext table = _my_DBContext;
            

            RatingViewModel DatabaseMaHalniData = new RatingViewModel
            {
                UserWhoRated = ratings.UserWhoRated,
                Communication = ratings.Communication,
                Personality = ratings.Personality,
                Punctuality = ratings.Punctuality
            };

            table.RatingViewModels.Add(DatabaseMaHalniData);
            table.SaveChanges();

            List<RatingViewModel> databasebataakodata = table.RatingViewModels.ToList();

            RatingCalculationModel calculate = new RatingCalculationModel();
            int initial_avg_rating = calculate.getInitialAverageRating(databasebataakodata);
            
            int newaverage = calculate.CalculateRating(databasebataakodata);
            DatabaseMaHalniData.AverageRating = newaverage;
            table.RatingViewModels.Update(DatabaseMaHalniData);
            table.SaveChanges();




            /* _userManager.FindByIdAsync();*/
            return View(databasebataakodata);
        }
    }
}
