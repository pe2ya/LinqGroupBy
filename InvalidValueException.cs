using System;
using System.Runtime.Serialization;

namespace StudentsMarks
{
    internal class InvalidValueException : Exception
    {
        public InvalidValueException(string message) : base(message)
        {
        }

    }
}