using System;
using System.Text;

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

        public static void GuessingGame()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 100);

            while (true)
            {
                Console.Write("Guess a number between 1 and 100: ");
                string input = Console.ReadLine() ?? "";

                try
                {
                    if (!int.TryParse(input, out int guess))
                    {
                        throw new ArgumentException("Please enter a valid number.");
                    }

                    if (guess < 1 || guess > 100)
                    {
                        throw new ArgumentException("Please enter a number between 1 and 100.");
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
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


        static string ReverseWords(string sentence)
        {
            try
            {
                string[] words = sentence.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    char[] chars = words[i].ToCharArray();
                    Array.Reverse(chars);
                    words[i] = new string(chars);
                }

                return string.Join(" ", words);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        

        public static void SwapObjects<T>(ref T obj1, ref T obj2)
        {
            try
            {

                if (typeof(T) == typeof(int))
                {
                    int num1 = Convert.ToInt32(obj1);
                    int num2 = Convert.ToInt32(obj2);


                    if (num1 <= 18 || num2 <= 18)
                    {
                        throw new ArgumentException("Error: Value must be more than 18");

                    }

                    int temp = num1;
                    num1 = num2;
                    num2 = temp;

                    obj1 = (T)(object)num1;
                    obj2 = (T)(object)num2;

                }
                else if (typeof(T) == typeof(string))
                {
                    string str1 = obj1.ToString();
                    string str2 = obj2.ToString();

                    if (str1.Length <= 5 || str2.Length <= 5)
                    {
                        throw new ArgumentException("Error: Value must be more than 5");

                    }
                    string temp = str1;
                    str1 = str2;
                    str2 = temp;

                    obj1 = (T)(object)str1;
                    obj2 = (T)(object)str2;

                }
                else if (obj1.GetType() != obj2.GetType())
                {
                    throw new ArgumentException("Error: Objects must be of the same type");

                }
                else
                {
                    throw new ArgumentException("Error: Upsupported data type");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

            SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25  
            SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

            SwapObjects(ref str1, ref str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            SwapObjects(ref str3, ref str4); // Error: Length must be more than 5

            // SwapObjects(true, false); // Error: Upsupported data type
            // SwapObjects(ref num1, str1); // Error: Objects must be of same types

            Console.WriteLine($"Numbers: {num1}, {num2}");
            Console.WriteLine($"Strings: {str1}, {str2}");

            // Challenge 3: Guessing Game
            Console.WriteLine("\nChallenge 3: Guessing Game");
            // Uncomment to test the GuessingGame method
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

            // Challenge 4: Simple Word Reversal
            Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            string sentence = "This is the original sentence!";
            string reversed = ReverseWords(sentence);
            Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
        }
    }
}
