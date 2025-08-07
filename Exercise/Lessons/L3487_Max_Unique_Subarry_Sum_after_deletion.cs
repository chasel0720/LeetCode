//https://leetcode.cn/problems/maximum-unique-subarray-sum-after-deletion/description/
namespace Exercise;

class L3487_Max_Unique_Subarry_Sum_after_deletion : LessonBase<int[], int>
{
    public override IEnumerable<(int[] TestCase, int ExpectedResult)> TestCases => [
        (new[] { 1, 2, 3, 4, 5 }, 15),
        (new[] { 1, 2, 2, 3, 4 }, 10),
        (new[] { -1, 0, 1,2 }, 3),
        (new[] { 5, 5, 5, 5 }, 5),
        (new[] { -1, -2, -3 }, -1),
        (new[] { -1, -2, -2, -3 }, -1)
    ];
    public override bool NeedToRunSingle => false;
    public override int Run(int[] testCase)
    {
        HashSet<int> positiveNumsSet = new HashSet<int>();
        foreach (int num in testCase)
        {
            if (num > 0)
            {
                positiveNumsSet.Add(num);
            }
        }
        if (positiveNumsSet.Count == 0)
        {
            return testCase.Max();
        }
        return positiveNumsSet.Sum();
    }
}
