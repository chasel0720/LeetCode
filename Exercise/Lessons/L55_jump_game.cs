//https://leetcode.cn/problems/jump-game/description/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;
public class L55_jump_game : LessonBase<int[], bool>
{
    public override IEnumerable<(int[] TestCase, bool ExpectedResult)> TestCases =>
        [
            (new int[] { 5,0,2,1,0,3,0,1}, true),
            (new int[] { 1,2,0,1 }, true),
            (new int[] { 2,5,0,0 }, true),
            (new int[] { 1,0,1,0 }, false),
            (new int[] { 2, 3, 1, 1, 4 }, true),
            (new int[] { 3, 2, 1, 0, 4 }, false),
            (new int[] { 3, 2, 2, 0, 4 }, true),
            (new int[] { 0 }, true),
            (new int[] { 2, 0 }, true),
            (new int[] { 0, 1 }, false),
            (new int[] { 1, 2, 3 }, true),
            (new int[] { 1, 1, 0, 1 }, false),
        ];

    public override bool Run(int[] testCase)
    {
        return CanJump(testCase);
    }

    /* image the value as a stick, the length is it's value
     * and let these sticks fall from their points towards the end point. We find out if the longest point of the connected sticks can exceed the end
     */
    bool CanJump(int[] nums)
    {
        var maxLen = 0;
        var endPoint = nums.Length - 1;
        if (endPoint <= 0)
        {
            return true;
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (maxLen >= i)
            {
                maxLen = Math.Max(maxLen, i + nums[i]);
            }
            else
            {
                break;
            }
        }
        return maxLen >= endPoint;
    }


    /* try to calculate from end to start
     * if current position + jump length >= end point, then move end point to current position
     * else move to previous position
     * and the hard part is how to check whether can jump ignore point which value is 0.
     */
    //bool CanJump(int[] nums)
    //{
    //    var endPoint = nums.Length - 1;
    //    if (endPoint <= 0)
    //    {
    //        return true;
    //    }
    //    var jumpPoint = endPoint - 1;
    //    while (jumpPoint > 0)
    //    {
    //        if (endPoint <= 0)
    //        {
    //            break;
    //        }
    //        if (nums[jumpPoint] + jumpPoint >= endPoint && nums[jumpPoint] > 0 && nums[endPoint] > 0)
    //        {
    //            endPoint--;
    //        }
    //        jumpPoint--;
    //    }
    //    return endPoint <= jumpPoint ||
    //        (nums[jumpPoint] + jumpPoint >= endPoint && nums[endPoint] > 0);
    //}
}