using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges._2020
{
    internal class Day_2 : AChallenge2020
    {
        public override string PartOne()
        {
            var validPasswords = 0;

            foreach (var line in Input)
            {
                var pw = GetPassword(line);

                var anz = pw.Content.ToCharArray().Count(k => k == pw.Policy);

                if (pw.Rule.min <= anz && anz <= pw.Rule.max)
                {
                    validPasswords++;
                }

            }

            return $"Found {validPasswords} Passwords";
        }

        public override string PartTwo()
        {
            var validPasswords = 0;

            foreach (var line in Input)
            {
                var pw = GetPassword(line);

                var first = pw.Content.ToCharArray()[pw.Rule.min - 1] == pw.Policy;
                var second = pw.Content.ToCharArray()[pw.Rule.max - 1] == pw.Policy;


                if (first ^ second)
                {
                    //Console.WriteLine($"Found password: {password} (char: {character}, {min}-{max})");
                    validPasswords++;
                }

            }

            return $"Found {validPasswords} Passwords";
        }


        string pattern = @"(\d*)-(\d*) ([a-z]): ([a-z]*)";
        private Password GetPassword(string input)
        {
            var regex = Regex.Match(input, pattern);

            var min = Convert.ToInt32(regex.Groups[1].Value);
            var max = Convert.ToInt32(regex.Groups[2].Value);
            var character = regex.Groups[3].Value.ToCharArray()[0];
            var password = regex.Groups[4].Value;
            return new Password
            {
                Content = password,
                Policy = character,
                Rule = (min,max)
            };
        }
    }
    
    class Password
    {
        public string Content { get; set; }
        public char Policy { get; set; }
        public (int min, int max) Rule { get; set; }
    }
}
