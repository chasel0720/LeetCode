namespace Exercise;
public abstract class LessonBase<TTestCase, TResult> : ILesson<TTestCase, TResult>
{
    public abstract IEnumerable<(TTestCase TestCase, TResult ExpectedResult)> TestCases { get; }
    public abstract TResult Run(TTestCase testCase);

    public void RunAllTestCases()
    {
        var testCases = TestCases.ToArray();

        for (int i = 0; i < testCases.Length; i++)
        {
            var testCase = testCases[i].TestCase;
            var expected = testCases[i].ExpectedResult;
            TimeSpan timeSpan = TimeSpan.Zero;
            var startTime = DateTime.Now;
            try
            {
                var actual = Run(testCase);
                timeSpan = DateTime.Now - startTime;
                var isSuccess = EqualityComparer<TResult>.Default.Equals(actual, expected);

                LogResult(i + 1, testCase, expected, actual, isSuccess, timeSpan);
            }
            catch (Exception ex)
            {
                timeSpan = DateTime.Now - startTime;
                LogError(i + 1, testCase, expected, ex, timeSpan);
            }
        }
    }

    protected virtual void LogResult(
        int testID,
        TTestCase testCase,
        TResult expected,
        TResult actual,
        bool isSuccess,
        TimeSpan timeSpan)
    {
        Console.ForegroundColor = isSuccess ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine($"Test #{testID} {(isSuccess ? "Successfull" : "Failed")}, TimeSpan: {timeSpan.TotalMilliseconds}mm");
        Console.ResetColor();

        Console.WriteLine($"Input: {testCase.ToJsonString()}");
        Console.WriteLine($"Expected: {expected.ToJsonString()}");

        if (!isSuccess)
        {
            Console.WriteLine($"Actual: {actual.ToJsonString()}");
        }
        Console.WriteLine();
    }

    protected virtual void LogError(
        int testID,
        TTestCase testCase,
        TResult expected,
        Exception ex,
        TimeSpan timeSpan)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Test #{testID} Failed, TimeSpan: {timeSpan.TotalMilliseconds}mm");
        Console.ResetColor();

        Console.WriteLine($"Input: {testCase.ToJsonString()}");
        Console.WriteLine($"Expected: {expected.ToJsonString()}");
        Console.WriteLine($"Error: {ex.ToJsonString()}");
        Console.WriteLine();
    }
}
