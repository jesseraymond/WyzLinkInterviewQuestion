using System;
using System.Linq;

static class Program
{
    static void Main(string[] args)
    {
        // Setup the console for desired user input (n)
        int n;
        Console.WriteLine("Input a number (1 - 9) to display its pattern:");
        ConsoleKeyInfo input = Console.ReadKey();
        Console.WriteLine("\n");
        if (char.IsDigit(input.KeyChar))
        {
            n = int.Parse(input.KeyChar.ToString());
        }
        else
        {
            // If the input is not a valid number, reset the console
            n = 0;
            Main(new string[] { });
        }

        // The number pattern we're trying to recreate only ever has an odd number of columns/rows,
        // so we compare the input with its place in a generated Linq list of odd numbers to get the column/row limit
        var oddNumbers = Enumerable.Range(1, 100).Where(i => i % 2 != 0);
        int odd = oddNumbers.ElementAt(n - 1);

        // Iterate through the rows to generate and output values
        for (int r = 0; r < odd; r++)
        {
            string output = "";

            // Find the value that matches the pattern based on only its row coordinate (we'll look at its column coordinate next)
            // Math.Abs() makes the values symmetrical once 0 is reached (at the midpoint). We then add one to match the pattern.
            int rowValue = Math.Abs(r - (n - 1)) + 1;

            // Now iterate through each column (per row)
            for (int c = 0; c < odd; c++)
            {
                // And use the same expression, except with the column coordinate instead of the row coordinate
                int colValue = Math.Abs(c - (n - 1)) + 1;

                // To create the ring pattern, the higher value between rowValue and colValue is what we output
                output += (rowValue > colValue) ? rowValue.ToString() : colValue.ToString();
            }

            Console.WriteLine(output);
        }

        // Restart when complete
        Console.WriteLine("");
        Main(new string[] { });
    }
}
