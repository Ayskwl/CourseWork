namespace курсач
{
    partial class FormClient
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelBank = new System.Windows.Forms.Label();
            this.labelINN = new System.Windows.Forms.Label();
            this.textBoxNameClient = new System.Windows.Forms.TextBox();
            this.textBoxINN = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.comboBoxBank = new System.Windows.Forms.ComboBox();
            this.labelNameClient = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.labelIP, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelBank, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelINN, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxNameClient, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxINN, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxIP, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxBank, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelNameClient, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(663, 82);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(498, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(69, 16);
            this.labelIP.TabIndex = 7;
            this.labelIP.Text = "Юр.Адрес";
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Location = new System.Drawing.Point(333, 0);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(39, 16);
            this.labelBank.TabIndex = 6;
            this.labelBank.Text = "Банк";
            // 
            // labelINN
            // 
            this.labelINN.AutoSize = true;
            this.labelINN.Location = new System.Drawing.Point(168, 0);
            this.labelINN.Name = "labelINN";
            this.labelINN.Size = new System.Drawing.Size(37, 16);
            this.labelINN.TabIndex = 5;
            this.labelINN.Text = "ИНН";
            // 
            // textBoxNameClient
            // 
            this.textBoxNameClient.Location = new System.Drawing.Point(3, 44);
            this.textBoxNameClient.Name = "textBoxNameClient";
            this.textBoxNameClient.Size = new System.Drawing.Size(152, 22);
            this.textBoxNameClient.TabIndex = 0;
            // 
            // textBoxINN
            // 
            this.textBoxINN.Location = new System.Drawing.Point(168, 44);
            this.textBoxINN.Name = "textBoxINN";
            this.textBoxINN.Size = new System.Drawing.Size(152, 22);
            this.textBoxINN.TabIndex = 1;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(498, 44);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(152, 22);
            this.textBoxIP.TabIndex = 2;
            // 
            // comboBoxBank
            // 
            this.comboBoxBank.FormattingEnabled = true;
            this.comboBoxBank.Items.AddRange(new object[] {
            "Сбербанк",
            "Банк Левобережный",
            "МТС Банк",
            "Вб банк",
            "ВТБ",
            "Газпромбанк",
            "Альфа-Банк",
            "Россельхозбанк",
            "РТС Банк",
            "Банк Открытие",
            "Юникредит Банк",
            "Райффайзенбанк",
            "Тинькофф Банк",
            "Банк Санкт-Петербург",
            "Промсвязьбанк",
            "Совкомбанк",
            "Уралсиб",
            "Банк Зенит"});
            this.comboBoxBank.Location = new System.Drawing.Point(333, 44);
            this.comboBoxBank.Name = "comboBoxBank";
            this.comboBoxBank.Size = new System.Drawing.Size(159, 24);
            this.comboBoxBank.TabIndex = 3;
            // 
            // labelNameClient
            // 
            this.labelNameClient.AutoSize = true;
            this.labelNameClient.Location = new System.Drawing.Point(3, 0);
            this.labelNameClient.Name = "labelNameClient";
            this.labelNameClient.Size = new System.Drawing.Size(73, 16);
            this.labelNameClient.TabIndex = 4;
            this.labelNameClient.Text = "Название";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormClient";
            this.Text = "FormClient";
            this.Load += new System.EventHandler(this.FormClient_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.Label labelINN;
        private System.Windows.Forms.TextBox textBoxNameClient;
        private System.Windows.Forms.TextBox textBoxINN;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.ComboBox comboBoxBank;
        private System.Windows.Forms.Label labelNameClient;
    }
}