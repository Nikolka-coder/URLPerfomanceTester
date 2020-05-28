using System.Collections.Generic;
using System.Linq;
using URLPerformanceTester.Models.Abstract;

namespace URLPerformanceTester.Models.Concrete
{
    public class ApproximativeModeAlgorithm : IApproximativeModeAlgorithm
    {
        public int Mode(IEnumerable<int> collection, int intervalSize)
        {
            var intervals = new Dictionary<int, int>();
            foreach (var el in collection)
            {
                var interval = el/intervalSize;
                if (intervals.ContainsKey(interval)) intervals[interval]++;
                else intervals.Add(interval, 1);
            }
            var maxInterval = intervals.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            var mode = maxInterval*intervalSize + (intervalSize/2);
            return mode;
        }
    }
}