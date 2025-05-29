namespace AppBingo
{
    partial class FormCartelaBingo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeJogador = new System.Windows.Forms.TextBox();
            this.txtNumCartela = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConferirBingo = new System.Windows.Forms.Button();
            this.btnFinalizarBingo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do jogador";
            // 
            // txtNomeJogador
            // 
            this.txtNomeJogador.Location = new System.Drawing.Point(12, 44);
            this.txtNomeJogador.Name = "txtNomeJogador";
            this.txtNomeJogador.Size = new System.Drawing.Size(289, 22);
            this.txtNomeJogador.TabIndex = 3;
            // 
            // txtNumCartela
            // 
            this.txtNumCartela.Location = new System.Drawing.Point(12, 111);
            this.txtNumCartela.Name = "txtNumCartela";
            this.txtNumCartela.Size = new System.Drawing.Size(289, 22);
            this.txtNumCartela.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Números da cartela (ex: 24, 11, 45...)";
            // 
            // btnConferirBingo
            // 
            this.btnConferirBingo.Location = new System.Drawing.Point(15, 160);
            this.btnConferirBingo.Name = "btnConferirBingo";
            this.btnConferirBingo.Size = new System.Drawing.Size(158, 28);
            this.btnConferirBingo.TabIndex = 7;
            this.btnConferirBingo.Text = "Conferir Bingo";
            this.btnConferirBingo.UseVisualStyleBackColor = true;
            this.btnConferirBingo.Click += new System.EventHandler(this.btnConferirBingo_Click);
            // 
            // btnFinalizarBingo
            // 
            this.btnFinalizarBingo.Location = new System.Drawing.Point(176, 160);
            this.btnFinalizarBingo.Name = "btnFinalizarBingo";
            this.btnFinalizarBingo.Size = new System.Drawing.Size(158, 28);
            this.btnFinalizarBingo.TabIndex = 8;
            this.btnFinalizarBingo.Text = "Finalizar Bingo";
            this.btnFinalizarBingo.UseVisualStyleBackColor = true;
            this.btnFinalizarBingo.Click += new System.EventHandler(this.btnFinalizarBingo_Click);
            // 
            // FormCartelaBingo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(346, 239);
            this.Controls.Add(this.btnFinalizarBingo);
            this.Controls.Add(this.btnConferirBingo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNumCartela);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeJogador);
            this.Name = "FormCartelaBingo";
            this.Text = "FormCartelaBingo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeJogador;
        private System.Windows.Forms.TextBox txtNumCartela;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConferirBingo;
        private System.Windows.Forms.Button btnFinalizarBingo;
    }
}