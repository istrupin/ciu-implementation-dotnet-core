using System.Linq;
using implementation.Algorithms;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;


namespace implementation_test.Algorithms
{
    public class SortedArrayMergerTests
    {

        [Theory]
        [InlineData(new int[] { 1,3,4,5 }, new int[] { 2,4,6,8 })]
        [InlineData(new int[] { 10, 10, 10, 15, 20, 20, 25, 25, 30, 7000}, new int[] {10, 15, 20, 20, 27, 7200 })]

        public void SorterCanSortNaive(int[] arr1, int[] arr2){
            var res = SortedArrayMerger.MergeNaive(arr1, arr2);
            var reverseRes = SortedArrayMerger.MergeNaive(arr2, arr1);
            res.Should().BeEquivalentTo(arr1.Concat(arr2).OrderBy(x => x));
            reverseRes.Should().BeEquivalentTo(arr1.Concat(arr2).OrderBy(x => x));
        }



    }
}