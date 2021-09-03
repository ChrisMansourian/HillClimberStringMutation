using System;

namespace HillClimbingStrings
{
    class Program
    {
        static string GenerateRandomString(int size)
        {
            Random gen = new Random();
            string temp = "";
            for (int i = 0; i < size; i++)
            {
                temp += (char)(gen.Next(32, 127));
            }
            return temp;
        }

        static double CalculateError(string Target, string Current)
        {
            double temp = 0;
            for (int i = 0; i < Target.Length; i++)
            {
                temp += Math.Abs(Target[i] - Current[i]);
            }
            return temp / Target.Length;
        }

        static string MutateString(string Target, string Current)
        {
            Random gen = new Random();
            int index = gen.Next(0, Current.Length);
            int add = 1;
            if (gen.Next(0, 2) == 1)
            {
                add *= -1;
            }

            string temp = "";

            for (int i = 0; i < Current.Length; i++)
            {
                if (i == index)
                {
                    temp += (char)((int)Current[i] + add);
                }
                else
                {
                    temp += Current[i];
                }
            }

            if (CalculateError(Target, temp) < CalculateError(Target, Current))
            {
                return temp;
            }
            return Current;
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a target string");
                string targetString = Console.ReadLine();
                string currentString = GenerateRandomString(targetString.Length);
                Console.WriteLine("Starting string is: " + currentString);
                Console.WriteLine("Hit enter to begin");
                Console.ReadLine();
                double Error = CalculateError(targetString, currentString);
                int mutationCount = 0;

                while (Error != 0)
                {
                    currentString = MutateString(targetString, currentString);
                    Error = CalculateError(targetString, currentString);
                    Console.WriteLine("Target: " + targetString);
                    Console.WriteLine("Current: " + currentString);

                    mutationCount++;
                }

                Console.WriteLine($"It took {mutationCount} mutations to find the target");


                string playAgain = "";
                while (playAgain.ToLower() != "yes" && playAgain.ToLower() != "no")
                {
                    Console.WriteLine("Do you want to compute another string");
                    playAgain = Console.ReadLine();
                }

                if (playAgain.ToLower() == "no")
                {
                    break;
                }
            }
        }



    }
}
