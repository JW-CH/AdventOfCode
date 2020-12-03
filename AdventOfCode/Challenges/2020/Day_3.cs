using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Challenges._2020
{
    class Day_3 : AChallenge
    {
        public override string PartOne()
        {



            var trees = EncounterTreesOptimized(3, 1);

            //var text = "";
            //for (int i = 0; i < map.Length; i++)
            //{
            //    text += $"{new string(map[i])}{Environment.NewLine}";
            //}

            return $"Trees: {trees}";
        }

        public override string PartTwo()
        {
            var option1 = EncounterTreesOptimized(1, 1);
            var option2 = EncounterTreesOptimized(3, 1);
            var option3 = EncounterTreesOptimized(5, 1);
            var option4 = EncounterTreesOptimized(7, 1);
            var option5 = EncounterTreesOptimized(1, 2);

            return $"Result: {option1 }, { option2 }, { option3 }, { option4 }, { option5} -> {(double)option1 * option2 * option3 * option4 * option5}";
        }

        public char[][] GetMap()
        {
            var map = Input.Select(k => k.ToCharArray()).ToArray();

            return map;
        }

        private int EncounterTreesOptimized(int moveX, int moveY)
        {
            var X = 0;
            var Y = 0;
            var trees = 0;
            var map = GetMap();
            while (true)
            {
                if (map[Y][X % map[Y].Length] == '#')
                {
                    trees++;
                }

                X += moveX;
                Y += moveY;

                if (map.Length <= Y)
                {
                    break;
                }
            }

            return trees;
        }


        private int EncounterTrees(int moveX, int moveY)
        {
            var X = 0;
            var Y = 0;
            var trees = 0;
            var map = GetMap();
            while (true)
            {
                if (map[Y][X] == '#')
                {
                    trees++;
                    map[Y][X] = 'X';
                }
                else
                {
                    map[Y][X] = 'O';
                }

                X += moveX;
                Y += moveY;

                if (map.Length <= Y)
                {
                    break;
                }

                if (map[Y].Length <= X)
                {
                    RepeatMap(map, GetMap());
                }
            }

            return trees;
        }

        private void RepeatMap(char[][] map, char[][] repeatMap)
        {
            var s = "sadfsadf".ToCharArray();

            for (int i = 0; i < map.Length; i++)
            {
                var list = map[i].ToList();
                list.AddRange(repeatMap[i]);

                map[i] = list.ToArray();
            }
        }
    }
}
