// https://leetcode.cn/problems/merge-sorted-array/description/?envType=study-plan-v2&envId=top-interview-150
namespace Exercise;
public class L88_merge_sorted_array : LessonBase<(int[] nums1, int m, int[] nums2, int n), string>
{
    public override IEnumerable<((int[] nums1, int m, int[] nums2, int n) TestCase, string ExpectedResult)> TestCases =>
        [
            (([1,2,3,0,0,0], 3, [2,5,6], 3),
        "[1,2,2,3,5,6]"),
            (([1], 1, [], 0),
        "[1]"),
            (([0], 0, [1], 1),
        "[1]"),
             (([4,0,0,0,0,0], 1, [1,2,3,5,6], 5),
        "[1,2,3,4,5,6]"),
        ];


    public override string Run((int[] nums1, int m, int[] nums2, int n) testCase)
    {
        Merge(testCase.nums1, testCase.m, testCase.nums2, testCase.n);
        return testCase.nums1.ToJsonString();
    }

    static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (n == 0)
        {
            return;
        }
        if (m == 0)
        {
            Array.Copy(nums2, nums1, n);
            return;
        }
        int cur1 = m - 1;
        int cur2 = n - 1;
        int cur = m + n - 1;
        while (cur >= 0)
        {
            var val = 0;
            if (cur1 < 0)
            {
                val = nums2[cur2--];
            }
            else if (cur2 < 0)
            {
                val = nums1[cur1--];
            }
            else if (nums1[cur1] > nums2[cur2])
            {
                val = nums1[cur1--];
            }
            else
            {
                val = nums2[cur2--];
            }
            nums1[cur--] = val;
        }
    }
}