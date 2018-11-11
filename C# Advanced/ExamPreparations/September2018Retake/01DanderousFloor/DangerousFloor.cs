using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01DanderousFloor
{
    class DangerousFloor
    {
        static void Main(string[] args)
        {
            char[][] board = new char[8][];
            char[] figuresCollection = { 'K', 'R', 'B', 'Q', 'P' };
            for (int i = 0; i < board.Length; i++)
            {
                char[] inputLines = Console.ReadLine()
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                board[i] = inputLines;
            }

            string inputCommands = Console.ReadLine();

            while (inputCommands != "END")
            {
                string command = inputCommands;
                char figure = command[0];
                int startRow = (int)char.GetNumericValue(command[1]);
                int startCol = (int)char.GetNumericValue(command[2]);
                int targetRow = (int)char.GetNumericValue(command[4]);
                int targetCol = (int)char.GetNumericValue(command[5]);
                bool isValid = true;
                while (true)
                {
                    if (board[startRow][startCol] != figure)
                    {
                        Console.WriteLine("There is no such a piece!");
                        isValid = false;
                        break;
                    }

                    if (figuresCollection.Contains(figure))
                    {
                        if (figure == 'K' && ((Math.Abs(startRow - targetRow) > 1) || Math.Abs(startCol - targetCol) > 1))
                        {
                            isValid = false;
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        else if (figure == 'R' && ((targetRow != startRow && (targetCol < startCol || targetCol > startCol)) ||
                            (targetCol != startCol && (targetRow > startRow || targetRow < startRow))))

                        {
                            isValid = false;
                            Console.WriteLine("Invalid move!");
                            break;
                        }

                        else if (figure == 'B' && ((targetRow != startRow && targetCol == startCol) ||
                            (targetCol != startCol && targetRow == startRow)))
                        {
                            isValid = false;
                            Console.WriteLine("Invalid move!");
                            break;
                        }
                        
                        else if (figure == 'Q')
                        {
                            if (Math.Abs(targetRow - startRow) == Math.Abs(targetCol - startCol) //Allows diagonal Movement
                        || (startRow == targetRow || startCol == targetCol)) // 
                            {
                                isValid = true;
                            }
                            else
                            {
                                isValid = true;
                                Console.WriteLine("Invalid move!");
                                break;
                            }
                        }

                        else if (figure == 'P' && (targetRow != startRow - 1 || targetCol != startCol))
                        {
                            isValid = false;
                            Console.WriteLine("Invalid move!");
                            break;
                        }
                    }
                    if ((targetRow < 0 || targetRow > board.Length - 1) || (targetCol < 0 || targetCol > board.Length - 1))
                    {
                        isValid = false;
                        Console.WriteLine("Move go out of board!");
                        break;
                    }
                    if (isValid && board[targetRow][targetCol] == 'x')
                    {
                        board[targetRow][targetCol] = figure;
                        board[startRow][startCol] = 'x';
                        break;
                    }
                }

                inputCommands = Console.ReadLine();
            }
        }
    }
}
