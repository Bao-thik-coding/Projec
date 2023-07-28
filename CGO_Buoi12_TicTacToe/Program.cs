using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGO_Buoi12_TicTacToe
{
    public enum Robot   
    {
        PlayerVsPlayer = 1,
        PlayerVsRobot = 2,
        RobotVsRobot = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            Console.ReadKey();
        }
    }
}
