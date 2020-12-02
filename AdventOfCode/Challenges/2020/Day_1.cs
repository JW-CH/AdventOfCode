using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2020
{
    internal class Day_1 : AChallenge
    {
        public override string PartOne()
        {
            var list = Input.Select(k=>Convert.ToInt32((string?) k)).ToList();
            var result = string.Empty;

            foreach (var item in list)
            {
                var remainder = 2020 - item;

                if (list.Contains(remainder))
                {
                    result = $"Number1: {item}, Number2: {remainder}, Result: {item * remainder}";
                    break;
                }
            }

            return result;
        }

        public override string PartTwo()
        {
            var list = Input.Select(k => Convert.ToInt32(k)).ToList();
            var result = string.Empty;

            var finished = false;
            foreach (var item in list)
            {
                var remainder1 = 2020 - item;

                foreach (var i in list.Where(k => k < remainder1))
                {
                    var number3 = remainder1 - i;
                    if (list.Contains(number3))
                    {
                        result = $"Number1: {item}, Number2: {i}, Number3: {number3}, Result: {item * i * number3}";
                        finished = true;

                        break;
                    }

                    if (finished)
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}
