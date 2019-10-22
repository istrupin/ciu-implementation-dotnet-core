using System.Linq;
using implementation.Algorithms;
using Xunit;
using Xunit.Abstractions;

namespace implementation_test.Algorithms
{
    public class KnapsackTests
    {
        private readonly ITestOutputHelper output;
        public KnapsackTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(new int[] { 10, 40, 30, 50 }, new int[] { 5, 4, 6, 3 },10,  50+40)]
        [InlineData(new int[] { 30, 50 }, new int[] {  3, 2 }, 5, 80)]
        public void KnapsackShouldReturnOptimizedValue(int[] itemValues, int[] itemWeights, int capacity, int expected){
            var knapsack = new Knapsack(itemValues, itemWeights, capacity);
            var res = knapsack.MaximizedValue;
            Assert.Equal(expected,res);
        }

        [Theory]
        [InlineData(new int[] { 10, 40, 30, 50 },new int[] { 5, 4, 6, 3 }, 10, new int[]{2,4} )]
        [InlineData(new int[] { 40, 100, 50, 60 }, new int[] {20, 10, 40, 30 }, 60, new int[] { 1, 2, 4 })]
        [InlineData(new int[] { 60, 100, 120 }, new int[] { 10, 20, 30 }, 50, new int[] { 2,3 })]
        public void KnapsackShouldReturnOptimizedSet(int[] itemValues, int[] itemWeights, int capacity, int[] expected)
        {
            var knapsack = new Knapsack(itemValues, itemWeights, capacity);
            var res = knapsack.GetSelectedItems().OrderBy(x => x);
            Assert.Equal(expected,res);
        }

    }
}