using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsMarks
{
    class Superior
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

        public Superior(string name, string surname, int personalId)
        {
            Name = name;
            Surname = surname;
            PersonalId = personalId;
        }

        public override string ToString()
        {
            return $"Name: {Name} {Surname}, PersonalId: {PersonalId}";
        }
    }
}
