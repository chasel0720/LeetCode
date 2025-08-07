// https://leetcode.cn/problems/longest-common-prefix/

namespace Exercise;
public class L14_longest_common_prefix : LessonBase<string[], string>
{
    public override IEnumerable<(string[] TestCase, string ExpectedResult)> TestCases =>
    [
        (["flower","flow","flight"],"fl"),
        (["dog","racecar","car"],"")
    ];
    // public override bool NeedToRunSingle => true;

    public override string Run(string[] testCase)
    {
        throw new NotImplementedException();
    }
}