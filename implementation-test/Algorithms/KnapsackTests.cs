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

        [Fact]
        public void KnapsackShouldReturnOptimizedValueSimple()
        {
            int[] itemValues = new int[] {  30, 50 };
            int[] itemWeights = new int[] { 3, 2 };
            int capacity = 5;

            var knapsack = new Knapsack(itemValues, itemWeights, capacity);
            var res = knapsack.MaximizedValue;
            Assert.Equal(80, res);
        }

        [Fact]
        public void KnapsackShouldReturnOptimizedValue(){
            int[] itemValues = new int[]{ 10, 40, 30, 50  };
            int[] itemWeights = new int[] { 5, 4, 6, 3 };
            int capacity = 10;
            
            var knapsack = new Knapsack(itemValues, itemWeights, capacity);
            var res = knapsack.MaximizedValue;
            Assert.Equal(50+40,res);
        }

        [Fact]
        public void KnapsackShouldReturnOptimizedSet()
        {
            int[] itemValues = new int[] { 10, 40, 30, 50 };
            int[] itemWeights = new int[] { 5, 4, 6, 3 };
            int capacity = 10;

            var knapsack = new Knapsack(itemValues, itemWeights, capacity);
            var res = knapsack.GetSelectedItems().OrderBy(x => x);
            Assert.Equal(new[]{2,4}.OrderBy(x => x),res);
        }

        [Fact]
        public void KnapsackShouldReturnOptimizedSet2()
        {
            int[] itemValues = new int[] { 40, 100, 50, 60 };
            int[] itemWeights = new int[] { 20, 10, 40, 30 };
            int capacity = 60;

            var knapsack = new Knapsack(itemValues, itemWeights, capacity);
            var res = knapsack.GetSelectedItems().OrderBy(x => x);
            Assert.Equal(new[] { 1, 2, 4  }.OrderBy(x => x), res);
        }

        [Fact]
        public void KnapsackShouldReturnOptimizedSet3()
        {
            int[] itemValues = new int[] { 60, 100, 120 };
            int[] itemWeights = new int[] { 10, 20, 30 };
            int capacity = 50;

            var knapsack = new Knapsack(itemValues, itemWeights, capacity);
            var res = knapsack.GetSelectedItems().OrderBy(x => x);
            Assert.Equal(new[] {  2, 3 }.OrderBy(x => x), res);
        }


    }
}