using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMarks
{
    class Student
    {
        private List<int> list;
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<int> ExamScores
        {
            get => list;
            set
            {
                foreach (var x in value)
                {
                    if (x < 1 || x > 5)
                    {
                        throw (new InvalidValueException("You set the wrong mark - <<" + x + ">>"));
                    }
                }
                list = value;
            }
        }

        public Student(string name, string surname, List<int> list)
        {
            Name = name;
            Surname = surname;
            ExamScores = list;
        }

        public string GetExamScores()
        {
            string result = "";
            foreach (var x in ExamScores)
            {
                result += x + ", ";
            }
           
            return result.Remove(result.Length - 2);
        }

        public override string ToString()
        {
            string result = "";
            foreach (var x in ExamScores)
            {
                result += x + ", ";
            }

            result = result.Remove(result.Length - 2);
            return $"Name: {Name} {Surname}, Marks: [{result}]";
        }
    }
}

