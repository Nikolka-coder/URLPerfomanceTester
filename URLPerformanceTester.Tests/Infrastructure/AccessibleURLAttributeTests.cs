using Xunit;
using URLPerformanceTester.Infrastructure;

namespace URLPerformanceTester.Tests.Infrastructure
{
    public class AccessibleURLAttributeTests
    {
        [Fact]
        public void ValidURLTest()
        {
            //arrage
            var url = "ukad-group.com";
            var attr = new AccessibleURLAttribute();
            //act
            var result = attr.IsValid(url);
            //assert
            Assert.True(result);
        }
        [Fact]
        public void InvalidURLTest()
        {
            //arrage
            var url = "https://www.ukad-gr.com/";
            var attr = new AccessibleURLAttribute();
            //act
            var result = attr.IsValid(url);
            //assert
            Assert.False(result);
        }
    }
}
