namespace Polymorphism.Domain
{
    public class Pet
    {
        private string _name;
        public string Name
        {
            get
            {
                Console.WriteLine("Getting the name");
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }

        //we use the virtual keyword, to allow the method to be overriden in the derived classes
        public virtual void Eat()
        {
            Console.WriteLine("Calling Eat method from Pet class...");
        }
    }
}