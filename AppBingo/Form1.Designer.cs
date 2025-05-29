namespace AppBingo
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPremio = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBingo = new System.Windows.Forms.Button();
            this.btnFinalizarBingo = new System.Windows.Forms.Button();
            this.btnSortearNumero = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumAtual = new System.Windows.Forms.Label();
            this.lblNumAnterior = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPremio
            // 
            this.txtPremio.Location = new System.Drawing.Point(12, 45);
            this.txtPremio.Name = "txtPremio";
            this.txtPremio.Size = new System.Drawing.Size(1143, 22);
            this.txtPremio.TabIndex = 0;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(15, 127);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(241, 34);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Iniciar BIngo";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prêmio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jogo";
            // 
            // btnBingo
            // 
            this.btnBingo.Location = new System.Drawing.Point(262, 127);
            this.btnBingo.Name = "btnBingo";
            this.btnBingo.Size = new System.Drawing.Size(370, 34);
            this.btnBingo.TabIndex = 4;
            this.btnBingo.Text = " BIngo!";
            this.btnBingo.UseVisualStyleBackColor = true;
            this.btnBingo.Click += new System.EventHandler(this.btnBingo_Click);
            // 
            // btnFinalizarBingo
            // 
            this.btnFinalizarBingo.Location = new System.Drawing.Point(638, 127);
            this.btnFinalizarBingo.Name = "btnFinalizarBingo";
            this.btnFinalizarBingo.Size = new System.Drawing.Size(311, 34);
            this.btnFinalizarBingo.TabIndex = 5;
            this.btnFinalizarBingo.Text = "Finalizar Bingo";
            this.btnFinalizarBingo.UseVisualStyleBackColor = true;
            this.btnFinalizarBingo.Click += new System.EventHandler(this.btnFinalizarBingo_Click);
            // 
            // btnSortearNumero
            // 
            this.btnSortearNumero.Location = new System.Drawing.Point(955, 127);
            this.btnSortearNumero.Name = "btnSortearNumero";
            this.btnSortearNumero.Size = new System.Drawing.Size(200, 34);
            this.btnSortearNumero.TabIndex = 6;
            this.btnSortearNumero.Text = "Sortear Número";
            this.btnSortearNumero.UseVisualStyleBackColor = true;
            this.btnSortearNumero.Click += new System.EventHandler(this.btnSortearNumero_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Atual";
            // 
            // lblNumAtual
            // 
            this.lblNumAtual.AutoSize = true;
            this.lblNumAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAtual.Location = new System.Drawing.Point(549, 278);
            this.lblNumAtual.Name = "lblNumAtual";
            this.lblNumAtual.Size = new System.Drawing.Size(0, 31);
            this.lblNumAtual.TabIndex = 8;
            // 
            // lblNumAnterior
            // 
            this.lblNumAnterior.AutoSize = true;
            this.lblNumAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumAnterior.Location = new System.Drawing.Point(549, 406);
            this.lblNumAnterior.Name = "lblNumAnterior";
            this.lblNumAnterior.Size = new System.Drawing.Size(0, 31);
            this.lblNumAnterior.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1179, 768);
            this.Controls.Add(this.lblNumAnterior);
            this.Controls.Add(this.lblNumAtual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSortearNumero);
            this.Controls.Add(this.btnFinalizarBingo);
            this.Controls.Add(this.btnBingo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtPremio);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPremio;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBingo;
        private System.Windows.Forms.Button btnFinalizarBingo;
        private System.Windows.Forms.Button btnSortearNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumAtual;
        private System.Windows.Forms.Label lblNumAnterior;
    }
}

