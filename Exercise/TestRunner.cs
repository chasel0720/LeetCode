namespace Exercise;
public class TestRunner
{
    public void RunAllLessons()
    {
        RunLessons();
    }

    public void RunSpecificLesson(Type lesson)
    {
        RunLessons(lesson);
    }

    void RunLessons(Type lessonType = null)
    {
        var assembly = typeof(TestRunner).Assembly;
        var lessons = assembly.GetTypes()
            .Where(t => t.IsClass
            && !t.IsAbstract && typeof(ILesson).IsAssignableFrom(t)
            )
            .Select(t => (ILesson)Activator.CreateInstance(t)!)
            .Where(l => lessonType == null || l.GetType() == lessonType)
            .ToList();

        Console.WriteLine($"Find {lessons.Count} Lessons");
        Console.WriteLine("==================================");

        foreach (var lesson in lessons)
        {
            var name = lesson.GetType().Name;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nRun: {name}");
            Console.ResetColor();

            lesson.RunAllTestCases();

            Console.WriteLine($"\nEnd: {name}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }
    }
}