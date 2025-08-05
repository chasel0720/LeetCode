namespace Exercise;
public interface ILesson<T,U>
{
    (T Case, U expectedResult)[] TestCases { get; }
    U Run (T args);
}
