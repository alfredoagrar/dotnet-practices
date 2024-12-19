using EvenNumbersConsole.Services;

namespace EvenNumbers.Tests
{
    /// <summary>
    /// Unit tests for the IArrayCalculator interface using Moq.
    /// </summary>
    [TestFixture]
    public class EvenNumbersTests
    {
        /// <summary>
        /// Tests that SumOfEvenNumbers returns 0 when the input array is empty.
        /// </summary>
        [Test]
        public void CalculateWithEmptyArray_ShouldReturnZero()
        {
            // Arrange
            var calculator = new CalculatorService();
            int[] numbers = Array.Empty<int>();

            // Act
            int result = calculator.SumOfEvenNumbers(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        /// <summary>
        /// Tests that SumOfEvenNumbers returns 0 when the input array is null.
        /// </summary>
        [Test]
        public void CalculateWithNullArray_ShouldReturnZero()
        {
            // Arrange
            var calculator = new CalculatorService();

            // Act
            int result = calculator.SumOfEvenNumbers(null);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        /// <summary>
        /// Tests that SumOfEvenNumbers correctly sums only the even numbers in a mixed array.
        /// </summary>
        [Test]
        public void CalculateWithMixedNumbersArray_ShouldOnlySumEvenNumbers()
        {
            // Arrange
            var calculator = new CalculatorService();
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Act
            int result = calculator.SumOfEvenNumbers(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(6));
        }

        /// <summary>
        /// Tests that SumOfEvenNumbers returns 0 when the input array contains only odd numbers.
        /// </summary>
        [Test]
        public void CalculateWithOnlyOddNumbersArray_ShouldReturnZero()
        {
            // Arrange
            var calculator = new CalculatorService();
            int[] numbers = { 1, 3, 5, 7, 9 };

            // Act
            int result = calculator.SumOfEvenNumbers(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
