using Valenia.Domain.Users.Applicants;
using Valenia.Domain.Users.Shared;
using Valenia.Infrastructure.Application;
using Xunit;

namespace Valenia.Tests
{
    public class ApplicantTests
    {
        public class Register : ApplicantTests
        {
            [Fact]
            public void RegisterAnApplicant_ValidParameters()
            {
                // Arrange
                var passwordHasher = new PasswordHasher();
                var fullName = FullName.FromString("Oleksandr Torianyk");
                var email = Email.FromString("ol.torianyk@konsulat.pl");
                var password = Password.FromString("strong password", passwordHasher);

                // Act
                var employee = new Applicant(fullName, email, password);

                //Assert
                Assert.Equal(fullName, employee.FullName);
                Assert.Equal(email, employee.Email);
                Assert.Equal(password, employee.Password);
            }
        }
    }
}
