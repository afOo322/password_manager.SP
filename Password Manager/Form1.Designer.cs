namespace Password_Manager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.NumericUpDown numericPasswordLength;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox listBoxAccounts;

        /// <summary>
        /// Освобождение всех используемых ресурсов.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            textBoxAccount = new TextBox();
            textBoxPassword = new TextBox();
            btnGenerate = new Button();
            numericPasswordLength = new NumericUpDown();
            btnSave = new Button();
            listBoxAccounts = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numericPasswordLength).BeginInit();
            SuspendLayout();
            // 
            // textBoxAccount
            // 
            textBoxAccount.Location = new Point(12, 12);
            textBoxAccount.Name = "textBoxAccount";
            textBoxAccount.PlaceholderText = "Имя учётной записи";
            textBoxAccount.Size = new Size(250, 23);
            textBoxAccount.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(12, 50);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Сгенерированный пароль";
            textBoxPassword.ReadOnly = true;
            textBoxPassword.Size = new Size(250, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 85);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(120, 30);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Сгенерировать";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // numericPasswordLength
            // 
            numericPasswordLength.Location = new Point(150, 92);
            numericPasswordLength.Name = "numericPasswordLength";
            numericPasswordLength.Size = new Size(120, 23);
            numericPasswordLength.TabIndex = 3;
            numericPasswordLength.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 130);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 30);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить пароль";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // listBoxAccounts
            // 
            listBoxAccounts.FormattingEnabled = true;
            listBoxAccounts.ItemHeight = 15;
            listBoxAccounts.Location = new Point(12, 180);
            listBoxAccounts.Name = "listBoxAccounts";
            listBoxAccounts.Size = new Size(250, 94);
            listBoxAccounts.TabIndex = 5;
            // 
            // Form1
            // 
            ClientSize = new Size(284, 291);
            Controls.Add(listBoxAccounts);
            Controls.Add(btnSave);
            Controls.Add(numericPasswordLength);
            Controls.Add(btnGenerate);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxAccount);
            Name = "Form1";
            Text = "Менеджер Паролей";
            ((System.ComponentModel.ISupportInitialize)numericPasswordLength).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
