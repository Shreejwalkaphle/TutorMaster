using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorMaster.Models
{
    public class RatingCalculationModel
    {
        public int getInitialAverageRating(List<RatingViewModel> ratinglistfromdatabase)
        {
            int avg_rating = 0;
            var avg = from averageFromDatabase in ratinglistfromdatabase
                      where averageFromDatabase.AverageRating != null
                      select averageFromDatabase;



            foreach (var item in avg)
            {
                 avg_rating = item.AverageRating;
            }
            return avg_rating;
        }
        
        private double calculateCommunicationWieightedAverage(List<RatingViewModel> ratinglistfromdatabase)
        {
         int onestarcount = 0;
         int twostarcount = 0;
         int threestarcount = 0;
         int fourstarcount = 0;
         int fivestarcount = 0;
        double comunication_weighted_avg = 0;
            foreach(var item in ratinglistfromdatabase)
            {
                if (item.Communication == 5)
                {
                    fivestarcount++;
                }
                else if (item.Communication == 4)
                {
                    fourstarcount++;
                }
                else if (item.Communication == 3)
                {
                    threestarcount++;
                }
                else if (item.Communication == 2)
                {
                    twostarcount++;
                }
                else if(item.Communication == 1)
                {
                    onestarcount++;
                }
            }
            comunication_weighted_avg = (5 * fivestarcount + 4 * fourstarcount + 3 * threestarcount + 2 * twostarcount + 1 * onestarcount)
                                         /(fivestarcount+fourstarcount+threestarcount+twostarcount+onestarcount);

            return comunication_weighted_avg;
        }
        private double calculatePersonalityWieightedAverage(List<RatingViewModel> ratinglistfromdatabase) {
            int onestarcount = 0;
            int twostarcount = 0;
            int threestarcount = 0;
            int fourstarcount = 0;
            int fivestarcount = 0;
            double Personality_weighted_avg = 0;
            foreach (var item in ratinglistfromdatabase)
            {
                if (item.Personality == 5)
                {
                    fivestarcount++;
                }
                else if (item.Personality == 4)
                {
                    fourstarcount++;
                }
                else if (item.Personality == 3)
                {
                    threestarcount++;
                }
                else if (item.Personality == 2)
                {
                    twostarcount++;
                }
                else if (item.Personality == 1)
                {
                    onestarcount++;
                }
            }
            Personality_weighted_avg = (5 * fivestarcount + 4 * fourstarcount + 3 * threestarcount + 2 * twostarcount + 1 * onestarcount)
                                         / (fivestarcount + fourstarcount + threestarcount + twostarcount + onestarcount);

            return Personality_weighted_avg;
        }
        private double calculatePunctualityWieightedAverage(List<RatingViewModel> ratinglistfromdatabase) {
            int onestarcount = 0;
            int twostarcount = 0;
            int threestarcount = 0;
            int fourstarcount = 0;
            int fivestarcount = 0;
            double Punctuality_weighted_avg = 0;
            foreach (var item in ratinglistfromdatabase)
            {
                if (item.Punctuality == 5)
                {
                    fivestarcount++;
                }
                else if (item.Punctuality == 4)
                {
                    fourstarcount++;
                }
                else if (item.Punctuality == 3)
                {
                    threestarcount++;
                }
                else if (item.Punctuality == 2)
                {
                    twostarcount++;
                }
                else if (item.Punctuality == 1)
                {
                    onestarcount++;
                }
            }
            Punctuality_weighted_avg = (5 * fivestarcount + 4 * fourstarcount + 3 * threestarcount + 2 * twostarcount + 1 * onestarcount)
                                         / (fivestarcount + fourstarcount + threestarcount + twostarcount + onestarcount);

            return Punctuality_weighted_avg;
        }
        public int CalculateRating(List<RatingViewModel> ratinglistfromdatabase)
        {
            int average = (int)(calculateCommunicationWieightedAverage(ratinglistfromdatabase) + calculatePersonalityWieightedAverage(ratinglistfromdatabase) + calculatePunctualityWieightedAverage(ratinglistfromdatabase))/3;
            return average;
        }
    }
}
