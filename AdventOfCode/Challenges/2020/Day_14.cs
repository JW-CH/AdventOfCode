using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Challenges._2020
{
    class Day_14 : AChallenge2020
    {
        private const int MaskLength = 36;

        public override string PartOne()
        {
            var input = GetInput();

            var memory = new Dictionary<string, long>();

            foreach (var instruction in input)
            {
                foreach (var addressValue in instruction.AddressValueDictionary)
                {
                    memory[addressValue.Key] = ApplyMask(addressValue.Value, instruction.Mask);
                }
            }

            return $"{memory.Values.Sum()}";
        }

        public override string PartTwo()
        {
            var input = GetInput();

            var memory = new Dictionary<string, long>();

            foreach (var instruction in input)
            {
                foreach (var addressValue in instruction.AddressValueDictionary)
                {
                    var address = ApplyFloatingMask(Convert.ToInt32(addressValue.Key), instruction.Mask);
                    
                    foreach (var add in DecodeAddress(address))
                    {
                        memory[add] = addressValue.Value;
                    }
                }
            }
            
            return $"{memory.Values.Sum()}";
        }

        private List<string> DecodeAddress(string address)
        {
            var index = address.IndexOf('X');
            if (index == -1)
            {
                return new List<string> { address };
            }

            var first = ReplaceFirst(address, 'X', '1');
            var second = ReplaceFirst(address, 'X', '0');

            var list = DecodeAddress(first);

            list.AddRange(DecodeAddress(second));
            
            return list;
        }

        private string ReplaceFirst(string text, char search, char replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + 1);
        }

        private long ApplyMask(int value, string mask)
        {
            var valueAsBinaryString = Convert.ToString(value, 2).PadLeft(36, '0');

            foreach ((char c, int index) in mask.Select((char c, int index) => (c, index)).Where(k => k.c != 'X'))
            {
                var aStringBuilder = new StringBuilder(valueAsBinaryString);
                aStringBuilder.Remove(index, 1);
                aStringBuilder.Insert(index, c);

                valueAsBinaryString = aStringBuilder.ToString();
            }

            return Convert.ToInt64(string.Join("", valueAsBinaryString), 2);
        }

        private string ApplyFloatingMask(int value, string mask)
        {
            var valueAsBinaryString = Convert.ToString(value, 2).PadLeft(36, '0');

            foreach ((char c, int index) in mask.Select((char c, int index) => (c, index)).Where(k => k.c != '0'))
            {
                var aStringBuilder = new StringBuilder(valueAsBinaryString);
                aStringBuilder.Remove(index, 1);
                aStringBuilder.Insert(index, c);

                valueAsBinaryString = aStringBuilder.ToString();
            }

            return valueAsBinaryString;
        }

        private List<Instruction> GetInput()
        {
            var instructionList = new List<Instruction>();
            foreach (var line in Input)
            {
                var lineItems = line.Split(" ");

                if (lineItems.First() == "mask")
                {
                    instructionList.Add(new Instruction(lineItems.Last()));
                }
                else
                {
                    instructionList.Last().AddressValueDictionary[lineItems.First()[4..^1]] = Convert.ToInt32(lineItems.Last());
                }
            }

            return instructionList;
        }

        private record Instruction(string Mask)
        {
            public Dictionary<string, int> AddressValueDictionary { get; } = new();
        }
    }
}
