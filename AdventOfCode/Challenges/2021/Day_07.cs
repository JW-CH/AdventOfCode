using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2021
{
    public class Day_07 : AChallenge2021
    {
        public override string PartOne()
        {
            var list = InputText.Split('\u002C').Select(i => Convert.ToInt32(i)).OrderBy(x=>x).ToList();

            var pos = GetMedian(list);
            var res = list.Select(i => Math.Abs(i - pos)).Sum();            

            return $"{res}";
        }
        public override string PartTwo()
        {
            var list = InputText.Split('\u002C').Select(i => Convert.ToInt32(i));
            var pos = Math.Floor(list.Average());
            
            var res = list.Select(i => (1 + Math.Abs(i - pos)) * Math.Abs(i - pos) / 2).Sum();

            return $"{res}";
        }

        private int GetMedian(List<int> sortedNumbers)
        {
            var size = sortedNumbers.Count();
            int mid = size / 2;
            return (size % 2 != 0) ? sortedNumbers[mid] : (sortedNumbers[mid] + sortedNumbers[mid - 1]) / 2;
        }
    }
}
