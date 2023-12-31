﻿using System.Collections.Generic;
using Tabuleiros;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;                 //conjunto para guardar todas as peças da partida
        private HashSet<Peca> capturadas;           //conjunto para guardar as peças capturadas

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Magenta;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
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

        // metodo para retornar todas as peças capturadas da cor informada
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        //metodo para retornar quem são as peças em jogo de uma dada cor exceto as capturadas
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        // metodo para adicionar a peça escolhida no conjunto de peças
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Tower(tab, Cor.Magenta));
            colocarNovaPeca('c', 2, new Tower(tab, Cor.Magenta));
            colocarNovaPeca('d', 2, new Tower(tab, Cor.Magenta));
            colocarNovaPeca('e', 2, new Tower(tab, Cor.Magenta));
            colocarNovaPeca('e', 1, new Tower(tab, Cor.Magenta));
            colocarNovaPeca('d', 1, new King(tab, Cor.Magenta));

            colocarNovaPeca('c', 7, new Tower(tab, Cor.Vermelha));
            colocarNovaPeca('c', 8, new Tower(tab, Cor.Vermelha));
            colocarNovaPeca('d', 7, new Tower(tab, Cor.Vermelha));
            colocarNovaPeca('e', 7, new Tower(tab, Cor.Vermelha));
            colocarNovaPeca('e', 8, new Tower(tab, Cor.Vermelha));
            colocarNovaPeca('d', 8, new King(tab, Cor.Vermelha));

        }
    }
}
