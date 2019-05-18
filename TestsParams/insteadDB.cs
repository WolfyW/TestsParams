using System.Collections.Generic;
using TestsParams.Model;

namespace TestsParams
{
    static class InsteadDB
    {
        private static TestContext context = new TestContext();

        public static IEnumerable<Tests> GetTests()
        {
            return context.Tests;
        }

        public static void AddTest(Tests test)
        {
            context.Tests.Add(test);
            foreach (var p in test.Parameters)
            {
                AddParameter(p);
            }
            SaveChanges();
        }

        public static void DeleteTest(Tests test)
        {
            context.Tests.Remove(test);
            SaveChanges();
        }

        public static void AddParameter(Parameters param)
        {
            context.Parameters.Add(param);
            SaveChanges();
        }

        public static void DeleteParameter(Parameters param)
        {
            context.Parameters.Remove(param);
            SaveChanges();
        }

        public static void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
