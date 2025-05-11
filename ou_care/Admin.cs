﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ou_care.AdminUC; // hoặc namespace chứa Dashboard
using TransferObject; // Them thu vien chua account


namespace ou_care
{   

    public partial class Admin : Form
    {
        private Acccount currentAccount;

        public Admin(Acccount account)
        {
            InitializeComponent();
            currentAccount = account;
        }

        // Hàm load Control
        public void LoadUserControl(UserControl uc)
        {
            panelMain.Controls.Clear();       // Xóa control cũ
            uc.Dock = DockStyle.Fill;         // Dock full panel
            panelMain.Controls.Add(uc);       // Thêm control mới vào panel
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Dashboard_UC()); // ko có new là sai !
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            LoadUserControl(new AddUser_UC());
        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ViewUser_UC());
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Profile_UC(currentAccount));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Login lg = new Login();
                this.Hide();
                lg.Show();
            }
            else
                this.DialogResult = DialogResult.No;
        }

        private void btnTheoDoiLog_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ActivityLog_UC());
        }
    }
}
