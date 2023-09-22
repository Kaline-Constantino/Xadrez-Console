using Tabuleiros;

namespace Xadrez
{
    class Tower : Peca
    {
        public Tower(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
