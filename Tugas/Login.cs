﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Import library MySQL


namespace Tugas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static int LoggedInUserId { get; private set; }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Ambil input dari TextBox
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Hash password input untuk dicocokkan dengan database
            string hashedPassword = HashPassword(password);

            // Koneksi ke database MySQL
            string connectionString = "server=localhost;port=3307;database=db_sigmafarma;uid=root;pwd=Password123!;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Buka koneksi
                    connection.Open();

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        // Tampilkan pesan error jika ada field kosong
                        MessageBox.Show("Semua field harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Hentikan eksekusi jika ada field yang kosong
                    }

                    // Query untuk mengecek username dan password
                    string query = "SELECT id_user FROM users WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                LoggedInUserId = Convert.ToInt32(reader["id_user"]);  // Menyimpan id_user

                                // Login berhasil
                                MessageBox.Show("Login berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Buka form menu utama
                                Menu menu = new Menu();
                                menu.Show();

                                Pembayaran pembayaran = new Pembayaran();

                                // Tutup form login
                                this.Hide();
                            }
                            else
                            {
                                // Login gagal
                                MessageBox.Show("Username atau password salah!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Tampilkan error jika ada
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Fungsi untuk hash password menggunakan SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.ShowDialog();
            this.Hide();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}

