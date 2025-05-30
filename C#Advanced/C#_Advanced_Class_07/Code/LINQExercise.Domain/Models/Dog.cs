﻿
using LINQExercise.Domain.Enums;

namespace LINQExercise.Domain.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }

        public BreedEnum Breed { get; set; }

        public Dog(string name, string color, int age,  BreedEnum breed)
        {
            Name = name;
            Color = color;
            Age = age;
            Breed = breed;
        }
    }
}