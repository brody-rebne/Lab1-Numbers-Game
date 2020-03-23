using System;

namespace Lab1_Numbers_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //initiate the program
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //app will always write this when completed, errors or not
                Console.WriteLine("Program completed");
            }
        }

        /// <summary>
        /// Runs a new game, prompting the user for input and returning their results
        /// </summary>
        public static void StartSequence()
        {
            try
            {
                Console.WriteLine("Welcome to the Numbers Game.");

                //creating  and populating an array of numbers based on a user-input length
                Console.WriteLine("How many numbers would you like to use in the game?");
                int gameLength = Convert.ToInt32(Console.ReadLine());
                int[] gameNumbers = new int[gameLength];

                gameNumbers = Populate(gameNumbers);
                
                //creating a sum, product, and quotient based on user-input numbers
                int sum = Add(gameNumbers);
                int product = Multiply(gameNumbers, sum);
                decimal quotient = Divide(product);

                //results for user
                Console.WriteLine($"Your array length is {gameLength}");
                Console.WriteLine($"The numbers in your array are {String.Join(", ", gameNumbers)}");
                Console.WriteLine($"The sum of your array is {sum}");
                Console.WriteLine($"The product of your sum and the number you chose is {product}");
                Console.WriteLine($"The quotient of your product and the number you gave is {quotient}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Populate array's numbers from user input
        /// </summary>
        /// <param name="array">The array to be populated</param>
        /// <returns>The populated array</returns>
        public static int[] Populate(int[] array)
        {
            //mirroring the input array
            int[] populatedNumbers = new int[array.Length];

            //take user input for each value in array
            for (int i = 0; i<array.Length; i++)
            {
                Console.WriteLine($"Please enter a positive integer ({i} of {array.Length})");
                populatedNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            return populatedNumbers;
        }

        /// <summary>
        /// Adds the numbers in an array together. Throws an error if the sum is less than 20
        /// </summary>
        /// <param name="numbers">The array of numbers to be added</param>
        /// <returns>The sum of the numbers</returns>
        public static int Add(int[] numbers)
        {
            int sum = 0;
            foreach(int num in numbers)
            {
                sum += num;
            }
            if(sum<20)
            {
                throw new Exception($"Value of sum ({sum}) is too low");
            }
            return sum;
        }

        /// <summary>
        /// Multiplies a number at a user-input index of an array by another user-input number
        /// </summary>
        /// <param name="numbers">The array of numbers to be chosen from</param>
        /// <param name="input">The multiplier</param>
        /// <returns>The product of number at the chosen index and the multiplier</returns>
        public static int Multiply(int[] numbers, int input)
        {
            try
            {
                Console.WriteLine($"Please enter a number between 1 and {numbers.Length}");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                int product = input * numbers[index];
                return product;
            }
            //throws an error if the user chooses a number out of the index' range
            catch(IndexOutOfRangeException e)
            {
                Console.Write(e);
                throw;
            }
        }

        /// <summary>
        /// Divides a given number by a user-input number
        /// </summary>
        /// <param name="input">The number to be divided</param>
        /// <returns>The quotient of the given number and a user input</returns>
        public static decimal Divide(int input)
        {
            try
            {
                Console.WriteLine($"Please input a number to divide your product ({input}) by");
                decimal divisor = Convert.ToDecimal(Console.ReadLine());
                decimal quotient = Decimal.Divide(input, divisor);
                return quotient;
            }
            //returns 0 if the user inputs 0 as the divisor
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
                return 0;
            }
        }
    }
}
