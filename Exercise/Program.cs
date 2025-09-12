// run lessons, should with test cases
// https://leetcode.cn/problemset/

using Exercise;
using Exercise.Lessons;
var testRunner = new TestRunner();

// run all lessons
//testRunner.RunAllLessons();
//Console.ReadKey();

/////run specific lesson only
testRunner.RunSpecificLesson(typeof(L392_is_subsequence));
Console.ReadKey();