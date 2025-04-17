using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ou_care
{
    public partial class BanThuocForm : Form
    {
        private MedicineBUS medicineBUS = new MedicineBUS();
        private BillBUS billBUS = new BillBUS();
        private BillDetailsBUS billDetailsBUS = new BillDetailsBUS();
        private List<Medicine> cart = new List<Medicine>();
        private double totalAmount = 0;
        private User currentUser;
        public BanThuocForm(User user)
        {
            InitializeComponent();
            currentUser = user; // Lưu thông tin người dùng
        }

        private void txtTimKiemThuoc_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiemThuoc.Text;
            var medicines = medicineBUS.SearchMedicines(searchText);
            listBox1.Items.Clear();

            foreach (var medicine in medicines)
            {
                listBox1.Items.Add($"{medicine.ID} - {medicine.name}");
            }
        }

        private void btnThamVaoGioHang_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null && !string.IsNullOrWhiteSpace(txtSoLuong.Text))
            {
                int quantity;
                if (!int.TryParse(txtSoLuong.Text, out quantity))
                {
                    MessageBox.Show("Số lượng không hợp lệ.");
                    return;
                }

                string selected = listBox1.SelectedItem.ToString();
                int medicineId = int.Parse(selected.Split('-')[0].Trim());
                Medicine selectedMedicine = medicineBUS.GetMedicineById(medicineId);

                if (selectedMedicine != null && selectedMedicine.quantity >= quantity)
                {
                    cart.Add(selectedMedicine);
                    double itemTotal = selectedMedicine.price.GetValueOrDefault() * quantity;
                    totalAmount += itemTotal;
                    txtTong.Text = totalAmount.ToString("N0");

                    textBox1.AppendText($"{selectedMedicine.name} - SL: {quantity} - Thành tiền: {itemTotal:N0}\r\n");
                }
                else
                {
                    MessageBox.Show("Không đủ số lượng thuốc.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thuốc và nhập số lượng.");
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }

            Bill bill = new Bill
            {
                cusID = 1, // Gắn ID khách hàng thật nếu có
                userID = currentUser.ID,
                total = (decimal?)totalAmount,
                billDate = DateTime.Now,
                qrLink = "link_qr_code"
            };

            int billId = billBUS.AddBill(bill); // Trả về ID

            foreach (var medicine in cart)
            {
                BillDetail billDetail = new BillDetail
                {
                    billID = billId,
                    medID = medicine.ID,
                    quantity = 1, // hoặc lấy từ textbox nếu lưu riêng
                    unitPrice = (decimal)medicine.price.GetValueOrDefault(),
                    amount = (decimal)(medicine.price.GetValueOrDefault() * 1)

                };

                billDetailsBUS.AddBillDetail(billDetail);
            }

            MessageBox.Show("Thanh toán thành công! Mã hóa đơn: " + billId);

            cart.Clear();
            totalAmount = 0;
            txtTong.Clear();
            textBox1.Clear();
        }
    }
}
