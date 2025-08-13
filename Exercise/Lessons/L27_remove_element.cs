// https://leetcode.cn/problems/remove-element/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;
public class L27_remove_element : LessonBase<(int[] nums, int val), int>
{
    public override IEnumerable<((int[] nums, int val) TestCase, int ExpectedResult)> TestCases =>
        [
            (([3,2,2,3],3),2),
            (([0,1,2,2,3,0,4,2],2),5)
        ];

    public override int Run((int[] nums, int val) testCase)
    {
        return RemoveElement(testCase.nums, testCase.val);
    }

    static int RemoveElement(int[] nums, int val)
    {
        if (nums.Length <= 0)
        {
            return 0;
        }
        var tail = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] == val)
            {
                var temp = nums[tail];
                nums[tail--] = nums[i];
                nums[i] = temp;
            }
        }
        return tail + 1;
    }
}