// https://leetcode.cn/problems/roman-to-integer/description/

namespace Exercise;
public class L13_roman_to_integer : LessonBase<string, int>
{
    public override IEnumerable<(string TestCase, int ExpectedResult)> TestCases =>
    [
        ("III",3),
        ("IV",4),
        ("IX",9),
        ("LVIII",58),
        ("MCMXCIV",1994),
        ("MMXXIII",2023),
        ("XLII",42),
        ("CDXLIV",444)
    ];
    public override bool NeedToRunSingle => false;
    public override int Run(string testCase)
    {
        char[] chars = testCase.ToCharArray();
        Dictionary<char, int> map = new()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
        var result = 0;
        var left = 0;
        for (int i = 0; i < chars.Length; i++)
        {
            var c = chars[i];
            var v = map[c];

            result += v;
            if (left < v)
            {
                result -= 2 * left;
            }
            left = v;
        }
        return result;
    }
}