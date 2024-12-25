using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas
{
    public partial class Resi : Form
    {
        public Resi()
        {
            InitializeComponent();
        }

        private void Resi_Load(object sender, EventArgs e)
        {

        }



        private void lblResi_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            int login = Login.LoggedInUserId;
            login = 0;  // Reset ID pengguna yang login
            this.Hide();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
