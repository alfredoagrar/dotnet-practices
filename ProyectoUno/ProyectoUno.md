# ProyectoUno

**ProyectoUno** is a solution that contains two projects: **CircleCalculator** and **EvenNumbersArray**. Each project has its own source code and corresponding test project. This solution demonstrates different functionalities and their respective unit tests using NUnit.

## Table of Contents

1. [CircleCalculator](#circlecalculator)
    - [Structure](#circlecalculator-structure)
    - [Usage](#circlecalculator-usage)
    - [Tests](#circlecalculator-tests)
2. [EvenNumbersArray](#evennumbersarray)
    - [Structure](#evennumbersarray-structure)
    - [Usage](#evennumbersarray-usage)
    - [Tests](#evennumbersarray-tests)

---

## CircleCalculator

This project provides functionality to calculate the circumference of a circle given its radius.

### CircleCalculator Structure

```
CircleCalculator/
│-- src/
│   └└ CircleCalculator/
│       ├└ Services/
│       │   └└ Circle.cs
│       └└ Program.cs
└-- tests/
    └└ CircleCalculatorTests/
        └└ CircleTests.cs
```

- **Circle.cs**: Contains the `Circle` class, which calculates the circumference of a circle based on the radius.
- **Program.cs**: A console program to interact with the `Circle` class, allowing the user to input a radius and see the calculated circumference.
- **CircleTests.cs**: NUnit tests for validating the functionality of the `Circle` class.

### Usage

To use the console application:

1. Run the **CircleCalculator** project.
2. Input the radius when prompted. You can type "exit" to quit the program.

**Example Execution:**
```
Enter the radius of the circle (or 'exit' to quit): 5
The circumference of the circle with radius 5 is: 31.41592653589793
```

### Tests

The tests cover various scenarios:

- **Valid Radii** (e.g., 1, 2, 5, 10)
- **Zero Radius** (expecting a circumference of 0)
- **Negative Radius** (expecting a negative circumference)
- **Edge Cases** (e.g., very large or very small numbers)

---

## EvenNumbersArray

This project provides functionality to work with even numbers in arrays.

### EvenNumbersArray Structure

```
EvenNumbersArray/
│-- src/
│   └└ EvenNumbersConsole/
│       ├└ Services/
│       │   └└ CalculatorService.cs
│       └└ Program.cs
└-- tests/
    └└ EvenNumbers.Tests/
        └└ EvenNumbersTests.cs
```

- **CalculatorService.cs**: Contains methods to process arrays and filter even numbers.
- **Program.cs**: A console program to interact with the `CalculatorService` class.
- **EvenNumbersTests.cs**: NUnit tests for validating the even number filtering functionality.

### Usage

To use the console application:

1. Run the **EvenNumbersConsole** project.
2. Enter an array of numbers separated by spaces.

**Example Execution:**
```
Enter numbers separated by spaces: 1 2 3 4 5 6
The even numbers are: 2 4 6
```

### Tests

The tests cover various scenarios:

- **Arrays with even and odd numbers**
- **Arrays with only even numbers**
- **Arrays with only odd numbers**
- **Empty arrays**
- **Null inputs**

---

## How to Run the Projects

1. Open the solution **"ProyectoUno"** in Visual Studio.
2. Build the solution to ensure there are no errors.
3. Run each console application:
   - **CircleCalculator**: Right-click on `CircleCalculator` project and select **Run**.
   - **EvenNumbersArray**: Right-click on `EvenNumbersConsole` project and select **Run**.

To run the tests:

1. Open the **Test Explorer** in Visual Studio (`Test > Test Explorer`).
2. Run all tests by clicking **Run All**.

---

## Requirements

- **.NET 6 or later**
- **NUnit** for unit testing

---

## Contributing

Feel free to contribute by adding new features or improving the existing code. Submit a pull request with your changes.

---

## License

This project is licensed under the MIT License.

---
