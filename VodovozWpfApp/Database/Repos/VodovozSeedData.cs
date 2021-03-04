using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Models.ClientSide.Database;
using System.Data.Entity;

namespace VodovozWpfApp
{
    public class VodovozSeedData
    {
        public static void EnsurePopulated()
        {
            VodovozClientDbContext context = DI.ServiceProvider.GetService<VodovozClientDbContext>();
            context.Database.EnsureCreated();

            List<Subdivision> subdivisions = new List<Subdivision>
            {
                new Subdivision {Name="Commercy" },
                new Subdivision {Name="Operation" },
                new Subdivision {Name="Logistic" },
                new Subdivision {Name="IT" }
            };

            List<Employee> employees = new List<Employee>
            {
                new Employee { Name = "Vasya", Surname = "Vetrov", FatherName = "Yuryevich", Birthday = DateTime.Today.AddYears(-30),  Sex = SexEnum.Male, Subdivision = subdivisions[0] },
                new Employee { Name = "Anastasia", Surname = "Aleksandrova", FatherName = "Yuryevna", Birthday = DateTime.Today.AddYears(-20),  Sex = SexEnum.Female, Subdivision = subdivisions[0] },
                new Employee { Name = "Boris", Surname = "Babushkin", FatherName = "Aleksandrovich", Birthday = DateTime.Today.AddYears(-45),  Sex = SexEnum.Male, Subdivision = subdivisions[0] },
                new Employee { Name = "Viktor", Surname = "Vasilyev", FatherName = "Anatolyevich", Birthday = DateTime.Today.AddYears(-21),  Sex = SexEnum.Male, Subdivision = subdivisions[1] },
                new Employee { Name = "Gennady", Surname = "Georgiyev", FatherName = "Victorovich", Birthday = DateTime.Today.AddYears(-48),  Sex = SexEnum.Male, Subdivision = subdivisions[1] },
                new Employee { Name = "Dmitry", Surname = "Dudinsky", FatherName = "Vyacheslavovich", Birthday = DateTime.Today.AddYears(-55),  Sex = SexEnum.Male, Subdivision = subdivisions[2] },
                new Employee { Name = "Yelena", Surname = "Yeremeyeva", FatherName = "Aleksandrovna", Birthday = DateTime.Today.AddYears(-50),  Sex = SexEnum.Female, Subdivision = subdivisions[2] },
                new Employee { Name = "Zhanna", Surname = "Strizh", FatherName = "Evgenyevna", Birthday = DateTime.Today.AddYears(-33),  Sex = SexEnum.Female, Subdivision = subdivisions[2] },
                new Employee { Name = "Andrey", Surname = "Zaytsev", FatherName = "Vladimirovich", Birthday = DateTime.Today.AddYears(-22),  Sex = SexEnum.Male, Subdivision = subdivisions[3] },
                new Employee { Name = "Leonid", Surname = "Kovalsky", FatherName = "Mikhaylovich", Birthday = DateTime.Today.AddYears(-29),  Sex = SexEnum.Male, Subdivision = subdivisions[3] },
            };

            //subdivisions[0].Manager = employees[0];


            List<Order> orders = new List<Order>
            {
                new Order { CounterAgent = "Microsoft", OrderTime = DateTime.Now.AddDays(-10), Author = employees[1] },
                new Order { CounterAgent = "Microsoft", OrderTime = DateTime.Now.AddDays(-5), Author = employees[0]},
                new Order { CounterAgent = "Microsoft", OrderTime = DateTime.Now.AddDays(-1), Author = employees[3]},
                new Order { CounterAgent = "Microsoft", OrderTime = DateTime.Now.AddDays(-2), Author = employees[3]},
                new Order { CounterAgent = "Microsoft", OrderTime = DateTime.Now.AddDays(-3), Author = employees[5]},
                new Order { CounterAgent = "Microsoft", OrderTime = DateTime.Now.AddDays(-3), Author = employees[6]},
            };


            if (!context.Subdivisions.Any())
            {
                context.Subdivisions.AddRange(subdivisions);
            }

            if (!context.Employees.Any())
            {
                context.Employees.AddRange(employees);
            }
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(orders);
            }
            context.SaveChanges();


        }
    }
}

