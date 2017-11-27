using Xunit;
using Implementation.DataStructures.HashTable;
using System.Linq;

namespace implementation_test
{
    public class HTable_Should
    {
        private HTable hTable;
        public HTable_Should()
        {
            hTable = new HTable(5);
        }

        [Fact]
        public void CorrectlyAddAndGetNewItem()
        {
            hTable.Add(1,"one");
            hTable.Add(2, "two");

            var res1 = hTable.Get(1);
            var res2 = hTable.Get(2);
            Assert.Equal("one", res1);
            Assert.Equal("two", res2);
        }

        [Fact]
        public void CorrectlyUpdateAndGetExistingItem()
        {
            hTable.Add(1,"one");
            hTable.Add(1, "won");
            var res = hTable.Get(1);
            Assert.Equal("won", res);            
        }
    }
}