using Xunit;
using ApiAiBlazorLab;

namespace ApiAiBlazorLab.Tests
{
    public class TextUtilitiesTests
    {
        [Fact]
        public void NormalizeFact_NullInput_ReturnsFallback()
        {
            // Arrange
            string? input = null;

            // Act
            var result = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.Equal("No fact available.", result);
        }

        [Fact]
        public void NormalizeFact_EmptyString_ReturnsFallback()
        {
            // Arrange
            string input = "";

            // Act
            var result = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.Equal("No fact available.", result);
        }

        [Fact]
        public void NormalizeFact_WhitespaceOnly_ReturnsFallback()
        {
            // Arrange
            string input = "   ";

            // Act
            var result = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.Equal("No fact available.", result);
        }

        [Fact]
        public void NormalizeFact_MissingPeriod_AddsPeriod()
        {
            // Arrange
            string input = "Cats are awesome";

            // Act
            var result = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.Equal("Cats are awesome.", result);
        }

        [Fact]
        public void NormalizeFact_ExistingPeriod_DoesNotAddAnother()
        {
            // Arrange
            string input = "Cats are awesome.";

            // Act
            var result = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.Equal("Cats are awesome.", result);
        }

        [Fact]
        public void NormalizeFact_ExtraWhitespace_TrimsAndAddsPeriod()
        {
            // Arrange
            string input = "  Cats sleep a lot  ";

            // Act
            var result = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.Equal("Cats sleep a lot.", result);
        }
    }
}
