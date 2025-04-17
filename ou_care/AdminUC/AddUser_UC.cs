using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ou_care.AdminUC
{
    public partial class AddUser_UC : UserControl
    {
        public AddUser_UC()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void AddUser_UC_Load(object sender, EventArgs e)
        {

        }
    }
}
