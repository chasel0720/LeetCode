// https://leetcode.cn/problems/best-time-to-buy-and-sell-stock/?envType=study-plan-v2&envId=top-interview-150

namespace Exercise;
public class L121_best_time_to_buy_and_sell_stock : LessonBase<int[], int>
{
    public override IEnumerable<(int[] TestCase, int ExpectedResult)> TestCases =>
        [
            ([7,1,5,3,6,4], 5),
            ([7,3,5,1,6,4], 5),
            ([7,6,4,3,1], 0),
            ([3,2,6,5,0,3],4),
            ([1,2],1),
            ([1,4,3],3)
        ];

    public override int Run(int[] testCase)
    {
        return MaxProfit(testCase);
    }
    int MaxProfit(int[] prices)
    {
        int profit = 0;
        var minPrice = -1;
        if (prices.Length == 1)
        {
            return 0;
        }
        if (prices.Length == 2)
        {
            return Math.Max(0, prices[1] - prices[0]);
        }
        for (int i = 1; i < prices.Length; i++)
        {
            if (minPrice < 0)
            {
                if (prices[i - 1] < prices[i])
                {
                    minPrice = prices[i - 1];
                    profit = prices[i] - prices[i - 1];
                }
                else
                {
                    minPrice = prices[i];
                }
            }
            else
            {
                if (prices[i] > minPrice)
                {
                    profit = Math.Max(prices[i] - minPrice, profit);
                }
                else
                {
                    minPrice = prices[i];
                }
            }
        }
        return profit;
    }
}