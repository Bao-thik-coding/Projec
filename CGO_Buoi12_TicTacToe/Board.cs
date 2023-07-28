using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGO_Buoi12_TicTacToe
{
    public class Board
    {
        public const int BOARD_SIZE = 3;    //kích thước cố định
        public Cell[,] board;               //ma trận 2 chiều

        //Khởi tạo bảng rỗng
        public Board()
        {
            board = new Cell[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++) //i la dòng
            {
                for (int j = 0; j < BOARD_SIZE; j++)//j là cột
                {
                    board[i, j] = new Cell();
                }
            }
        }

        private void DrawCell(int row, int col)
        {
            board[row, col].DrawCell();

            if (col < BOARD_SIZE - 1)
                Console.Write("|");
        }

        //Hiển thị bảng
        public void printBoard()
        {
            int fieldNumber = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("______");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    DrawCell(i, j);
                    fieldNumber++;

                    Console.ForegroundColor = ConsoleColor.Green;
                    if (j < BOARD_SIZE - 1) Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("");

                if (i < BOARD_SIZE - 1)
                    Console.WriteLine("------");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("______");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Xác định tạo độ
        public void putMark(Player player, int fieldNumber)
        {
            int verticalY = (fieldNumber - 1) / BOARD_SIZE;
            int horizontalX = (fieldNumber - 1) % BOARD_SIZE;
            if (board[verticalY, horizontalX].isEmpty())
                board[verticalY, horizontalX].markField(player);
            else
            {
                Console.WriteLine("This place is taken. Select the field again: ");
                putMark(player, player.takeTurn());
            }
        }

        //Xóa bảng
        public void clearBoard()
        {
            Console.Clear();
        }
    }
}
