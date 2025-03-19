
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace Inheritance.Models
{
    public class Cat : Animal
    {
        public bool IsLazy { get; set; } // specific property for the cat class

        // this method is specific only for the Catclass => the Animal class does not have a PrintAge method
        public void PrintAge()
        {
            // we can use Age because it is protected in the Animal class and it is inherited by the Cat class
            Console.WriteLine($"The cat is {Age} years old");

            //we cannot use _Id because it is a private property in the animal class
            //Console.WriteLine($"The cat wit id {_Id} is {Age} years old");  // error
        }

        //first call the default constructor from the base class (Animal) than execute the default constructor of the Cat class
        public Cat() : base()
        {
            Console.WriteLine("Calling the default Cat constructor");
        }

        //Override method
        // we need to use the overide keyword
        public override void PrintInfo()
        {
             base.PrintInfo();     // this way we can access the PrintInfo implementation from the parent class
                                    // (we call the PrintInfo method from the Animal parent class

            // this way we totally change the implementation of the method
            string lazy = IsLazy ? "is lazy" : "is not lazy";
            Console.WriteLine($"The cat {Name} is {Age} years old and is {lazy}");
        }
    }
}
