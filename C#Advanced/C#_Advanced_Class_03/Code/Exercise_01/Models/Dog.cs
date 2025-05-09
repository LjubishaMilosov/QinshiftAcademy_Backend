

namespace Exercise_01.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public void Bark()
        {
            Console.WriteLine("{Bark bark");
        }
        public static bool Validate(Dog dog)
        {
            if(dog == null)
            { 
                return false;
            }
            if(dog.Id == null || string.IsNullOrEmpty(dog.Name) || string.IsNullOrEmpty(dog.Color))
            {
                return false;
            }
            if(dog.Id < 0)
            {
                return false;
            }
            if (dog.Name.Length < 2 )
            {
                return false;
            }

            return true; // if it did not return false in any of the previous case, the dog is a valid object
        }
    }
}
