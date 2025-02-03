using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tateti
{
    internal class Program
    {
        static int[,] tablero = new int[3, 3];
        static char[] simbolos = { ' ', 'O', 'X' };

        static void Main(string[] args)
        {
            //Funcion encargada de crear el tablero
            CrearTablero();
            Console.WriteLine("\nJugador 1: O\nJugador 2: X");

        }// Fin de la función Main

        static void CrearTablero()
        {
            // Variables del ciclo anidado
            int fila=0, columna = 0;

            Console.WriteLine(); // Espacio en blanco
            string guiones = new string('-', 13);
            Console.WriteLine(guiones);

            for (fila=0; fila < 3; fila++)
            {
                Console.Write("|");
                for (columna = 0; columna < 3; columna++)
                {
                    Console.Write(" " + simbolos[tablero[fila, columna]] + " |");
                }
                Console.WriteLine($"\n{guiones}");
            }

        }// Fin de la función CrearTablero
    }
}
