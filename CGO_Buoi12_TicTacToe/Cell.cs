using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGO_Buoi12_TicTacToe
{
    public enum FIELD { FLD_EMPTY = ' ', FLD_X = 'X', FLD_O = 'O' }

    public class Cell
    {
        //Giá trị hiển thị tại ô
        FIELD fieldState = FIELD.FLD_EMPTY;

        private const ConsoleColor ColorX = ConsoleColor.Green;
        private const ConsoleColor ColorO = ConsoleColor.Red;

        //Khởi tạo ô giá trị rỗng
        public Cell()
        {
            fieldState = FIELD.FLD_EMPTY;
        }

        //Lấy giá trị tại ô
        public FIELD getFieldState()
        {
            return fieldState;
        }

        //Kiểm tra ô rỗng
        public bool isEmpty()
        {
            if (fieldState != FIELD.FLD_EMPTY) //X hoac O
                return false;
            return true;
        }

        //Gán giá trị tại ô theo dấu
        public void markField(Player player)
        {
            if (isEmpty())
            {
                if (player.getSign() == 'X')
                    fieldState = FIELD.FLD_X;
                else
                    fieldState = FIELD.FLD_O;
            }
        }

        // Vẽ ô với màu sắc tương ứng cho X và O    
        private void DrawCell()
        {
            if (fieldState == FIELD.FLD_EMPTY)
                Console.Write(" ");
            else
            {
                Console.ForegroundColor = (fieldState == FIELD.FLD_X) ? ColorX : ColorO;
                Console.Write((char)fieldState);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
