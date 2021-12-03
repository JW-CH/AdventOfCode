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
            for (int i = 0; i < Input.First().ToCharArray().Length; i++)
            {
                var count0 = 0;
                var count1 = 0;

                for (int j = 0; j < Input.Count; j++)
                {
                    if(list[j][i] == '0')
                        count0++;
                    else
                        count1++;
                }
                gamma += count0 > count1 ? "0" : "1";
            }

            var epsilon = BitWiseComplement(gamma);

            return $"{Convert.ToInt32(gamma, 2)*Convert.ToInt32(epsilon, 2)}";
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
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
