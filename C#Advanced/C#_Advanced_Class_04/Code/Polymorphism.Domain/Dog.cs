using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Domain
{
    public class Dog : Pet
    {
        public string Color { get; set; }
        public void Bark()
        {
            Console.WriteLine("Bark bark");
        }
        // we use the 'override' keyword to override the base class method/the parent implementation of the method
        public override void Eat()
        {
            base.Eat(); // Calls the base class method
        }
    }
}
