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
        private UserServiceBL userService; // Khai báo UserService

        public Login()
        {
            InitializeComponent();
            userService = new UserServiceBL(); // Khởi tạo UserService
        }

        private bool isUserLogin(Acccount account)
        {
            try
            {
                return userService.IsUserLogin_ORM(account);
            }
            catch (Exception ex)
            {
                // Hiển thị chi tiết lỗi bao gồm inner exception
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\nInner Exception: " + ex.InnerException.Message;
                }
                MessageBox.Show("Lỗi khi đăng nhập: " + errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            bool result = userService.IsUserLogin_ORM(account);

            if (result)
            {
                Admin adminForm = new Admin(account); // Truyền account vào
                this.Hide();
                adminForm.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
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

        private void txtPw_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsername.Text = "Admin01";
            txtPw.Text = "Admin123";
        }

        private void panel2_39_Khanh_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
