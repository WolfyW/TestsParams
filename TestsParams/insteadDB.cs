using System.Collections.Generic;
using TestsParams.Model;

namespace TestsParams
{
    static class InsteadDB
    {
        private static TestContext _DBcontext = new TestContext();

        public static IEnumerable<Tests> GetTests()
        {
            return _DBcontext.Tests;
        }

        public static void AddTest(Tests test)
        {
            _DBcontext.Tests.Add(test);
            foreach (var p in test.Parameters)
            {
                AddParameter(p);
            }
            SaveChanges();
        }

        public static void DeleteTest(Tests test)
        {
            _DBcontext.Tests.Remove(test);
            SaveChanges();
        }

        public static void AddParameter(Parameters param)
        {
            _DBcontext.Parameters.Add(param);
            SaveChanges();
        }

        public static void DeleteParameter(Parameters param)
        {
            _DBcontext.Parameters.Remove(param);
            SaveChanges();
        }

        public static void SaveChanges()
        {
            _DBcontext.SaveChanges();
        }

    }
}
