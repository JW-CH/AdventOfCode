using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2020
{
    class Day_10 : AChallenge2020
    {
        public override string PartOne()
        {
            var jolts = GetInput();

            var list = jolts.Skip(1).Zip(jolts).Select(p => (current: p.First, prev: p.Second)).ToList();

            var diffOne = list.Count(pair => pair.current - pair.prev == 1);
            var diffThree = list.Count(pair => pair.current - pair.prev == 3);

            return $"{diffOne * diffThree}";
        }

        public override string PartTwo()
        {
            var jolts = GetInput();

            // Not my Solution
            var (a, b, c) = (1L, 0L, 0L);
            for (var i = jolts.Count - 2; i >= 0; i--)
            {
                var s =
                    (i + 1 < jolts.Count && jolts[i + 1] - jolts[i] <= 3 ? a : 0) +
                    (i + 2 < jolts.Count && jolts[i + 2] - jolts[i] <= 3 ? b : 0) +
                    (i + 3 < jolts.Count && jolts[i + 3] - jolts[i] <= 3 ? c : 0);
                (a, b, c) = (s, a, b);
            }

            return $"{a}";
        }

        private List<int> GetInput()
        {
            var list = Input.Select(k=>Convert.ToInt32(k)).OrderBy(x => x).ToList();

            list.Add(0);
            list.Add(list.Max()+3);

            return list.OrderBy(x => x).ToList();
        }
    }
}
