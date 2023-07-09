using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Models;

namespace TestRailFinalTask.Utilities.Helpers
{
    public class TestDataHelper
    {
        public static Section GetTestSection(string FileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar + FileName);
            return JsonHelper.FromJson(json).ToObject<Section>();
        }

        public static Milestone GetTestMilestone(string FileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar + FileName);
            return JsonHelper.FromJson(json).ToObject<Milestone>();
        }
    }
}
