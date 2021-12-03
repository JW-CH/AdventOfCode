using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2021
{
    public class Day_03 : AChallenge2021
    {
        public override string PartOne()
        {
            var list = Input.Select(i => i.ToCharArray()).ToArray();
            var gamma = "";
            for (int i = 0; i < list.First().Length; i++)
            {
                var count0 = 0;
                var count1 = 0;

                for (int j = 0; j < Input.Count; j++)
                {
                    if (list[j][i] == '0')
                        count0++;
                    else
                        count1++;
                }
                gamma += count0 > count1 ? "0" : "1";
            }

            var epsilon = BitWiseComplement(gamma);

            return $"{Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2)}";
        }

        public override string PartTwo()
        {
            var list = Input.Select(i => i.ToCharArray()).ToArray();

            var oxygenList = list;
            var co2List = list;
            var skip1 = false;
            var skip2 = false;

            for (int i = 0; i < list.First().Length; i++)
            {
                if (!skip1)
                {
                    var bit = GetMostCommonBit(oxygenList, i);

                    oxygenList = oxygenList.Where(x => x[i] == bit).ToArray();
                }

                if (!skip2)
                {
                    var bit = GetMostCommonBit(co2List, i) == '1' ? '0' : '1';

                    co2List = co2List.Where(x => x[i] == bit).ToArray();
                }

                skip1 = oxygenList.Length == 1;
                skip2 = co2List.Length == 1;

                if (skip2)
                {
                    var x = 1;
                }

                if (skip1 && skip2)
                {
                    break;
                }
            }

            var oxygen = new string(oxygenList.First());
            var co2 = new string(co2List.First());

            return $"{Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2)}";
        }

        private char GetMostCommonBit(char[][] input, int pos)
        {
            var count0 = 0;
            var count1 = 0;

            for (int j = 0; j < input.Length; j++)
            {
                if (input[j][pos] == '0')
                    count0++;
                else
                    count1++;
            }

            return count0 > count1 ? '0' : '1';
        }

        private string BitWiseComplement(string firstBinaryNumber)
        {
            int result = Convert.ToInt32(firstBinaryNumber, 2);
            string complementedBinaryNumber = Convert.ToString(~result, 2);
            complementedBinaryNumber = complementedBinaryNumber.Remove(0, complementedBinaryNumber.Length - firstBinaryNumber.Length);

            return complementedBinaryNumber;
        }
    }
}
