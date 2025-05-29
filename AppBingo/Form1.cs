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

        string GetCadastro()
        {
            //Iremos concatenar os dados do cadastro para gerear o conteudo do arquivo
            string cadastro = "Nome do Prêmio: " + txtPremio.Text + Environment.NewLine +
                            "Horário de início: " + DateTime.Now.ToShortTimeString();

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
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();

        }

        private List<int> numerosRestantes = new List<int>();
        private int numeroAtual = -1;
        private int numeroAnterior = -1;
        private Dictionary<int, Label> labelsNumeros = new Dictionary<int, Label>();
        private Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            numerosRestantes = Enumerable.Range(1, 75).ToList();

            // Preenche dicionário com os labels
            for (int i = 1; i <= 75; i++)
            {
                Label lbl = this.Controls.Find("lbsNum" + i.ToString(), true).FirstOrDefault() as Label;
                if (lbl != null)
                    labelsNumeros[i] = lbl;
            }
        }
        private string GetLetra(int numero)
        {
            if (numero <= 15) return "B";
            if (numero <= 30) return "I";
            if (numero <= 45) return "N";
            if (numero <= 60) return "G";
            return "O";
        }

        private void SortearNumero()
        {
            if (numerosRestantes.Count == 0)
            {
                MessageBox.Show("Todos os números já foram sorteados!");
                return;
            }
            // Sorteia índice aleatório e obtém número
            int index = rnd.Next(numerosRestantes.Count);
            int sorteado = numerosRestantes[index];
            numerosRestantes.RemoveAt(index);

            // Atualiza registros
            numeroAnterior = numeroAtual;
            numeroAtual = sorteado;

            // Letra correspondente (B-I-N-G-O)
            string letraAtual = GetLetra(numeroAtual);
            string letraAnterior = numeroAnterior > 0 ? GetLetra(numeroAnterior) : "";

            // Atualiza labels
            lblNumAtual.Text = $"{letraAtual}\n{numeroAtual:D2}";
            lblNumAnterior.Text = numeroAnterior > 0 ? $"{letraAnterior} {numeroAnterior:D2}" : "";

            // Marca label do número sorteado em verde
            if (labelsNumeros.TryGetValue(numeroAtual, out Label lblAtual))
            {
                lblAtual.BackColor = Color.LimeGreen;
                lblAtual.ForeColor = Color.White;
                lblAtual.Font = new Font(lblAtual.Font, FontStyle.Bold);
            }

            // Grava no arquivo
            File.AppendAllText(caminhoArquivoAtual,Environment.NewLine + $"Sorteado: {letraAtual} {numeroAtual:D2}");
        }

        private void btnSortearNumero_Click(object sender, EventArgs e)
        {
            SortearNumero();
        }

        private void btnBingo_Click(object sender, EventArgs e)
        {
            FormCartelaBingo tela = new FormCartelaBingo();
            tela.ShowDialog();
        }

        private void btnFinalizarBingo_Click(object sender, EventArgs e)
        {
            FormCartelaBingo tela = new FormCartelaBingo();
            tela.ShowDialog();
        }
    }
}
