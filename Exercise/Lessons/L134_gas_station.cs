// https://leetcode.cn/problems/gas-station/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;
public class L134_gas_station : LessonBase<(int[] gas, int[] cost), int>
{
    public override IEnumerable<((int[] gas, int[] cost) TestCase, int ExpectedResult)> TestCases => [
            (([5,8,2,8], [6,5,6,6]),3),
            (([3,1,1],[1,2,2]),0),
            (([1,2,3,4,5],[3,4,5,1,2]),3),
            (([2,3,4],[3,4,3]),-1),
        ];
    public override int Run((int[] gas, int[] cost) testCase)
    {
        return CanCompleteCircuit(testCase.gas, testCase.cost);
    }

    /*
     * if it always has the single answer while it has an answer
     * we can find out the min value of (gas - cost), it should be the start point
     * if the total value of (gas - cost) < 0, it means no answer, or the min value + 1 should be the answer
     * the (result + 1) means we can start from the next station to gain the most gas before we reach the min value station
     * (result + 1) % len means if the min value is the last station, we should start from the first station
     */
    int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int result = -1;
        var len = gas.Length;
        int minValue = int.MaxValue;
        int leftAfterLoop = 0;
        for (int i = 0; i < len; i++)
        {
            leftAfterLoop += gas[i] - cost[i];
            if (leftAfterLoop < minValue)
            {
                minValue = leftAfterLoop;
                result = i;
            }
        }
        return leftAfterLoop < 0 ? -1 : (result + 1) % len;
    }
}