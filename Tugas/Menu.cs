using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Import library MySQL

namespace Tugas
{
    public partial class Menu : Form
    {
        
        public static DatabaseHelper dbHelper = new DatabaseHelper();
        public Menu()
        {
            InitializeComponent();
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

            //}

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Set Tag untuk tombol atau inisialisasi lainnya jika perlu
            btnKeranjang1.Tag = 2; // id_obat Paracetamol
            btnKeranjang2.Tag = 3; // id_obat Promaag
            btnKeranjang3.Tag = 4; // id_obat Insto Mata Regular
            btnKeranjang4.Tag = 5; // id_obat Degirol
            btnKeranjang5.Tag = 6; // id_obat Imboost 10 Tablet
            btnKeranjang6.Tag = 7; // id_obat OBH Combi

            // Menghubungkan tombol dengan event handler
            btnKeranjang1.Click += btnKeranjang_Click;
            btnKeranjang2.Click += btnKeranjang_Click;
            btnKeranjang3.Click += btnKeranjang_Click; 
            btnKeranjang4.Click += btnKeranjang_Click;
            btnKeranjang5.Click += btnKeranjang_Click;
            btnKeranjang6.Click += btnKeranjang_Click;

            txtSearch.Text = "Cari Produk...";
            txtSearch.ForeColor = Color.Gray;
        }

        private void btnKeranjang_Click(object sender, EventArgs e)
        {
           try
           {
            Button btn = sender as Button;

            int idObat = Convert.ToInt32(btn.Tag); // Ambil ID obat dari Tag tombol
            int jumlah = 1; // Default jumlah 1

                // Ambil data obat berdasarkan id
           Dictionary<string, object> dataObat = DatabaseHelper.GetObatById(idObat);

                if (dataObat.Count == 0)
                {
                    MessageBox.Show("Data obat tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            int stok = Convert.ToInt32(dataObat["stok"]); // Ambil stok dari hasil query

            if (stok <= 0)
            {
                MessageBox.Show($"Stok obat \"{dataObat["nama_obat"]}\" habis. Tidak dapat ditambahkan ke keranjang.", "Stok Habis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                int idUser = Login.LoggedInUserId;
                // Jika stok tersedia, tambahkan ke keranjang
                dbHelper.TambahKeKeranjang(idUser, idObat, jumlah);
                Console.WriteLine("Id User = " + idUser);

                // Tambahkan ID obat ke List (jika ada variabel keranjangObat)
                keranjangObat.Add(idObat);

            MessageBox.Show($"Obat \"{dataObat["nama_obat"]}\" berhasil ditambahkan ke keranjang! Stok tersisa: {stok - jumlah}", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
            }

        private List<int> keranjangObat = new List<int>(); // List untuk simpan ID obat

        private void btnKeranjangSaya_Click(object sender, EventArgs e)
        {
            Pembayaran pembayaranForm = new Pembayaran(keranjangObat);
            pembayaranForm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string cariObat = txtSearch.Text;

            string connectionString = "server=localhost;port=3307;database=db_sigmafarma;uid=root;pwd=Password123!;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Buka koneksi
                    connection.Open();

                    // Query untuk mencari obat
                    string query = "SELECT * FROM data_obat WHERE nama_obat = @namaObat";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@namaObat", cariObat);

                        // Eksekusi query dan baca hasilnya
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Jika data ditemukan
                                MessageBox.Show("Obat tersedia", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Jika data tidak ditemukan
                                MessageBox.Show("Obat tidak ditemukan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
