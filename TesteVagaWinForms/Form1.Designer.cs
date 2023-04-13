namespace TesteVagaWinForms
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
            this.lbMeuNome = new System.Windows.Forms.Label();
            this.btnColetarDados = new System.Windows.Forms.Button();
            this.btnExibirDados = new System.Windows.Forms.Button();
            this.txtConteudoArquivo = new System.Windows.Forms.RichTextBox();
            this.btnSelDiretorio = new System.Windows.Forms.Button();
            this.txtDiretorio = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbMeuNome
            // 
            this.lbMeuNome.AutoSize = true;
            this.lbMeuNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMeuNome.Location = new System.Drawing.Point(12, 9);
            this.lbMeuNome.Name = "lbMeuNome";
            this.lbMeuNome.Size = new System.Drawing.Size(303, 20);
            this.lbMeuNome.TabIndex = 0;
            this.lbMeuNome.Text = "GUILHERME SMANIA SEMENSATO";
            // 
            // btnColetarDados
            // 
            this.btnColetarDados.Location = new System.Drawing.Point(12, 85);
            this.btnColetarDados.Name = "btnColetarDados";
            this.btnColetarDados.Size = new System.Drawing.Size(116, 32);
            this.btnColetarDados.TabIndex = 1;
            this.btnColetarDados.Text = "Coletar Dados";
            this.btnColetarDados.UseVisualStyleBackColor = true;
            this.btnColetarDados.Click += new System.EventHandler(this.btnColetarDados_Click);
            // 
            // btnExibirDados
            // 
            this.btnExibirDados.Enabled = false;
            this.btnExibirDados.Location = new System.Drawing.Point(12, 123);
            this.btnExibirDados.Name = "btnExibirDados";
            this.btnExibirDados.Size = new System.Drawing.Size(116, 32);
            this.btnExibirDados.TabIndex = 2;
            this.btnExibirDados.Text = "Exibir Dados";
            this.btnExibirDados.UseVisualStyleBackColor = true;
            this.btnExibirDados.Click += new System.EventHandler(this.btnExibirDados_Click);
            // 
            // txtConteudoArquivo
            // 
            this.txtConteudoArquivo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtConteudoArquivo.Location = new System.Drawing.Point(134, 85);
            this.txtConteudoArquivo.Name = "txtConteudoArquivo";
            this.txtConteudoArquivo.ReadOnly = true;
            this.txtConteudoArquivo.Size = new System.Drawing.Size(286, 346);
            this.txtConteudoArquivo.TabIndex = 3;
            this.txtConteudoArquivo.Text = "";
            // 
            // btnSelDiretorio
            // 
            this.btnSelDiretorio.Location = new System.Drawing.Point(12, 47);
            this.btnSelDiretorio.Name = "btnSelDiretorio";
            this.btnSelDiretorio.Size = new System.Drawing.Size(116, 32);
            this.btnSelDiretorio.TabIndex = 4;
            this.btnSelDiretorio.Text = "Selecionar Diretório";
            this.btnSelDiretorio.UseVisualStyleBackColor = true;
            this.btnSelDiretorio.Click += new System.EventHandler(this.btnSelDiretorio_Click);
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtDiretorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiretorio.Location = new System.Drawing.Point(134, 47);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.ReadOnly = true;
            this.txtDiretorio.Size = new System.Drawing.Size(286, 32);
            this.txtDiretorio.TabIndex = 5;
            this.txtDiretorio.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 450);
            this.Controls.Add(this.txtDiretorio);
            this.Controls.Add(this.btnSelDiretorio);
            this.Controls.Add(this.txtConteudoArquivo);
            this.Controls.Add(this.btnExibirDados);
            this.Controls.Add(this.btnColetarDados);
            this.Controls.Add(this.lbMeuNome);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste para Vaga C#";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMeuNome;
        private System.Windows.Forms.Button btnColetarDados;
        private System.Windows.Forms.Button btnExibirDados;
        private System.Windows.Forms.RichTextBox txtConteudoArquivo;
        private System.Windows.Forms.Button btnSelDiretorio;
        private System.Windows.Forms.RichTextBox txtDiretorio;
    }
}

