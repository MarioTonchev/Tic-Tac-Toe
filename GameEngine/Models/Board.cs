using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Models;

public class Board
{
    public int Moves { get; set; } = 0;

    public string[,] Table =
    {
        { "-", "-", "-" }
        , { "-", "-", "-" }
        , { "-", "-", "-" }
    };
   
    public void Change(int num, string player)
    {
        if (player == "X")
        {
            switch (num)
            {
                case 1:
                    Table[0, 0] = "X";
                    Moves++;
                    break;
                case 2:
                    Table[0, 1] = "X";
                    Moves++;
                    break;
                case 3:
                    Table[0, 2] = "X";
                    Moves++;
                    break;
                case 4:
                    Table[1, 0] = "X";
                    Moves++;
                    break;
                case 5:
                    Table[1, 1] = "X";
                    Moves++;
                    break;
                case 6:
                    Table[1, 2] = "X";
                    Moves++;
                    break;
                case 7:
                    Table[2, 0] = "X";
                    Moves++;
                    break;
                case 8:
                    Table[2, 1] = "X";
                    Moves++;
                    break;
                case 9:
                    Table[2, 2] = "X";
                    Moves++;
                    break;
                default:
                    Console.WriteLine("Error! Please choose a number between 1 and 9.");
                    break;

            }
        }
        else if (player == "O")
        {
            switch (num)
            {
                case 1:
                    Table[0, 0] = "O";
                    Moves++;
                    break;
                case 2:
                    Table[0, 1] = "O";
                    Moves++;
                    break;
                case 3:
                    Table[0, 2] = "O";
                    Moves++;
                    break;
                case 4:
                    Table[1, 0] = "O";
                    Moves++;
                    break;
                case 5:
                    Table[1, 1] = "O";
                    Moves++;
                    break;
                case 6:
                    Table[1, 2] = "O";
                    Moves++;
                    break;
                case 7:
                    Table[2, 0] = "O";
                    Moves++;
                    break;
                case 8:
                    Table[2, 1] = "O";
                    Moves++;
                    break;
                case 9:
                    Table[2, 2] = "O";
                    Moves++;
                    break;
                default:
                    Console.WriteLine("Error! Please choose a number between 1 and 9.");
                    break;

            }
        }        
    }
    public void Reset()
    {
        Table = new[,]
        {
            { "-", "-", "-" }
            , { "-", "-", "-" }
            , { "-", "-", "-" }
        };

        Moves = 0;
    }
    public void PrintTable()
    {
        for (int i = 0; i < Table.GetLength(0); i++)
        {
            for (int j = 0; j < Table.GetLength(1); j++)
            {
                if (j < 2)
                {
                    Console.Write($"{Table[i, j]} | ");
                }
                else
                {
                    Console.Write($"{Table[i, j]}");
                }

            }
            Console.WriteLine();
            if (i < 2)
            {
                Console.WriteLine("---------");
            }
        }
    }
}
