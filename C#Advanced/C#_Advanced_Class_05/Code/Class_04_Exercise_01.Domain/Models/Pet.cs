
namespace Class_04_Exercise_01.Domain.Models
{
    //➢ Pet( abstract ) with Name, Type, Age and abstract PrintInfo()
    //➢ Dog(from Pet) with GoodBoy and FavoriteFood
    //➢ Cat(from Pet) with Lazy and LivesLeft
    //➢ Fish(from Pet) with color, size
    public abstract class Pet
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public PetTypeEnum Type { get; set; }
        public abstract void PrintInfo();

        public Pet(string name, string age, PetTypeEnum type)
        {
            Name = name;
            Age = age;
            Type = type;
        }
    }
}
