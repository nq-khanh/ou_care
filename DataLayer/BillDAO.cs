using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BillDAO
    {
        public int AddBill(Bill bill)
        {
            using (OUCareEntities2 db = new OUCareEntities2()) 
            {
                db.Bills.Add(bill);
                db.SaveChanges(); // tự động thêm bill và gán ID
                return bill.ID; // trả về ID vừa được tạo
                
            }
        }
    }
}
