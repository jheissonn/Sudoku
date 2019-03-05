using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSegunda
{
    class ColunaLinha
    {
        private int coluna;
        private int linha;
        private int Intensidade;

        public ColunaLinha(int x, int y, int i )
        {
            this.coluna = y;
            this.linha = x;
            this.Intensidade = i;
        }
        public int getColuna()
        {
            return coluna;
        }
        public int getLinha()
        {
            return linha;
        }
        public void setColuna(int x)
        {
            this.coluna = x;
        }
        public void setLinha(int y)
        {
            this.linha = y;
        }
        public void setIntensidade(int i) {

            this.Intensidade = i;
        }
        public int getIntensidade()
        {

           return Intensidade;
        }
    }
}
