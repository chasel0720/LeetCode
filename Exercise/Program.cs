// run lessons, should with test cases
// https://leetcode.cn/problemset/

using Exercise;
var testRunner = new TestRunner();

// run all lessons
//testRunner.RunAllLessons();
//Console.ReadKey();

/////run specific lesson only
testRunner.RunSpecificLesson(typeof(L238_product_of_array_except_self));
Console.ReadKey();