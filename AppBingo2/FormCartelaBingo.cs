using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBingo
{
    public partial class FormCartelaBingo : Form
    {
        string caminhoArquivoAtual;
        Array numSorteados;
        DateTime inicioBingo;

        public FormCartelaBingo(string pcaminhoArquivoAtual, Array pnumSorteados, DateTime pinicioBingo)
        {
            InitializeComponent();
            caminhoArquivoAtual = pcaminhoArquivoAtual;
            numSorteados = pnumSorteados;
            inicioBingo = pinicioBingo;

        }

        string SoNumero(string Texto)
        {
            string resultado = "";
            for (int i = 0; i < Texto.Length; i++)
            {
                if (char.IsDigit(Texto[i]))
                {
                    resultado += Texto[i];
                }
            }

            //Retorno o resultado
            return resultado;
        }

        private bool SolicitarCartela(out List<int> cartela)
        {
            cartela = new List<int>();
            string nomeJogador = txtNomeJogador.Text;
             string NumCartela = txtNumCartela.Text;

            if (string.IsNullOrWhiteSpace(nomeJogador) || string.IsNullOrWhiteSpace(NumCartela))
            {
                MessageBox.Show("Erro ao conferir cadastro." + Environment.NewLine + "Preencha todos os campos!",
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string[] partes = NumCartela.Split(',');
            foreach (var p in partes)
            {
                string apenasNumeros = SoNumero(p.Trim());
                if (int.TryParse(apenasNumeros, out int num))
                {
                    if (num >= 1 && num <= 75)
                        cartela.Add(num);
                }
            }
   
            return cartela.Count > 0;
        }

        public void Conferir()
        {
            if (!SolicitarCartela(out List<int> cartela))
            {
                MessageBox.Show("Informações inválidas!");
                return;
            }

            // Verifica se a cartela tem EXATAMENTE 5 números
            if ((cartela.Count != 5))
            {
                MessageBox.Show("A cartela deve conter exatamente 5 números!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}