using System;
using CircleCalculator.Services;
using NUnit.Framework;

namespace CircleCalculator.Tests
{
    /// <summary>
    /// Contains unit tests for the <see cref="Circle"/> class to validate the calculation of the circle's circumference.
    /// The tests include various valid radii, edge cases, and special numerical values to ensure the robustness of the calculation,
    /// particularly when dealing with the limitations of the double type in C#.
    /// </summary>
    [TestFixture]
    public class CircleTests
    {
        /// <summary>
        /// Tests that the circumference calculation returns the expected result for various valid radii.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="expectedCircumference">The expected circumference for the given radius.</param>
        [TestCase(1, 6.283185307179586)]  // Circumference of a circle with radius 1
        [TestCase(2, 12.566370614359172)] // Circumference of a circle with radius 2
        [TestCase(5, 31.41592653589793)]  // Circumference of a circle with radius 5
        [TestCase(10, 62.83185307179586)] // Circumference of a circle with radius 10
        public void Calculate_Circumference_ValidRadius(double radius, double expectedCircumference)
        {
            // Arrange: Create a new Circle instance with the specified radius.
            var circle = new Circle(radius);

            // Act: Calculate the circumference of the circle using the Calculate method.
            double result = circle.Calculate(r => 2 * Math.PI * r);

            // Assert: Verify that the calculated circumference is equal to the expected value within a tolerance.
            Assert.That(result, Is.EqualTo(expectedCircumference).Within(1e-14)); // Comparing with a tolerance of 14 decimal places
        }

        /// <summary>
        /// Tests that the circumference calculation returns zero when the circle's radius is zero.
        /// </summary>
        [Test]
        public void Calculate_Circumference_ZeroRadius_ReturnsZero()
        {
            // Arrange: Create a new Circle instance with a radius of zero.
            var circle = new Circle(0);

            // Act: Calculate the circumference of the circle.
            double result = circle.Calculate(r => 2 * Math.PI * r);

            // Assert: Verify that the result is zero.
            Assert.That(result, Is.EqualTo(0));
        }

        /// <summary>
        /// Tests that the circumference calculation returns a negative circumference for a negative radius.
        /// </summary>
        [Test]
        public void Calculate_Circumference_NegativeRadius_ReturnsNegativeCircumference()
        {
            // Arrange: Create a new Circle instance with a negative radius.
            var circle = new Circle(-5);

            // Act: Calculate the circumference of the circle.
            double result = circle.Calculate(r => 2 * Math.PI * r);

            // Assert: Verify that the result is the expected negative circumference within a tolerance.
            Assert.That(result, Is.EqualTo(-31.41592653589793).Within(1e-14)); // Negative radius results in a negative circumference
        }

        /// <summary>
        /// Tests that the circumference calculation returns positive infinity for a radius equal to double.MaxValue.
        /// </summary>
        [Test]
        public void Calculate_Circumference_MaxDoubleRadius_ReturnsInfinity()
        {
            // Arrange: Create a new Circle instance with the maximum double value as the radius.
            var circle = new Circle(double.MaxValue);

            // Act: Calculate the circumference of the circle.
            double result = circle.Calculate(r => 2 * Math.PI * r);

            // Assert: Verify that the result is positive infinity.
            Assert.That(double.IsInfinity(result));
        }

        /// <summary>
        /// Tests that the circumference calculation returns negative infinity for a radius equal to double.MinValue.
        /// </summary>
        [Test]
        public void Calculate_Circumference_MinDoubleRadius_ReturnsNegativeInfinity()
        {
            // Arrange: Create a new Circle instance with the minimum double value as the radius.
            var circle = new Circle(double.MinValue);

            // Act: Calculate the circumference of the circle.
            double result = circle.Calculate(r => 2 * Math.PI * r);

            // Assert: Verify that the result is negative infinity.
            Assert.That(double.IsNegativeInfinity(result));
        }

        /// <summary>
        /// Tests that the circumference calculation returns NaN when the radius is NaN.
        /// </summary>
        [Test]
        public void Calculate_Circumference_NaNRadius_ReturnsNaN()
        {
            // Arrange: Create a new Circle instance with NaN as the radius.
            var circle = new Circle(double.NaN);

            // Act: Calculate the circumference of the circle.
            double result = circle.Calculate(r => 2 * Math.PI * r);

            // Assert: Verify that the result is NaN.
            Assert.That(double.IsNaN(result));
        }

        /// <summary>
        /// Tests that the circumference calculation returns positive infinity for a radius equal to double.PositiveInfinity.
        /// </summary>
        [Test]
        public void Calculate_Circumference_PositiveInfinityRadius_ReturnsPositiveInfinity()
        {
            // Arrange: Create a new Circle instance with positive infinity as the radius.
            var circle = new Circle(double.PositiveInfinity);

            // Act: Calculate the circumference of the circle.
            double result = circle.Calculate(r => 2 * Math.PI * r);

            // Assert: Verify that the result is positive infinity.
            Assert.That(double.IsPositiveInfinity(result));
        }

        /// <summary>
        /// Tests that the circumference calculation returns negative infinity for a radius equal to double.NegativeInfinity.
        /// </summary>
        [Test]
        public void Calculate_Circumference_NegativeInfinityRadius_ReturnsNegativeInfinity()
        {
            // Arrange: Create a new Circle instance with negative infinity as the radius.
            var circle = new Circle(double.NegativeInfinity);

            // Act: Calculate the circumference of the circle.
            double result = circle.Calculate(r => 2 * Math.PI * r);

            // Assert: Verify that the result is negative infinity.
            Assert.That(double.IsNegativeInfinity(result));
        }
    }
}
