
namespace Class_04_Exercise_01.Domain.Models
{

    public class Cat : Pet
    {
        public bool IsLazy { get; set; }
        public int LivesLeft { get; set; }

        public Cat(string name, string age, bool isLazy, int livesLeft)
            : base(name, age, PetTypeEnum.Cat)
        {
            IsLazy = isLazy;
            LivesLeft = livesLeft;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} is of type {Type.ToString()} ageed {Age} and lives left {LivesLeft}");
            if(IsLazy)
            {
                Console.WriteLine($"{Name} is lazy");
            }
            else
            {
                Console.WriteLine($"{Name} is not lazy");
            }
        }
    }
}
