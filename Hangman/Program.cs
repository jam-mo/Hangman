using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList myList = new ArrayList();
            //List<string> list = new List<string>();
            string contents = "";
            Random random = new Random();

            // var lines = File.ReadAllLines(@"D:\vscFiles\Lessons\HangmanGame\Hangman\Hangman\Files\Words.txt");
            //using (var sr = new StreamReader)

            try
            {
                // Get file name.
                string path = @"D:\vscFiles\Lessons\HangmanGame\Hangman\Hangman\Files\Words.txt";
                // Get path name.
                string filename = Path.GetFileName(path);
                // Open the text file using a stream reader. Read into a string
                using (var sr = new StreamReader(path))
                {
                    // Read the stream as a string, and write the string to the console.
                    contents = sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            var arr = contents.Split('\n'); // splits conents into array
                                            //foreach (string line in arr)
                                            //{
                                            //  Console.WriteLine(line);
                                            //}

            var assigned_word = arr[random.Next(0,arr.Length)]; // accesses random word in array 
            var guessing_word = new StringBuilder(); // seperated due to length issue, System.ArgumentOutOfRangeException: 'Capacity exceeds maximum capacity. Parameter name: capacity'
            guessing_word.Append('*', assigned_word.Length); // sets astericks of assigned_word, when user guesses correctly, will reveal letters
            Console.WriteLine(assigned_word);
            var score = 0;

            Console.WriteLine("Welcome to Hangman - You have 7 guesses to guess the correct word");

            while (score != 7 && guessing_word.ToString() != assigned_word) //conditions to break the game - if words been guessed, or too many guesses
            {
                Console.WriteLine(guessing_word);
                Console.WriteLine("Take a guess: ");

                String guess = Console.ReadLine();
                //String guessString = Console.ReadLine();
                //StringBuilder guess = new StringBuilder(guessString); // converts string to StringBuilder
                if (guess.Length > 1 ) 
                { // if guess is more than 1 character, taking a guess for the whole word.
                    if (guess == assigned_word)
                    {
                        Console.WriteLine("Congratulations! You guessed correctly!");
                        score++;
                        Console.WriteLine($"You guessed it in {score} "); // do it in if/else attempts
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You guessed, wrong. Try again!");
                    }
                }
                else
                { // else if it's just one character, loop compares guess against each character in word to see if it exists.
                    for (int i = 0; i < assigned_word.Length; i++) 
                    {
                    if (assigned_word[i] == guess[0])
                        {
                            char guessChar = guess[0]; // needs to be converted into char so it can replace *.
                            guessing_word[i] = guessChar;
                        }
                    }
                }
                score++;
            }

            
            if (guessing_word.ToString() == assigned_word)
            {
                Console.WriteLine("Congratulations! You guessed correctly!");
            }
            else
            {
                Console.WriteLine("Sorry, you ran out of guesses.");
                Console.WriteLine($"The word was: {assigned_word}");
            }




            Console.ReadLine();
      
        }
    }
}
