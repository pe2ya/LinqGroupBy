using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentsMarks
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Student> list = new List<Student>()
            {
                new Student("Andrii", "Petii", new List<int>() {1, 1, 2, 3, 4}),
                new Student("Jan", "Kos", new List<int>() {2, 1, 4, 5, 1}),
                new Student("David", "Poe", new List<int>() {2, 2, 4, 3, 4}),
                new Student("Charles", "Baudi", new List<int>() {5, 3, 2, 3, 4}),
                new Student("Joseph", "Harris", new List<int>() {3, 1, 2, 5, 4}),
            };

                foreach (var x in list)
                {
                    Console.WriteLine($"Name: {x.Name} {x.Surname}\n\t Mark: {x.getAvarege()}\n");
                }
                Console.WriteLine("----------------------------\n");

                int choise = 1;
                bool done = false;
                Console.WriteLine("Select a mark");
                while(!done)
                {
                    try
                    {
                        if (choise != 1) { Console.WriteLine("Mark must be beetwen range <1; 5>"); }

                        string input = Console.ReadLine();
                        if (int.TryParse(input, out int output))
                        {
                            choise = Int32.Parse(input);
                            if (choise < 1 || choise > 5)
                            {
                                throw (new InvalidValueException("Mark must be beetwen range <1; 5>"));
                            }
                        }
                        else 
                        {
                            throw (new InvalidValueException("Invalid data type"));
                        }
                        done = true;
                    }
                    catch (InvalidValueException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                list.HighScores(choise);
                Console.WriteLine("\n----------------------------\n");

                list.getMarksGroup();
                Console.WriteLine("\n----------------------------\n");

                list.getGroupBySurname();
                Console.WriteLine("\n----------------------------\n");

                list.getGroupBySurnameAndMarks();
                Console.WriteLine("\n----------------------------\n");

                Console.WriteLine("Avarage Student mark: " + list.getAvarageStudent());
                Console.WriteLine("\n----------------------------\n");
            }
            catch (InvalidValueException e)
            {
                Console.WriteLine(e.Message + "\n");
            }
            //------------------------------------------------------------------------------
            try
            {
                Superior noah = new Superior("Noah", "Roberts", 7123);
                Superior oliver = new Superior("Oliver", "Hall", 1111);
                Superior james = new Superior("James", "Baker", 1155);
                Superior lucas = new Superior("Lucas", "Nelson", 2334);
                Superior ethan = new Superior("Ethan", "Carter", 7777);

                Employee andrii = new Employee("Andrii", "Petii", 1529, EmpRole.Worker, noah);
                Employee daniel = new Employee("Daniel", "Allen", 5555, EmpRole.Worker, lucas);
                Employee michael = new Employee("Michael", "King", 9842, EmpRole.Manager, oliver);
                Employee jacob = new Employee("Jacob", "Walker", 6542, EmpRole.Worker, james);
                Employee henry = new Employee("Henry", "Lewis", 1764, EmpRole.Cleaner, noah);

                List<Superior> superiors = new List<Superior>() { noah, oliver, james, lucas, ethan };
                List<Employee> employees = new List<Employee>() { andrii, daniel, michael, jacob, henry };

                employees.RoleCount();
                Console.WriteLine("\n----------------------------\n");

                employees.EmployeesAndSuperior();
                Console.WriteLine("\n----------------------------\n");

                employees.SuperiorW();
                Console.WriteLine("\n----------------------------\n");
            }
            catch (InvalidValueException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
