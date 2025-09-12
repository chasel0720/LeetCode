//https://leetcode.cn/problems/jump-game-ii/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;

public class L45_jump_game_ii : LessonBase<int[], int>
{
    public override IEnumerable<(int[] TestCase, int ExpectedResult)> TestCases => [
            ([2,3,1,1,4], 2),
            ([2,3,0,1,4], 2)
        ];

    public override int Run(int[] testCase)
    {
        return Jump(testCase);
    }

    /* as the desc, it makes sure that the end point is reachable
     */
    int Jump(int[] nums)
    {
        var jumps = 0;
        var endPoint = 0;
        if (nums.Length <= 1)
        {
            return 0;
        }
        var maxLen = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            maxLen = Math.Max(i + nums[i], maxLen);
            if (i == endPoint)
            {
                jumps++;
                endPoint = maxLen;
                if (endPoint >= nums.Length - 1)
                {
                    break;
                }
            }
        }
        return jumps;
    }
}