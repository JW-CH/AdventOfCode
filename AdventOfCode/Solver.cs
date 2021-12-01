using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AdventOfCode.Challenges;

namespace AdventOfCode
{
    public class Solver
    {

        public static void Solve<T>(bool clearConsole = true)
            where T : IChallenge, new()
        {
            T challenge = new T();

            challenge.Solve();
        }

        public static void Solve(Type type)
        {
            var c = LoadChallenges(Assembly.GetEntryAssembly()!);
            foreach (Type challengeType in c)
            {
                if (type.IsAssignableFrom(challengeType) && Activator.CreateInstance(challengeType) is IChallenge challenge)
                {
                    challenge.Solve();
                }
            }
        }

        private static IEnumerable<Type> LoadChallenges(Assembly assembly)
        {
            return assembly.GetTypes()
                .Where(type => typeof(IChallenge).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
        }
    }
}
