using System;

namespace _05OnlyLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string digits = null;
            digits = TakeLastDigits(input, digits); // Collectng last digits in the string if we have such.
            int counter = 0;
            input = RemoveLastDigits(input);
            for (int i = 0; i < input.Length; i++) // Looping over the main string.
            {

                char substitute = input[i]; // restarting the substitude variable after manipulations bellow are finished.
                if (Char.IsNumber(input[i]))
                {
                    for (int j = i + 1; j < input.Length; j++) // If we find a number at index[i] => looping over the next symbols for checking if they are numbers or letters.
                    {                                          // This loop starts from the symbol after the first number is found e.g. index[i+1].
                        if (Char.IsLetter(input[j])) // if the symbol after the number[i] is letter => replace number[i] with that letter[j].
                        {
                            substitute = input[j];
                            input = input.Replace(input[i], substitute);
                            break;
                        }
                        else if (char.IsNumber(input[j])) //If the symbol after the number[i] is also a number....
                        {
                            for (int k = j; k < input.Length; k++)//...looping over the next symbols after the one at index[i].
                            {
                                if (Char.IsLetter(input[k])) // if they are numbers, we are counting how many numbers we have. If letters, break. 
                                {
                                    break;
                                }
                                counter++; // Counting how many numbers we have afrer the first number at index[i] 
                            }
                            int index = j; //If we have a number at index[i](at first position) and we have a number/s after that...
                            input = input.Remove(index, counter);//...we are removing the number/s following the first number at index[i]; ex 12345H => 1H
                            substitute = input[j];//Afrer we have removed all numbers[j] following the number at index[i] we are havig a letter at index[j]
                            input = input.Replace(input[i], substitute);//...we are replacing the number at[i] wigh the letter at[j] examp 1H => HH
                            break;
                        }
                    }
                }
            }

            string result = input + digits;
            Console.WriteLine(result);
        }
        private static string RemoveLastDigits(string input) //Method for removing if last symbols of the string are digits.
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (Char.IsNumber(input[i]))
                {
                    input = input.Remove(i);
                }
                else
                {
                    break;
                }
            }
            return input;
        }

        private static string TakeLastDigits(string input, string digits) // Method for collecting last digits in a variable. Will concat them to the main string after finishing operations.
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (Char.IsNumber(input[i]))
                {
                    digits += input[i];
                }
                else
                {
                    break;
                }
            }
            return digits;
        }
    }
}
