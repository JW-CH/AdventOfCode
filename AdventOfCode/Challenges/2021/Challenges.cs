using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges._2021
{
    public class Day_01 : AChallenge2021
    {
        public override string PartOne()
        {
            var list = Input.Select(k => Convert.ToInt32(k)).ToList();
            var increases = 0;
            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i] < list[i + 1])
                    increases++;
            }
            return increases.ToString();
        }

        public override string PartTwo()
        {
            var list = Input.Select(k => Convert.ToInt32(k)).ToList();

            int startIdx = 0;
            int lastGroup = Get3GroupSum(0, list);
            int increases = 0;
            while (startIdx <= list.Count - 3)
            {
                var val = Get3GroupSum(startIdx, list);
                if (lastGroup < val)
                {
                    increases++;
                }
                lastGroup = val;

                startIdx++;
            }

            return increases.ToString();

        }

        public int Get3GroupSum(int startIdx, List<int> list)
        {
            return list[startIdx] + list[startIdx + 1] + list[startIdx + 2];
        }
    }

    public class Day_02 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_03 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_04 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_05 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_06 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_07 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_08 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_09 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_10 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_11 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_12 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_13 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_14 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_15 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_16 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_17 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_18 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_19 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_20 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_21 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_22 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_23 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_24 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }

    public class Day_25 : AChallenge2021
    {
        public override string PartOne()
        {
            throw new NotImplementedException();
        }

        public override string PartTwo()
        {
            throw new NotImplementedException();
        }
    }
}
