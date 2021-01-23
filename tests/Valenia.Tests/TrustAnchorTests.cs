using Valenia.Domain.TrustAnchors;
using Xunit;

namespace Valenia.Tests
{
    public class TrustAnchorTests
    {
        public class Register : TrustAnchorTests
        {
            [Fact]
            public void Register_Called()
            {
                // Arrange
                const string did = "test_did";
                const string verKey = "test_verKey";

                // Act
                var trustAnchor = new TrustAnchor(did, verKey);

                //Assert
                Assert.Equal(did, trustAnchor.Id);
                Assert.Equal(verKey, trustAnchor.VerKey);
            }
        }

        public class UpdateConfiguration : TrustAnchorTests
        {
            [Fact]
            public void UpdateConfiguration_Called()
            {
                // Arrange
                var trustAnchor = new TrustAnchor("test_did", "test_verKey");
                var name = TrustAnchorName.FromString("Opole University of Technology");
                const string logoUrl = "https://pyxis.nymag.com/v1/imgs/bc9/5bb/95f88f06973066c75f07b98ed8af7f634a-18-pepe-the-frog.rsocial.w1200.jpg";

                // Act
                trustAnchor.UpdateConfiguration(name, logoUrl);

                //Assert
                Assert.Equal(name, trustAnchor.Name);
                Assert.Equal(logoUrl, trustAnchor.Logo.ToString());
            }
        }
    }
}
