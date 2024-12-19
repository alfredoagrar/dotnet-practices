namespace EvenNumbersConsole.Services
{
    /// <summary>
    /// Service class responsible for array calculations.
    /// </summary>
    public class CalculatorService
    {
        /// <summary>
        /// Calculates the sum of even numbers in the provided array.
        /// </summary>
        /// <param name="numbers">The array of integers to process.</param>
        /// <returns>The sum of even numbers in the array. Returns 0 if the array is null or empty.</returns>
        public int SumOfEvenNumbers(int[]? numbers)
        {
            // Initialize the sum variable
            int sum = 0;

            // If the input array is null or empty, return the sum as 0
            if (numbers == null || numbers.Length == 0) return sum;

            // Use LINQ to filter even numbers and calculate their sum
            sum = numbers.Where(number => number % 2 == 0).Sum();

            // Return the sum of even numbers
            return sum;
        }
    }
}
