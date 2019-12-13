using System.Linq;
using FluentAssertions;
using implementation.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace implementation_test.Algorithms
{
    public class ParenFinderTests
    {
        private readonly ITestOutputHelper output;
        public ParenFinderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ParenFinderFindsSinglePair()
        {
            var res = ParenFinder.ShowParens(1);
            output.WriteLine(res.FirstOrDefault());
            res.Should().HaveCount(1);
            res.Single().Should().Contain("()");
        }

        
        [Fact]
        public void ParenFinderFindsTwoPairs()
        {
            var res = ParenFinder.ShowParens(2);
            foreach (var item in res)
            {
                output.WriteLine(item);
            }
            res.Should().HaveCount(2);
        }


    }
}