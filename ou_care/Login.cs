using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

using BusinessLayer;


namespace ou_care
{
    public partial class Login : Form
    {
        private UserService userService; // Khai báo UserService

        public Login()
        {
            InitializeComponent();
            userService = new UserService(); // Khởi tạo UserService
        }

        private bool isUserLogin(Acccount account)
        {
            try
            {
                // Gọi đến UserService để kiểm tra đăng nhập
                return userService.IsUserLogin(account);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Khi nút đăng nhập được nhấn
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            // Lấy dữ liệu từ người dùng
            user = txtUsername.Text;
            pass = txtPw.Text;

            Acccount account = new Acccount(user, pass);

            if(isUserLogin(account))
            {
                MessageBox.Show("Đăng nhập thành công", "Login");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                string msg = "Tài khoản hoặc mật khẩu sai";
                DialogResult result = MessageBox.Show(msg, "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    txtPw.Clear();
                    txtPw.Focus();
                }
                else
                    this.DialogResult = DialogResult.OK;
            }
        }

        private void checkPw_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPw.Checked)
                txtPw.UseSystemPasswordChar = true;
            else
                txtPw.UseSystemPasswordChar = false;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
