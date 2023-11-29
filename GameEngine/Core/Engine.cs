using GameEngine.Core.Interfaces;
using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Core;

public class Engine : IEngine
{
    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        HashSet<int> placesTaken = new HashSet<int>();

        string[] random = { "X", "O" };
        Random random1 = new Random();

        bool gameEnded = false;
        string winner = null;

        string playerTurn = random[random1.Next(0, 2)];

        Board board = new Board();
        Console.WriteLine("Welcome to Tic-Tac-Toe! Select a number between 1 and 9 to to make your move on the corresponding square.");
        Console.WriteLine();
        board.PrintTable();

        while (!gameEnded)
        {
            Console.Write($"Player {playerTurn} select your next move: ");

            if (playerTurn == "X")
            {
                int number = int.Parse(Console.ReadLine());
                if (placesTaken.Contains(number))
                {
                    Console.WriteLine("Cannot make a move there...");
                }
                else
                {
                    placesTaken.Add(number);
                    board.Change(number, playerTurn);
                    board.PrintTable();
                    playerTurn = "O";
                }
            }
            else if (playerTurn == "O")
            {
                int number = int.Parse(Console.ReadLine());
                if (placesTaken.Contains(number))
                {
                    Console.WriteLine("Cannot make a move there...");
                }
                else
                {
                    placesTaken.Add(number);
                    board.Change(number, playerTurn);
                    board.PrintTable();
                    playerTurn = "X";
                }
            }
            if (CheckForXWin())
            {
                Console.WriteLine();
                Console.WriteLine($"Congratulations Player X! You have won the game!");
                board.PrintTable();

                //Option to continue
                Console.WriteLine("Continue? Y/N");
                char yesOrNo = char.ToLower(char.Parse(Console.ReadLine()));
                CheckForContinue(yesOrNo);
            }
            else if (CheckForOWin())
            {
                Console.WriteLine();
                Console.WriteLine($"Congratulations Player O! You have won the game!");
                board.PrintTable();

                //Option to continue
                Console.WriteLine("Continue? Y/N");
                char yesOrNo = char.ToLower(char.Parse(Console.ReadLine()));
                CheckForContinue(yesOrNo);
            }
            else if (CheckForTie())
            {
                Console.WriteLine();
                Console.WriteLine("Oops. There was a tie!");
                board.PrintTable();               

                //Option to continue
                Console.WriteLine("Continue? Y/N");
                char yesOrNo = char.ToLower(char.Parse(Console.ReadLine()));
                CheckForContinue(yesOrNo);
            }
        }

        bool CheckForXWin()
        {
            if (board.Table[0, 0] == "X" && board.Table[0, 1] == "X" && board.Table[0, 2] == "X")
            {
                return true;
            }
            else if (board.Table[1, 0] == "X" && board.Table[1, 1] == "X" && board.Table[1, 2] == "X")
            {
                return true;
            }
            else if (board.Table[2, 0] == "X" && board.Table[2, 1] == "X" && board.Table[2, 2] == "X")
            {
                return true;
            }
            else if (board.Table[0, 0] == "X" && board.Table[1, 0] == "X" && board.Table[2, 0] == "X")
            {
                return true;
            }
            else if (board.Table[0, 1] == "X" && board.Table[1, 1] == "X" && board.Table[2, 1] == "X")
            {
                return true;
            }
            else if (board.Table[0, 2] == "X" && board.Table[1, 2] == "X" && board.Table[2, 2] == "X")
            {
                return true;
            }
            else if (board.Table[0, 0] == "X" && board.Table[1, 1] == "X" && board.Table[2, 2] == "X")
            {
                return true;
            }
            else if (board.Table[0, 2] == "X" && board.Table[1, 1] == "X" && board.Table[2, 0] == "X")
            {
                return true;
            }
            return false;
        }
        bool CheckForOWin()
        {
            if (board.Table[0, 0] == "O" && board.Table[0, 1] == "O" && board.Table[0, 2] == "O")
            {
                return true;
            }
            else if (board.Table[1, 0] == "O" && board.Table[1, 1] == "O" && board.Table[1, 2] == "O")
            {
                return true;
            }
            else if (board.Table[2, 0] == "O" && board.Table[2, 1] == "O" && board.Table[2, 2] == "O")
            {
                return true;
            }
            else if (board.Table[0, 0] == "O" && board.Table[1, 0] == "O" && board.Table[2, 0] == "O")
            {
                return true;
            }
            else if (board.Table[0, 1] == "O" && board.Table[1, 1] == "O" && board.Table[2, 1] == "O")
            {
                return true;
            }
            else if (board.Table[0, 2] == "O" && board.Table[1, 2] == "O" && board.Table[2, 2] == "O")
            {
                return true;
            }
            else if (board.Table[0, 0] == "O" && board.Table[1, 1] == "O" && board.Table[2, 2] == "O")
            {
                return true;
            }
            else if (board.Table[0, 2] == "O" && board.Table[1, 1] == "O" && board.Table[2, 0] == "O")
            {
                return true;
            }
            return false;
        }
        bool CheckForTie()
        {
            if (board.Moves == 9)
            {
                return true;
            }
            return false;
        }
        void CheckForContinue(char yesOrNo)
        {
            if (yesOrNo == 'y')
            {
                placesTaken.Clear();
                board.Reset();
                board.PrintTable();
            }
            else if (yesOrNo == 'n')
            {
                Console.WriteLine("Thank you for playing. Goodbye!");
                gameEnded = true;
            }
        }
    }
}
