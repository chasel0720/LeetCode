namespace Exercise;
public interface ILesson
{
    void RunAllTestCases();
}

public interface ILesson<TTestCase, TResult> : ILesson
{
    IEnumerable<(TTestCase TestCase, TResult ExpectedResult)> TestCases { get; }

    TResult Run(TTestCase testCase);
}