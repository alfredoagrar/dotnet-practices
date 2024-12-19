using CircleCalculator.Services;

Console.WriteLine("Program to calculate the circumference of a circle.");
Console.WriteLine("--------------------------------------------------");

while (true)
{
    try
    {
        Console.Write("Enter the radius of the circle (or 'exit' to quit): ");
        string input = Console.ReadLine();

        // Exit the program
        if (input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Thank you for using the program. Goodbye!");
            break;
        }

        // Validate that the input is a number
        if (!double.TryParse(input, out double radius))
        {
            Console.WriteLine("Error: Please enter a valid number.");
            continue;
        }

        // Create a Circle instance
        var circle = new Circle(radius);

        // Calculate the circumference
        double circumference = circle.Calculate(r => 2 * Math.PI * r);

        // Handle special results
        if (double.IsNaN(circumference))
        {
            Console.WriteLine("Result: The circumference is NaN (not a number).");
        }
        else if (double.IsPositiveInfinity(circumference))
        {
            Console.WriteLine("Result: The circumference is positive infinity (∞).");
        }
        else if (double.IsNegativeInfinity(circumference))
        {
            Console.WriteLine("Result: The circumference is negative infinity (-∞).");
        }
        else
        {
            Console.WriteLine($"The circumference of the circle with radius {radius} is: {circumference:F14}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    }

    Console.WriteLine();
}