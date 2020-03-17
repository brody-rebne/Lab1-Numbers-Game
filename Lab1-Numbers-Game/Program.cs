using System;

namespace Lab1_Numbers_Game
{
    class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("Program completed");
            }
        }

        public static void StartSequence()
        {
            try
            {
                Console.WriteLine("Welcome to the Numbers Game.");
                Console.WriteLine("How many numbers would you like to use in the game?");
                int gameLength = Convert.ToInt32(Console.ReadLine());
                int[] gameNumbers = new int[gameLength];
                gameNumbers = Populate(gameNumbers);
                int sum = Add(gameNumbers);
                int product = Multiply(gameNumbers, sum);
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

        public static int[] Populate(int[] array)
        {
            int[] populatedNumbers = new int[array.Length];
            for (int i = 0; i<array.Length; i++)
            {
                Console.WriteLine($"Please enter a positive integer ({i} of {array}");
                populatedNumbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            return populatedNumbers;
        }

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

        public static int Multiply(int[] numbers, int sum)
        {
            try
            {
                Console.WriteLine($"Please enter a number between 1 and {numbers.Length}");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                int product = sum * numbers[];
                return product;
            }
            catch(IndexOutOfRangeException e)
            {
                throw;
            }
        }
    }
}
