namespace Classes  // the path from our solution to our class => in our case the project Classes
{
    public class Person  // default is Internal
    {
        // we can access Firstname and Lastname and Age from anywhere
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        // we can access _ssn only from the Person class and its methods
        private long _ssn { get; set; }

        // Constructor
        //Constructor is public and has the same name as class
        // we need it in order to instantiate objects
        public Person() {
            _ssn = new Random().Next(100000, 999999);  AttributeTargets a random number from 100000 to 9999999
        }

        public Person(string firstname, string LastName, int age, long ssn)
        {
            Firstname = firstname;
            Lastname = LastName;
            Age = age;
            if(ssn >= 100000 && ssn <= 999999)
            {
                _ssn = ssn;
            }
            else
            {
                _ssn =  new Random().Next(100000, 999999);
            }

    }

        // we can create more constructors
        public Person(string firstname, string LastName)
        {
            Firstname = firstname;
            Lastname = LastName;
            Age = 0;
            _ssn = new Random().Next(100000, 999999);
        }
    }
