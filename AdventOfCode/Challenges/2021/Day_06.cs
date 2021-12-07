using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2021
{
    public class Day_06 : AChallenge2021
    {
        public override string PartOne()
        {
            var list = InputText.Split(',').Select(i => Convert.ToInt32(i)).ToList();

            var fishis = GetFishPopulationAfterDays(list, 80);

            return $"{fishis}";

        }

        public override string PartTwo()
        {
            var list = InputText.Split(',').Select(i => Convert.ToInt32(i)).ToList();

            var fishis = GetFishPopulationAfterDays(list, 256);

            return $"{fishis}";
        }

        private long GetFishPopulationAfterDays(List<int> list, int days)
        {
            var fishis = new long[9];

            foreach (int i in list)
            {
                fishis[i]++;
            }

            for (var t = 0; t < days; t++)
            {
                var zeroFish = fishis[0];
                for(var i = 0; i < fishis.Length-1; i++)
                {
                    fishis[i] = fishis[i+1];
                }
                fishis[6] += zeroFish;
                fishis[8] = zeroFish;
            }

            return fishis.Sum();
        }
    }
}
