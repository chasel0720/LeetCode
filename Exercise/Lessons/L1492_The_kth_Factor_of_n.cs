//https://leetcode.cn/problems/the-kth-factor-of-n/description/
namespace Exercise;
public class L1492_The_kth_Factor_of_n : LessonBase<(int n, int k), int>
{
    public override IEnumerable<((int n, int k) TestCase, int ExpectedResult)> TestCases =>
        [
            ((12,3),3),
            ((7,2),7),
            ((4,4),-1)
        ];

    public override int Run((int n, int k) testCase)
    {
        return FindKthFactor(testCase.n, testCase.k);
    }

    private int FindKthFactor(int n, int k)
    {
        int count = 0;
        for (int i = 1; i <= n / 2; i++)
        {
            if (n % i == 0)
            {
                count++;
                if (count == k)
                {
                    return i;
                }
            }
        }
        if (count == k - 1) // 添加edge case
        {
            return n;
        }
        return -1;
    }
}