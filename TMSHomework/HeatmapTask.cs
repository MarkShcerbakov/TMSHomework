using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSHomework
{
    internal class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var data = names.Where(nd => nd.BirthDate.Day != 1);
            var xLabels = Enumerable.Range(2, 30).Select(x => $"{x}").ToArray();
            var yLabels = Enumerable.Range(1, 12).Select(x => $"{x}").ToArray();
            var heat = new double[30, 12];
            for (int day = 0; day < 30; day++)
                for (int month = 0; month < 12; month++)
                    heat[day, month] = data.Count(name => name.BirthDate.Day == day + 2 && name.BirthDate.Month == month + 1);
            return new HeatmapData("Пример карты интенсивностей", heat, xLabels, yLabels);
        }
    }
}
