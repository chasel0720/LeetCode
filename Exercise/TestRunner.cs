namespace Exercise;
public class TestRunner
{
    public void RunAllLessons()
    {
        var assembly = typeof(TestRunner).Assembly;
        var lessonTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(ILesson).IsAssignableFrom(t))
            .ToList();

        Console.WriteLine($"Find {lessonTypes.Count} Lessons");
        Console.WriteLine("==================================");

        foreach (var lessonType in lessonTypes)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nRun: {lessonType.Name}");
            Console.ResetColor();

            var lesson = (ILesson)Activator.CreateInstance(lessonType);
            lesson.RunAllTests();

            Console.WriteLine($"\nEnd: {lessonType.Name}");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
        }
    }

    public void RunSpecificLesson(Type t)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\nRun: {t.Name}");
        Console.ResetColor();

        var lesson = (ILesson)Activator.CreateInstance(t);
        lesson.RunAllTests();

        Console.WriteLine($"\nEnd: {t.Name}");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine();
    }
}