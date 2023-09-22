using System;
using Tabuleiros;

namespace Xadrez_Console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i=0; i<tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j=0; j<tab.Colunas; j++)
                {
                    Peca peca = tab.peca(i, j);
                    imprimirPeca(peca);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Magenta)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }

                Console.Write(peca + " ");
            }

            Console.ResetColor();
        }
    }
}
