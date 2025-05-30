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
    public partial class FormCartelaBingo: Form
    {
        private Form1 _form1;
        public FormCartelaBingo(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
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

        private List<int> numerosSorteados = new List<int>(); // adicionados após cada sorteio
        private DateTime fimBingo;
        private string nomeVencedor;
        private List<int> cartelaVencedora;
        private List<int> numerosRestantes = new List<int>();


        private bool SolicitarCartela(out string nome, out List<int> cartela)
        {
            nome = "";
            cartela = new List<int>();

            string nomeJogador = txtNomeJogador.Text;
            string cartelaTexto = txtNumCartela.Text;

            if (string.IsNullOrWhiteSpace(nomeJogador) || string.IsNullOrWhiteSpace(cartelaTexto))
                return false;

            string[] partes = cartelaTexto.Split(',');
            foreach (var p in partes)
            {
                string apenasNumeros = SoNumero(p.Trim());
                if (int.TryParse(apenasNumeros, out int num))
                {
                    if (num >= 1 && num <= 75)
                        cartela.Add(num);
                }
            }

            nome = nomeJogador;
            return cartela.Count > 0;
        }

        private void btnConferirBingo_Click(object sender, EventArgs e)
        {
            if (!SolicitarCartela(out string nome, out List<int> cartela))
            {
                MessageBox.Show("Informações inválidas!");
                return;
            }

            bool cartelaValida = cartela.All(n => !numerosRestantes.Contains(n));
            
            if (cartelaValida)
            {
                nomeVencedor = nome;
                cartelaVencedora = cartela;
                fimBingo = DateTime.Now;

                MessageBox.Show($"Parabéns {nomeVencedor}! Cartela válida 🎉", "BINGO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConferirBingo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Cartela inválida! Continue o jogo...", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFinalizarBingo_Click(object sender, EventArgs e)
        {
            string caminho = _form1.caminhoArquivoAtual;
            DateTime inicioBingo = DateTime.Parse(_form1.inicioBingo); // Convert string to DateTime

            TimeSpan duracao = fimBingo - inicioBingo; // Calculate duration

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\nVencedor: {nomeVencedor}");
            sb.AppendLine("Cartela: " + string.Join(", ", cartelaVencedora));
            sb.AppendLine("Hora de término: " + fimBingo.ToString("HH:mm:ss"));
            sb.AppendLine("Duração: " + duracao.ToString(@"hh\:mm\:ss"));
            sb.AppendLine("Números sorteados: " + string.Join(", ", Enumerable.Range(1, 75).Except(numerosRestantes)));

            File.AppendAllText(caminho, sb.ToString());

            MessageBox.Show("Bingo finalizado com sucesso!", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
