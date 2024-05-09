using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1beadando_mestintgyak_kallaiviktor_l88i9i_8queensproblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 8; // Sakktábla mérete

            // Backtracking algoritmus példányosítása és megoldás keresése.
            BacktrackingSolver backtrackingSolver = new BacktrackingSolver(N);
            backtrackingSolver.SolveNQueens();

            Console.WriteLine();

            // Hegymászó algoritmus példányosítása és megoldás keresése.
            HillClimbingSolver hillClimbingSolver = new HillClimbingSolver(N);
            hillClimbingSolver.SolveNQueens();

            Console.ReadKey();
        }
    }
}
