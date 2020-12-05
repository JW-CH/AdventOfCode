using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AdventOfCode.Challenges;
using AdventOfCode.Challenges._2020;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Solver.Solve<Day_1>();
            Solver.Solve(typeof(IChallenge));

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
