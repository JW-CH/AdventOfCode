using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges._2020
{
    class Day_8 : AChallenge2020
    {
        public override string PartOne()
        {
            var res = Test(Input);
            return $"Accumulator Value: {res.accumulator}";
        }

        public override string PartTwo()
        {
            var lines = Enumerable.Range(0, Input.Count).Where(k => ParseLine(Input[k]).operation != "acc").ToList();

            foreach (var line in lines)
            {
                var newInput = Input.ToArray();

                if (ParseLine(newInput[line]).operation == "jmp")
                {
                    newInput[line] = newInput[line].Replace("jmp", "nop");
                }
                else
                {
                    newInput[line] = newInput[line].Replace("nop", "jmp");
                }

                var res = Test(newInput.ToList());

                if (res.successfulRunThrough)
                {
                    return $"Accumulator Value: {res.accumulator}";
                }
            }

            return $"Not Found";
        }

        private (string operation, int argument) ParseLine(string line)
        {
            var operation = line.Substring(0, 3);
            var argument = Convert.ToInt32(line.Substring(4, line.Length - 4));


            return (operation, argument);
        }

        private (int accumulator, bool successfulRunThrough) Test(List<string> input)
        {
            var check = new HashSet<int>();

            var accumulator = 0;
            var successfulRunThrough = false;

            var pointer = 0;
            while (true)
            {
                var field = pointer;
                if (check.Contains(pointer))
                {
                    break;
                }

                var line = ParseLine(input[pointer]);
                

                switch (line.operation)
                {
                    case "acc":
                        accumulator += line.argument;
                        break;
                    case "jmp":
                        pointer += line.argument;
                        break;
                    case "nop":
                        break;
                    default:
                        throw new NotImplementedException();
                }

                check.Add(field);

                if (line.operation != "jmp")
                {
                    pointer++;
                }

                if (pointer >= Input.Count)
                {
                    successfulRunThrough = true;
                    break;
                }
            }

            return (accumulator, successfulRunThrough);
        }
    }
}
