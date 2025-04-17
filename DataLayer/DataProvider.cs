using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

// Hàm xử lý chung các thao tác với dữ liệu
namespace DataLayer
{
    public class DataProvider
    {
        private SqlConnection cn;

        public DataProvider()
        {
            // Chuỗi kết nối tự sinh
            string cnStr = "Data Source=.;Initial Catalog=OUCare;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        // Hàm kết nối
        private void Connect()
        {
            try
            {
                // Nếu đang khác rỗng và trạng thái đang đóng thì mở ra
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // Hàm ngắt kết nối
        private void DisConnect()
        {
            try
            {
                // Nếu đang khác rỗng và trạng thái đang mở thì đóng
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // Thực hiện câu truy vấn trên DB và trả dữ liệu về 
        public object MyExcuteScalar(string sql, CommandType type, SqlParameter[] parameters = null)
        {
            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = type;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
