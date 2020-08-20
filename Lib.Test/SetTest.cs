using Xunit;

namespace Lib.Test
{
    public class SetTest
    {
        [Fact]
        public void GetLength()
        {
            var set = new Set<string>();

            Assert.Equal(0, set.Length);
        }

        [Fact]
        public void AddItem()
        {
            var set = new Set<string>();

            set.Add("foo");

            Assert.Equal(1, set.Length);
        }

        [Fact]
        public void AddExistingItemShouldNotChangeLength()
        {
            var set = new Set<int>();

            set.Add(1);
            set.Add(1);

            Assert.Equal(1, set.Length);
        }

        [Fact]
        public void GetItemByIndex()
        {
            var set = new Set<string>();

            set.Add("foo");

            Assert.Equal("foo", set[0]);
        }

        [Fact]
        public void SortItems()
        {
            var set = new Set<int>();

            set.Add(2);
            set.Add(1);
            set.Add(0);
            set.Add(1);

            set.Sort(Compare);

            Assert.Equal(0, set[0]);
            Assert.Equal(1, set[1]);
            Assert.Equal(1, set[2]);
            Assert.Equal(2, set[3]);

            Comparison Compare(int left, int right)
            {
                if (left > right) return Comparison.Greater;
                if (left < right) return Comparison.Lesser;
                return Comparison.Equal;
            }
        }

        [Fact]
        public void SortItemsDescending()
        {
            var set = new Set<int>();

            set.Add(0);
            set.Add(1);
            set.Add(2);
            set.Add(1);

            set.Sort(Compare);

            Assert.Equal(0, set[3]);
            Assert.Equal(1, set[2]);
            Assert.Equal(1, set[1]);
            Assert.Equal(2, set[0]);

            Comparison Compare(int left, int right)
            {
                if (left > right) return Comparison.Lesser;
                if (left < right) return Comparison.Greater;
                return Comparison.Equal;
            }
        }
    }
}
