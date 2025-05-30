﻿using AdvancedLINQ.Domain.Enums;
using AdvancedLINQ.Domain.Models;

namespace AdvancedLINQ.Domain
{
    public static class QinshiftAcademy
    {
        public static List<Student> Students = new List<Student>()
        {
            new Student(12, "Bob", "Bobsky", 29, false),
            new Student(22, "Jill", "Wayne", 36, true),
            new Student(27, "Greg", "Gregsky", 45, false),
            new Student(29, "Anne", "Willson", 31, true),
            new Student(30, "Liana", "Wurtz", 25, false),
            new Student(41, "Bill", "Zu", 31, false)
        };

        public static List<Subject> Subjects = new List<Subject>()
        {
            new Subject(15, "C# Basic", 10, 24, AcademyTypeEnum.Programming ),
            new Subject(16,"C# Advanced", 15, 26, AcademyTypeEnum.Programming ),
            new Subject(44, "JavaScript", 25, 22, AcademyTypeEnum.Programming ),
            new Subject(67, "Photoshop", 12, 18, AcademyTypeEnum.Design ),
            new Subject(88, "Illustrator", 12, 18, AcademyTypeEnum.Design ),
            new Subject(97,"Networks Basic", 8, 12, AcademyTypeEnum.Network ),
            new Subject(98, "Networks Advanced", 16, 10, AcademyTypeEnum.Network )
        };

        static QinshiftAcademy()
        {
            //Description: This is a static constructor that initializes the Students and Subjects lists with data.
            // It creates a list of students and subjects, and assigns subjects to each student.
            // It is called automatically when the class is first accessed.
            // It is used to set up the initial state of the class.
            // It is not called directly by the user.
            Students[0].Subjects = new List<Subject>() { Subjects[0], Subjects[2], Subjects[3], Subjects[4] };
            Students[1].Subjects = new List<Subject>() { Subjects[3], Subjects[4], Subjects[5], Subjects[1] };
            Students[2].Subjects = new List<Subject>() { Subjects[5], Subjects[6] };
            Students[3].Subjects = new List<Subject>() { Subjects[3], Subjects[4] };
            Students[4].Subjects = new List<Subject>() { Subjects[1], Subjects[2], Subjects[3], Subjects[5] };
            Students[5].Subjects = new List<Subject>() { Subjects[2] };
        }
    }
}