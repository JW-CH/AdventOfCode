using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges._2020
{
    class Day_11 : AChallenge2020
    {
        public override string PartOne()
        {
            var input = GetInput();

            Work(input, 4, true);

            return $"{string.Join(Environment.NewLine, input.Select(k => string.Join("", k))).Count(k => k == '#')}";
        }

        private void Work(char[][] input, int occupiedSeatsCriteria, bool partOne)
        {
            var hasChanges = true;

            while (hasChanges)
            {
                hasChanges = false;

                var inputCopy = input.Select(a => a.ToArray()).ToArray();

                for (int x = 0; x < inputCopy.Length; x++)
                {
                    for (int y = 0; y < inputCopy[x].Length; y++)
                    {
                        if (inputCopy[x][y] == '.')
                        {
                            continue;
                        }

                        var occupied = GetOccupiedSeats(inputCopy, x, y, partOne);

                        var place = input[x][y];

                        if (occupied == 0)
                        {
                            if (place != '#')
                            {
                                input[x][y] = '#';
                                hasChanges = true;
                            }
                        }
                        else if (occupied >= occupiedSeatsCriteria)
                        {
                            if (place != 'L')
                            {
                                input[x][y] = 'L';
                                hasChanges = true;
                            }
                        }
                    }
                }
                //Console.WriteLine(string.Join(Environment.NewLine, input.Select(k => string.Join("", k))));
                //Console.WriteLine();
            }
        }

        public override string PartTwo()
        {
            var input = GetInput();

            Work(input, 5, false);

            //return string.Join(Environment.NewLine, input.Select(k=>string.Join("", k)));
            return $"{string.Join(Environment.NewLine, input.Select(k => string.Join("", k))).Count(k => k == '#')}";
        }

        public char[][] GetInput()
        {
            return Input.Select(k => k.ToCharArray()).ToArray();
        }

        private int GetOccupiedSeats(char[][] input, int x, int y, bool partOne)
        {
            var directions = new[] { (0, -1), (0, 1), (-1, 0), (1, 0), (-1, -1), (-1, 1), (1, -1), (1, 1) };
            var occupied = 0;

            foreach (var direction in directions)
            {
                var newX = x + direction.Item1;
                var newY = y + direction.Item2;
                if (PlaceExists(input, newX, newY))
                {
                    var place = input[newX][newY];

                    if (place == '#')
                    {
                        occupied++;
                    }
                    else if (place == '.')
                    {
                        if (partOne)
                        {
                            continue;
                        }
                        while (true)
                        {
                            newX = newX + direction.Item1;
                            newY = newY + direction.Item2;

                            if (PlaceExists(input, newX, newY))
                            {
                                if (input[newX][newY] != '.')
                                {
                                    if (input[newX][newY] == '#')
                                    {
                                        occupied++;
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return occupied;
        }

        private bool PlaceExists(char[][] input, int x, int y)
        {
            return (x >= 0 && x < input.Length) && (y >= 0 && y < input[0].Length);
        }
    }
}
