using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSegunda
{
    public partial class Form1 : Form
    {
        Stack<ColunaLinha> emPilha = new Stack<ColunaLinha>();
        int[,] sudoku ={{0, 7, 0, 0, 0, 0, 0, 2, 0},
                        {2, 0, 0, 0, 0, 0, 0, 0, 3},
                        {3, 0, 5, 2, 0, 6, 9, 0, 8},
                        {0, 9, 0, 0, 2, 0, 0, 1, 0},
                        {0, 0, 0, 0, 4, 0, 0, 0, 0},
                        {0, 8, 0, 0, 1, 0, 0, 3, 0},
                        {1, 0, 7, 4, 0, 5, 6, 0, 2},
                        {8, 0, 0, 0, 0, 0, 0, 0, 1},
                        {0, 6, 0, 0, 0, 0, 0, 9, 0 } };





        int ta = 1;
        public Form1()
        {
            InitializeComponent();
            
            dataGridSudoku.RowCount = 9;
            dataGridSudoku.ColumnCount = 9;
            proMostrar(sudoku);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int getColPilha()
        {
            return emPilha.Peek().getColuna();
        }
        private int getLiPilha()
        {
            return emPilha.Peek().getLinha();
        }

        private int getIntensidadePilha()
        {
            return emPilha.Peek().getIntensidade();
           // emPilha.Peek()

        }

        public void proMostrar(int[,] grid)
        {
            for (int y = 0; y <= 8; y++)
            {
                for (int x = 0; x <= 8; x++)
                {

                    dataGridSudoku.Rows[y].Cells[x].Value = grid[y,x];
                    dataGridSudoku.Rows[y].Cells[x].Style.ForeColor = Color.Red;
                    dataGridSudoku.Rows[y].Cells[x].ReadOnly = true;
                }

            }

        }

        private Boolean verifica(int linha, int coluna, int numeroValidar)
        {
           
            if (sudoku[linha, coluna] != 0)
            {
                return false;// valores vazios serão colocados como 0 caso o valor seja diferente de 0 significa que não está vazio
            }
            for (int colTemp = 0; colTemp < 9; colTemp++)
            {
                if (sudoku[linha, colTemp] == numeroValidar)
                {
                    return false;//Verifica se existe já o número na coluna
                }
            }
            for (int linhaTemp = 0; linhaTemp < 9; linhaTemp++)
            {

                if (sudoku[linhaTemp, coluna] == numeroValidar)
                {
                    return false;//Verifica se existe já o número na linha
                }
            }
            int comecoLinha = linha / 3; /*ex: 4/3 = 1*/
            int comecoColuna = coluna / 3;/*para sempre começar no 3 ou no 6 ou no 9*/
            for (int linhaTemp = comecoLinha * 3; linhaTemp < (comecoLinha + 1) * 3; linhaTemp++)
            {
                for (int colunaTemp = comecoColuna * 3; colunaTemp < (comecoColuna + 1) * 3; colunaTemp++)
                {
                    if (sudoku[linhaTemp, colunaTemp] == numeroValidar)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void resolverSudoku(int lin, int col,int inicio)
        {
            
            if (lin == 8 && col == 8)
                return;
            if (sudoku[lin, col] != 0 && sudoku[lin, col] != 10)
            {   /*Caso seja diferente de 0 passa para a próxima possivel*/
                if ((lin + 1) < 9)
                    resolverSudoku(lin + 1, col, 1);
                else if ((col + 1) < 9)
                    resolverSudoku(lin, col + 1, 1);
            }
            else
            {   
                for (int teste = inicio; teste <= 9; teste++)
                {   /*Caso esteja ok algum número ele vai entrar e chamar para ir ao próximo*/
                    if (verifica(lin, col, teste))
                    {
                        emPilha.Push(new ColunaLinha(lin, col, teste));
                        sudoku[lin, col] = teste;
                        if ((lin + 1) < 9)
                        {
                            resolverSudoku(lin + 1, col, 1);
                        }
                        else if ((col + 1) < 9)
                        {
                            resolverSudoku(lin, col + 1, 1);
                        }
                    }
                }
            }
            if (getColPilha() == 90)
                return;
            int vamove = getIntensidadePilha();//sudoku[getLiPilha(), getColPilha()];
            
            if (getIntensidadePilha() >= 9 && sudoku[getLiPilha(), getColPilha()] == 0)
            {
                emPilha.Pop();
            }
            
            if (getColPilha() == 90)
                return;
            int temp = sudoku[getLiPilha(), getColPilha()];
            sudoku[getLiPilha(), getColPilha()] = 0;
            int vai = getIntensidadePilha();
            emPilha.Peek().setIntensidade(vai + 1);
            resolverSudoku(getLiPilha(), getColPilha(), getIntensidadePilha());
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            emPilha.Push(new ColunaLinha(90, 90,0));
            resolverSudoku(0,0,1);
            proMostrar(sudoku);
            MessageBox.Show(ta.ToString());
        }
    }
}

       

