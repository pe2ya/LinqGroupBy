using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMarks
{
    public enum EmpRole
    { 
        Worker = 0,
        Manager,
        Cleaner
    }
    class Employee
    {
        private int id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonalId
        {
            get => id;
            set
            {
                if (value < 999 || value > 10000)
                {
                    throw (new InvalidValueException("Invalid ID has Employee - <<" + Name + ">>"));
                }

                id = value;
            }
        }
        public EmpRole Role { get; set; }
        public Superior EmpSuperior { get; set; }

        public Employee(string name, string surname, int personalId, EmpRole role, Superior empSuperior)
        {
            Name = name;
            Surname = surname;
            PersonalId = personalId;
            Role = role;
            EmpSuperior = empSuperior;
        }

        public override string ToString()
        {
            return $"Name: {Name} {Surname}, Role: {Role}, Superior: {EmpSuperior.Name} {EmpSuperior.Surname},  PersonalId: {PersonalId}";
        }
    }
}
