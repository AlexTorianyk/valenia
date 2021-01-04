using System;
using System.Reflection;

namespace Valenia.Common
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(MemberInfo type, string message)
            : base($"Value of {type.Name} {message}")
        {
        }
    }
}
