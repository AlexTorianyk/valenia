using System;
using Valenia.Domain.Visas;
using Xunit;

namespace Valenia.Tests
{
    public class VisaExpectedProcessingTimeTests
    {
        [Fact]
        public void Create_CalledWithFromIntWithValidArgument()
        {
            // Arrange
            const int days = 30;

            // Act
            var expectedProcessingTimes = VisaExpectedProcessingTime.FromInt(days);

            // Assert
            Assert.Equal(days, expectedProcessingTimes.Days);
        }

        [Fact]
        public void Create_CalledWithFromStringWithValidArgument()
        {
            // Arrange
            const string days = "30";

            // Act
            var expectedProcessingTimes = VisaExpectedProcessingTime.FromString(days);

            // Assert
            Assert.Equal(days, expectedProcessingTimes.Days.ToString());
        }

        [Fact]
        public void ThrowExceptions_CalledWithFromStringWithInvalidArgument()
        {
            // Arrange
            const string days = "invalid_days";

            // Act & Assert
            Assert.Throws<FormatException>(() => VisaExpectedProcessingTime.FromString(days));
        }

        [Fact]
        public void Create_CalledWithFromIntWithMoreThan1000Days()
        {
            // Arrange
            const int days = 1000000;

            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => VisaExpectedProcessingTime.FromInt(days));
        }

        [Fact]
        public void Create_CalledWithFromIntWithLessThanOneDay()
        {
            // Arrange
            const int days = -1;

            // Act
            Assert.Throws<ArgumentException>(() => VisaExpectedProcessingTime.FromInt(days));
        }
    }
}
