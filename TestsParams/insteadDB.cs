using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsParams.Model;

namespace TestsParams
{
    static class InsteadDB
    {
        public static IEnumerable<Tests> GetTests()
        {
            return tes;
        }

        public static IEnumerable<Parameters> GetParametrs(Tests test)
        {
            var pars = from p in par
                where p.TestId == test.TestId
                select p;
           return pars.ToList();
        }

        public static void AddTest(Tests test)
        {
            int id = GetNextTestId();
            test.TestId = id;
            tes.Add(test);
            if (test.Parameters.Count > 0)
            {
                foreach (var p in test.Parameters)
                {
                    AddParam(test, p);
                }
            }
        }

        public static void AddParam(Tests test, Parameters param)
        {
            var x = par.Max(n => n.ParametrId);
            param.ParametrId = x + 1;
            param.TestId = test.TestId;
            par.Add(param);
        }

        public static void DeleteTest(Tests test)
        {
            if (!tes.Contains(test))
                return;

            foreach (var p in GetParametrs(test))
            {
                DeleteParameter(p);
            }
            tes.Remove(test);
        }

        public static void DeleteParameter(Parameters param)
        {
            if (par.Contains(param))
                par.Remove(param);
        }

        private static int GetNextTestId()
        {
            var x = tes.Max(n => n.TestId);
            x++;
            return x;
        }

        private static List<Tests> tes = new List<Tests>
        {
            new Tests { TestId = 0, BlockName = "Тест №0", Note = "это тест записки номер №0 для теста", TestDate = DateTime.Parse("25.04.2015") },
            new Tests { TestId = 1, BlockName = "Тест №1", Note = "это тест записки номер №1 для теста", TestDate = DateTime.Parse("15.07.2015") },
            new Tests { TestId = 2, BlockName = "Тест №2", Note = "это тест записки номер №2 для теста", TestDate = DateTime.Parse("04.12.2015") },
            new Tests { TestId = 3, BlockName = "Тест №3", Note = "это тест записки номер №3 для теста", TestDate = DateTime.Parse("25.01.2016") },
            new Tests { TestId = 4, BlockName = "Тест №4", Note = "это тест записки номер №4 для теста", TestDate = DateTime.Parse("17.06.2017") }
        };

        private static List<Parameters> par = new List<Parameters>
        {
            new Parameters { TestId = 0, ParametrId = 0,  ParameterName = "Параметра №0",  MeasuredValue = 0,  RequiredValue = 0, },
            new Parameters { TestId = 0, ParametrId = 1,  ParameterName = "Параметра №1",  MeasuredValue = 10, RequiredValue = 10 },
            new Parameters { TestId = 0, ParametrId = 2,  ParameterName = "Параметра №2",  MeasuredValue = 20, RequiredValue = 20 },
            new Parameters { TestId = 1, ParametrId = 3,  ParameterName = "Параметра №3",  MeasuredValue = 30, RequiredValue = 30 },
            new Parameters { TestId = 1, ParametrId = 4,  ParameterName = "Параметра №4",  MeasuredValue = 40, RequiredValue = 40 },
            new Parameters { TestId = 2, ParametrId = 5,  ParameterName = "Параметра №5",  MeasuredValue = 50, RequiredValue = 50 },
            new Parameters { TestId = 2, ParametrId = 6,  ParameterName = "Параметра №6",  MeasuredValue = 60, RequiredValue = 60 },
            new Parameters { TestId = 3, ParametrId = 7,  ParameterName = "Параметра №7",  MeasuredValue = 70, RequiredValue = 70 },
            new Parameters { TestId = 4, ParametrId = 8,  ParameterName = "Параметра №8",  MeasuredValue = 80, RequiredValue = 80 },
            new Parameters { TestId = 4, ParametrId = 9,  ParameterName = "Параметра №9",  MeasuredValue = 90, RequiredValue = 90 },
            new Parameters { TestId = 4, ParametrId = 10, ParameterName = "Параметра №10", MeasuredValue = 10, RequiredValue = 10 },
            new Parameters { TestId = 4, ParametrId = 11, ParameterName = "Параметра №11", MeasuredValue = 20, RequiredValue = 20 },
            new Parameters { TestId = 2, ParametrId = 12, ParameterName = "Параметра №12", MeasuredValue = 30, RequiredValue = 30 },
            new Parameters { TestId = 1, ParametrId = 13, ParameterName = "Параметра №13", MeasuredValue = 40, RequiredValue = 40 },
            new Parameters { TestId = 0, ParametrId = 14, ParameterName = "Параметра №14", MeasuredValue = 50, RequiredValue = 50 },
            new Parameters { TestId = 1, ParametrId = 15, ParameterName = "Параметра №15", MeasuredValue = 60, RequiredValue = 60 },
            new Parameters { TestId = 4, ParametrId = 16, ParameterName = "Параметра №16", MeasuredValue = 70, RequiredValue = 70 },

        };
    }
}
