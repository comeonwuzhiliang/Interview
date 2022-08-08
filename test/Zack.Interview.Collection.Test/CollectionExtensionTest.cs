using System.Linq;
using Xunit;

namespace Zack.Interview.Collection.Test
{
    public class CollectionExtensionTest
    {
        [Fact(DisplayName = "�������������û��Ԫ��")]
        public void TwoCollectionNoElement()
        {
            var arr1 = new int[] { };
            var arr2 = new int[] { };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.Empty(intersection);
        }

        [Fact(DisplayName = "����һ�����������û��Ԫ��")]
        public void ACollectionNoElement()
        {
            var arr1 = new int[] { };
            var arr2 = new int[] { 4, 5, 6 };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.Empty(intersection);
        }

        [Fact(DisplayName = "������������û�н���")]
        public void TwoCollectionNoIntersection()
        {
            var arr1 = new int[] { 1, 2, 3 };
            var arr2 = new int[] { 4, 5, 6 };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.Empty(intersection);
        }

        [Fact(DisplayName = "��������������һ������")]
        public void TwoCollectionIntersectionOnlyOne()
        {
            var arr1 = new int[] { 1, 2, 3, 4 };
            var arr2 = new int[] { 4, 5, 6 };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.True(intersection.Count() == 1);

            Assert.True(intersection.First() == 4);
        }

        [Fact(DisplayName = "�������������ж������")]
        public void TwoCollectionIntersectionHaveMany()
        {
            var arr1 = new int[] { 1, 2, 3, 4, 5 };
            var arr2 = new int[] { 4, 5, 6 };

            var intersection = arr1.TwoCollectionIntersection(arr2);

            Assert.True(intersection.Count() == 2);

            Assert.True(intersection.First() == 4 && intersection.Last() == 5);
        }

        [Fact(DisplayName = "���Ϸ���")]
        public void DuplicateCollectionGrouping()
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 5, 5, 4 };
            var groupNumbers = arr.DuplicateCollectionGrouping(10);
        }

    }
}