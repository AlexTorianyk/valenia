using System;
using Valenia.Domain.Users.Shared;
using Xunit;

namespace Valenia.Tests
{
    public class EmailTests
    {
        [Fact]
        public void Create_CalledWithValidArguments()
        {
            // Arrange
            const string emailText = "oleksandr.torianyk@konsulat.pl";

            // Act
            var email = Email.FromString(emailText);

            // Assert
            Assert.Equal(emailText, email.Value);
        }

        [Fact]
        public void ThrowException_CalledWithInValidArguments()
        {
            // Arrange
            const string emailText = "invalid_email";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => Email.FromString(emailText));
        }
    }
}
