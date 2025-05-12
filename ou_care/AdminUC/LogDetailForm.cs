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

namespace ou_care.AdminUC
{
    public partial class LogDetailForm : Form
    {
        private LogDTO log;
        public LogDetailForm(LogDTO log)
        {
            InitializeComponent();
            this.log = log;
            LoadLogDetail();
            this.SuspendLayout();            

            // Close Button
            var btnClose = new Button
            {
                Text = "Đóng",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnClose.Click += btnClose_Click;

            this.Controls.Add(btnClose);
            this.Text = "Chi tiết log";
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoSize = true;
            this.ResumeLayout(false);
        }

        private void LoadLogDetail()
        {
            this.Text = $"Chi tiết hoạt động - {log.ID}";

            lblTime.Text = log.logDateFormatted;
            lblUser.Text = log.userName;
            lblAction.Text = log.action;
            lblEntityType.Text = log.entityType;
            lblEntityID.Text = log.entityID?.ToString() ?? "N/A";

            // Lấy thêm thông tin chi tiết của đối tượng tùy theo loại
            LoadEntityDetail();
        }

        private void LoadEntityDetail()
        {
            // Tùy theo loại đối tượng, hiển thị thông tin chi tiết khác nhau
            switch (log.entityType)
            {
                case "Medicine":
                    LoadMedicineDetail();
                    break;
                case "Bill":
                    LoadBillDetail();
                    break;
                case "Customer":
                    LoadCustomerDetail();
                    break;
                    // Xử lý các loại khác...
            }
        }

        private void LoadMedicineDetail()
        {
            if (!log.entityID.HasValue) return;

            // Gọi Business Layer để lấy thông tin thuốc
            // Hiển thị thông tin thuốc lên form
            // ...
        }

        private void LoadBillDetail()
        {
            if (!log.entityID.HasValue) return;

            // Gọi Business Layer để lấy thông tin hóa đơn
            // Hiển thị thông tin hóa đơn lên form
            // ...
        }

        private void LoadCustomerDetail()
        {
            // Tương tự...
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogDetailForm_Load(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void lblAction_Click(object sender, EventArgs e)
        {

        }

        private void lblEntityType_Click(object sender, EventArgs e)
        {

        }

        private void lblEntityID_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
