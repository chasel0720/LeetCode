// https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-ii/description/?envType=study-plan-v2&envId=top-interview-150


using System.Reflection;

namespace Exercise;
public class L122_best_time_to_buy_and_sell_stock_ii : LessonBase<int[], int>
{
    public override IEnumerable<(int[] TestCase, int ExpectedResult)> TestCases =>
        [
            ([7,1,5,3,6,4], 7),
            ([1,2,3,4,5], 4),
            ([7,6,4,3,1], 0),
            ([1,2,3], 2),
            ([3,2,1], 0),
            ([1,2,3,4], 3),
            ([1], 0),
            ([2,1], 0),
            ([1,2], 1),
            ([5,4,3,2,1], 0)

        ];

    public override int Run(int[] testCase)
    {
        return MaxProfit(testCase);
    }

    static int MaxProfit(int[] prices)
    {
        int profit = 0;
        int allProfit = 0;
        var minPrice = -1;
        if (prices.Length == 1)
        {
            return 0;
        }
        if (prices.Length == 2)
        {
            return Math.Max(0, prices[1] - prices[0]);
        }
        /* if today greater than yesterday, buy yesterday, and mark as minPrice
         * then mark profit as today - yesterday.
         * if tomorrow less than today, seals at today and then set minPrice as tomorrow
         * else if tomorrow greater than today, mark profit as tomorrow - minPrice
         */
        for (int i = 1; i < prices.Length; i++)
        {
            if (minPrice < 0)
            {
                if (prices[i - 1] < prices[i])
                {
                    minPrice = prices[i - 1];
                    profit = prices[i] - prices[i - 1];
                }
            }
            else
            {
                if (prices[i - 1] < prices[i])
                {
                    profit += prices[i] - prices[i - 1];
                }
                else
                {
                    allProfit += profit;
                    profit = 0;
                    minPrice = prices[i];
                }
            }
        }
        allProfit += profit;
        return allProfit;
    }
}