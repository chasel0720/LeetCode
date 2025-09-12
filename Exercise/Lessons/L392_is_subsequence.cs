// https://leetcode.cn/problems/is-subsequence/?envType=study-plan-v2&envId=top-interview-150


namespace Exercise.Lessons;

public class L392_is_subsequence : LessonBase<(string s, string t), bool>
{
    public override IEnumerable<((string s, string t) TestCase, bool ExpectedResult)> TestCases => [
            (("abc","ahbgdc"), true),
            (("axc","ahbgdc"), false),
        ];

    public override bool Run((string s, string t) testCase)
    {
        return IsSubsequence(testCase.s, testCase.t);
    }

    private bool IsSubsequence(string s, string t)
    {
        int sIndex = 0, tIndex = 0;
        while (sIndex < s.Length && tIndex < t.Length)
        {
            if (s[sIndex] == t[tIndex])
            {
                sIndex++;
            }
            tIndex++;
        }
        return sIndex == s.Length;
    }
}
