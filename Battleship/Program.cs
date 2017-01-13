using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        public static void Main()
        {           
            Console.Write("Welcome to the BATTLESHIP world!\n" +
                          "Battlefield grid has five rows and five columns.\n" +
                          "To take a shot, enter coordinates. Coordinates are two digits, representing a point in the battlefield grid.\n" +
                          "First digit is for rows, second for columns.\n" +
                          "For instance if you enter: " +
                          "12. This means that you presume your target ship \nin the battlefield grid to be at row 1, colimn 2.\n");
            Console.WriteLine();
            int length = 5;
            int shipsCount = 0;
            string[,] battleshipGrid = new string[length, length];
            int scores = 0;
            BattleshipGame ob = new BattleshipGame(shipsCount, scores, battleshipGrid);
            ob.Game();
            Console.WriteLine("Do you want to play again?\n\"Yes\" or \"No\"");

            Console.Write("Your choice is: ");
            string choose = Console.ReadLine();
            while (!(choose == "Yes" || choose == "No"))
            {
                Console.Write("Please choose between \"Yes\" or \"No\": ");
                choose = Console.ReadLine();
            }
            while (true)
            {
                if (choose == "Yes")
                {
                    Console.Clear();
                    ob.ShipCount = 0;
                    ob.Score = 0;
                    Console.WriteLine("=====================================");
                    ob.Game();
                    Console.Write("Do you want to play again?\n\"Yes\" or \"No\"\n");
                    choose = Console.ReadLine();

                    while (!(choose == "Yes" || choose == "No"))
                    {
                        Console.Write("Please choose between \"Yes\" or \"No\": ");
                        choose = Console.ReadLine();
                    }
                }
                if (choose == "No")
                {
                    ob.Quit();
                    Console.ReadLine();
                    return;
                }
            }
        }
    }

}
