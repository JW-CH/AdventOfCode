using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges._2020
{
    class Day_12 : AChallenge2020
    {
        public override string PartOne()
        {
            (int ns, int ew, int deg) coords = (0, 0, 90);

            foreach (var action in GetInput())
            {
                coords = Ns(action, coords.ns, coords.ew, coords.deg, true);
            }

            return $"{(coords.ns > 0 ? $"North: {coords.ns}" : $"South: {coords.ns * -1}")}, {(coords.ew > 0 ? $"East: {coords.ew}" : $"West: {coords.ew * -1}")} -> {Math.Abs(coords.ns) + Math.Abs(coords.ew)}";
        }

        private static (int ns, int ew, int deg) Ns((char cardinalDirection, int num) action, int ns, int ew, int deg, bool part1)
        {
            switch (action.cardinalDirection)
            {
                case 'N':
                    ns += action.num;
                    break;
                case 'E':
                    ew += action.num;
                    break;
                case 'S':
                    ns -= action.num;
                    break;
                case 'W':
                    ew -= action.num;
                    break;
                case 'L':
                    deg = (deg - action.num + 360) % 360;
                    break;
                case 'R':
                    deg = (deg + action.num) % 360;
                    break;
                case 'F':
                    if (part1)
                    {
                        switch (deg)
                        {
                            case 0:
                                ns += action.num;
                                break;
                            case 90:
                                ew += action.num;
                                break;
                            case 180:
                                ns -= action.num;
                                break;
                            case 270:
                                ew -= action.num;
                                break;
                        }
                    }
                    break;
                default:
                    throw new Exception();
            }

            return (ns, ew, deg);
        }

        public override string PartTwo()
        {
            (int ns, int ew, int deg) coords = (1, 10, 90);

            var posX = 0;
            var posY = 0;

            foreach (var action in GetInput())
            {
                coords = Ns(action, coords.ns, coords.ew, coords.deg, false);

                if (action.cardinalDirection == 'F')
                {
                    posX += (coords.ns * action.num);
                    posY += (coords.ew * action.num);
                }
            }

            return $"{(posX > 0 ? $"North: {posX}" : $"South: {posX * -1}")}, {(posY > 0 ? $"East: {posY}" : $"West: {posY * -1}")} -> {Math.Abs(posX) + Math.Abs(posY)}";
        }

        public List<(char cardinalDirection, int num)> GetInput()
        {
            return Input.Select(k => (cardinalDirection: k.Substring(0, 1).ToCharArray()[0], num: Convert.ToInt32(k.Substring(1, k.Length - 1)))).ToList();
        }
    }
}
