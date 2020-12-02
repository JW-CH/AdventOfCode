using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges
{
    class Day2 : IChallenge
    {
        public void PartOne(List<string> input)
        {
            var validPasswords = 0;

            string pattern = @"(?'min'\d*)-(?'max'\d*) (?'char'[a-z]): (?'password'[a-z]*)";
            foreach (var line in input)
            {
                var regex = Regex.Match(line, pattern);

                var min = Convert.ToInt32(regex.Groups["min"].Value);
                var max = Convert.ToInt32(regex.Groups["max"].Value);
                var character = regex.Groups["char"].Value.ToCharArray()[0];
                var password = regex.Groups["password"].Value;

                var anz = password.ToCharArray().Count(k => k == character);

                if (min <= anz && anz <= max)
                {
                    //Console.WriteLine($"Found password: {password} (char: {character}, {min}-{max})");
                    validPasswords++;
                }

            }

            Console.WriteLine($"Found {validPasswords} Passwords");
        }

        public void PartTwo(List<string> input)
        {
            var validPasswords = 0;

            string pattern = @"(\d*)-(\d*) ([a-z]): ([a-z]*)";
            foreach (var line in input)
            {
                var regex = Regex.Match(line, pattern);

                var min = Convert.ToInt32(regex.Groups[1].Value);
                var max = Convert.ToInt32(regex.Groups[2].Value);
                var character = regex.Groups[3].Value.ToCharArray()[0];
                var password = regex.Groups[4].Value;

                var first = password.ToCharArray()[min-1] == character;
                var second = password.ToCharArray()[max-1] == character;


                if (first ^ second)
                {
                    //Console.WriteLine($"Found password: {password} (char: {character}, {min}-{max})");
                    validPasswords++;
                }

            }

            Console.WriteLine($"Found {validPasswords} Passwords");
        }

    }
}
