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
        private int userId;
        public Pembayaran(int idUser)
        {
            InitializeComponent();
            this.userId = idUser;
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
    }
}
