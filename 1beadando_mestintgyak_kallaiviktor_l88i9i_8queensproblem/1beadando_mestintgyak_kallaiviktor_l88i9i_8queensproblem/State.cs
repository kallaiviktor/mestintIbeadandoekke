using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1beadando_mestintgyak_kallaiviktor_l88i9i_8queensproblem
{
    internal class State
    {
        readonly int N; // A sakktábla mérete

        // Konstruktor: Beállítja a sakktábla méretét.
        public State(int n)
        {
            N = n;
        }

        // Ellenőrzi, hogy a királynő biztonságosan elhelyezhető-e a sakktáblán az adott pozícióban.
        public bool IsSafe(int[,] board, int row, int col)
        {
            // Ellenőrizzük az oszlopokat és az átlókat az adott pozícióban.
            for (int i = 0; i < col; i++)
            {
                if (board[row, i] == 1)
                    return false;
            }

            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            for (int i = row, j = col; j >= 0 && i < N; i++, j--)
            {
                if (board[i, j] == 1)
                    return false;
            }

            return true;
        }
    }
}
