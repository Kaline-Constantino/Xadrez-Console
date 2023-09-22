using System;
using Tabuleiros;
using Xadrez;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Tower(tab, Cor.Magenta), new Posicao(0, 0));
                tab.colocarPeca(new Tower(tab, Cor.Magenta), new Posicao(1, 3));
                tab.colocarPeca(new King(tab, Cor.Magenta), new Posicao(0, 2));

                Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

             Console.ReadLine();
        }
    }
}
