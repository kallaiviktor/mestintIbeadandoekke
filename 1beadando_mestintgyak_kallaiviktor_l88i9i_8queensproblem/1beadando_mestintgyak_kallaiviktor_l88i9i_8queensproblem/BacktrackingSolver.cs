using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1beadando_mestintgyak_kallaiviktor_l88i9i_8queensproblem
{
    internal class BacktrackingSolver
    {
        readonly int N; // A sakktábla mérete
        readonly State state; // Az állapottér osztálya
        int steps = 0; // Lépésszám számláló

        // Konstruktor: Beállítja a sakktábla méretét és létrehozza az állapottér osztályt.
        public BacktrackingSolver(int n)
        {
            N = n;
            state = new State(N);
        }

        // A királynők elhelyezésének megoldása backtracking algoritmussal.
        public void SolveNQueens()
        {
            int[,] board = new int[N, N]; // Inicializjuk a sakktáblát.
            steps = 0; // Lépésszám nullázása

            // Rekurzív backtracking algoritmus hívása.
            if (!Backtrack(board, 0))
            {
                Console.WriteLine("No solution exists."); // Ha nem találtunk megoldást, kiírjuk.
                return;
            }

            PrintSolution(board); // Ha találtunk megoldást, kiírjuk.
            Console.WriteLine($"Backtracking solution found in {steps} steps."); // Lépésszám kiírása.
        }

        // Rekurzív backtracking algoritmus.
        bool Backtrack(int[,] board, int col)
        {
            steps++; // Lépésszám növelése

            // Ha az összes királynőt elhelyeztük, visszatérünk igazzal.
            if (col >= N)
                return true;

            // Végigmegyünk az összes soron az aktuális oszlopban.
            for (int i = 0; i < N; i++)
            {
                // Ellenőrizzük, hogy a királynőt biztonságosan elhelyezhetjük-e az adott pozícióban.
                if (state.IsSafe(board, i, col))
                {
                    // Ha igen, elhelyezzük a királynőt az adott pozícióba.
                    Operator.PlaceQueen(board, i, col);

                    // Rekurzív hívás a következő oszlopban.
                    if (Backtrack(board, col + 1))
                        return true;

                    // Ha a rekurzív hívás nem vezet megoldáshoz, eltávolítjuk a királynőt és visszalépünk (backtrack).
                    Operator.RemoveQueen(board, i, col);
                }
            }

            // Ha nem találtunk megoldást az aktuális oszlopban, visszatérünk hamissal.
            return false;
        }

        // Sakktábla kiírása a megoldással együtt.
        void PrintSolution(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 1)
                        Console.Write("Q "); // Királynő jelölése
                    else
                        Console.Write(". "); // Üres mező jelölése
                }
                Console.WriteLine();
            }
        }
    }
}
