using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Challenges
{
    public abstract class AChallenge
    {
        /// <summary>
        /// Expected input file dir path.
        /// </summary>
        protected virtual string InputFileDirPath { get; } = "Inputs";

        /// <summary>
        /// Expected input file extension.
        /// </summary>
        protected virtual string InputFileExtension { get; } = ".txt";

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
                var index = CalculateIndex().ToString("D2");

                var s = Path.Combine(InputFileDirPath, $"{index}.{InputFileExtension.TrimStart('.')}");
                return s;
            }
        }

        public abstract string PartOne();
        public abstract string PartTwo();
    }
}
