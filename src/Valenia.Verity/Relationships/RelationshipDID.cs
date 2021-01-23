using System;
using Valenia.Common;

namespace Valenia.Verity.Relationships
{
    public class RelationshipDID : Value<RelationshipDID>
    {
        public string Value { get; internal set; }
        protected RelationshipDID() { }

        public RelationshipDID(string value)
        {
            CheckValidity(value);

            Value = value;
        }

        private static void CheckValidity(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value), "Relationship id cannot be empty");

        }

        public static implicit operator string(RelationshipDID self) => self.Value;

    }
}
