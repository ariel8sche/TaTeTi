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
            bool terminado = false;

            //Funcion encargada de crear el tablero
            DibujarTablero();
            Console.WriteLine("\nJugador 1: O\nJugador 2: X");

            do
            {
                //Turno del jugador 1
                PreguntarPosicion(1);

                //Dibujar eleccion del jugador 1
                DibujarTablero();

                terminado = VerificarGanador();

                if (terminado)
                {
                    Console.WriteLine("\n¡Jugador 1 ha ganado!");
                }
                else
                {
                    terminado = VerificarEmpate();
                    if (terminado)
                    {
                        Console.WriteLine("\n¡Empate!");
                    }
                    else
                    {
                        //Turno del jugador 2
                        PreguntarPosicion(2);

                        //Dibujar eleccion del jugador 2
                        DibujarTablero();

                        terminado = VerificarGanador();

                        if (terminado)
                        {
                            Console.WriteLine("\n¡Jugador 2 ha ganado!");
                        }
                        else
                        {
                            terminado = VerificarEmpate();
                            if (terminado)
                            {
                                Console.WriteLine("\n¡Empate!");
                            }
                        }
                    }
                }
            } while (terminado == false);

        }// Fin de la función Main

        static void DibujarTablero()
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

        static void PreguntarPosicion(int jugador)
        {
            int fila, columna;

            do
            {
                Console.WriteLine();
                Console.WriteLine($"Turno del jugador {jugador}");

                // Pedimos numero de fila
                do
                {
                    Console.Write("\nSeleccione la fila (1 a 3): ");
                    fila = int.Parse(Console.ReadLine());
                } while (fila < 1 || fila > 3); // Verificando si la fila es valida

                // Pedimos numero de columna
                do
                {
                    Console.Write("\nSeleccione la columna (1 a 3): ");
                    columna = int.Parse(Console.ReadLine());
                } while (columna < 1 || columna > 3); // Verificando si la columna es valida

                if (tablero[fila - 1, columna - 1] != 0)
                {
                    Console.WriteLine("\nPosición ocupada, intente de nuevo");
                }

            } while (tablero[fila - 1, columna - 1] != 0);

            tablero[fila - 1, columna - 1] = jugador;
        }// Fin de la función PreguntarPosicion

        static bool VerificarGanador()
        {
            int fila=0, columna = 0;
            bool ticTacToe = false;

            for (fila = 0; fila < 3; fila++)
            {
                if (tablero[fila, 0] == tablero[fila, 1] && tablero[fila, 1] == tablero[fila, 2] && tablero[fila, 0] != 0)
                {
                    ticTacToe = true;
                }
            }

            for (columna = 0; columna < 3; columna++)
            {
                if (tablero[0, columna] == tablero[1, columna] && tablero[1, columna] == tablero[2, columna] && tablero[0, columna] != 0)
                {
                    ticTacToe = true;
                }
            }

            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != 0)
            {
                ticTacToe = true;
            }

            if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != 0)
            {
                ticTacToe = true;
            }

            return ticTacToe;
        }// Fin de la función VerificarGanador

        static bool VerificarEmpate()
        {
            bool hayEspacio = false;
            int fila, columna;

            for (fila = 0; fila < 3; fila++)
            {
                for (columna = 0; columna < 3; columna++)
                {
                    if (tablero[fila, columna] == 0)
                    {
                        hayEspacio = true;
                    }
                }
            }
            return !hayEspacio;
        }// Fin de la función VerificarEmpate

    }
}
