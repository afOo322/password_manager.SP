using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json; // Для работы с JSON

namespace Password_Manager
{
    public partial class Form1 : Form
    {
        // Путь к файлу для сохранения данных
        private string filePath = "passwords.json";
        private Dictionary<string, string> accounts = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            // Загружаем данные при запуске программы
            LoadDataFromFile();
            listBoxAccounts.SelectedIndexChanged += listBoxAccounts_SelectedIndexChanged;
        }

        // Генерация случайного пароля
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int length = (int)numericPasswordLength.Value;
            string password = GeneratePassword(length);
            textBoxPassword.Text = password;
        }

        // Метод для генерации случайного пароля
        private string GeneratePassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(validChars[(int)(num % (uint)validChars.Length)]);
                }
            }
            return res.ToString();
        }

        // Сохранение пароля в словаре и файл
        private void btnSave_Click(object sender, EventArgs e)
        {
            string account = textBoxAccount.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите имя учётной записи и сгенерируйте пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Шифруем пароль перед сохранением
            string encryptedPassword = EncryptDecrypt(password);

            // Сохранение зашифрованного пароля в словаре
            accounts[account] = encryptedPassword;
            listBoxAccounts.Items.Add(account);

            // Сохранение данных в файл
            SaveDataToFile();

            // Очистка полей
            textBoxAccount.Clear();
            textBoxPassword.Clear();
        }

        // Шифрование/дешифрование пароля
        private void btnEncryptDecrypt_Click(object sender, EventArgs e)
        {
            string account = listBoxAccounts.SelectedItem?.ToString();

            if (account == null)
            {
                MessageBox.Show("Выберите учётную запись для шифрования/дешифрования!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string password = accounts[account];
            string encryptedPassword = EncryptDecrypt(password);
            accounts[account] = encryptedPassword;

            // Сохранение изменений в файл
            SaveDataToFile();

            MessageBox.Show($"Пароль для {account} был зашифрован/дешифрован: {encryptedPassword}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Простой XOR для шифрования/дешифрования
        private string EncryptDecrypt(string input)
        {
            char key = 'K'; // Ключ для шифрования
            StringBuilder output = new StringBuilder();

            foreach (char c in input)
            {
                output.Append((char)(c ^ key));
            }

            return output.ToString();
        }

        // Сохранение данных в JSON файл
        private void SaveDataToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(accounts, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка данных из JSON файла
        private void LoadDataFromFile()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    accounts = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                    // Отображаем учётные записи в listBox
                    foreach (var account in accounts.Keys)
                    {
                        listBoxAccounts.Items.Add(account);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string account = listBoxAccounts.SelectedItem?.ToString();

            if (account != null && accounts.ContainsKey(account))
            {
                // Расшифровываем пароль перед отображением
                string encryptedPassword = accounts[account];
                string decryptedPassword = EncryptDecrypt(encryptedPassword);

                textBoxPassword.Text = decryptedPassword;
            }
        }
    }
}
