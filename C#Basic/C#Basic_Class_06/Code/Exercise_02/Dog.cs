using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
//Create a class Dog
//● Add properties: Name, Race, Color
//● The dog needs to have an Eat method that returns
//message: The dog is now eating. A Play method
//returning a message : The dog is now playing. and a
//ChaseTail method that returns a message: Dog is now
//chasing its tail.
//● The user needs to create the dog object by inputs and
//then give an option to choose one of the actions
//mentioned above.
//EXERCISE 2

namespace Exercise_02
{
    class Dog
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Color { get; set; }

        public Dog() // empty default constructor
        {
        }

        public Dog(string name, string race, string color)
        {
            Name = name;
            Race = race;
            Color = color;
        }

        public string Eat()
        {
            return $"{Name} is now eating.";
        }
        public string Play()
        {
            return $"{Name} is now playing.";
        }
        public string ChaseTail()
        {
            return $"{Name} is now chasing its tail.";
        }
    }
}
