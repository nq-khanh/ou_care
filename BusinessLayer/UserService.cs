using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using DataLayer; // BusinessLayer có thể tham chiếu đến DataLayer
using TransferObject; // Để sử dụng Acccount
using System.Data.SqlClient; // Tạo SqlParameter để tránh Data injection
using System.Linq; // Thêm dòng này vào đầu file


namespace BusinessLayer
{
    public class UserService
    {
        private DataProvider dataProvider;

        public UserService()
        {
            dataProvider = new DataProvider();
        }

        // Kiểm tra Login
        public bool IsUserLogin(Acccount account)
        {
            try
            {
                // Truy vấn SQL để kiểm tra thông tin đăng nhập
                string sql = "SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password";

                // Tạo tham số để tránh SQL injection
                var parameters = new[]
                {
                    new SqlParameter("@Username", account.Username),
                    new SqlParameter("@Password", account.Password)
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

        // Kiểm tra Login bằng Entity Framework
        public bool IsUserLogin_ORM(Acccount account)
        {
            try
            {
                // Sử dụng OucareModel thay vì SQL trực tiếp
                using (var context = new DataLayer.OUCareDBContext())
                {
                    // Kiểm tra đăng nhập bằng LINQ
                    return context.Users.Any(u =>
                    u.userName == account.Username &&
                    u.passWord == account.Password &&
                        u.isActive == 1);
                }
            }
            catch(SqlException ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        // View User, viết theo cách này sẽ trả về kiểu dữ liệu trong lớp data. Presen ko ref đến data nên sẽ gây lỗi
        // Hướng giải quyết: Trả về kiểu dữ liệu trong DTO
        //public List<User> GetAllUsers()
        //{
        //    using(var context = new DataLayer.OUCareDBContext())
        //    {
        //        return context.Users.ToList();
        //    }
        //}

        // Trong UserService.cs
        public List<TransferObject.UsersDTO> GetAllUsers()
        {
            using (var context = new DataLayer.OUCareDBContext())
            {
                // Lấy dữ liệu từ DataLayer và chuyển đổi sang DTO
                return context.Users.Select(u => new TransferObject.UsersDTO
                {
                    ID = u.ID,
                    userName = u.userName,
                    name = u.name,
                    email = u.email,
                    roleID = u.roleID,
                    CreateDate = u.createDate,
                    IsActive = u.isActive
                }).ToList();
            }
        }

        // Chức năng tìm kiếm trong View User
        public List<TransferObject.UsersDTO> SearchUsers(string username)
        {
            using (var context = new DataLayer.OUCareDBContext())
            {
                return context.Users
                    .Where(u => u.userName.Contains(username))
                    .Select(u => new TransferObject.UsersDTO
                    {
                        ID = u.ID,
                        userName = u.userName,
                        name = u.name,
                        email = u.email,
                        roleID = u.roleID,
                        CreateDate = u.createDate,
                        IsActive = u.isActive
                    }).ToList();
            }
        }

        // Chức năng xóa người dùng trong View user
        public bool DeleteUser(int userID)
        {
            try
            {
                using (var context = new DataLayer.OUCareDBContext())
                {
                    var user = context.Users.Find(userID);
                    if (user != null)
                    {
                        context.Users.Remove(user);
                        return context.SaveChanges() > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa người dùng: " + ex.Message);
            }
        }
    }
}
