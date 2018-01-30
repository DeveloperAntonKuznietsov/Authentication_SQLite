using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_SQLite_Authentication
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFaq_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В этом окне Вы должны зарегестрирываться\nобратите внимание что пороль должен совпадать.", "Справка", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
