using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges
{
    class Day1 : IChallenge
    {

        public void PartTwo(List<string> input)
        {
            var list = input.Select(k => Convert.ToInt32(k)).ToList();

            var finished = false;
            foreach (var item in list)
            {
                var remainder1 = 2020 - item;

                foreach (var i in list.Where(k => k < remainder1))
                {
                    var zahl3 = remainder1 - i;
                    if (list.Contains(zahl3))
                    {
                        Console.WriteLine($"Zahl1: {item}, Zahl2: {i}, Zahl3: {zahl3}, Ergebnis: {item * i * zahl3}");
                        finished = true;

                        break;
                    }

                    if (finished)
                    {
                        break;
                    }
                }
            }
        }

        public void PartOne(List<string> input)
        {
            var list = input.Select(k=>Convert.ToInt32(k)).ToList();

            foreach (var item in list)
            {
                var remainder = 2020 - item;

                if (list.Contains(remainder))
                {
                    Console.WriteLine($"Zahl1: {item}, Zahl2: {remainder}, Ergebnis: {item * remainder}");
                    break;
                }
            }
        }
    }
}
