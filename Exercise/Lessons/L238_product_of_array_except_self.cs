// https://leetcode.cn/problems/product-of-array-except-self/description/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;
public class L238_product_of_array_except_self : LessonBase<int[], string>
{
    public override IEnumerable<(int[] TestCase, string ExpectedResult)> TestCases =>
        [
            ([1,2,3,4],"[24,12,8,6]"),
            ([-1,1,0,-3,3],"[0,0,9,0,0]")
        ];

    public override string Run(int[] testCase)
    {
        return ProductExceptSelf(testCase).ToJsonString();
    }

    int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        result[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }
        var right = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            result[i] = result[i] * right;
            right *= nums[i];
        }
        return result;
    }
}