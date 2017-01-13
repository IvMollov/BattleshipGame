using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class BattleshipGame
    {
        private static Random ships = new Random();
        private int shipCount;
        private int score;
        private string[,] battleshipGrid;
        private string[,] demo;
        private int shots;
        private List<string> log = new List<string>();

        public int ShipCount
        {
            get
            {
                return this.shipCount;
            }
            set
            {
                this.shipCount = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        public string[,] Demo
        {
            get;
              
        }


        public BattleshipGame(int shipCount, int score, string[,] battleshipGrid)
        {
            this.score = score;
            this.shipCount = shipCount;
            this.battleshipGrid = battleshipGrid;
            this.shots = 0;
        }

        public void Game()
        {
            shots = 0;
            demo = new string[,] { {"~", "~", "~", "~", "~"},
                                   {"~", "~", "~", "~", "~"},
                                   {"~", "~", "~", "~", "~"},
                                   {"~", "~", "~", "~", "~"},
                                   {"~", "~", "~", "~", "~"}};
            PrintDemo();

            for (int row = 0; row < battleshipGrid.GetLength(0); row++)
            {
                for (int col = 0; col < battleshipGrid.GetLength(1); col++)
                {
                    battleshipGrid[row, col] = "~";
                    if(col == 3)
                    {
                        battleshipGrid[ships.Next(0, 5), ships.Next(0, 5)] = "4";
                    }                                    
                }
            }

            for (int row = 0; row < battleshipGrid.GetLength(0); row++)
            {
                for (int col = 0; col < battleshipGrid.GetLength(1); col++)
                {
                    Console.Write(battleshipGrid[row, col]);
                    if (battleshipGrid[row, col] == "4")
                    {
                        shipCount++;
                    }                    
                }
                Console.WriteLine();
            }

            while (true)
            {               
                Console.WriteLine("\nShips hit: {0}/{1}. Shots {2}", this.score, this.shipCount, this.shots);
                Console.Write("Enter coordinates to take a shot: ");

                int coordinates;
                string shot = Console.ReadLine();

                while ((!int.TryParse(shot, out coordinates) || (shot.Length != 2)) ||
                      (((int)Char.GetNumericValue(shot[0]) > 5 || (int)Char.GetNumericValue(shot[0]) < 1)
                      || ((int)Char.GetNumericValue(shot[1]) > 5 || (int)Char.GetNumericValue(shot[1]) < 1)))
                {
                    Console.Write("Enter valid coordinates to take a shot: ");
                    shot = Console.ReadLine();
                }

                Console.Write("Shot at row {0}, column {1}. ", coordinates / 10, coordinates % 10);

                int rows = (coordinates / 10) - 1;
                int columns = (coordinates % 10) - 1;
                if (battleshipGrid[rows, columns] == "4")
                {
                    Console.Write("Ship hit!\n");
                    log.Add("Ship hit!");
                    battleshipGrid[rows, columns] = "X";
                    demo[rows, columns] = "X";
                    PrintDemo();
                    score++;                    
                }
                else
                {
                    Console.Write("Water hit!\n");
                    log.Add("Water hit!");
                    demo[rows, columns] = "O";
                    PrintDemo();
                }
                shots++;
                if (score == shipCount)
                {
                    Console.WriteLine("Congratulations! You have won! Score: {0}/{1}! Shots needed: {2}", score, shipCount, shots);
                    Print(battleshipGrid);
                    PrintLog();
                    Console.WriteLine("=====================================");
                    return;
               }              
            }
        }

        public void Quit()
        {
            Console.WriteLine("=====================================\nGood bye!");
        }

        public void Print(string[,] battleshipGrid)
        {
            Console.WriteLine();
            for (int row = 0; row < battleshipGrid.GetLength(0); row++)
            {
                for (int col = 0; col < battleshipGrid.GetLength(1); col++)
                {
                    Console.Write(battleshipGrid[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("*\"X\" stands for ship hit.\n");
        }

        public void PrintDemo()
        {
            for (int row = 0; row < demo.GetLength(0); row++)
            {
                for (int col = 0; col < demo.GetLength(1); col++)
                {
                    Console.ResetColor();
                    if(demo[row, col] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(demo[row, col]);
                        continue;
                    }
                    else if(demo[row, col] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(demo[row, col]);
                        continue;
                    }
                    Console.Write(demo[row, col]);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public void PrintLog()
        {
            for(int i = 0; i < log.Count; i++)
            {
                Console.WriteLine($"Shot [{i + 1}]: {log[i]}");
            }
        }
    }
}

