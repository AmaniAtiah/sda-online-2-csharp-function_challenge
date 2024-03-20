using System;

namespace FunctionChallenges
{
    class Program
    {
        public static void StringNumberProcessor(params object[] objects)
        {
            int total = 0;
            string concatenatedString = "";

            foreach (object obj in objects)
            {
                if (obj.GetType() == typeof(int))
                {
                    total += Convert.ToInt32(obj);
                }
                else
                {
                    concatenatedString += obj.ToString() + " ";
                }
            }

            Console.WriteLine($"{concatenatedString}; {total}");
        }


        public static void GuessGame()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 100);


            while (true)
            {
                Console.Write("Guess a number between 1 and 100: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                if (guess < randomNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed it right!");
                    break;
                }


            }



        }


        static void Main(string[] args)
        {
            // Challenge 1: String and Number Processor
            Console.WriteLine("Challenge 1: String and Number Processor");
            StringNumberProcessor("Hello", 100, 200, "World"); // Expected outcome: "Hello World; 300"

            // Challenge 2: Object Swapper
            Console.WriteLine("\nChallenge 2: Object Swapper");
            int num1 = 25, num2 = 30;
            int num3 = 10, num4 = 30;
            string str1 = "HelloWorld", str2 = "Programming";
            string str3 = "Hi", str4 = "Programming";

            GuessGame();

            // SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25  
            // SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

            // SwapObjects(str1, str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            // SwapObjects(str3, str4); // Error: Length must be more than 5

            // SwapObjects(true, false); // Error: Upsupported data type
            // SwapObjects(ref num1, str1); // Error: Objects must be of same types

            // Console.WriteLine($"Numbers: {num1}, {num2}");
            // Console.WriteLine($"Strings: {str1}, {str2}");

            // // Challenge 3: Guessing Game
            // Console.WriteLine("\nChallenge 3: Guessing Game");
            // // Uncomment to test the GuessingGame method
            // // GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

            // // Challenge 4: Simple Word Reversal
            // Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            // string sentence = "This is the original sentence!";
            // string reversed = ReverseWords(sentence);
            // Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
        }
    }
}
