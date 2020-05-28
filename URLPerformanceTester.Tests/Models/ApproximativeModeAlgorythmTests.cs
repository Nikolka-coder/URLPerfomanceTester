using URLPerformanceTester.Models.Concrete;
using Xunit;

namespace URLPerformanceTester.Tests.Models
{
    public class ApproximativeModeAlgorythmTests
    {
        [Theory]
        [InlineData(new[] {1, 20, 11, 12, 23, 23, 34, 65})]
        [InlineData(new[] {-133, 20, 11, 12, 23, 23, 34, 65})]
        public void ApproximativeModeAlgorythmTest(int[] collection)
        {
            //arrange
            var interval = 10;
            var alg = new ApproximativeModeAlgorithm();
            //act
            var result = alg.Mode(collection, interval);
            //assert
            Assert.True(result == 25);
        }
    }
}
