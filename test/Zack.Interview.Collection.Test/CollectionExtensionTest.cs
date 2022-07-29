using System.Linq;
using Xunit;

namespace Zack.Interview.Collection.Test
{
    public class CollectionExtensionTest
    {
        [Fact(DisplayName = "两个集合里面的没有元素")]
        public void TwoCollectionNoElement()
        {
            var arr1 = new int[] { };
            var arr2 = new int[] { };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.Empty(intersection);
        }

        [Fact(DisplayName = "其中一个集合里面的没有元素")]
        public void ACollectionNoElement()
        {
            var arr1 = new int[] { };
            var arr2 = new int[] { 4, 5, 6 };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.Empty(intersection);
        }

        [Fact(DisplayName = "两个集合里面没有交集")]
        public void TwoCollectionNoIntersection()
        {
            var arr1 = new int[] { 1, 2, 3 };
            var arr2 = new int[] { 4, 5, 6 };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.Empty(intersection);
        }

        [Fact(DisplayName = "两个集合里面有一个交集")]
        public void TwoCollectionIntersectionOnlyOne()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 4, 5, 6 };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.True(intersection.Count() == 1);

            Assert.True(intersection.First() == 4);
        }

        [Fact(DisplayName = "两个集合里面有多个交集")]
        public void TwoCollectionIntersectionHaveMany()
        {
            var arr1 = new int[] { 1, 2, 3, 4, 5 };
            var arr2 = new int[] { 4, 5, 6 };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.True(intersection.Count() == 2);

            Assert.True(intersection.First() == 4 && intersection.Last() == 5);
        }

    }
}