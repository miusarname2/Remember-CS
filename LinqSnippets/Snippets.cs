using System.Security.AccessControl;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinq() {

            string[] cars = {
                "Vm Golf",
                "Audi 4",
                "Audi 5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat Leon"
            };
        
            // Select * From cars

            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // SELECT * FROM cars WHERE 
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var Audi in audiList)
            {
                Console.WriteLine(Audi);
            }

        }

        static public void linqNumbers() {
            List<int> numbers = new List<int> { 1,2,3,4,5,6,7,8,9,10};

            // Each number multiplieb by 3
            // take all but not 9
            // Order

            var procceeNumberList = numbers.Select(num => num * 3).Where(num => num != 9).OrderBy(num => num);  


        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "g",
                "c"
            };

             // SELECT * FROM textList LIMIT 1

            var first = textList.First();

            // SELECT * FROM textList WHERE ='c' LIMIT 1

            var ctext = textList.First(text => text.Equals("c"));

            // SELECT * FROM textList CONTAINS ='c' LIMIT 1

            var jText = textList.First(Text => Text.Contains("j"));
        }

         static public void multipleSelects()
        {
            var enterprices = new[]
            {
                new Enterprise()
                {
                    Id=1,
                    Name = "Enterprice 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id =1,
                            Name="Juan",
                            Email="lo mama",
                            Salary= 3000
                        },
                         new Employee
                        {
                            Id =2,
                            Name="Miguel",
                            Email="lo mama",
                            Salary= 30000
                        },
                          new Employee
                        {
                            Id =3,
                            Name="Pedro",
                            Email="lo mama",
                            Salary= 300
                        },
                           new Employee
                        {
                            Id =4,
                            Name="Jholver",
                            Email="lo mama",
                            Salary= 300000
                        },
                            new Employee
                        {
                            Id =5,
                            Name="Diego",
                            Email="lo recontra mama",
                            Salary= 30
                        },
                    }
                },
                new Enterprise()
                {
                    Id=2,
                    Name = "Enterprice 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id =1,
                            Name="Ana",
                            Email="lo mama",
                            Salary= 3000
                        },
                         new Employee
                        {
                            Id =2,
                            Name="Alisson",
                            Email="lo mama",
                            Salary= 30000
                        },
                          new Employee
                        {
                            Id =3,
                            Name="Pedro",
                            Email="lo mama",
                            Salary= 300
                        },
                           new Employee
                        {
                            Id =4,
                            Name="Julian",
                            Email="lo mama",
                            Salary= 300000
                        },
                            new Employee
                        {
                            Id =6,
                            Name="Karen",
                            Email="lo recontra mama",
                            Salary= 30
                        },
                    }
                },
            };

            // Obtain All Empoyees of all Enterprices

            var employeesList = enterprices.SelectMany(enterprice => enterprice.Employees);

            // If is null o undined
            bool hasEnterprices = enterprices.Any();

            bool hasEmployees = enterprices.Any(enterprice => enterprice.Employees.Any());

            // All enterprice at least has an employess minumun 1000

            bool hasEmployeeMillonetas = enterprices.Any(enterprice => enterprice.Employees.Any(employee => employee.Salary >= 1000));
        }

        static public void linqCollection()
        {
            var firstList = new List<string>() { "a", "b","c"};
            var secondList = new List<string>() { "a","n","c" };

            // INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(secondList, element => element, secondElement => secondElement, (element, secondElement) => new { element,secondElement });

            // INNER LEFT
        }
    }
}
