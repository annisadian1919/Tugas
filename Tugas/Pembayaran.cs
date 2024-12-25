using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Bcpg;

namespace Tugas
{
    public partial class Pembayaran : Form
    {
        public Pembayaran()
        {
            InitializeComponent();
        }

        private List<int> idObatList; // List untuk menyimpan ID obat

        public Pembayaran(List<int> idObat)
        {
            InitializeComponent();
            this.idObatList = idObat;
        }

        


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPesananSaya_Click(object sender, EventArgs e)
        {

        }

        private void lblAlamat_Click(object sender, EventArgs e)
        {

        }

        private void lblJumlah(object sender, EventArgs e)
        {

        }

        private void lblStok_Click(object sender, EventArgs e)
        {

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuatPesanan_Click(object sender, EventArgs e)
        {
            Resi resi = new Resi();
            resi.Show();
            this.Hide();
        }
    }
}
