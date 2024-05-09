using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1beadando_mestintgyak_kallaiviktor_l88i9i_8queensproblem
{
    internal class Operator
    {
        // Királynő elhelyezése a sakktáblán adott sorban és oszlopban.
        public static void PlaceQueen(int[,] board, int row, int col)
        {
            board[row, col] = 1;
        }

        // Királynő eltávolítása a sakktábláról adott sorban és oszlopban.
        public static void RemoveQueen(int[,] board, int row, int col)
        {
            board[row, col] = 0;
        }
    }
}
