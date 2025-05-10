using Generics;

List<string> strings = new List<string>() { "Hello", "G6", "bye" };
List<int> ints = new List<int>() { 1, 2, 3 };
List<bool> bools = new List<bool>() {true, false, true };

NonGenericHelper nonGenericHelper = new NonGenericHelper();
nonGenericHelper.PrintListOStrings(strings);
nonGenericHelper.PrintListOfIntegers(ints);
nonGenericHelper.PrintListOfBools(bools);

Console.WriteLine("=====================================");

// here we pass on the type that will be placed in the placeholder T in genericHelper
GenericHelper<string>.PrintList(strings);
GenericHelper<int>.PrintList(ints);
GenericHelper<bool>.PrintList(bools);

Console.WriteLine("=====================================");

GenericHelper<string>.PrintListInfo(strings);
GenericHelper<int>.PrintListInfo(ints);