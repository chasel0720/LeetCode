namespace Exercise;
using System.Text.Json;
using System.Text.Json.Serialization;
public abstract class LessonBase<TTestCase, TResult> : ILesson<TTestCase, TResult>
{
    public abstract IEnumerable<(TTestCase TestCase, TResult ExpectedResult)> TestCases { get; }
    public abstract TResult Run(TTestCase testCase);

    public void RunAllTests()
    {
        var testCases = TestCases.ToArray();

        for (int i = 0; i < testCases.Length; i++)
        {
            var testCase = testCases[i].TestCase;
            var expected = testCases[i].ExpectedResult;

            try
            {
                var actual = Run(testCase);
                var isSuccess = EqualityComparer<TResult>.Default.Equals(actual, expected);

                LogResult(i + 1, testCase, expected, actual, isSuccess);
            }
            catch (Exception ex)
            {
                LogError(i + 1, testCase, expected, ex);
            }
        }
    }

    protected virtual void LogResult(
        int testID,
        TTestCase testCase,
        TResult expected,
        TResult actual,
        bool isSuccess)
    {
        Console.ForegroundColor = isSuccess ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine($"Test #{testID} {(isSuccess ? "Successfull" : "Failed")}");
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
        Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Test #{testID} Failed: {ex.Message}");
        Console.ResetColor();

        Console.WriteLine($"Input: {testCase.ToJsonString()}");
        Console.WriteLine($"Expected: {expected.ToJsonString()}");
        Console.WriteLine($"Error: {ex}");
        Console.WriteLine();
    }
}
