using System;
using Valenia.Common;
using Valenia.Domain.Shared.Exceptions;

namespace Valenia.Domain.TrustAnchors
{
    public class TrustAnchor : AggregateRoot<TrustAnchorDID>
    {
        public TrustAnchorName Name { get; set; }
        public Uri Logo { get; set; }
        public string VerKey { get; set; }

        public TrustAnchor(string DID, string verKey)
        {
            Apply(new TrustAnchorEvents.Registered
            {
                DID = DID,
                VerKey = verKey
            });
        }

        public void UpdateConfiguration(TrustAnchorName name, string logo)
        {
            Apply(new TrustAnchorEvents.ConfigurationUpdated
            {
                Name = name,
                Url = logo
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case TrustAnchorEvents.Registered e:
                    Id = new TrustAnchorDID(e.DID);
                    VerKey = e.VerKey;
                    break;
                case TrustAnchorEvents.ConfigurationUpdated e:
                    Name = TrustAnchorName.FromString(e.Name);
                    Logo = new Uri(e.Url);
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = !Id.Value.IsEmpty() && !VerKey.IsEmpty();

            if (!valid)
                throw new Exceptions.InvalidEntityState(this,
                    $"Post-checks failed for Trust anchor {Id}");
        }

        private string DbId
        {
            get => $"TrustAnchor/{Id.Value}";
            set { }
        }

        protected TrustAnchor() { }
    }
}
