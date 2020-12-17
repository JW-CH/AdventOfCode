using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges._2020
{
    class Day_13 : AChallenge2020
    {
        public override string PartOne()
        {
            var input = GetInput();

            var hasBus = false;
            var currentTime = input.time;
            var finalLane = 0L;
            
            while (!hasBus)
            {
                foreach (var lane in input.lanes)
                {
                    if (currentTime % lane.nr == 0)
                    {
                        finalLane = lane.nr;
                        hasBus = true;
                        break;
                    }
                }

                if (!hasBus)
                {
                    currentTime++;
                }
                
            }
            
            return $"Departure: {currentTime}, Waited: {currentTime - input.time}, Lane: {finalLane}, Result: {finalLane * (currentTime - input.time)}";
        }

        // Got help from https://github.com/encse/adventofcode/blob/master/2020/Day13/Solution.cs
        public override string PartTwo()
        {
            var input = GetInput();

            var result = ChineseRemainderTheorem(
                input.lanes
                    .Select(bus => (mod: bus.nr, a: bus.nr - bus.delay))
                    .ToArray()
            );

            return $"Result: {result}";
        }

        private (int time, List<(long nr, int delay)> lanes) GetInput()
        {
            var time = Convert.ToInt32(Input[0]);

            var buses = Input[1].Split(",")
                .Select((lane, index) => (lane, index))
                .Where(k=>k.lane != "x")
                .Select(item => (lane: Convert.ToInt64(item.lane), delay: item.index))
                .ToList();

            return (time, buses);
        }

        
        // https://rosettacode.org/wiki/Chinese_remainder_theorem#C.23
        long ChineseRemainderTheorem((long mod, long a)[] items)
        {
            var prod = items.Aggregate(1L, (acc, item) => acc * item.mod);
            var sum = items.Select((item, i) => {
                var p = prod / item.mod;
                return item.a * ModInv(p, item.mod) * p;
            }).Sum();

            return sum % prod;
        }
        long ModInv(long a, long m) => (long)BigInteger.ModPow(a, m - 2, m);
    }
}
