using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2021
{
    public class Day_01 : AChallenge2021
    {
        public override string PartOne()
        {
            var list = Input.Select(k => Convert.ToInt32(k)).ToList();
            var increases = 0;
            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i] < list[i + 1])
                    increases++;
            }
            return increases.ToString();
        }

        public override string PartTwo()
        {
            var list = Input.Select(k => Convert.ToInt32(k)).ToList();

            int startIdx = 0;
            int lastGroup = Get3GroupSum(0, list);
            int increases = 0;
            while (startIdx <= list.Count - 3)
            {
                var val = Get3GroupSum(startIdx, list);
                if (lastGroup < val)
                {
                    increases++;
                }
                lastGroup = val;

                startIdx++;
            }

            return increases.ToString();

        }

        public int Get3GroupSum(int startIdx, List<int> list)
        {
            return list[startIdx] + list[startIdx + 1] + list[startIdx + 2];
        }
    }
}
