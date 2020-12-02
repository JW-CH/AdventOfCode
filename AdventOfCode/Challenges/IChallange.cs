using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.Challenges
{
    public interface IChallenge
    {
        void PartOne(List<string> input);
        void PartTwo(List<string> input);
    }
}
