using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessLayer;

namespace ou_care.AdminUC
{
    public partial class ViewUser_UC : UserControl
    {
        private UserService userService; // Khai báo thuộc tính
        public ViewUser_UC()
        {
            InitializeComponent();
            userService = new UserService(); // Gọi cons
        }

        private void LoadAllUsers()
        {
            var users = userService.GetAllUsers();
            dgvViewUser.DataSource = users; // Đổ dữ liệu vào dgv
        }

        private void ViewUser_UC_Load(object sender, EventArgs e)
        {
            LoadAllUsers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadAllUsers(); // Nếu không có từ khóa, load tất cả
            }
            else
            {
                var users = userService.SearchUsers(searchText);
                dgvViewUser.DataSource = users;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dgvViewUser.SelectedRows.Count > 0)
            {
                // Lấy ID của người dùng được chọn
                int userID = Convert.ToInt32(dgvViewUser.SelectedRows[0].Cells["ID"].Value);

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?",
                                                    "Xác nhận xóa",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = userService.DeleteUser(userID);
                        if (success)
                        {
                            MessageBox.Show("Xóa người dùng thành công!", "Thông báo",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Tải lại danh sách sau khi xóa
                            LoadAllUsers();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa người dùng!", "Lỗi",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
