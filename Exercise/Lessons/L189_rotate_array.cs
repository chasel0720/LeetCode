// https://leetcode.cn/problems/rotate-array/description/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;
public class L189_rotate_array : LessonBase<(int[] nums, int k), string>
{
    public override IEnumerable<((int[] nums, int k) TestCase, string ExpectedResult)> TestCases =>
        [
            (([1,2,3,4,5,6,7,8,9,10,11],3),"[9,10,11,1,2,3,4,5,6,7,8]"),
            (([1,2,3,4,5,6,7],3), "[5,6,7,1,2,3,4]"),
            (([-1,-100,3,99],2),"[3,99,-1,-100]")
        ];

    public override string Run((int[] nums, int k) testCase)
    {
        Rotate3(testCase.nums, testCase.k);
        return testCase.nums.ToJsonString();
    }

    //// reference from leetcode
    static void Rotate3(int[] nums, int k)
    {
        static void reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }
        k %= nums.Length;
        reverse(nums, 0, nums.Length - 1);
        reverse(nums, 0, k - 1);
        reverse(nums, k, nums.Length - 1);
    }

    //// reference from leetcode
    //static void Rotate2(int[] nums, int k)
    //{
    //    if (k == 0 || k == nums.Length)
    //    {
    //        return;
    //    }
    //    if (k > nums.Length)
    //    {
    //        k = k % nums.Length;
    //    }
    //    static int GCD(int x, int y) => y > 0 ? GCD(y, x % y) : x;
    //    int count = GCD(nums.Length, k);
    //    for (int start = 0; start < count; ++start)
    //    {
    //        int current = start;
    //        int prev = nums[start];
    //        do
    //        {
    //            int next = (current + k) % nums.Length;
    //            int temp = nums[next];
    //            nums[next] = prev;
    //            prev = temp;
    //            current = next;
    //        } while (start != current);
    //    }
    //}

    //// rotate force, so it is O(n*k), out of time limit for large test case
    //static void Rotate1(int[] nums, int k)
    //{
    //    if (k == 0 || k == nums.Length)
    //    {
    //        return;
    //    }
    //    if (k > nums.Length)
    //    {
    //        k = k % nums.Length;
    //    }
    //    for (int j = 0; j < k; j++)
    //    {
    //        for (int i = nums.Length - 1; i > 0; i--)
    //        {
    //            var tar = (i + 1) % nums.Length;
    //            var temp = nums[i];
    //            nums[i] = nums[tar];
    //            nums[tar] = temp;
    //        }
    //    }
    //}
}