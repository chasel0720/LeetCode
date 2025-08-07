// https://leetcode.cn/problems/longest-common-prefix/

namespace Exercise;
public class L14_longest_common_prefix : LessonBase<string[], string>
{
    public override IEnumerable<(string[] TestCase, string ExpectedResult)> TestCases =>
    [
        (["flower","flow","flight"],"fl"),
        (["dog","racecar","car"],"")
    ];
    // public override bool NeedToRunSingle => false;

    public override string Run(string[] strs)
    {
        var result = "";
        int index = 0;
        var prefix = "";
        while (true)
        {
            for (int i = 0; i < strs.Length; i++)
            {
                if (index > strs[i].Length - 1)
                {
                    return result;
                }
                if (i == 0)
                {
                    prefix = strs[i][index].ToString();
                }
                else if (prefix != strs[i][index].ToString())
                {
                    return result;
                }
            }
            index++;
            result += prefix;
        }
    }
}