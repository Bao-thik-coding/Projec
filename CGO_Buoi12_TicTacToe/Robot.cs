using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGO_Buoi12_TicTacToe
{
    public class Robot : Player
    {
        // Add any additional behavior or AI logic for the Robot

        public Robot(char playerSign, string playerName) : base(playerSign, playerName)
        {
        }

        // Override the takeTurn method for the Robot's AI logic
        public override int takeTurn()
        {
            // Implement the AI logic to make a move for the Robot
            // For example, you can generate a random number as the field number to mark

            Random random = new Random();
            int fieldNumber = random.Next(1, Board.BOARD_SIZE * Board.BOARD_SIZE + 1);

            return fieldNumber;
        }
    }
}
