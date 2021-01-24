using Valenia.Domain.Shared.Exceptions;
using Valenia.Domain.Visas;
using Valenia.Domain.Visas.Requirements;
using Xunit;

namespace Valenia.Tests
{
    public class VisaTests
    {
        public class Create : VisaTests
        {
            [Fact]
            public void CreateVisa_ValidParameters()
            {
                // Arrange
                const VisaType type = VisaType.D;

                // Act
                var visa = new Visa(type);

                //Assert
                Assert.Equal(type, visa.Type);
                Assert.False(visa.Id == null);
            }
        }

        public class SetGoal : VisaTests
        {
            [Fact]
            public void SetVisaGoal_ValidGoal()
            {
                // Arrange
                const VisaType type = VisaType.D;
                var visa = new Visa(type);
                var goal = VisaGoal.FromString("Education");

                // Act
                visa.SetGoal(goal);

                //Assert
                Assert.Equal(goal, visa.Goal);
            }
        }

        public class AddRequirement : VisaTests
        {
            [Fact]
            public void AddRequirement_ValidRequirementAndExpectedProcessingTimeSet()
            {
                // Arrange
                const VisaType type = VisaType.D;
                var visa = new Visa(type);
                var requirementName = RequirementName.FromString("Invitation Letter");
                var requirementDescription =
                    RequirementDescription.FromString("A letter of acceptance from a foreign university.");
                var requirementExample = RequirementExample.FromString("acceptance_letter_example.png");
                visa.SetExpectedProcessingTime(VisaExpectedProcessingTime.FromInt(30));

                // Act
                visa.AddRequirement(requirementName, requirementDescription, requirementExample);

                //Assert
                Assert.NotEmpty(visa.Requirements);
            }

            [Fact]
            public void ThrowException_ValidRequirementButExpectedProcessingTimeNotSet()
            {
                // Arrange
                const VisaType type = VisaType.D;
                var visa = new Visa(type);
                var requirementName = RequirementName.FromString("Invitation Letter");
                var requirementDescription =
                    RequirementDescription.FromString("A letter of acceptance from a foreign university.");
                var requirementExample = RequirementExample.FromString("acceptance_letter_example.png");

                // Act & Assert
                Assert.Throws<Exceptions.InvalidEntityState>(() =>
                    visa.AddRequirement(requirementName, requirementDescription, requirementExample));
            }
        }
    }
}
