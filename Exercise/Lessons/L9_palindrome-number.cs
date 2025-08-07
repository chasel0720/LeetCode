// https://leetcode.cn/problems/palindrome-number/
namespace Exercise;
public class L9_palindrome_number : LessonBase<int, bool>
{
    public override IEnumerable<(int TestCase, bool ExpectedResult)> TestCases =>
    [
        (121,true),
        (-121, false),
        (10,false)
    ];
    public override bool Run(int testCase)
    {
        if (testCase < 0)
        {
            return false;
        }
        var str = testCase.ToString();
        for (int i = 0, j = str.Length - 1; i < str.Length && j >= 0; i++, j--)
        {
            if (str[i] != str[j])
            {
                return false;
            }
        }
        return true;
    }
}