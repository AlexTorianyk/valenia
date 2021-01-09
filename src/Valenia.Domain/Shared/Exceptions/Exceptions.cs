using System;

namespace Valenia.Domain.Shared.Exceptions
{
    public static class Exceptions
    {
        public class InvalidEntityState : Exception
        {
            public InvalidEntityState(object entity, string message)
                : base($"Entity {entity.GetType().Name} state change rejected, {message}")
            {
            }
        }
    }
}
