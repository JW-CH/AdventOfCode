using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AdventOfCode.Challenges;

namespace AdventOfCode
{
    class Solver
    {

        public static void Solve<T>(bool clearConsole = true)
            where T : AChallenge, new()
        {
            T challenge = new T();

            challenge.Solve();
        }

        public static void Solve(Type type)
        {
            var c = LoadChallenges(Assembly.GetEntryAssembly()!);
            foreach (Type challengeType in c)
            {
                if (typeof(AChallenge).IsAssignableFrom(type) && Activator.CreateInstance(challengeType) is AChallenge challenge)
                {
                    challenge.Solve();
                }
            }
        }

        private static IEnumerable<Type> LoadChallenges(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => typeof(AChallenge).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
        }
    }
}
