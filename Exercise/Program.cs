// run lessons, should with test cases
// https://leetcode.cn/problemset/

using Exercise;
var testRunner = new TestRunner();

// run all lessons
//testRunner.RunAllLessons();
//Console.ReadKey();

/////run specific lesson only
testRunner.RunSpecificLesson(typeof(L80_remove_duplicates_from_sorted_array_ii));
Console.ReadKey();