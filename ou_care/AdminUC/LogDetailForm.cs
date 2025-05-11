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
    }
}
