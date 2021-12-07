using System;
using System.Linq;

namespace AdventOfCode.Challenges._2021
{
    public class Day_07 : AChallenge2021
    {
        public override string PartOne()
        {
            var list = InputText.Split('\u002C').Select(i => Convert.ToInt32(i));
            var sortedNumbers = list.ToArray();
            Array.Sort(sortedNumbers);

            var pos = GetMedian(sortedNumbers);

            var res = list.Select(i => Math.Abs(i - pos)).Sum();            

            return $"{res}";
        }
        public override string PartTwo()
        {
            var list = InputText.Split('\u002C').Select(i => Convert.ToInt32(i));
            var avg = list.Average();
            var pos = Math.Floor(list.Average());
            
            var res = list.Select(i => (1 + Math.Abs(i - pos)) * Math.Abs(i - pos) / 2).Sum();

            return $"{res}";
        }

        private int GetMedian(int[] sortedNumbers)
        {
            var size = sortedNumbers.Length;
            int mid = size / 2;
            return (size % 2 != 0) ? sortedNumbers[mid] : (sortedNumbers[mid] + sortedNumbers[mid - 1]) / 2;
        }
    }
}
