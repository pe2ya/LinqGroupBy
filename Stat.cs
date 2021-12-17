using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsMarks
{
    static class Stat
    {
        public static int getAvarege(this Student s)
        {
            return (int)(s.ExamScores.Average());
        }

        public static int getAvarageStudent(this List<Student> list)
        {
            int result = 0;
            int help = 0;
            foreach (var x in list)
            {
                result += x.getAvarege();
                help++;
            }

            return (int)(result / help);
        }



        public static void getMarksGroup(this List<Student> list)
        {
            var result =
                 from student in list
                 group student by student.getAvarege();

            foreach (var n in result)
            {
                Console.WriteLine($"Mark = {n.Key}");
                foreach (var x in n)
                {
                    Console.WriteLine($"\t {x}");
                }
            }
        }



        public static void getGroupBySurname(this List<Student> list)
        {
            var result =
                   from student in list
                   group student by student.Surname[0] into a
                   from st in
                       (from student in a
                        select new { Surname = student.Surname, Marks = student.GetExamScores() })
                   group st by a.Key;

            foreach (var names in result)
            {
                Console.WriteLine($"Surnames = {names.Key}");
                foreach (var x in names)
                {
                    Console.WriteLine($"\t Surname = {x.Surname}, Marks = [{x.Marks}] ");
                }
            }
        }



        public static void getGroupBySurnameAndMarks(this List<Student> list)
        {

            var result =
                  from student in list
                  group student by student.Surname[0] into b
                  from marks in
                      (from student in b
                       group student by student.getAvarege())
                  group marks by b.Key;

            foreach (var names in result)
            {
                Console.WriteLine("Surname = " + names.Key);
                foreach (var marks in names)
                {
                    Console.WriteLine("\tMarks =" + marks.Key);
                    foreach (var x in marks)
                    {
                        Console.WriteLine($"\t\tSurname = {x.Surname}, Marks = {x.GetExamScores()}");
                    }
                }
            }
        }
        public static void HighScores(this List<Student> list, int score)
        {
            var highScores = from student in list
                             where student.getAvarege() <= score
                             select new { N = student.Name, Score = student.getAvarege() };

            if (highScores.Count() == 0)
            {
                Console.WriteLine($"No one has this mark");
            }
            else
            {
                foreach (var x in highScores)
                {
                    Console.WriteLine($"{x.N}\t\tMark: {x.Score}");
                }
            }
        }



        public static void RoleCount(this List<Employee> list)
        {
            var result =
                  from emp in list
                  group emp by emp.Role;

            foreach (var x in result)
            {
                Console.WriteLine(x.Key + " - " + x.Count());
            }
        }



        public static void EmployeesAndSuperior(this List<Employee> list)
        {
            var result =
                    from emp in list
                    group emp by emp.EmpSuperior.Surname;

            foreach (var x in result)
            {
                Console.WriteLine("Superior: " + x.Key);
                foreach (var emp in x)
                {
                    Console.WriteLine("\t\t" + emp);
                }
            }
        }



        public static void SuperiorW(this List<Employee> list)
        {
            var result =
                from emp in list
                group emp by emp.EmpSuperior.Surname;

            foreach (var x in result)
            {
                Console.WriteLine($"{x.Key} - {x.Count()} Employees");
            }
        }
    }
}
