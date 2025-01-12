using System;

namespace Lab06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Uncomment the method calls below to test each feature
            // PrintAlternateArray();
            // SimpleCalculator();
            // FactorialCalculator();
            // SecondLargest();
            CanadianPostalCode();
        }

        // Method to print alternate elements from an array
        static void PrintAlternateArray()
        {
            int[] A = { 1, 2, 3, 5, 7, 55, 54, 25, 17, 97 };

            Console.WriteLine("*** Start of Program ***");
            Console.WriteLine("Print Alternate Array");
            for (int i = 0; i < A.Length; i += 2) // Loop through every second element
            {
                Console.Write(A[i] + " "); // Print the alternate element
            }
            Console.WriteLine();
            Console.WriteLine("***   End of Program ***");
        }

        // Method for a simple calculator
        static void SimpleCalculator()
        {
            Console.WriteLine("*** Start of Program ***");
            bool continueCalculating = true; // Flag to control the loop

            while (continueCalculating)
            {
                // Display calculator options
                Console.WriteLine("Simple Calculator");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                int choice;
                // Validate user input
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    continue; // Restart the loop if input is invalid
                }

                if (choice == 5) // Exit option
                {
                    continueCalculating = false; // Set flag to false to exit loop
                    break;
                }

                // Get first number from user
                Console.Write("Enter first number: ");
                double num1;
                if (!double.TryParse(Console.ReadLine(), out num1)) // Validate input
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue; // Restart the loop
                }

                // Get second number from user
                Console.Write("Enter second number: ");
                double num2;
                if (!double.TryParse(Console.ReadLine(), out num2)) // Validate input
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue; // Restart the loop
                }

                double result = 0; // Variable to store the result

                // Perform the selected operation
                switch (choice)
                {
                    case 1:
                        result = num1 + num2; // Addition
                        break;
                    case 2:
                        result = num1 - num2; // Subtraction
                        break;
                    case 3:
                        result = num1 * num2; // Multiplication
                        break;
                    case 4:
                        if (num2 == 0) // Check for division by zero
                        {
                            Console.WriteLine("Division by zero is not allowed.");
                            continue; // Restart the loop
                        }
                        result = num1 / num2; // Division
                        break;
                }

                // Display the result
                Console.WriteLine($"Result: {result}");
                Console.WriteLine();
            }

            Console.WriteLine("Exiting the program. Press any key to continue...");
            Console.ReadKey(); // Wait for user input
            Console.WriteLine("***   End of Program ***");
        }

        // Method to calculate factorial of a number
        static void FactorialCalculator()
        {
            Console.WriteLine("*** Start of Program ***");
            Console.Write("Enter a number to calculate its factorial (0-20): ");
            int num1;
            // Validate input
            if (!int.TryParse(Console.ReadLine(), out num1) || num1 < 0 || num1 > 20)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return; // Exit the method if input is invalid
            }
            long factorial = 1; // Variable to store the factorial value
            for (int i = 1; i <= num1; i++)
            {
                factorial *= i; // Calculate factorial
            }
            Console.WriteLine($"Factorial of {num1} is: {factorial}");
            Console.WriteLine("***   End of Program ***");
        }

        // Method to find the second largest number in an array
        static void SecondLargest()
        {
            Console.WriteLine("*** Start of Program ***");
            Console.WriteLine("Find second largest number in the array");
            int[] Arr = { 10, 5, 20, 8, 15 };
            int N = Arr.Length;

            // Ensure there are at least two elements
            if (N < 2)
            {
                Console.WriteLine("Invalid input. Array must have at least two elements.");
                return; // Exit the method if input is invalid
            }

            int firstLargest = int.MinValue; // Initialize first largest
            int secondLargest = int.MinValue; // Initialize second largest

            // Iterate through the array to find the largest and second largest
            foreach (int num in Arr)
            {
                if (num > firstLargest)
                {
                    secondLargest = firstLargest; // Update second largest
                    firstLargest = num; // Update first largest
                }
                else if (num > secondLargest && num < firstLargest)
                {
                    secondLargest = num; // Update second largest if needed
                }
            }

            // Output result
            if (secondLargest == int.MinValue)
            {
                Console.WriteLine("There is no second largest element.");
            }
            else
            {
                Console.WriteLine($"Second largest element is: {secondLargest}");
            }
            Console.WriteLine("***   End of Program ***");
        }

        // Method to validate a Canadian postal code
        static void CanadianPostalCode()
        {
            Console.WriteLine("*** Start of Program ***");
            Console.WriteLine("Enter a Canadian Postal Code:");
            string postal = Console.ReadLine()?.Replace(" ", "").Trim(); // Remove spaces and trim input

            // Validate the length of the postal code
            if (postal.Length != 6)
            {
                Console.WriteLine($"Invalid length for postal code: {postal}");
                Console.WriteLine("***   End of Program ***");
                return; // Exit the method if invalid
            }

            bool validate = true; // Flag for validation

            // Validate the format of the postal code
            for (int i = 0; i < postal.Length; i++)
            {
                if ((i % 2 == 0 && !char.IsLetter(postal[i])) || // Check if even index is a letter
                    (i % 2 == 1 && !char.IsDigit(postal[i]))) // Check if odd index is a digit
                {
                    validate = false; // Set validation flag to false if format is incorrect
                    break; // Exit the loop
                }
            }

            // Output validation result
            Console.WriteLine($"Postal code validation for {postal} is {validate}");
            Console.WriteLine("***   End of Program ***");
            Console.ReadKey(); // Wait for user input
        }
    }
}
