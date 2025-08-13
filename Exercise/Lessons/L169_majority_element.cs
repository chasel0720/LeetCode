//https://leetcode.cn/problems/majority-element/description/?envType=study-plan-v2&envId=top-interview-150


namespace Exercise;
public class L169_majority_element : LessonBase<int[], int>
{
    public override IEnumerable<(int[] TestCase, int ExpectedResult)> TestCases =>
        [
            ([3,2,3],3),
            ([2,2,1,1,1,2,2],2),
            ([3,3,4],3)
        ];

    public override int Run(int[] testCase)
    {
        return MajorityElement(testCase);
    }

    static int MajorityElement(int[] nums)
    {
        int element = int.MinValue;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (count <= 0)
            {
                element = nums[i];
                count = 1;
            }
            else
            {
                if (element != nums[i])
                {
                    count--;
                }
                else
                {
                    count++;
                }
            }
        }
        return element;
    }
}