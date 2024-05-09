using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1beadando_mestintgyak_kallaiviktor_l88i9i_8queensproblem
{
    internal class HillClimbingSolver
    {
        readonly int N; // Sakktábla mérete
        readonly State state; // Az állapottér osztálya
        int steps = 0; // Lépésszám számláló

        // Konstruktor: Beállítja a sakktábla méretét és létrehozza az állapottér osztályt.
        public HillClimbingSolver(int n)
        {
            N = n;
            state = new State(N);
        }

        // Királynők elhelyezése a sakktáblán hegymászó módszerrel.
        public void SolveNQueens()
        {
            int[,] board = new int[N, N]; // Inicializjuk a sakktáblát.
            steps = 0; // Lépésszám nullázása

            // Kezdeti elhelyezés véletlenszerűen történik.
            RandomlyPlaceQueens(board);

            // Hegymászó algoritmus lefutása.
            while (true)
            {
                int[,] nextBoard = GetNextBoard(board); // Következő állapot keresése.

                if (nextBoard == null)
                    break; // Ha nem találunk javítást, kilépünk.

                board = nextBoard; // Az új állapotot beállítjuk.

                steps++; // Lépésszám növelése
            }

            PrintSolution(board); // Megoldás kiírása.
            Console.WriteLine($"Hill climbing solution found in {steps} steps."); // Lépésszám kiírása.
        }

        // Véletlenszerű elhelyezés a sakktáblán.
        void RandomlyPlaceQueens(int[,] board)
        {
            Random random = new Random();

            for (int i = 0; i < N; i++)
            {
                int randomRow = random.Next(0, N);
                Operator.PlaceQueen(board, randomRow, i);
            }
        }

        // A következő állapot keresése.
        int[,] GetNextBoard(int[,] board)
        {
            int[,] nextBoard = null;
            int currentAttacks = CalculateAttacks(board); // Jelenlegi támadások számának kiszámítása.

            for (int col = 0; col < N; col++)
            {
                for (int row = 0; row < N; row++)
                {
                    if (board[row, col] == 1)
                    {
                        for (int i = 0; i < N; i++)
                        {
                            if (i != row)
                            {
                                int[,] newBoard = (int[,])board.Clone(); // Az állapot klónozása.

                                // Királynő mozgatása az adott oszlopban.
                                Operator.RemoveQueen(newBoard, row, col);
                                Operator.PlaceQueen(newBoard, i, col);

                                int newAttacks = CalculateAttacks(newBoard); // Új támadások számának kiszámítása.

                                // Ha az új támadások száma kisebb, mint a jelenlegi támadások száma, akkor elfogadjuk az állapotot.
                                if (newAttacks < currentAttacks)
                                {
                                    nextBoard = newBoard;
                                    return nextBoard;
                                }
                            }
                        }
                    }
                }
            }

            return nextBoard;
        }

        // Támadások számának kiszámítása az állapoton.
        int CalculateAttacks(int[,] board)
        {
            int attacks = 0;

            for (int col = 0; col < N; col++)
            {
                for (int row = 0; row < N; row++)
                {
                    if (board[row, col] == 1)
                    {
                        // Sorban levő királynők számának kiszámítása.
                        for (int i = col + 1; i < N; i++)
                        {
                            if (board[row, i] == 1)
                                attacks++;
                        }

                        // Jobb alsó átlóban levő királynők számának kiszámítása.
                        for (int i = row + 1, j = col + 1; i < N && j < N; i++, j++)
                        {
                            if (board[i, j] == 1)
                                attacks++;
                        }

                        // Jobb felső átlóban levő királynők számának kiszámítása.
                        for (int i = row - 1, j = col + 1; i >= 0 && j < N; i--, j++)
                        {
                            if (board[i, j] == 1)
                                attacks++;
                        }
                    }
                }
            }

            return attacks;
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
