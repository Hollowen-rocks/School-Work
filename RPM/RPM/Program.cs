namespace RPM
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Russian Peasant Multiplication!");

            int num1 = 0, num2 = 0;
            bool inputValid = false;

            while (!inputValid)
            {
                try
                {
                    num1 = GetValidIntegerInput("Enter the first number: ");
                    num2 = GetValidIntegerInput("Enter the second number: ");

                    inputValid = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                }
            }
            int result = RussianPeasantMultiplication(num1, num2);

            Console.WriteLine($"The product of {num1} and {num2} is: {result}");
        }

        public static int RussianPeasantMultiplication(int a, int b)
        {
            int result = 0;

            while (a > 0)
            {
                if (a % 2 != 0)
                {
                    try
                    {
                        result = checked(result + b);
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return -1;
                    }
                }

                try
                {
                    a = checked(a / 2);
                    b = checked(b * 2);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return -1;
                }
            }

            return result;
        }

        private static int GetValidIntegerInput(string message)
        {
            int number = 0;
            bool isValid = false;

            do
            {
                Console.Write(message);
                string? input = Console.ReadLine(); // Added nullable reference type (?)

                try
                {
                    number = int.Parse(input!); // Added null-forgiving operator (!)
                    isValid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input is too large or too small for an integer.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                }
            } while (!isValid);

            return number;
        }
    }
}
