using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges._2020
{
    class Day_06 : AChallenge2020
    {
        public override string PartOne()
        {
            var answers = GetAnswersCombined();

            var count = answers.Select(k => k.Count).Sum();

            return $"Answers count: {count}";
        }

        public override string PartTwo()
        {
            var groupAnswers = GetAnswers();

            var list = new List<int>();

            foreach (var group in groupAnswers)
            {
                var counter = 0;
                var firstItem = group[0];

                foreach (var c in firstItem)
                {
                    var itemInAllGroups = true;
                    for (int i = 1; i < group.Count; i++)
                    {
                        if (!group[i].Contains(c))
                        {
                            itemInAllGroups = false;
                            break;
                        }
                    }

                    if (itemInAllGroups)
                    {
                        counter++;
                    }
                }

                list.Add(counter);
            }

            return $"Result: {list.Sum()}";
        }

        private IEnumerable<HashSet<char>> GetAnswersCombined()
        {
            var groupAnswer = InputText.Split("\r\n\r\n").ToList();

            var hashSet = groupAnswer.Select(k => new HashSet<char>(k.Replace("\r\n", "").ToCharArray()));

            return hashSet;
        }

        private IEnumerable<List<char[]>> GetAnswers()
        {
            var groupAnswer = InputText.Split("\r\n\r\n").ToList();

            var hashSet = groupAnswer.Select(k => k.Split("\r\n").Select(k=>k.ToCharArray()).ToList());

            return hashSet;
        }
    }
}
