﻿using System;
using Tabuleiros;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Magenta;
            terminada = false; 
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        // Método para testar se a posição de origem escolhida é válida
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Magenta)
            {
                jogadorAtual = Cor.Vermelha;
            }
            else
            {
                jogadorAtual = Cor.Magenta;
            }
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Tower(tab, Cor.Magenta), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Tower(tab, Cor.Magenta), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new Tower(tab, Cor.Magenta), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new Tower(tab, Cor.Magenta), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new Tower(tab, Cor.Magenta), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new King(tab, Cor.Magenta), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new Tower(tab, Cor.Vermelha), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new Tower(tab, Cor.Vermelha), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Tower(tab, Cor.Vermelha), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new Tower(tab, Cor.Vermelha), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new Tower(tab, Cor.Vermelha), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new King(tab, Cor.Vermelha), new PosicaoXadrez('d', 8).toPosicao());
        }
    }
}
