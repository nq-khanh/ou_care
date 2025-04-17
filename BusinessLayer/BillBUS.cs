using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BillBUS
    {
        private BillDAO billDAO = new BillDAO();

        public int AddBill(Bill bill)
        {
            bill.billDate = DateTime.Now; // Set thời gian tạo hóa đơn
            billDAO.AddBill(bill);
            return billDAO.AddBill(bill);
        }
    }
}
