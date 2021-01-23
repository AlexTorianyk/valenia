using Valenia.Infrastructure.Application;
using Xunit;

namespace Valenia.Tests
{
    public class PasswordHasherTests
    {
        public class HashPassword : PasswordHasherTests
        {
            // this is due to the salt
            [Fact]
            public void ProduceDifferentHash_CalledWithTheSameValues()
            {
                // Arrange
                const string password = "strong password";
                var passwordHasher = new PasswordHasher();

                // Act
                var firstHashedPassword = passwordHasher.HashPassword(password);
                var secondHashedPassword = passwordHasher.HashPassword(password);

                // Assert
                Assert.NotEqual(firstHashedPassword, secondHashedPassword);
            }

            [Fact]
            public void ProduceDifferentHashHash_CalledWithDifferentValues()
            {
                // Arrange
                const string firstPassword = "strong password";
                const string secondPassword = "weak password";
                var passwordHasher = new PasswordHasher();

                // Act
                var firstHashedPassword = passwordHasher.HashPassword(firstPassword);
                var secondHashedPassword = passwordHasher.HashPassword(secondPassword);

                // Assert
                Assert.NotEqual(firstHashedPassword, secondHashedPassword);
            }
        }
    }
}
