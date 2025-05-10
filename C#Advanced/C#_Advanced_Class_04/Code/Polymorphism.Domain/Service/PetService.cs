

namespace Polymorphism.Domain.Service
{
    // Compile time Polymorphism
    //Having methods with the same name
    // but they have different signature/ different parameters
    public class PetService
    {
        public void PetStatus()
        {
            Console.WriteLine("PetStatus without params");
        }
        // ERROR -> when calling this method we dont specify the return type(we only specify the name and the params that we send)
        // so the program does not know which PetStatus() method to call

        //public string PetStatus()
        //{
        //    return "";
        //}

        // the name of  te method is the same but it has two params - first param is of type string and the second is of type Cat
        public void PetStatus(string name, Cat cat)
        {
            Console.WriteLine($"Hello {name}. The {cat.Name} is {cat.getAge()} years old.");
        }

        // when we call the method, we dont specify the name of params only the type of the params
        //public void PetStatus(string catName, Cat catObject)
        //{
        //    Console.WriteLine($"Hello {name}. The {cat.Name} is {cat.Age} years old.");
        //}

        // the name of the method is the same but it has two params - first param is of type Cat and the second is of type string
        public void PetStatus(Cat cat, string name)
        {
           // Console.WriteLine($"Hello {name}. The {cat.Name} is {cat.Age} years old.");
            Console.WriteLine($"Hello {name}. The {cat.Name} is {cat.getAge()} years old.");
        }

        public void PetStatus(Dog dog, string name)
        {
            Console.WriteLine($"Hello {name}. The {dog.Name} is {dog.Color} years old.");
        }

        public void PetStatus(string name, Dog dog)
        {
            Console.WriteLine($"Hello {name}. The {dog.Name} is {dog.Color} years old.");
        }
    }
}
