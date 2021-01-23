using Valenia.Domain.Users.EmbassyEmployees;
using Valenia.Domain.Users.Shared;
using Valenia.Infrastructure.Application;
using Xunit;

namespace Valenia.Tests
{
    public class EmbassyEmployeeTests
    {
        public class Register : EmbassyEmployeeTests
        {
            [Fact]
            public void CreateAnEmployee_ValidParameters()
            {
                // Arrange
                var passwordHasher = new PasswordHasher();
                var fullName = FullName.FromString("Oleksandr Torianyk");
                var email = Email.FromString("ol.torianyk@konsulat.pl");
                var password = Password.FromString("strong password", passwordHasher);
                const EmbassyEmployeeRole role = EmbassyEmployeeRole.Admin;

                // Act
                var employee = new EmbassyEmployee(fullName, email, password, role);

                //Assert
                Assert.Equal(fullName, employee.FullName);
                Assert.Equal(email, employee.Email);
                Assert.Equal(password, employee.Password);
                Assert.Equal(role, employee.Role);
            }
        }

        public class Fire : EmbassyEmployeeTests
        {
            [Fact]
            public void ChangeStatus_Called()
            {
                // Arrange
                var passwordHasher = new PasswordHasher();
                var fullName = FullName.FromString("Oleksandr Torianyk");
                var email = Email.FromString("ol.torianyk@konsulat.pl");
                var password = Password.FromString("strong password", passwordHasher);
                const EmbassyEmployeeRole role = EmbassyEmployeeRole.Admin;
                var employee = new EmbassyEmployee(fullName, email, password, role);

                // Act
                employee.Fire();

                //Assert
                Assert.Equal(fullName, employee.FullName);
                Assert.Equal(email, employee.Email);
                Assert.Equal(password, employee.Password);
                Assert.Equal(EmbassyEmployeeRole.Discharged,  employee.Role);
            }
        }
    }
}
