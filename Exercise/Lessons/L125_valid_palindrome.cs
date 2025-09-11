// https://leetcode.cn/problems/valid-palindrome/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;
public class L125_valid_palindrome : LessonBase<string, bool>
{
    public override IEnumerable<(string TestCase, bool ExpectedResult)> TestCases => [
        ("A man, a plan, a canal: Panama",true),
        ("race a car", false),
        (" ",true)
        ];

    public override bool Run(string testCase)
    {
        return IsPalindrome(testCase);
    }

    private bool IsPalindrome(string s)
    {
        var chars = s.ToLower().Replace(" ", "").Where(x => ((int)x >= 97 && (int)x <= 122) || ((int)x >= 48 && (int)x <= 57)).ToArray();
        if (chars.Length == 0)
        {
            return true;
        }
        int i = 0, j = chars.Length - 1;
        while (i < j)
        {
            if (chars[i] != chars[j])
            {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }
}