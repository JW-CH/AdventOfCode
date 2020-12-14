using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges._2020
{
    class Day_09 : AChallenge2020
    {
        public override string PartOne()
        {
            int preamble = 25;

            var number = GetWrongNumber(preamble);
            return $"Wrong Preamble: {number}";
        }

        public override string PartTwo()
        {
            int preamble = 25;

            var number = GetWrongNumber(preamble);

            var set = GetNumbers(number);

            return $"Min: {set.Min()}, Max: {set.Max()}, Result: {set.Min() + set.Max()}";
        }

        private List<long> GetInput()
        {
            return Input.Select(k => Convert.ToInt64(k)).ToList();
        }

        private List<long> GetNumbers(long number)
        {
            var set = new List<long>();

            bool Condition(long sum) => sum == number && set.Count > 1;

            foreach (var n in GetInput())
            {
                set.Add(n);

                var sum = set.Sum();
                if (Condition(sum))
                {
                    return set;
                }

                while (set.Count > 0 && sum > number)
                {
                    set.Remove(set[0]);

                    sum = set.Sum();
                    if (Condition(sum))
                    {
                        return set;
                    }
                }
            }

            throw new Exception();
        }

        private long GetWrongNumber(int preamble)
        {
            var input = GetInput();

            for (int i = preamble; i < input.Count; i++)
            {
                var preambles = input.GetRange(i - preamble, preamble);
                var number = input[i];

                if (!PreamableValid(number, preambles))
                {
                    return number;
                }
            }

            throw new Exception();
        }

        private bool PreamableValid(long input, List<long> preambles)
        {
            for (int i = 0; i < preambles.Count; i++)
            {
                var listCopy = new List<long>(preambles);
                listCopy.RemoveAt(i);

                if (listCopy.Contains(input - preambles[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
