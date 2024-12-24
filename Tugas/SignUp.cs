using System;
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

    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSign_Click(object sender, EventArgs e)
        {

            // Ambil data dari TextBox
            string namaDepan = textNamaDepan.Text;
            string namaBelakang = textNamaBelakang.Text;
            string username = textUsername.Text;
            string noTelp = textNoTelp.Text;
            string password = textPassword.Text;

            // Hash password dengan SHA256
            string hashedPassword = HashPassword(password);

            // Koneksi ke database MySQL
            string connectionString = "server=localhost;port=3307;database=db_sigmafarma;uid=root;pwd=Password123!;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Buka koneksi
                    connection.Open();

                    // Query untuk memasukkan data user
                    string query = "INSERT INTO users (nama_depan, nama_belakang, username, no_telp, password) " +
                                   "VALUES (@namaDepan, @namaBelakang, @Username, @NoTelp, @Password)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@namaDepan", namaDepan);
                        cmd.Parameters.AddWithValue("@namaBelakang", namaBelakang);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@NoTelp", noTelp);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        // Eksekusi query
                        cmd.ExecuteNonQuery();

                        // Beri pesan sukses
                        MessageBox.Show("Registrasi berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Bersihkan TextBox setelah berhasil
                        textNamaDepan.Clear();
                        textNamaBelakang.Clear();
                        textUsername.Clear();
                        textNoTelp.Clear();
                        textPassword.Clear();
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
                    builder.Append(bytes[i].ToString("x2")); // Ubah ke format hex
                }
                return builder.ToString();
            }
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Hide();
        }
    }

}

