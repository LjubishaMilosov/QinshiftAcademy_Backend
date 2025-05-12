using Class_04_Exercise_01.Domain.Enums;

namespace Class_04_Exercise_01.Domain.Models
{
    public class Dog : Pet
    {
        public string FavoriteFood { get; set; }
        public bool GoodBoy { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} is of type {Type.ToString()} aged {Age} whose favorite food is {FavoriteFood}");
        }
        public Dog(string name, string age, string favoriteFood, bool goodBoy)
            : base(name, age, PetTypeEnum.Dog)
        {
            FavoriteFood = favoriteFood;
            GoodBoy = goodBoy;
        }
    }
}
