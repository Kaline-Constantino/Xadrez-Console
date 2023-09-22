using Tabuleiros;

namespace Xadrez
{
    class King : Peca
    {
        public King(Tabuleiro tab, Cor cor ) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}
