namespace Exercise;
public interface ILesson<TTestCase, TResult>
{
    void RunAllTestCases();
    IEnumerable<(TTestCase TestCase, TResult ExpectedResult)> TestCases { get; }

    TResult Run(TTestCase testCase);
}