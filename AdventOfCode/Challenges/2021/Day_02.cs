using System;
using System.Linq;

namespace AdventOfCode.Challenges._2021
{
    public class Day_02 : AChallenge2021
    {
        public override string PartOne()
        {
            int depth = 0;
            int horizontalPos = 0;

            foreach (var item in Input.Select(i => i.Split(' ')).Select(i => new { direction = i[0], value = Convert.ToInt32(i[1]) }))
            {
                switch (item.direction)
                {
                    case "forward":
                        horizontalPos+=item.value;
                        break;
                    case "up":
                        depth -= item.value;
                        break;
                    case "down":
                        depth += item.value;
                        break;
                    default:
                        throw new NotImplementedException();
                        break;
                }
            }

            return $"Multiply {horizontalPos}*{depth}, ({nameof(horizontalPos)}*{nameof(depth)}): {horizontalPos*depth}";
        }

        public override string PartTwo()
        {
            int aim = 0;
            int depth = 0;
            int horizontalPos = 0;

            foreach(var item in Input.Select(i=>i.Split(' ')).Select(i=>new {direction = i[0], value = Convert.ToInt32(i[1])}))
            {
                switch (item.direction)
                {
                    case "forward":
                        horizontalPos += item.value;
                        depth += aim * item.value;
                        break;
                    case "up":
                        aim -= item.value;
                        break;
                    case "down":
                        aim += item.value;
                        break;
                    default:
                        throw new NotImplementedException();
                        break;
                }
            }

            return $"Multiply {horizontalPos}*{depth}, ({nameof(horizontalPos)}*{nameof(depth)}): {horizontalPos * depth}";
        }
    }
}
