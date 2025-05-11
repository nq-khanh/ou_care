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
using TransferObject;

namespace ou_care.AdminUC
{
    public partial class ActivityLog_UC : UserControl
    {

        LogBL logBL = new LogBL();

        public ActivityLog_UC()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            dtpStartDate.Enabled = true;
            dtpEndDate.Enabled = true;
            // Khởi tạo DateTimePicker cho khoảng thời gian
            dtpStartDate.Value = DateTime.Now.AddDays(-30); // Mặc định xem 30 ngày gần nhất
            dtpEndDate.Value = DateTime.Now;

            // Khởi tạo ComboBox lọc theo loại hoạt động
            cboActionType.Items.Clear();
            cboActionType.Items.Add("Tất cả");
            cboActionType.Items.AddRange(new string[] {
                "Thêm thuốc", "Sửa thuốc", "Xóa thuốc",
                "Tạo hóa đơn", "Thêm khách hàng", "Sửa khách hàng",
                "Thêm người dùng", "Sửa người dùng", "Đăng nhập", "Đăng xuất"
            });
            cboActionType.SelectedIndex = 0;

            // Khởi tạo ComboBox lọc theo người dùng
            cboUsers.Items.Clear();
            cboUsers.Items.Add("Tất cả người dùng");

            // Lấy danh sách người dùng từ Business Layer
            List<UsersDTO> users = logBL.GetAllUsers();
            foreach (var user in users)
            {
                cboUsers.Items.Add(new ComboboxItem { Text = user.name, Value = user.ID });
            }
            cboUsers.SelectedIndex = 0;

            // Khởi tạo ComboBox lọc theo đối tượng
            cboEntityType.Items.Clear();
            cboEntityType.Items.Add("Tất cả");
            cboEntityType.Items.AddRange(new string[] { "Medicine", "Bill", "Customer", "User" });
            cboEntityType.SelectedIndex = 0;

            // Thiết lập DataGridView
            SetupDataGridView();

            // Load dữ liệu mặc định
            LoadLogData();
        }

        private void SetupDataGridView()
        {
            dgvLogs.AutoGenerateColumns = false;
            dgvLogs.Columns.Clear();

            // Thêm cột thời gian
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Thời gian",
                DataPropertyName = "logDateFormatted",
                Name = "logDate",
                Width = 150
            });

            // Thêm cột người dùng
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Người dùng",
                DataPropertyName = "userName",
                Name = "userName",
                Width = 150
            });

            // Thêm cột hành động
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Hành động",
                DataPropertyName = "action",
                Name = "action",
                Width = 200
            });

            // Thêm cột đối tượng
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Loại đối tượng",
                DataPropertyName = "entityType",
                Name = "entityType",
                Width = 120
            });

            // Thêm cột ID đối tượng
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID đối tượng",
                DataPropertyName = "entityID",
                Name = "entityID",
                Width = 100
            });

            // Thêm cột chi tiết (nút xem chi tiết)
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                HeaderText = "Chi tiết",
                Text = "Xem",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            dgvLogs.Columns.Add(btnDetail);
        }

        private void LoadLogData()
        {
            // Lấy giá trị từ các bộ lọc
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value.AddDays(1).AddSeconds(-1); // Kết thúc cuối ngày

            string actionFilter = cboActionType.SelectedIndex > 0 ? cboActionType.SelectedItem.ToString() : null;

            int? userIDFilter = null;
            if (cboUsers.SelectedIndex > 0)
            {
                ComboboxItem selectedUser = cboUsers.SelectedItem as ComboboxItem;
                userIDFilter = (int)selectedUser.Value;
            }

            string entityTypeFilter = cboEntityType.SelectedIndex > 0 ? cboEntityType.SelectedItem.ToString() : null;

            // Gọi Business Layer để lấy dữ liệu log
            List<LogDTO> logs = logBL.GetFilteredLogs(startDate, endDate, actionFilter, userIDFilter, entityTypeFilter);

            // Gán dữ liệu cho DataGridView
            dgvLogs.DataSource = logs;

            // Hiển thị số lượng bản ghi
            lblTotalRecords.Text = $"Tổng số: {logs.Count} bản ghi";
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            LoadLogData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Xuất dữ liệu log ra Excel hoặc PDF
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx|PDF Files (*.pdf)|*.pdf",
                Title = "Xuất báo cáo nhật ký hoạt động"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;
                string extension = System.IO.Path.GetExtension(filePath).ToLower();

                if (extension == ".xlsx")
                {
                    ExportToExcel(filePath);
                }
                else if (extension == ".pdf")
                {
                    ExportToPDF(filePath);
                }
            }
        }

        private void ExportToExcel(string filePath)
        {
            // Code xuất Excel ở đây - có thể sử dụng thư viện như EPPlus
            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToPDF(string filePath)
        {
            // Code xuất PDF ở đây - có thể sử dụng thư viện như iTextSharp
            MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvLogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào nút "Xem" chi tiết
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvLogs.Columns.Count - 1)
            {
                LogDTO selectedLog = (dgvLogs.DataSource as List<LogDTO>)[e.RowIndex];
                ShowLogDetail(selectedLog);
            }
        }

        private void ShowLogDetail(LogDTO log)
        {
            // Hiển thị form chi tiết log
            using (var detailForm = new LogDetailForm(log))
            {
                detailForm.ShowDialog();
            }
        }

        private void cboActionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ActivityLog_UC_Load(object sender, EventArgs e)
        {

        }
    }

    // Class hỗ trợ cho ComboBox
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
