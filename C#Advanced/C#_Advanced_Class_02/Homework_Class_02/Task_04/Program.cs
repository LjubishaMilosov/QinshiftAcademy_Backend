using Task_04.Domain.Models;

Employee manager = new Manager(1,"Mitko", 2000, 1500);
Employee programmer = new Programmer(2, "Ace", 3000, 600);

manager.DisplayInfo();
programmer.DisplayInfo();