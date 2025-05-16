

namespace Class_08_Delegates
{
    public class DelegatesService
    {
        private delegate void SayDelegate(string something);
        // Action<string>

        private delegate int NumberDelegate(int num1, int num2);

        private void SayHello(string someString)
        {
            Console.WriteLine("HELLOOOOO");
        }

        private void SayWhatever(string whatever, SayDelegate sayDelegate)
        {
            //Console.WriteLine($"Say whatever {whatever}");
            sayDelegate(whatever);
        }



        public void Main()
        {
            Console.WriteLine("Hello World");

            // In JavaScript
            // let sum = (num1, num2) => num1 + num2
            // sum(10,20)  // 30

            // In C#                 //parameters     // body of the function
            Func<int, int, int> sum = (num1, num2) => num1 + num2;
            Action<string, int> printSomething = (word, num) => Console.WriteLine($"Word {word}. Number{num}...");

            Console.WriteLine($"The sum is {sum(10, 20)} "); // 30
            printSomething("Hello", 10);

            SayDelegate sayHello = (someName) => Console.WriteLine($"Hello {someName}");
            sayHello("Ljubisha");

            SayDelegate sayHelloMethod = new SayDelegate(SayHello);
            sayHelloMethod("bla bla bla");

            NumberDelegate sumResult = new NumberDelegate((num1, num2) => num1 + num2);
            int result = sumResult(10, 20);
            Console.WriteLine($"The result is {result}"); // 30


            SayWhatever("WHATEVER", (string word) => Console.WriteLine("Here is your word" + word));
            SayWhatever("WHATEVER", sayHello);
            SayWhatever("WHATEVER", SayHello);

        }
    }
}
