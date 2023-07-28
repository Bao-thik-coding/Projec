using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGO_Buoi12_TicTacToe
{
    public class TicTacToe
    {
        //Khoi tao
        public TicTacToe()
        {
            play();
        }

        //Luot choi
        public void play()
        {
            while (true)
            {
                DisplayMenu();
                int choice = GetMenuChoice();

                if (choice == 0)
                {
                    Console.WriteLine("Exiting the game...");
                    break;
                }
                else if (choice == (int)GameMode.PlayerVsPlayer || choice == (int)GameMode.PlayerVsRobot)
                {
                    // Prompt players to enter their names
                    Console.Write("Enter Player X's name: ");
                    string nameX = Console.ReadLine();
                    Console.Write("Enter Player O's name: ");
                    string nameO = Console.ReadLine();

                    Player playerX = new Player('X', nameX);
                    Player playerO = (choice == (int)GameMode.PlayerVsPlayer) ? new Player('O', nameO) : new Robot('O', "Robot");
                    Player currentPlayer = playerX;

                    int moveCounter = 0;
                    Board gameBoard = new Board();

                    bool play = true;
                    while (play)
                    {
                        gameBoard.printBoard();
                        Console.WriteLine("Player: {0} Enter the field in which you want to put the character: ", currentPlayer.Name);

                        try
                        {
                            gameBoard.putMark(currentPlayer, currentPlayer.takeTurn());
                            gameBoard.clearBoard();
                            moveCounter++;

                            if (currentPlayer.checkWin(gameBoard))
                            {
                                Console.WriteLine("Player: {0} won!", currentPlayer.Name);
                                gameBoard.printBoard();
                                play = false;
                            }
                            else if (checkDraw(moveCounter))
                            {
                                Console.WriteLine("DRAW");
                                gameBoard.printBoard();
                                play = false;
                            }

                            currentPlayer = (moveCounter % 2 == 0) ? playerX : playerO;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid Input. Please enter number between 1-9!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }

                    // Log the game details
                    LogGameDetails(playerX, playerO, moveCounter);
                }
                else if (choice == (int)GameMode.RobotVsRobot)
                {
                    // Implement the code for robot vs robot mode if needed
                    Console.WriteLine("Robot vs Robot mode is not implemented yet.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please choose again.");
                }
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("==== Tic Tac Toe ====");
            Console.WriteLine("Press 1. Player vs Player");
            Console.WriteLine("Press 2. Player vs Robot");
            Console.WriteLine("Press 3. Robot vs Robot");
            Console.WriteLine("Press 0. Exit");
            Console.Write("Enter your choice: ");
        }

        public int GetMenuChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 3)
            {
                Console.WriteLine("Invalid choice. Please enter a valid number (0-3):");
            }
            return choice;
        }

        //Kiem tra luot di cuoi
        private bool checkDraw(int turnCounter)
        {
            if (turnCounter == 9)
                return true;
            return false;
        }

        // Log the game details with date and time
        private void LogGameDetails(Player playerX, Player playerO, int moveCounter)
        {
            string mode = (playerO is Robot) ? "Player vs Robot" : "Player vs Player";
            string winner = (moveCounter % 2 == 0) ? playerX.Name : playerO.Name;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - Mode: {mode}, Winner: {winner}";
            // You can write the logEntry to a file or another suitable destination.
            Console.WriteLine("Game details logged: " + logEntry);
        }
    }
}
