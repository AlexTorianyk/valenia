using System;
using Valenia.Common;

namespace Valenia.Domain.TrustAnchors
{
    public class TrustAnchorName : Value<TrustAnchorName>
    {
        public string Value { get; internal set; }

        public static TrustAnchorName FromString(string name)
        {
            CheckValidity(name);
            return new TrustAnchorName(name);
        }

        internal TrustAnchorName(string value) => Value = value;

        public static implicit operator string(TrustAnchorName name) => name.Value;

        private static void CheckValidity(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(TrustAnchorName));

            if (value.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Trust anchor name cannot be longer than 100 characters");
        }

        public static TrustAnchorName NoName => new TrustAnchorName();
        protected TrustAnchorName() { }
    }
}
