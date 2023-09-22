using System;
using Tabuleiros;
using Xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Tower(tab, Cor.Magenta), new Posicao(0, 0));
            tab.colocarPeca(new Tower(tab, Cor.Magenta), new Posicao(1, 3));
            tab.colocarPeca(new King(tab, Cor.Magenta), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tab);

             Console.ReadLine();
        }
    }
}
