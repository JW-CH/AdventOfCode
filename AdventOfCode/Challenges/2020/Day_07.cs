using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges._2020
{
    class Day_07 : AChallenge2020
    {
        public override string PartOne()
        {
            var parentsOf = new Dictionary<string, HashSet<string>>();

            foreach (var ruleText in Input)
            {
                var rule = ParseRule(ruleText);

                foreach (var r in rule.children)
                {
                    if (!parentsOf.ContainsKey(r.bag))
                    {
                        parentsOf[r.bag] = new HashSet<string>();
                    }
                    parentsOf[r.bag].Add(rule.bag);
                }
            }

            var count = FindRoot("shiny gold bag", parentsOf).ToHashSet().Count - 1;

            return $"Can hold: {count}";
        }

        public override string PartTwo()
        {
            var childrenOf = new Dictionary<string, List<(string bag, int count)>>();

            foreach (var ruleText in Input)
            {
                var rule = ParseRule(ruleText);

                childrenOf[rule.bag] = rule.children;
            }

            var count = CountWithChildren("shiny gold bag", childrenOf)-1;

            return $"Holds: {count}";
        }

        private IEnumerable<string> FindRoot(string bag, Dictionary<string, HashSet<string>> parentsOf)
        {
            yield return bag;

            if (parentsOf.ContainsKey(bag))
            {
                foreach (var container in parentsOf[bag])
                {
                    foreach (var bagT in FindRoot(container, parentsOf))
                    {
                        yield return bagT;
                    }
                }
            }
        }

        private long CountWithChildren(string bag, Dictionary<string, List<(string bag, int count)>> childrenOf)
        {
            return childrenOf[bag].Select(k => k.count * CountWithChildren(k.bag, childrenOf)).Sum() + 1;
        }

        (string bag, List<(string bag, int count)> children) ParseRule(string rule)
        {
            var bag = Regex.Match(rule, @"^[a-z]+ [a-z]+ bag").Value;

            var children =
                Regex
                    .Matches(rule, @"(\d+) ([a-z]+ [a-z]+ bag)")
                    .Select(x => (bag: x.Groups[2].Value, count: int.Parse(x.Groups[1].Value)))
                    .ToList();

            return (bag, children);
        }
    }
}
