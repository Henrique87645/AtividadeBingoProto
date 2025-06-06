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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        bool ArquivoExiste(string caminho)
        {
            //verifica se o arquivo existe, o nome do arquivo sera o CPF, 
            //portanto se já existir, o usuário já possue cadastro
            return File.Exists(caminho);
        }

        void GravarArquivo(string caminho, string conteudo)
        {
            //grava o conteudo no arquivo
            //se o arquivo não existir, ele será criado
            string pasta = Path.GetDirectoryName(caminho);

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            File.WriteAllText(caminho, conteudo);
        }

        string GetDirArquivo(string nomePasta, string nomeArquivo)
        {
            //O arquivo será montado: Diretório Raiz do Executavel
            // nome da pasta: será o tipo de cadastro
            // nome do arquivo: será o CPF

            string raizExe = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(raizExe, nomePasta, nomeArquivo + ".txt");
        }

        public string inicioBingo = DateTime.Now.ToShortTimeString();
        string GetCadastro()
        {
           
            //Iremos concatenar os dados do cadastro para gerear o conteudo do arquivo
            string cadastro = "Nome do Prêmio: " + txtPremio.Text + Environment.NewLine +
                            "Horário de início: " + inicioBingo;

            return cadastro;
        }

        public string caminhoArquivoAtual;

        // Método para salvar o cadastro
        public void Salvar()
        {
            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();

            string caminhoCompleto = GetDirArquivo("Bingo", ("Bingo_" + SoNumero(date) + "_" + SoNumero(time)));

            //verifica se o arquivo já existe
            if (ArquivoExiste(caminhoCompleto))
            {
                //se o arquivo já existe, o usuário já possui cadastro
                MessageBox.Show("Usuário já cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                //gravar o arquivo
                GravarArquivo(caminhoCompleto, GetCadastro());

                //se o arquivo foi gravado com sucesso, exibe uma mensagem de sucesso
                MessageBox.Show("Registro salvo com sucesso!" + Environment.NewLine + Environment.NewLine +
                    "Salvo em :" + caminhoCompleto, "Informção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o cadastro." + Environment.NewLine + "Erro original: " + ex.Message,
                    "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            caminhoArquivoAtual = caminhoCompleto;
        }
        private void btnIniciarBingo_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        /*
        ==========================================================================================================================================
        Parte de cima está totalmente funcional. 
        Cadastro do prêmio, data e hora de início.
        ==========================================================================================================================================
        */

        private void Form1_Load_1(object sender, EventArgs e)
        {
            numerosRestantes = Enumerable.Range(1, 75).ToList();
            InicializarLabels();
        }
        private string numeroAtual = "";

        private string GetLetra(int numeros)
        {
            if (numeros <= 15) return "B";
            if (numeros <= 30) return "I";
            if (numeros <= 45) return "N";
            if (numeros <= 60) return "G";
            return "O";
        }
        private List<int> numerosRestantes;
        private Random random = new Random();
        public void SorteioDeNumeros()
        {
            
            if (numerosRestantes.Count == 0)
            {
                MessageBox.Show("Todos os números foram sorteados!");
                return;
            }

            // Sorteia um índice aleatório na lista de números restantes
            int indice = random.Next(numerosRestantes.Count);
            int numeroSorteado = numerosRestantes[indice];

            // Remove o número sorteado da lista
            numerosRestantes.RemoveAt(indice);

            // Converte o array inteiro para string
            string letra = GetLetra(numeroSorteado);
            string resultado = $"{letra} {numeroSorteado}";

            // Atualiza o anterior com o valor atual antes de sortear novo.
            if (!string.IsNullOrEmpty(numeroAtual))
            {
                lblNumAnterior.Text = numeroAtual;
            }

            // Atualiza atual
            numeroAtual = resultado;
            lblNumAtual.Text = numeroAtual;

            //Faz a troca de cor do fundo das labals para verde quando sorteadas.
 
            Label lbl = this.Controls.Find($"lbsNum{numeroSorteado}", true).FirstOrDefault() as Label;
            if (lbl != null)
            {
                lbl.BackColor = Color.Green;
            }

            // Grava no arquivo.
            File.AppendAllText(caminhoArquivoAtual, Environment.NewLine + $"Sorteado: {numeroAtual}");
        }


        private void InicializarLabels()
        {
            for (int i = 1; i <= 75; i++)
            {
                Label lbl = this.Controls.Find($"lbsNum{i}", true).FirstOrDefault() as Label;

                if (lbl != null)
                {
                    string letra = GetLetra(i);
                    lbl.Text = $"{letra}\n{i}";
                    lbl.TextAlign = ContentAlignment.TopCenter;
                    lbl.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void btnSortearNumero_Click(object sender, EventArgs e)
        {
            SorteioDeNumeros();
        }


    }
}
