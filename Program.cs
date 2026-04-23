using System;

class Programa
{
    static void Main()
    {
        string[,] matrizJuego = new string[3, 3];
        string jugadorTurno = "X";
        int fila;
        int columna;
        int contadorJugadas = 0;
        bool hayGanador = false;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrizJuego[i, j] = " ";
            }
        }

        while (contadorJugadas < 9 && hayGanador == false)
        {
            Console.Clear();
            MostrarJuego(matrizJuego);

            Console.WriteLine("Turno del jugador " + jugadorTurno);
            Console.Write("Ingrese fila (0-2): ");
            fila = int.Parse(Console.ReadLine());

            Console.Write("Ingrese columna (0-2): ");
            columna = int.Parse(Console.ReadLine());

            if (fila >= 0 && fila < 3 && columna >= 0 && columna < 3)
            {
                if (matrizJuego[fila, columna] == " ")
                {
                    matrizJuego[fila, columna] = jugadorTurno;
                    contadorJugadas++;

                    if (VerificarGanador(matrizJuego, jugadorTurno))
                    {
                        Console.Clear();
                        MostrarJuego(matrizJuego);
                        Console.WriteLine("Gano el jugador " + jugadorTurno);
                        hayGanador = true;
                    }
                    else
                    {
                        if (jugadorTurno == "X")
                        {
                            jugadorTurno = "O";
                        }
                        else
                        {
                            jugadorTurno = "X";
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Espacio ocupado");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Posicion invalida");
                Console.ReadKey();
            }
        }

        if (hayGanador == false)
        {
            Console.Clear();
            MostrarJuego(matrizJuego);
            Console.WriteLine("Empate");
        }
    }

    static void MostrarJuego(string[,] matrizJuego)
    {
        Console.WriteLine("  0   1   2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(" " + matrizJuego[i, j] + " ");
                if (j < 2)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();

            if (i < 2)
            {
                Console.WriteLine(" ---|---|---");
            }
        }
    }

    static bool VerificarGanador(string[,] matrizJuego, string jugadorTurno)
    {
        for (int i = 0; i < 3; i++)
        {
            if (matrizJuego[i, 0] == jugadorTurno && matrizJuego[i, 1] == jugadorTurno && matrizJuego[i, 2] == jugadorTurno)
            {
                return true;
            }
        }

        for (int j = 0; j < 3; j++)
        {
            if (matrizJuego[0, j] == jugadorTurno && matrizJuego[1, j] == jugadorTurno && matrizJuego[2, j] == jugadorTurno)
            {
                return true;
            }
        }

        if (matrizJuego[0, 0] == jugadorTurno && matrizJuego[1, 1] == jugadorTurno && matrizJuego[2, 2] == jugadorTurno)
        {
            return true;
        }

        if (matrizJuego[0, 2] == jugadorTurno && matrizJuego[1, 1] == jugadorTurno && matrizJuego[2, 0] == jugadorTurno)
        {
            return true;
        }

        return false;
    }
}
