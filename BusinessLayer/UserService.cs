using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer; // BusinessLayer có thể tham chiếu đến DataLayer
using TransferObject; // Để sử dụng Acccount

namespace BusinessLayer
{
    public class UserService
    {
        private DataProvider dataProvider;

        public UserService()
        {
            dataProvider = new DataProvider();
        }

        public bool IsUserLogin(Acccount account)
        {
            try
            {
                // Truy vấn SQL để kiểm tra thông tin đăng nhập
                string sql = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";

                // Tạo tham số để tránh SQL injection
                var parameters = new[]
                {
                    new System.Data.SqlClient.SqlParameter("@Username", account.Username),
                    new System.Data.SqlClient.SqlParameter("@Password", account.Password)
                };

                // Sử dụng MyExcuteScalar để lấy số lượng bản ghi khớp
                object result = dataProvider.MyExcuteScalar(sql, System.Data.CommandType.Text, parameters);

                // Chuyển đổi kết quả thành int
                int count = Convert.ToInt32(result);
                return count > 0; // Trả về true nếu tìm thấy bản ghi khớp
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra đăng nhập: " + ex.Message);
            }
        }
    }
}
