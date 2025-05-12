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

namespace ou_care.AdminUC
{
    public partial class Revenue : UserControl
    {
        RevenueBL bl = new RevenueBL();
        public Revenue()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            DateTime from = dtpStartDate.Value.Date;
            DateTime to = dptEndDate.Value.Date;

            var report = bl.GetRevenueByDateRange(from, to);

            // Thêm cột STT bằng cách tạo DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Ngày", typeof(DateTime));
            dt.Columns.Add("Số lượt mua", typeof(int));
            dt.Columns.Add("Doanh thu", typeof(decimal));

            // Thêm dữ liệu vào DataTable với STT
            for (int i = 0; i < report.Count; i++)
            {
                dt.Rows.Add(i + 1, report[i].Date, report[i].PatientCount, report[i].TotalRevenue);
            }

            dgvDoanhThu.DataSource = dt;

            // Format grid
            dgvDoanhThu.Columns["STT"].Width = 50;
            dgvDoanhThu.Columns["Ngày"].Width = 100;
            dgvDoanhThu.Columns["Ngày"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDoanhThu.Columns["Số lượt mua"].Width = 100;
            dgvDoanhThu.Columns["Doanh thu"].Width = 150;
            dgvDoanhThu.Columns["Doanh thu"].DefaultCellStyle.Format = "N0";

            // Tổng doanh thu toàn bộ
            decimal tong = report.Sum(r => r.TotalRevenue);
            lbTongDoanhThu.Text = $"Tổng doanh thu: {tong:N0} VNĐ";
        }

        private void Revenue_Load(object sender, EventArgs e)
        {
            LoadData();
            // Giao diện đẹp hơn cho DataGridView
            dgvDoanhThu.BorderStyle = BorderStyle.None;
            dgvDoanhThu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvDoanhThu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDoanhThu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 153, 255);
            dgvDoanhThu.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDoanhThu.BackgroundColor = Color.White;
            dgvDoanhThu.EnableHeadersVisualStyles = false;
            dgvDoanhThu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDoanhThu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 70, 160);
            dgvDoanhThu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDoanhThu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvDoanhThu.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvDoanhThu.RowTemplate.Height = 30;
            dgvDoanhThu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoanhThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime from = dtpStartDate.Value.Date;
            DateTime to = dptEndDate.Value.Date;
            LoadData();
        }
    }
}
