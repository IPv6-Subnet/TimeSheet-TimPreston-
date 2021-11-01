using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data
{
    public class DbInitializer
    {
        /*
        
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Employees.Any())
            {
                return;
            }


            var employees = new Employee[]
            {
                new Employee{FirstName="John", LastName="Johnson", HourlyWage=15.00, Phone="3783829920", Email="john@email.com", Street="356 Elm Street", City="Millville", State="KS", ZipCode="32142", HireDate = DateTime.Parse("2017-01-15")},
                new Employee{FirstName="Zeb", LastName="Jones", HourlyWage=18.00, Phone="3289816410", Email="zeb@email.com", Street="32 Day Street", City="Lake Charles", State="IL", ZipCode="32984", HireDate = DateTime.Parse("2010-11-25")},
                new Employee{FirstName="Billy", LastName="Costigan", HourlyWage=50.00, Phone="1265376862", Email="bill@email.com", Street="2431 Dugger Drive", City="Boston", State="MA", ZipCode="87991", HireDate = DateTime.Parse("2021-06-04")},
                new Employee{FirstName="Mariah", LastName="Carey", HourlyWage=5.00, Phone="5655387652", Email="mc@email.com", Street="2655 High Lane", City="Henry", State="OH", ZipCode="81191", HireDate = DateTime.Parse("2015-12-01")},
                new Employee{FirstName="Haley", LastName="Moss", HourlyWage=45.00, Phone="2964863342", Email="haley@email.com", Street="4 Sesame Terrace", City="Window", State="CA", ZipCode="99211", HireDate = DateTime.Parse("2019-01-21")},
                new Employee{FirstName="Jace", LastName="Lebannon", HourlyWage=65.00, Phone="3783829920", Email="jace@email.com", Street="35226 Elmore Castle", City="Mill", State="TX", ZipCode="37742", HireDate = DateTime.Parse("2002-07-19")},
                new Employee{FirstName="Taylor", LastName="Hill", HourlyWage=18.00, Phone="3289816410", Email="taytay@email.com", Street="44 Magnum Street", City="Lake Charles", State="IL", ZipCode="44614", HireDate = DateTime.Parse("2006-05-05")},
                new Employee{FirstName="Timmy", LastName="Williams", HourlyWage=30.00, Phone="1265376862", Email="timmy@email.com", Street="69 Education Blvd", City="Boston", State="MA", ZipCode="08461", HireDate = DateTime.Parse("2016-08-13")},
                new Employee{FirstName="Zac", LastName="Bays", HourlyWage=85.00, Phone="5223327652", Email="zac@email.com", Street="0 Doge Lane", City="Henry", State="OH", ZipCode="97405", HireDate = DateTime.Parse("2020-02-28")},
                new Employee{FirstName="Terry", LastName="Crews", HourlyWage=45.00, Phone="9565348442", Email="tc@email.com", Street="114 Blank Terrace", City="Window", State="CA", ZipCode="98111", HireDate = DateTime.Parse("2014-06-06")}
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var divisions = new Division[]
            {
                new Division{DivisionManagerID=employees.Single(e => e.LastName == "Carey").ID, Title="Music Division", Budget=10000.00},
                new Division{DivisionManagerID=employees.Single(e => e.LastName == "Costigan").ID, Title="Technology Division", Budget=150000.00},
                new Division{DivisionManagerID=employees.Single(e => e.LastName == "Moss").ID, Title="Human Resources Division", Budget=10.00}
            };
            foreach (Division d in divisions)
            {
                context.Divisions.Add(d);
            }
            context.SaveChanges();

            var groups = new Group[]
            {
                new Group{DivisionID=divisions.Single(d => d.Title == "Technology Division").ID, GroupManagerID=employees.Single(e => e.LastName == "Jones").ID, Title="Beer Delivery Robot"},
                new Group{DivisionID=divisions.Single(d => d.Title == "Music Division").ID, Title="Tibetan Throat Singing Contest"}
            };
            foreach (Group g in groups)
            {
                context.Groups.Add(g);
            }
            context.SaveChanges();

            var employeeAssignments = new EmployeeAssignment[]
            {
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Johnson").ID, DivisionID=divisions.Single(d => d.Title == "Music Division").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Jones").ID, DivisionID=divisions.Single(d => d.Title == "Technology Division").ID, GroupID=groups.Single(g => g.Title == "Beer Delivery Robot").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Costigan").ID, DivisionID=divisions.Single(d => d.Title == "Technology Division").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Carey").ID, DivisionID=divisions.Single(d => d.Title == "Music Division").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Moss").ID, DivisionID=divisions.Single(d => d.Title == "Human Resources Division").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Lebannon").ID, DivisionID=divisions.Single(d => d.Title == "Human Resources Division").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Hill").ID, DivisionID=divisions.Single(d => d.Title == "Human Resources Division").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Williams").ID, DivisionID=divisions.Single(d => d.Title == "Music Division").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Bays").ID, DivisionID=divisions.Single(d => d.Title == "Technology Division").ID, GroupID=groups.Single(g => g.Title == "Beer Delivery Robot").ID},
                new EmployeeAssignment{EmployeeID=employees.Single(e => e.LastName == "Crews").ID, DivisionID=divisions.Single(d => d.Title == "Technology Division").ID, GroupID=groups.Single(g => g.Title == "Beer Delivery Robot").ID},
            };
            foreach (EmployeeAssignment ea in employeeAssignments)
            {
                context.EmployeeAssignments.Add(ea);
            }
            context.SaveChanges();
        }
        */
        
    }
}
