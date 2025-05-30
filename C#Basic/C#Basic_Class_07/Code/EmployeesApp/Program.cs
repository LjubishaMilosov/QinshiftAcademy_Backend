﻿using Domain.Enums;
using Domain.Models;

Employee employee = new Employee("Petko", "petkovski", RoleEnum.Other, 600);
employee.PrintInfo();

//  double salary = employee.Salary;  // ERROR, Salary is protected
double salary = employee.GetSalary();

SalesPerson salesPerson = new SalesPerson("Stefan", "Stefanovski", 0);
salesPerson.AddSuccessRevenue(2500);
Console.WriteLine(salesPerson.GetSalary());

Manager manager = new Manager("Nikola", "Nikolovski", 600);
manager.PrintInfo();  // Inherited from Employee
manager.AddBonus(100);
Console.WriteLine(manager.GetSalary());
manager.AddBonus(150);
Console.WriteLine(manager.GetSalary());