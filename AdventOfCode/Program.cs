using System;
using AdventOfCode.Challenges;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            AChallenge challenge = new Day_1();

            Console.WriteLine(challenge.GetType());
            Console.WriteLine("");

            Console.WriteLine(nameof(challenge.PartOne));
            Console.WriteLine(challenge.PartOne());
            Console.WriteLine("");

            Console.WriteLine(nameof(challenge.PartTwo));
            Console.WriteLine(challenge.PartTwo());

            Console.ReadLine();
        }
    }
}
