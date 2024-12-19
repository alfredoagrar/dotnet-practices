using EvenNumbersConsole.Services;

var calculator = new CalculatorService();

// Initialize an empty array to store numbers
int[] numbers = Array.Empty<int>();
int index = 0; // Index to track where the next number should be added

Console.WriteLine("Enter integers to add to the array. Type 's' to stop.");

// Run a loop to accept integers
while (true)
{
    Console.Write("Enter an integer: ");
    string input = Console.ReadLine();

    // Check for 'exit' to stop the loop
    if (input?.ToLower() == "s")
        break;

    // Try to parse the input as an integer
    if (int.TryParse(input, out int number))
    {
        // Increase the size of the array and add the new number
        Array.Resize(ref numbers, numbers.Length + 1);
        numbers[index] = number;  // Add the valid integer to the array
        index++;  // Move the index forward
    }
    else
    {
        // Inform the user of invalid input
        Console.WriteLine("Invalid input. Please enter a valid integer.");
    }
}

// Calculate the sum of even numbers
int sumOfEvens = calculator?.SumOfEvenNumbers(numbers) ?? 0;

// Output the result to the console
Console.WriteLine($"The sum of even numbers is: {sumOfEvens}");
