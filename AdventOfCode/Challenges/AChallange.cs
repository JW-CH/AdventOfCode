using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCode.Challenges
{
    public abstract class AChallenge
    {
        /// <summary>
        /// Expected input file dir path.
        /// </summary>
        protected virtual string InputFileDirPath => "Inputs";

        /// <summary>
        /// Expected input file extension.
        /// </summary>
        protected virtual string InputFileExtension => ".txt";
        public string DayName => CalculateIndex().ToString("D2");

        private List<string> _input;
        /// <summary>
        /// Input as list from the file provided in InputFilePath
        /// </summary>
        public List<string> Input
        {
            get
            {
                if (_input == null)
                {
                    if (!File.Exists(InputFilePath))
                    {
                        throw new Exception($"Path {InputFilePath} not found for {GetType().Name}");
                    }

                    _input = File.ReadAllLines(InputFilePath).ToList();
                }

                return _input;
            }
        }

        private string _inputText;
        /// <summary>
        /// Input as list from the file provided in InputFilePath
        /// </summary>
        public string InputText
        {
            get
            {
                if (_inputText == null)
                {
                    if (!File.Exists(InputFilePath))
                    {
                        throw new Exception($"Path {InputFilePath} not found for {GetType().Name}");
                    }

                    _inputText = File.ReadAllText(InputFilePath);
                }

                return _inputText;
            }
        }

        /// <summary>
        /// Gets day as int from the ClassName
        /// </summary>
        /// <returns>int number of day</returns>
        public virtual int CalculateIndex()
        {
            var typeName = GetType().Name;

            return int.TryParse(typeName.Split('_')[1].TrimStart('_'), out var index)
                ? index
                : default;
        }

        /// <summary>
        /// Complete path to file with inputs
        /// </summary>
        public virtual string InputFilePath
        {
            get
            {
                var s = Path.Combine(InputFileDirPath, $"{DayName}.{InputFileExtension.TrimStart('.')}");
                return s;
            }
        }

        public abstract string PartOne();
        public abstract string PartTwo();

        public IEnumerable<(TimeSpan time, object result, bool error)> GetResults()
        {
            var res1 = (TimeSpan.Zero, (object)null, true);
            var res2 = (TimeSpan.Zero, (object)null, true);
            try
            {
                var now = DateTime.Now;
                res1.Item2 = PartOne();
                res1.Zero = DateTime.Now - now;
                res1.Item3 = false;
            }
            catch (NotImplementedException e)
            {
                res1.Item2 = "Not Implemented yet";
            }
            try
            {
                var now = DateTime.Now;
                res2.Item2 = PartTwo();
                res2.Zero = DateTime.Now - now;
                res2.Item3 = false;
            }
            catch (NotImplementedException e)
            {
                res2.Item2 = "Not Implemented yet";
            }

            yield return res1;
            yield return res2;
        }

        public void Solve()
        {
            WriteLine(ConsoleColor.Blue, $"========= Day {DayName} =========");
            WriteLine();

            var dt = DateTime.Now;
            foreach (var line in GetResults())
            {
                var now = DateTime.Now;
                var (statusColor, status) =
                    !line.error ? (ConsoleColor.DarkGreen, "OK") :
                        (ConsoleColor.Red, "X");

                Write(statusColor, $"  {status}");
                Console.Write($" {line.result} ");
                var diff = line.time.TotalMilliseconds;
                WriteLine(
                    diff > 1000 ? ConsoleColor.Red :
                    diff > 500 ? ConsoleColor.Yellow :
                    ConsoleColor.DarkGreen,
                    $"({diff.ToString("F3")} ms)"
                );
                dt = DateTime.Now;
            }
            WriteLine();
        }


        private void WriteLine(ConsoleColor color = ConsoleColor.Gray, string text = "")
        {
            Write(color, text + "\n");
        }
        private void Write(ConsoleColor color = ConsoleColor.Gray, string text = "")
        {
            var c = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = c;
        }

    }
}
