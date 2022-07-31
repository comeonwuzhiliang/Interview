using System.Diagnostics.CodeAnalysis;

namespace Zack.Interview.Collection
{
    public static class CollectionExtension
    {
        // 两个集合交集问题（不使用双层循环）
        public static IEnumerable<T> TwoCollectionIntersection<T>([NotNull] this IEnumerable<T> arr1, [NotNull] IEnumerable<T> arr2) where T : notnull
        {
            if (!arr1.Any() || !arr2.Any())
            {
                yield break;
            }
            // 定义一个字典,将数据的元素当成字典的Key
            IDictionary<T, bool> arr1Dic = new Dictionary<T, bool>();
            foreach (var item in arr1)
            {
                arr1Dic.TryAdd(item, true);
            }

            foreach (var item in arr2)
            {
                // TryGetValue 源码地址：https://source.dot.net/#System.Private.CoreLib/Dictionary.cs,2e5bc6d8c0f21e67,references
                if (arr1Dic.TryGetValue(item, out bool value))
                {
                    //代表该元素是存在两个集合里面的
                    yield return item;
                }
            }
        }

        public static int DuplicateCollectionGrouping(this int[] arr, int sumMax)
        {
            // 计算前缀和
            var prefixSums = new int[arr.Length];

            prefixSums[0] = arr[0];

            for (var i = 1; i < arr.Length; i++)
            {
                prefixSums[i] = prefixSums[i - 1] + arr[i];
            }

            int groupNumber = 0;

            //利用滑动窗口的思路来计算
            int left = 0;
            int right = 0;

            while (right < arr.Length)
            {
                if (GetSum(left, right) <= sumMax)
                {
                    right++;
                }
                else
                {
                    left = right;
                    groupNumber++;
                }
            }

            return groupNumber + 1;

            //返回arr[from] + arr[from+1] + .... + arr[to]
            int GetSum(int from, int to)
            {
                if (from == 0)
                {
                    return prefixSums[to];
                }

                return prefixSums[to] - prefixSums[from - 1];
            }
        }
    }
}