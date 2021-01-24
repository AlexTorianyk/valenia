using System;
using Valenia.Common;

namespace Valenia.Domain.TrustAnchors
{
    public class TrustAnchorDID : Value<TrustAnchorDID>
    {
        public string Value { get; internal set; }
        protected TrustAnchorDID() { }

        public TrustAnchorDID(string value)
        {
            CheckValidity(value);

            Value = value;
        }

        private static void CheckValidity(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value), "Trust anchor did cannot be empty");
        }

        public static TrustAnchorDID FromString(string trustAnchorDID)
        {
            if (trustAnchorDID.IsEmpty())
                throw new ArgumentNullException(nameof(trustAnchorDID));

            return new TrustAnchorDID(trustAnchorDID);
        }

        public static implicit operator string(TrustAnchorDID self) => self.Value;
    }
}
