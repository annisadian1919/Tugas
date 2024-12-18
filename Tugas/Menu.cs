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
        private DatabaseHelper dbHelper;
        private int userId;
        public Menu(int idUser)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper(); // Inisialisasi DatabaseHelper
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

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
        }

        private void btnKeranjang_Click(object sender, EventArgs e)
        {
            // Misalnya tombol btnKeranjang1 adalah untuk Paracetamol
            Button btn = sender as Button;
            int idObat = Convert.ToInt32(btn.Tag); // Ambil ID obat dari Tag tombol
            int idUser = this.userId; // ID User yang sedang login (contoh)
            int jumlah = 1;
            keranjangObat.Add(idObat); // Simpan ID obat ke List

            // Tambah ke database (opsional, kalau memang perlu)
            dbHelper.TambahKeKeranjang(this.userId, idObat, jumlah);

            MessageBox.Show("Obat berhasil ditambahkan ke keranjang.");
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
    }
}
