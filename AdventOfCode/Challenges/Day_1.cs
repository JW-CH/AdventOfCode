using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges
{
    internal class Day_1 : AChallenge
    {

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
                    var zahl3 = remainder1 - i;
                    if (list.Contains(zahl3))
                    {
                        result = $"Zahl1: {item}, Zahl2: {i}, Zahl3: {zahl3}, Ergebnis: {item * i * zahl3}";
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

        public override string PartOne()
        {
            var list = Input.Select(k=>Convert.ToInt32(k)).ToList();
            var result = string.Empty;

            foreach (var item in list)
            {
                var remainder = 2020 - item;

                if (list.Contains(remainder))
                {
                    result = $"Zahl1: {item}, Zahl2: {remainder}, Ergebnis: {item * remainder}";
                    break;
                }
            }

            return result;
        }
    }
}
