// https://leetcode.cn/problems/remove-duplicates-from-sorted-array-ii/description/?envType=study-plan-v2&envId=top-interview-150


namespace Exercise;
public class L80_remove_duplicates_from_sorted_array_ii : LessonBase<int[], int>
{
    public override IEnumerable<(int[] TestCase, int ExpectedResult)> TestCases =>
        [
            ([1,1,1,2,2,3],5),
            ([0,0,1,1,1,1,2,3,3], 7)
        ];
    public override int Run(int[] testCase)
    {
        return RemoveDuplicates(testCase);
    }

    int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 2)
            return nums.Length;

        int slow = 2;
        int fast = 2;
        while (fast < nums.Length)
        {
            if (nums[slow - 2] != nums[fast])
            {
                nums[slow] = nums[fast];
                slow++;
            }
            fast++;
        }
        Console.WriteLine(nums.ToJsonString());
        return slow;
    }
}