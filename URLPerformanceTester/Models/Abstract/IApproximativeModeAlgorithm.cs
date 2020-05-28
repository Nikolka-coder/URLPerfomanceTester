using System.Collections.Generic;

namespace URLPerformanceTester.Models.Abstract
{
    public interface IApproximativeModeAlgorithm
    {
        int Mode(IEnumerable<int> collection, int intervalSize);
    }
}