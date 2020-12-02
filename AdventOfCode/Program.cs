using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Challenges;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            IChallenge challenge = new Day2();
            var input = GetInput(@"./Inputs/day2.txt");

            Console.WriteLine(nameof(challenge.PartOne));
            challenge.PartOne(input);

            Console.WriteLine("");

            Console.WriteLine(nameof(challenge.PartTwo));
            challenge.PartTwo(input);

            Console.ReadLine();
        }

        private static List<string> GetInput(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            return lines.ToList();
        }
    }
}
