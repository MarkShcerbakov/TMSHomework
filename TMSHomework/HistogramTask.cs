using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var data = names.Where(nd => nd.Name == name && nd.BirthDate.Day != 1);
            var peoplePerDay = new double[31].Select((_, day) => data.Count(nd => nd.BirthDate.Day == day + 1) + 0D).ToArray();
            var days = numerable.Range(1, 31).Select(x => $"{x}").ToArray();
            return new HistogramData($"Рождаемость людей с именем '{name}'", days, peoplePerDay);
        }
    }
}
