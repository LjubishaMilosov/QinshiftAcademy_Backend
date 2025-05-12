using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_04_Exercise_01.Domain.Models
{
    public class Fish : Pet
    {
        public string Color { get; set; }
        public int Size { get; set; }
        public Fish(string name, string age, string color, int size)
            : base(name, age, PetTypeEnum.Fish)
        {
            Color = color;
            Size = size;
        }
        public override void PrintInfo()
        {
            Console.WriteLine($"{Name} is of type {Type.ToString()} aged {Age} and is of color  {Color} and size {Size}");
        }
    }
}
