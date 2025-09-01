// https://leetcode.cn/problems/h-index/?envType=study-plan-v2&envId=top-interview-150



namespace Exercise;
public class L274_h_index : LessonBase<int[], int>
{
    public override IEnumerable<(int[] TestCase, int ExpectedResult)> TestCases =>
        [
            ([3,0,6,1,5], 3),
            ([1,3,1], 1),
            ([0,0,0], 0),
            ([100], 1),
            ([11,15], 2)
        ];

    public override int Run(int[] testCase)
    {
        return HIndex(testCase);
    }

    int HIndex(int[] citations)
    {
        Array.Sort(citations);
        for (int i = 0; i < citations.Length; i++)
        {
            if (citations[i] >= citations.Length - i)
            {
                return citations.Length - i;
            }
        }
        return 0;
    }
}