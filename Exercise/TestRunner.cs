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

    static void RunLessons(Type? lessonType = null)
    {
        var assembly = typeof(TestRunner).Assembly;
        var lessons = assembly.GetTypes()
            .Where(t => t.IsClass
            && !t.IsAbstract
            && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ILesson<,>))
            )
            .Select(t => Activator.CreateInstance(t)!)
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

            var runMethod = lesson.GetType().GetMethod("RunAllTestCases");
            if (runMethod != null)
            {
                runMethod.Invoke(lesson, null);
            }

            Console.WriteLine($"\nEnd: {name}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }
    }
}