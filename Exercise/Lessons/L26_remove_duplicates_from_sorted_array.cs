// https://leetcode.cn/problems/remove-duplicates-from-sorted-array/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;
public class L26_remove_duplicates_from_sorted_array : LessonBase<int[], int>
{
    public override IEnumerable<(int[] TestCase, int ExpectedResult)> TestCases =>
        [
            ([1,1,2],2),
            ([0,0,1,1,1,2,2,3,3,4],5)
        ];

    public override int Run(int[] testCase)
    {
        return RemoveDuplicates(testCase);
    }

    static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 1)
            return nums.Length;
        int i = 1;
        int j = 1;
        while (j < nums.Length)
        {
            if (nums[j] != nums[j - 1])
            {
                nums[i] = nums[j];
                i++;
            }
            j++;
        }

        return i;
    }
}