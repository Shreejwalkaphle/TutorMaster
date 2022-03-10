using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models
{
    public class RatingViewModel
    {
        [Key]
        public int key { get; set; }
        public string UserWhoRated { get; set; }
        /*public string UserWhoGotRated { get; set; }*/
        public int Communication { get; set; }
        public int Punctuality { get; set; }
        public int Personality { get; set; }
        public int AverageRating { get; set; }
               
    }
}
